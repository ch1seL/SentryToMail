using Newtonsoft.Json;

namespace SentryToMail.Models.SentryDataModel {
	public class RequestInformation {
		[JsonProperty(propertyName: "New Session")]
		public string NewSession { get; set; }

		[JsonProperty(propertyName: "Date & Time")]
		public string DateTime { get; set; }

		[JsonProperty(propertyName: "ApplicationId")]
		public string ApplicationId { get; set; }

		[JsonProperty(propertyName: "Host")]
		public string Host { get; set; }

		[JsonProperty(propertyName: "type")]
		public string Type { get; set; }
	}
}