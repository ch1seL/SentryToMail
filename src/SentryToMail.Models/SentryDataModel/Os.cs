using Newtonsoft.Json;

namespace SentryToMail.Models.SentryDataModel {
	public class Os {
		[JsonProperty(propertyName: "raw_description")]
		public string RawDescription { get; set; }

		[JsonProperty(propertyName: "version")]
		public string Version { get; set; }

		[JsonProperty(propertyName: "type")]
		public string Type { get; set; }

		[JsonProperty(propertyName: "name")]
		public string Name { get; set; }
	}
}