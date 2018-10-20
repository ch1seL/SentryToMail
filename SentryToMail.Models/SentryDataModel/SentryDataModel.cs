using System;
using Newtonsoft.Json;

namespace SentryToMail.Models.SentryDataModel {
	public partial class SentryDataModel {
		[JsonProperty(propertyName: "project")]
		public string Project { get; set; }

		[JsonProperty(propertyName: "project_name")]
		public string ProjectName { get; set; }

		[JsonProperty(propertyName: "culprit")]
		public string Culprit { get; set; }

		[JsonProperty(propertyName: "project_slug")]
		public string ProjectSlug { get; set; }

		[JsonProperty(propertyName: "url")]
		public Uri Url { get; set; }

		[JsonProperty(propertyName: "logger")]
		public object Logger { get; set; }

		[JsonProperty(propertyName: "level")]
		public string Level { get; set; }

		[JsonProperty(propertyName: "message")]
		public string Message { get; set; }

		[JsonProperty(propertyName: "id")]
		[JsonConverter(typeof(ParseStringConverter))]
		public long Id { get; set; }

		[JsonProperty(propertyName: "event")]
		public Event Event { get; set; }
	}

	public partial class SentryDataModel {
		public static SentryDataModel FromJson(string json) {
			return JsonConvert.DeserializeObject<SentryDataModel>(json, Converter.Settings);
		}
	}
}