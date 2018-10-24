using System;
using System.Net.Mail;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using SentryToMail.Configurations.Options;

namespace SentryToMail.Domain {
	public class SmtpClientWrapper : ISmtpClient, IDisposable {
		private readonly SmtpClient _smtpClient;

		public SmtpClientWrapper(IOptions<SmtpOptions> smtpOptionsAccessor) {
			SmtpOptions smtpOptions = smtpOptionsAccessor.Value;
			_smtpClient = new SmtpClient(smtpOptions.Host, smtpOptions.Port);
		}

		public Task SendMailAsync(MailMessage mailMessage, CancellationToken cancellationToken) {
			cancellationToken.ThrowIfCancellationRequested();
			cancellationToken.Register(() => {
				if (Disposed) {
					return;
				}
				_smtpClient?.SendAsyncCancel();
			}, useSynchronizationContext: false);

			_smtpClient.SendCompleted += (s, e) => {
				var callbackClient = s as SmtpClient;
				var callbackMailMessage = e.UserState as MailMessage;
				callbackClient?.Dispose();
				callbackMailMessage?.Dispose();
				Disposed = true;
			};

			return _smtpClient.SendMailAsync(mailMessage);
		}

		private bool Disposed { get; set; }

		void IDisposable.Dispose() {
			if (!Disposed) {
				_smtpClient.Dispose();
			}
			Disposed = true;
		}
	}
}