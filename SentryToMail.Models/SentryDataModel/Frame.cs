using Newtonsoft.Json;

namespace SentryToMail.Models.SentryDataModel {
	public class Frame {
		[JsonProperty(propertyName: "function")]
		public string Function { get; set; }

		[JsonProperty(propertyName: "package", NullValueHandling = NullValueHandling.Ignore)]
		public string Package { get; set; }

		[JsonProperty(propertyName: "module")]
		public string Module { get; set; }

		[JsonProperty(propertyName: "context_line")]
		public string ContextLine { get; set; }

		[JsonProperty(propertyName: "in_app")]
		public bool InApp { get; set; }

		[JsonProperty(propertyName: "abs_path", NullValueHandling = NullValueHandling.Ignore)]
		public string AbsPath { get; set; }

		[JsonProperty(propertyName: "filename", NullValueHandling = NullValueHandling.Ignore)]
		public string Filename { get; set; }

		[JsonProperty(propertyName: "lineno", NullValueHandling = NullValueHandling.Ignore)]
		public long? Lineno { get; set; }

		[JsonProperty(propertyName: "colno", NullValueHandling = NullValueHandling.Ignore)]
		public long? Colno { get; set; }
	}
}