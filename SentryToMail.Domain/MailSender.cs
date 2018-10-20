using System;
using System.Net.Mail;
using System.Threading.Tasks;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using SentryToMail.Configurations.Options;
using SentryToMail.Models;

namespace SentryToMail.Domain {
	public class MailSender : IMailSender {
		private readonly IViewRender _viewRender;
		private readonly ISmtpClient _smtpClient;
		private readonly MailOptions _mailOptions;
		private readonly ILogger<MailSender> _logger;

		public MailSender(IViewRender viewRender, ISmtpClient smtpClient, IOptions<MailOptions> mailOptionsAccessor, ILogger<MailSender> logger) {
			_viewRender = viewRender;
			_logger = logger;
			_smtpClient = smtpClient;
			_mailOptions = mailOptionsAccessor.Value;
		}

		public async Task<bool> RenderAndTrySendMail(MailModel mail) {
			string from = string.Format(_mailOptions.MailFromTemplate, mail.Environment);
			string to = string.Format(_mailOptions.MailToTemplate, mail.Environment);
			string subject = string.Format(_mailOptions.MailSubjectTemplate, mail.Message);
			string body;

			_logger.LogInformation($"Trying to render mail: {mail.Id}");
			try {
				body = _viewRender.Render(_mailOptions.MailBodyTemplatePath, mail);
			} catch (Exception ex) {
				_logger.LogWarning(ex, $"Mail {mail.Id} render is failed!");
				return false;
			}
			_logger.LogInformation($"Mail {mail.Id} has been render successfully!");

			var mailMessage = new MailMessage(from, to, subject, body) {
				IsBodyHtml = true
			};

			_logger.LogInformation($"Trying to send mail: {mail.Id}");
			try {
				await _smtpClient.SendMailAsync(mailMessage);
			} catch (Exception ex) {
				_logger.LogWarning(ex, $"Mail {mail.Id} send is failed!");
				return false;
			}
			_logger.LogInformation($"Mail {mail.Id} has been send successfully!");
			return true;
		}
	}
}