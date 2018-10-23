using System.Collections.Generic;
using System.Threading.Tasks;
using SentryToMail.Models;

namespace SentryToMail.Domain {
	public interface IMailQueueRepository {
		Task Add(MailModel mail);
		Task<HashSet<MailModel>> PeekMailQueue();
		Task Delete(MailModel mail);
	}
}