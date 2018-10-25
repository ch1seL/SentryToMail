using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using SentryToMail.Configurations.Options;
using SentryToMail.Models;

namespace SentryToMail.Domain {
	public class BackgroundMailSender : BackgroundService {
		private readonly IServiceProvider _serviceProvider;
		private readonly ILogger<BackgroundMailSender> _logger;
		private readonly BackgroundMailSenderOptions _options;
		private static readonly SemaphoreSlim Semaphore = new SemaphoreSlim(10, 10);

		public BackgroundMailSender(IServiceProvider serviceProvider, ILogger<BackgroundMailSender> logger, IOptions<BackgroundMailSenderOptions> optionsAccessor) {
			_serviceProvider = serviceProvider;
			_logger = logger;
			_options = optionsAccessor.Value;
		}

		protected override async Task ExecuteAsync(CancellationToken stoppingToken) {
			stoppingToken.Register(() => _logger.LogDebug("Background task is stopping."));

			while (!stoppingToken.IsCancellationRequested) {
				bool useDelay = true;
				_logger.LogDebug("Background task doing background work.");
				using (IServiceScope scope = _serviceProvider.CreateScope()) {
					IServiceProvider serviceProvider = scope.ServiceProvider;
					var mailQueueRepository = serviceProvider.GetRequiredService<IMailQueueRepository>();
					Guid[] mailQueue = mailQueueRepository.GetMailQueueIds();
					if (mailQueue.Length > 0) {
						_logger.LogInformation($"Found {mailQueue.Length} mails in repository");
						var mailSender = serviceProvider.GetRequiredService<IMailSender>();
						IEnumerable<Task> tasks = mailQueue.Select(async m => {
							try {
								await Semaphore.WaitAsync(stoppingToken);
								MailModel mail = await mailQueueRepository.GetMailById(m);
								bool isSuccess = await mailSender.TryRenderAndSendMail(mail, stoppingToken);
								if (isSuccess) {
									mailQueueRepository.Delete(m);
									useDelay = false;
								}
							} finally {
								Semaphore.Release();
							}
						});
						await Task.WhenAll(tasks);
					}
				}
				if (useDelay) {
					await Task.Delay((int)_options.Interval.TotalMilliseconds, stoppingToken);
				}
			}

			_logger.LogDebug("Background task is stopping.");
		}
	}
}