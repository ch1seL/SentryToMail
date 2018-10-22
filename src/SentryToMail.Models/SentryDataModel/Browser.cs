using Newtonsoft.Json;

namespace SentryToMail.Models.SentryDataModel {
	public class Browser {
		[JsonProperty("type")]
		public string Type { get; set; }

		[JsonProperty("name")]
		public string Name { get; set; }
	}
}