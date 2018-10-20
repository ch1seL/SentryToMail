using System.Net.Mail;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using SentryToMail.API.Model;

namespace SentryToMail.API.Domain {
	public class MailSender : IMailSender {
		private readonly SmtpClient _smtpClient;
		private readonly IViewRender _viewRender;
		private readonly ILogger<MailSender> _logger;

		public MailSender(SmtpClient smtpClient, IViewRender viewRender, ILogger<MailSender> logger) {
			_smtpClient = smtpClient;
			_viewRender = viewRender;
			_logger = logger;
		}

		public async Task<bool> RenderAndTrySendMail(MailModel mail) {
			string from = $"errors-{mail.Environment}@appulate.com";
			string to = $"errors-{mail.Environment}@appulate.com";
			string subject = $"[Error] {mail.Message}";
			string body = _viewRender.Render(name: "Emails/Sentry", mail);
			var mailMessage = new MailMessage(from, to, subject, body) {
				IsBodyHtml = true
			};

			_logger.LogInformation($"Trying to send mail: {mail.Id}");
			try {
				await _smtpClient.SendMailAsync(mailMessage);
			} catch {
				_logger.LogWarning($"Mail {mail.Id} send is failed!");
				return false;
			}
			_logger.LogInformation($"Mail {mail.Id} send successfully!");
			return true;
		}
	}
}