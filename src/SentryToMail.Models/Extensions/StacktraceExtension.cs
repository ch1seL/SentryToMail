using System.Linq;
using System.Text;
using SentryToMail.Models.SentryDataModel;

namespace SentryToMail.Models.Extensions {
	public static class StacktraceExtension {
		public static string ToExceptionString(this Stacktrace stacktrace) {
			if (stacktrace.Frames.Length == 0) {
				return null;
			}

			var stringBuilder = new StringBuilder();
			foreach (Frame frame in stacktrace.Frames.Reverse().Take(count: 10)) {
				stringBuilder.AppendLine(frame.ToHtmlString());
			}

			if (stacktrace.Frames.Length > 10) {
				stringBuilder.AppendLine("...<br>");
				stringBuilder.AppendLine($"({stacktrace.Frames.Length - 10} additional frame(s) were not displayed)");
			}
			return stringBuilder.ToString();
		}
	}
}