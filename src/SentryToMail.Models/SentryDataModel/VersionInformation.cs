using Newtonsoft.Json;

namespace SentryToMail.Models.SentryDataModel {
	public class VersionInformation {
		[JsonProperty("type")]
		public string Type { get; set; }

		[JsonProperty("storage")]
		public string Storage { get; set; }
	}
}