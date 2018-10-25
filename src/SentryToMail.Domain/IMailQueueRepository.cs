using System;
using System.Threading.Tasks;
using SentryToMail.Models;

namespace SentryToMail.Domain {
	public interface IMailQueueRepository {
		Task Add(MailModel mail);
		Guid[] GetMailQueueIds();
		void Delete(Guid mailId);
		Task<MailModel> GetMailById(Guid guid);
	}
}