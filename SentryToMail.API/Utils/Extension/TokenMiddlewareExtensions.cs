using Microsoft.AspNetCore.Builder;
using SentryToMail.API.Middleware;

namespace SentryToMail.API.Utils.Extension {
	public static class TokenMiddlewareExtensions {
		public static IApplicationBuilder UseToken(this IApplicationBuilder builder, string token) {
			return string.IsNullOrWhiteSpace(token) ? builder : builder.UseMiddleware<TokenMiddleware>(token);
		}
	}
}