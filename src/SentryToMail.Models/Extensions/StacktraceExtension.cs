using System.Linq;
using System.Text;
using SentryToMail.Models.SentryDataModel;

namespace SentryToMail.Models.Extensions {
	public static class StacktraceExtension {
		private const int LinesToShow = 10;

		public static string ToExceptionString(this Value exceptionValue) {
			var stringBuilder = new StringBuilder();
			stringBuilder.Append(exceptionValue.Type)
			             .Append(": ")
			             .AppendLine(exceptionValue.ValueValue);

			if (exceptionValue.Stacktrace.Frames.Length == 0) {
				return stringBuilder.ToString();
			}

			foreach (Frame frame in exceptionValue.Stacktrace.Frames.Reverse().Take(LinesToShow)) {
				stringBuilder.AppendFrame(frame);
			}

			if (exceptionValue.Stacktrace.Frames.Length <= LinesToShow) {
				return stringBuilder.ToString();
			}

			stringBuilder.AppendLine("...")
			             .Append("(")
			             .Append(exceptionValue.Stacktrace.Frames.Length - LinesToShow)
			             .Append(" additional frame(s) were not displayed)");

			return stringBuilder.ToString();
		}

		public static void AppendFrame(this StringBuilder stringBuilder, Frame frame) {
			stringBuilder.Append("  at ")
			             .Append(frame.ContextLine)
			             .AppendLine(frame.Filename != null ? $" in {frame.Filename}:line {frame.Lineno}" : null);
		}
	}
}