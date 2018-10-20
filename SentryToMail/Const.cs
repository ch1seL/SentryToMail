namespace SentryToMail.API {
	public static class Const {
		public const string RepositoriesPath = "./Repositories/";
		public const string MailFromTemplate = "errors-{0}@appulate.com";
		public const string MailToTemplate = "errors-{0}@appulate.com";
		public const string MailSubjectTemplate = "[Error] {0}";
		public const string MailBodyTemplatePath = "Emails/Sentry";
	}
}