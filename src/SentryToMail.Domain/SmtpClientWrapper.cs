using System;
using System.Net.Mail;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using SentryToMail.Configurations.Options;

namespace SentryToMail.Domain {
	public class SmtpClientWrapper : ISmtpClient {
		public SmtpClient SmtpClient { get; set; }

		public SmtpClientWrapper(IOptions<SmtpOptions> smtpOptionsAccessor) {
			SmtpOptions smtpOptions = smtpOptionsAccessor.Value;
			SmtpClient = new SmtpClient(smtpOptions.Host, smtpOptions.Port);
		}

		public Task SendMailAsync(MailMessage mailMessage, CancellationToken cancellationToken = default) {
			cancellationToken.Register(() => SmtpClient.SendAsyncCancel());
			return SmtpClient.SendMailAsync(mailMessage);
		}

		void IDisposable.Dispose() {
			SmtpClient.Dispose();
		}
	}
}