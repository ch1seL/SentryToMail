using System.Net.Mail;
using System.Threading.Tasks;
using SentryToMail.API.Model;

namespace SentryToMail.API.Domain {
	public class MailSender : IMailSender {
		private readonly IMailQueueRepository _mailQueueRepository;
		private readonly SmtpClient _smtpClient;
		private readonly IViewRender _viewRender;

		public MailSender(SmtpClient smtpClient, IViewRender viewRender, IMailQueueRepository mailQueueRepository) {
			_smtpClient = smtpClient;
			_viewRender = viewRender;
			_mailQueueRepository = mailQueueRepository;
		}

		public async Task<bool> TryRenderSendOrAddToQueue(MailModel mail) {
			string from = $"errors-{mail.Environment}@appulate.com";
			string to = $"errors-{mail.Environment}@appulate.com";
			string subject = $"[Error] {mail.Message}";
			string body = _viewRender.Render(name: "Emails/Sentry", mail);
			var mailMessage = new MailMessage(from, to, subject, body) {
				IsBodyHtml = true
			};

			try {
				await _smtpClient.SendMailAsync(mailMessage);
				return true;
			} catch {
				_mailQueueRepository.Add(mail);
				return false;
			}
		}
	}
}