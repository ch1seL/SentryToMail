using System.Linq;
using System.Text;
using SentryToMail.Models.SentryDataModel;

namespace SentryToMail.Models.Extensions {
	public static class StacktraceExtension {
		public static string ToExceptionString(this Value exceptionValue) {
			var stringBuilder = new StringBuilder();
			stringBuilder.AppendLine($"{exceptionValue.Type}: {exceptionValue.ValueValue}");

			if (exceptionValue.Stacktrace.Frames.Length == 0) {
				return stringBuilder.ToString();
			}

			foreach (Frame frame in exceptionValue.Stacktrace.Frames.Reverse().Take(count: 10)) {
				stringBuilder.AppendLine(frame.ToHtmlString());
			}

			if (exceptionValue.Stacktrace.Frames.Length <= 10) {
				return stringBuilder.ToString();
			}

			stringBuilder.AppendLine("...");
			stringBuilder.AppendLine($"({exceptionValue.Stacktrace.Frames.Length - 10} additional frame(s) were not displayed)");
			return stringBuilder.ToString();
		}
	}
}