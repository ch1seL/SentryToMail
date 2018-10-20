using System.Collections.Generic;
using SentryToMail.API.Model;

namespace SentryToMail.API.Domain {
	public interface IMailQueueRepository {
		void Add(MailModel mail);
		HashSet<MailModel> PeekMailQueue();
	}
}