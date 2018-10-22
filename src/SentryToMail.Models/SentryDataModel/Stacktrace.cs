using Newtonsoft.Json;

namespace SentryToMail.Models.SentryDataModel {
	public class Stacktrace {
		[JsonProperty("frames")]
		public Frame[] Frames { get; set; }
	}
}