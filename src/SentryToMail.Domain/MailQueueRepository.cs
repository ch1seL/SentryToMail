using System.Collections.Generic;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using SentryToMail.Configurations.Options;
using SentryToMail.Models;
using SentryToMail.Utils;

namespace SentryToMail.Domain {
	public class MailQueueRepository : IMailQueueRepository {
		private readonly ILogger<MailQueueRepository> _logger;
		private static readonly object SyncLock = new object();
		private readonly FileCollection<HashSet<MailModel>> _mailQueueRepository;

		public MailQueueRepository(IOptions<RepositoriesOptions> repositoryOptionsAccessor, ILogger<MailQueueRepository> logger) {
			_logger = logger;
			_mailQueueRepository = new FileCollection<HashSet<MailModel>>($"{repositoryOptionsAccessor.Value.Path}{nameof(MailQueueRepository)}.json");
		}

		public HashSet<MailModel> PeekMailQueue() {
			lock (SyncLock) {
				return _mailQueueRepository.PeekAll();
			}
		}

		public void Delete(MailModel mail) {
			_logger.LogInformation($"Delete mail {mail.Id} from repository");
			lock (SyncLock) {
				if (_mailQueueRepository.Update(hashSet => hashSet.RemoveWhere(model => model.Id == mail.Id)) == 1) {
					_logger.LogInformation($"The mail {mail.Id} has been deleted from repository!");
				} else {
					_logger.LogError($"The mail {mail.Id} was not found in repository!");
				}
			}
		}

		public void Add(MailModel mail) {
			lock (SyncLock) {
				_mailQueueRepository.Update(hashSet => hashSet.Add(mail));
			}
		}
	}
}