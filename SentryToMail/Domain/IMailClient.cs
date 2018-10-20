using System.Net.Mail;
using System.Threading.Tasks;

namespace SentryToMail.API.Domain {
	public interface IMailClient {
		Task SendMailAsync(MailMessage mailMessage);
	}
}