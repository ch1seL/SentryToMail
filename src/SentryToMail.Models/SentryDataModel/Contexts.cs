using Newtonsoft.Json;

namespace SentryToMail.Models.SentryDataModel {
	public class Contexts {
		[JsonProperty("Page Path")]
		public PagePath PagePath { get; set; }

		[JsonProperty("Session vars")]
		public SessionVars SessionVars { get; set; }

		[JsonProperty("Session Objects")]
		public SessionObjects SessionObjects { get; set; }

		[JsonProperty("Posted data")]
		public PostedData PostedData { get; set; }

		[JsonProperty("Version Information")]
		public VersionInformation VersionInformation { get; set; }

		[JsonProperty("runtime")]
		public Os Runtime { get; set; }

		[JsonProperty("os")]
		public Os Os { get; set; }

		[JsonProperty("Request Information")]
		public RequestInformation RequestInformation { get; set; }

		[JsonProperty("browser")]
		public Browser Browser { get; set; }
	}
}