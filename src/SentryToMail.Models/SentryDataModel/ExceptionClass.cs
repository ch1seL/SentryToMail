using Newtonsoft.Json;

namespace SentryToMail.Models.SentryDataModel {
	public class ExceptionClass {
		[JsonProperty("exc_omitted")]
		public object ExcOmitted { get; set; }

		[JsonProperty("values")]
		public Value[] Values { get; set; }
	}
}