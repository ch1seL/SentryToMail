using System.Net.Mail;

namespace SentryToMail.API.Domain {
	public class MailClient : SmtpClient, IMailClient {
		public MailClient(string host, int port) : base(host, port) { }
	}
}