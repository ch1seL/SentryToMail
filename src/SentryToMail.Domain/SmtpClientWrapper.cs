using System;
using System.Net.Mail;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using SentryToMail.Configurations.Options;

namespace SentryToMail.Domain {
	public class SmtpClientWrapper : ISmtpClient, IDisposable {
		private readonly ILogger<SmtpClientWrapper> _logger;
		public SmtpClient SmtpClient { get; set; }

		public SmtpClientWrapper(IOptions<SmtpOptions> smtpOptionsAccessor, ILogger<SmtpClientWrapper> logger) {
			_logger = logger;
			SmtpOptions smtpOptions = smtpOptionsAccessor.Value;
			SmtpClient = new SmtpClient(smtpOptions.Host, smtpOptions.Port);
		}

		public Task SendMailAsync(MailMessage mailMessage) {
			return SmtpClient.SendMailAsync(mailMessage);
		}

		public void Dispose() {
			_logger.LogDebug("SmtpClientWrapper dispose");
			SmtpClient.SendAsyncCancel();
			SmtpClient?.Dispose();
		}
	}
}