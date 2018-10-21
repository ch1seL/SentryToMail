using Newtonsoft.Json;

namespace SentryToMail.Models.SentryDataModel {
	public class SessionVars {
		[JsonProperty(propertyName: "type")]
		public string Type { get; set; }

		[JsonProperty(propertyName: "pathLog")]
		public string PathLog { get; set; }

		[JsonProperty(propertyName: "isRootLogin")]
		public string IsRootLogin { get; set; }
	}
}