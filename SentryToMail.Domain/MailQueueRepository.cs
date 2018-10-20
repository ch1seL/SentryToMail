using System.Collections.Generic;
using Microsoft.Extensions.Options;
using SentryToMail.Configurations.Options;
using SentryToMail.Models;
using SentryToMail.Utils;

namespace SentryToMail.Domain {
	public class MailQueueRepository : IMailQueueRepository {
		private static readonly object SyncLock = new object();
		private readonly FileCollection<HashSet<MailModel>> _mailQueueRepository;

		public MailQueueRepository(IOptions<RepositoriesOptions> repositoryOptions) {
			_mailQueueRepository = new FileCollection<HashSet<MailModel>>($"{repositoryOptions.Value.Path}{nameof(MailQueueRepository)}.json");
		}

		public HashSet<MailModel> PeekMailQueue() {
			lock (SyncLock) {
				return _mailQueueRepository.PeekAll();
			}
		}

		public void Delete(MailModel mail) {
			lock (SyncLock) {
				_mailQueueRepository.Update(hashSet => hashSet.Remove(mail));
			}
		}

		public void Add(MailModel mail) {
			lock (SyncLock) {
				_mailQueueRepository.Update(hashSet => hashSet.Add(mail));
			}
		}
	}
}