using System.Net.Mail;
using System.Threading.Tasks;

namespace SentryToMail.Domain {
	public interface ISmtpClient {
		Task SendMailAsync(MailMessage mailMessage);
	}
}