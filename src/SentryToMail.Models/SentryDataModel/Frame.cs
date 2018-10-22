using Newtonsoft.Json;

namespace SentryToMail.Models.SentryDataModel {
	public class Frame {
		[JsonProperty("function")]
		public string Function { get; set; }

		[JsonProperty("package", NullValueHandling = NullValueHandling.Ignore)]
		public string Package { get; set; }

		[JsonProperty("module")]
		public string Module { get; set; }

		[JsonProperty("context_line")]
		public string ContextLine { get; set; }

		[JsonProperty("in_app")]
		public bool InApp { get; set; }

		[JsonProperty("abs_path", NullValueHandling = NullValueHandling.Ignore)]
		public string AbsPath { get; set; }

		[JsonProperty("filename", NullValueHandling = NullValueHandling.Ignore)]
		public string Filename { get; set; }

		[JsonProperty("lineno", NullValueHandling = NullValueHandling.Ignore)]
		public long? Lineno { get; set; }

		[JsonProperty("colno", NullValueHandling = NullValueHandling.Ignore)]
		public long? Colno { get; set; }
	}
}