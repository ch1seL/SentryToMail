using Newtonsoft.Json;

namespace SentryToMail.Models.SentryDataModel {
	public class VersionInformation {
		[JsonProperty(propertyName: "type")]
		public string Type { get; set; }

		[JsonProperty(propertyName: "storage")]
		public string Storage { get; set; }
	}
}