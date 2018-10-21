using Newtonsoft.Json;

namespace SentryToMail.Models.SentryDataModel {
	public class Package {
		[JsonProperty(propertyName: "Version")]
		public string Version { get; set; }

		[JsonProperty(propertyName: "Name")]
		public string Name { get; set; }
	}
}