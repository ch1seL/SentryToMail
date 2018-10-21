using Newtonsoft.Json;

namespace SentryToMail.Models.SentryDataModel {
	public class Stacktrace {
		[JsonProperty(propertyName: "frames")]
		public Frame[] Frames { get; set; }
	}
}