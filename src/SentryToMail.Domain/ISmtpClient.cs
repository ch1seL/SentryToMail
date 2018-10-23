using System;
using System.Net.Mail;
using System.Threading;
using System.Threading.Tasks;

namespace SentryToMail.Domain {
	public interface ISmtpClient : IDisposable {
		Task SendMailAsync(MailMessage mailMessage, CancellationToken cancellationToken);
	}
}