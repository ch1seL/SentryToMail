using System;

namespace SentryToMail.Models {
	public class MailModel {
		public Guid Id { get; } = Guid.NewGuid();
		public string Project { get; set; }
		public string Environment { get; set; }
		public string MachineName { get; set; }
		public string Url { get; set; }
		public string Message { get; set; }
		public string Module { get; set; }
		public string Culprit { get; set; }
	}
}