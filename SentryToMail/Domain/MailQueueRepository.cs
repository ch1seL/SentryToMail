using System.Collections.Generic;
using SentryToMail.API.Model;
using SentryToMail.API.Utils;

namespace SentryToMail.API.Domain {
	public class MailQueueRepository : IMailQueueRepository {
		private static readonly object SyncLock = new object();
		private readonly FileCollection<HashSet<MailModel>> _mailQueueRepository;

		public MailQueueRepository() {
			_mailQueueRepository = new FileCollection<HashSet<MailModel>>($"Repositories/{nameof(MailQueueRepository)}.json");
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