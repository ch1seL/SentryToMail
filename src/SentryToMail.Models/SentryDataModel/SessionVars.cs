using Newtonsoft.Json;

namespace SentryToMail.Models.SentryDataModel {
	public class SessionVars {
		[JsonProperty("type")]
		public string Type { get; set; }

		[JsonProperty("pathLog")]
		public string PathLog { get; set; }

		[JsonProperty("isRootLogin")]
		public string IsRootLogin { get; set; }
	}
}