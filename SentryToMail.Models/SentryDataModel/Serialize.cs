using Newtonsoft.Json;

namespace SentryToMail.Models.SentryDataModel {
	public static class Serialize {
		public static string ToJson(this SentryDataModel self) {
			return JsonConvert.SerializeObject(self, Converter.Settings);
		}
	}
}