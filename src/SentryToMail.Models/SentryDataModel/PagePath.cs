using Newtonsoft.Json;

namespace SentryToMail.Models.SentryDataModel {
	public class PagePath {
		[JsonProperty("type")]
		public string Type { get; set; }

		[JsonProperty("Page4")]
		public string Page4 { get; set; }

		[JsonProperty("Page2")]
		public string Page2 { get; set; }

		[JsonProperty("Page3")]
		public string Page3 { get; set; }

		[JsonProperty("Page1")]
		public string Page1 { get; set; }
	}
}