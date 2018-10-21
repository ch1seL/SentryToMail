namespace SentryToMail.Configurations.Options {
	public class MailOptions {
		public string MailFromTemplate { get; set; }
		public string MailToTemplate { get; set; }
		public string MailBodyTemplatePath { get; set; }
		public string MailSubjectTemplatePath { get; set; }
	}
}