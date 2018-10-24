using System;
using System.Net.Mail;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Sentry;
using SentryToMail.Configurations.Options;
using SentryToMail.Models;

namespace SentryToMail.Domain {
	public class MailSender : IMailSender {
		private readonly IViewRender _viewRender;
		private readonly IServiceProvider _serviceProvider;
		private readonly MailOptions _mailOptions;
		private readonly ILogger<MailSender> _logger;
		private readonly IHub _sentry;

		public MailSender(IViewRender viewRender, IServiceProvider serviceProvider, IOptions<MailOptions> mailOptionsAccessor, ILogger<MailSender> logger, IHub sentry) {
			_viewRender = viewRender;
			_serviceProvider = serviceProvider;
			_logger = logger;
			_sentry = sentry;
			_mailOptions = mailOptionsAccessor.Value;
		}

		public async Task<bool> RenderAndTrySendMail(MailModel mail, CancellationToken cancellationToken = default) {
			string from = string.Format(_mailOptions.MailFromTemplate, mail.Environment);
			string to = string.Format(_mailOptions.MailToTemplate, mail.Environment);
			string subject;
			string body;

			_logger.LogInformation($"Trying to render mail: {mail.Id}");
			try {
				subject = await _viewRender.RenderAsync(_mailOptions.MailSubjectTemplatePath, mail);
				body = await _viewRender.RenderAsync(_mailOptions.MailBodyTemplatePath, mail);
			} catch (Exception ex) {
				_logger.LogError(ex, $"Mail {mail.Id} render is failed!");
				_sentry.CaptureException(ex);
				return false;
			}
			_logger.LogInformation($"Mail {mail.Id} has been render successfully!");

			var mailMessage = new MailMessage(from, to, subject, body) {
				IsBodyHtml = true
			};

			_logger.LogInformation($"Trying to send mail: {mail.Id}");
			try {
				var smtpClient = _serviceProvider.GetRequiredService<ISmtpClient>();
				await smtpClient.SendMailAsync(mailMessage, cancellationToken);
			} catch (Exception ex) {
				_logger.LogError(ex, $"Mail {mail.Id} send is failed!");
				_sentry.CaptureException(ex);
				return false;
			}
			_logger.LogInformation($"Mail {mail.Id} has been send successfully!");
			return true;
		}
	}
}