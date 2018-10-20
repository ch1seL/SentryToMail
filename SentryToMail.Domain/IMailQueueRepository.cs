using System.Collections.Generic;
using SentryToMail.Models;

namespace SentryToMail.Domain {
	public interface IMailQueueRepository {
		void Add(MailModel mail);
		HashSet<MailModel> PeekMailQueue();
		void Delete(MailModel mail);
	}
}