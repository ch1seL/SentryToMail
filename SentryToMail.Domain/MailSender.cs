using System.Net.Mail;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using SentryToMail.Configurations.Options;
using SentryToMail.Models;

namespace SentryToMail.Domain {
	public class MailSender : IMailSender {
		private readonly SmtpClient _smtpClient;
		private readonly IViewRender _viewRender;
		private readonly ILogger<MailSender> _logger;
		private readonly IOptions<MailOptions> _mailOptions;

		public MailSender(SmtpClient smtpClient, IViewRender viewRender, ILogger<MailSender> logger, IOptions<MailOptions> mailOptions) {
			_smtpClient = smtpClient;
			_viewRender = viewRender;
			_logger = logger;
			_mailOptions = mailOptions;
		}

		public async Task<bool> RenderAndTrySendMail(MailModel mail) {
			MailOptions options = _mailOptions.Value;
			string from = string.Format(options.MailFromTemplate, mail.Environment);
			string to = string.Format(options.MailToTemplate, mail.Environment);
			string subject = string.Format(options.MailSubjectTemplate, mail.Message);
			string body = _viewRender.Render(options.MailBodyTemplatePath, mail);
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