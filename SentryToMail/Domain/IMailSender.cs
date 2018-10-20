using System.Threading.Tasks;
using SentryToMail.API.Model;

namespace SentryToMail.API.Domain {
	public interface IMailSender {
		Task<bool> RenderAndTrySendMail(MailModel mail);
	}
}