using Newtonsoft.Json;

namespace SentryToMail.Models.SentryDataModel {
	public class Sdk {
		[JsonProperty("version")]
		public string Version { get; set; }

		[JsonProperty("name")]
		public string Name { get; set; }

		[JsonProperty("packages")]
		public Package[] Packages { get; set; }
	}
}