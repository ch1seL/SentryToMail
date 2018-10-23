using System;
using System.Linq;
using System.Text;
using SentryToMail.Models.SentryDataModel;

namespace SentryToMail.Models.Extensions {
	public static class StacktraceExtension {
		private const int LinesToShow = 10;

		public static string ToExceptionString(this Value exceptionValue) {
			var stringBuilder = new StringBuilder();
			stringBuilder.AppendFormat("{0}: {1}{2}", exceptionValue.Type, exceptionValue.ValueValue, Environment.NewLine);

			if (exceptionValue.Stacktrace.Frames.Length == 0) {
				return stringBuilder.ToString();
			}

			foreach (Frame frame in exceptionValue.Stacktrace.Frames.Reverse().Take(LinesToShow)) {
				stringBuilder.AppendFrame(frame);
			}

			if (exceptionValue.Stacktrace.Frames.Length <= LinesToShow) {
				return stringBuilder.ToString();
			}
			
			stringBuilder.AppendFormat("...{1}({0} additional frame(s) were not displayed)", exceptionValue.Stacktrace.Frames.Length - LinesToShow, Environment.NewLine);
			return stringBuilder.ToString();
		}

		public static void AppendFrame(this StringBuilder stringBuilder, Frame frame) {
			stringBuilder.AppendFormat("  at {0}{1}{2}", frame.ContextLine, frame.IsFile() ? $" in {frame.Filename}:line {frame.Lineno}" : string.Empty, Environment.NewLine);
		}
	}
}