namespace SentryToMail.API.Model {
	public class MailModel {
		public string Project { get; set; }
		public string Environment { get; set; }
		public string MachineName { get; set; }
		public string Url { get; set; }
		public string Message { get; set; }
		public string Module { get; set; }
		public string Culprit { get; set; }
	}
}