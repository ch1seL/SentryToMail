using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Sentry;
using SentryToMail.Configurations.Options;
using SentryToMail.Models;
using SentryToMail.Utils;

namespace SentryToMail.Domain {
	public class MailQueueRepository : IMailQueueRepository {
		private readonly ILogger<MailQueueRepository> _logger;
		private readonly IHub _sentry;
		private readonly FileCollection<HashSet<MailModel>> _mailQueueRepository;
		private static readonly SemaphoreSlim SemaphoreSlim = new SemaphoreSlim(1, 1);

		public MailQueueRepository(IOptions<RepositoriesOptions> repositoryOptionsAccessor, ILogger<MailQueueRepository> logger, IHub sentry) {
			_logger = logger;
			_sentry = sentry;
			_mailQueueRepository = new FileCollection<HashSet<MailModel>>($"{repositoryOptionsAccessor.Value.Path}{nameof(MailQueueRepository)}.json");
		}

		public Task<HashSet<MailModel>> PeekMailQueue() {
			return _mailQueueRepository.PeekAll();
		}

		public async Task Delete(MailModel mail) {
			_logger.LogInformation($"Delete mail {mail.Id} from repository");
			try {
				await SemaphoreSlim.WaitAsync();
				int updatedRecords = await _mailQueueRepository.Update(hashSet => hashSet.RemoveWhere(model => model.Id == mail.Id));
				SemaphoreSlim.Release();
				if (updatedRecords == 1) {
					_logger.LogInformation($"Mail {mail.Id} has been deleted from repository!");
					return;
				}
				if (updatedRecords == 0) {
					throw new Exception($"Mail {mail.Id} was not found in repository!");
				}
				if (updatedRecords > 1) {
					throw new Exception($"More than one mail id:{mail.Id} founded in repository!");
				}
			} catch (Exception ex) {
				_logger.LogError(ex, $"Unknown error while deleting {mail.Id} from repository!");
				_sentry.CaptureException(ex);
			}
		}

		public async Task Add(MailModel mail) {
			await SemaphoreSlim.WaitAsync();
			bool success = await _mailQueueRepository.Update(hashSet => hashSet.Add(mail));
			SemaphoreSlim.Release();

			if (!success) {
				throw new Exception("Element is already present");
			}
		}
	}
}