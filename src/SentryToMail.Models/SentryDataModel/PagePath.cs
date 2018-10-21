using Newtonsoft.Json;

namespace SentryToMail.Models.SentryDataModel {
	public class PagePath {
		[JsonProperty(propertyName: "type")]
		public string Type { get; set; }

		[JsonProperty(propertyName: "Page1")]
		public string Page1 { get; set; }
	}
}