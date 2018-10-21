using System;
using Newtonsoft.Json;

namespace SentryToMail.Models.SentryDataModel {
	public class SessionObjects {
		[JsonProperty(propertyName: "UserName")]
		public string UserName { get; set; }

		[JsonProperty(propertyName: "AgencyName")]
		public string AgencyName { get; set; }

		[JsonProperty(propertyName: "FormEditor")]
		public string FormEditor { get; set; }

		[JsonProperty(propertyName: "UserId")]
		[JsonConverter(typeof(ParseStringConverter))]
		public long UserId { get; set; }

		[JsonProperty(propertyName: "Insured")]
		public string Insured { get; set; }

		[JsonProperty(propertyName: "LoginUrl")]
		public Uri LoginUrl { get; set; }

		[JsonProperty(propertyName: "type")]
		public string Type { get; set; }
	}
}