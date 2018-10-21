using Newtonsoft.Json;

namespace SentryToMail.Models.SentryDataModel {
	public class Sdk {
		[JsonProperty(propertyName: "version")]
		public string Version { get; set; }

		[JsonProperty(propertyName: "name")]
		public string Name { get; set; }

		[JsonProperty(propertyName: "packages")]
		public Package[] Packages { get; set; }
	}
}