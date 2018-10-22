using Newtonsoft.Json;

namespace SentryToMail.Models.SentryDataModel {
	public class RequestInformation {
		[JsonProperty("New Session")]
		public string NewSession { get; set; }

		[JsonProperty("Date & Time")]
		public string DateTime { get; set; }

		[JsonProperty("ApplicationId")]
		public string ApplicationId { get; set; }

		[JsonProperty("Host")]
		public string Host { get; set; }

		[JsonProperty("type")]
		public string Type { get; set; }
	}
}