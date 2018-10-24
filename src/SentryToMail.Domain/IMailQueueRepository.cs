using System;
using System.Threading.Tasks;
using SentryToMail.Models;

namespace SentryToMail.Domain {
	public interface IMailQueueRepository {
		Task Add(MailModel mail);
		Task<MailModel[]> PeekMailQueue();
		void Delete(Guid mailId);
	}
}