using Newtonsoft.Json;

namespace SentryToMail.Models.SentryDataModel {
	public class Contexts {
		[JsonProperty(propertyName: "Page Path")]
		public PagePath PagePath { get; set; }

		[JsonProperty(propertyName: "Session vars")]
		public SessionVars SessionVars { get; set; }

		[JsonProperty(propertyName: "Session Objects")]
		public SessionObjects SessionObjects { get; set; }

		[JsonProperty(propertyName: "Posted data")]
		public PostedData PostedData { get; set; }

		[JsonProperty(propertyName: "Version Information")]
		public VersionInformation VersionInformation { get; set; }

		[JsonProperty(propertyName: "runtime")]
		public Os Runtime { get; set; }

		[JsonProperty(propertyName: "os")]
		public Os Os { get; set; }

		[JsonProperty(propertyName: "Request Information")]
		public RequestInformation RequestInformation { get; set; }

		[JsonProperty(propertyName: "browser")]
		public Browser Browser { get; set; }
	}
}