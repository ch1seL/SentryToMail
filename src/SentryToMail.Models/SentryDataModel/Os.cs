using Newtonsoft.Json;

namespace SentryToMail.Models.SentryDataModel {
	public class Os {
		[JsonProperty("raw_description")]
		public string RawDescription { get; set; }

		[JsonProperty("version")]
		public string Version { get; set; }

		[JsonProperty("type")]
		public string Type { get; set; }

		[JsonProperty("name")]
		public string Name { get; set; }
	}
}