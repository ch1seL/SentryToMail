using System;
using Newtonsoft.Json;

namespace SentryToMail.Models.SentryDataModel {
	public class SentryDataModel {
		[JsonProperty("project")]
		public string Project { get; set; }

		[JsonProperty("project_name")]
		public string ProjectName { get; set; }

		[JsonProperty("culprit")]
		public string Culprit { get; set; }

		[JsonProperty("project_slug")]
		public string ProjectSlug { get; set; }

		[JsonProperty("url")]
		public Uri Url { get; set; }

		[JsonProperty("logger")]
		public object Logger { get; set; }

		[JsonProperty("level")]
		public string Level { get; set; }

		[JsonProperty("message")]
		public string Message { get; set; }

		[JsonProperty("id")]
		[JsonConverter(typeof(ParseStringConverter))]
		public long Id { get; set; }

		[JsonProperty("event")]
		public Event Event { get; set; }
	}
}