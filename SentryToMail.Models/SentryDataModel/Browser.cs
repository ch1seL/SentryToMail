using Newtonsoft.Json;

namespace SentryToMail.Models.SentryDataModel {
	public class Browser {
		[JsonProperty(propertyName: "type")]
		public string Type { get; set; }

		[JsonProperty(propertyName: "name")]
		public string Name { get; set; }
	}
}