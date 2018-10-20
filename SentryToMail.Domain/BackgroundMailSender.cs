using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using SentryToMail.Models;

namespace SentryToMail.Domain {
	public class BackgroundMailSender : BackgroundService {
		private readonly IServiceProvider _serviceProvider;
		private readonly ILogger<BackgroundMailSender> _logger;

		public BackgroundMailSender(IServiceProvider serviceProvider, ILogger<BackgroundMailSender> logger) {
			_serviceProvider = serviceProvider;
			_logger = logger;
		}

		protected override async Task ExecuteAsync(CancellationToken stoppingToken) {
			stoppingToken.Register(() => _logger.LogDebug(" BackgroundMailSender task is stopping."));

			while (!stoppingToken.IsCancellationRequested) {
				_logger.LogDebug("BackgroundMailSender task doing background work.");

				using (IServiceScope scope = _serviceProvider.CreateScope()) {
					IServiceProvider serviceProvider = scope.ServiceProvider;
					var mailQueueRepository = serviceProvider.GetRequiredService<IMailQueueRepository>();
					HashSet<MailModel> mailQueue = mailQueueRepository.PeekMailQueue();
					if (mailQueue.Count > 0) {
						_logger.LogInformation($"Found {mailQueue.Count} mails in repository");
						var mailSender = serviceProvider.GetRequiredService<IMailSender>();
						foreach (MailModel mail in mailQueue) {
							if (await mailSender.RenderAndTrySendMail(mail)) {
								mailQueueRepository.Delete(mail);
							} else {
								await Task.Delay((int)TimeSpan.FromMinutes(1).TotalMilliseconds, stoppingToken);
							}
						}
					}
				}
				await Task.Delay((int)TimeSpan.FromMinutes(1).TotalMilliseconds, stoppingToken);
			}

			_logger.LogDebug("GracePeriod background task is stopping.");
		}
	}
}