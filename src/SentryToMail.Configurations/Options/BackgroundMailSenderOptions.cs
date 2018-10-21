using System;

namespace SentryToMail.Configurations.Options {
	public class BackgroundMailSenderOptions {
		public TimeSpan Interval { get; set; } = TimeSpan.FromMinutes(1);
	}
}