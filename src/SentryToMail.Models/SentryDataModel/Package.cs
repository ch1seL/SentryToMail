using Newtonsoft.Json;

namespace SentryToMail.Models.SentryDataModel {
	public class Package {
		[JsonProperty("Version")]
		public string Version { get; set; }

		[JsonProperty("Name")]
		public string Name { get; set; }
	}
}