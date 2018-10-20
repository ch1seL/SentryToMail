using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SentryToMail.Configurations;
using SentryToMail.Middleware;

namespace SentryToMail.Utils.Extension {
	public static class TokenMiddlewareExtensions {
		public static IApplicationBuilder UseToken(this IApplicationBuilder builder, string token = null) {
			if (token == null) {
				var configuration = builder.ApplicationServices.GetRequiredService<IConfiguration>();
				var securitySettings = configuration.GetSection(nameof(SecuritySettings)).Get<SecuritySettings>();
				token = securitySettings.Token;
			}
			return string.IsNullOrWhiteSpace(token) ? builder : builder.UseMiddleware<TokenMiddleware>(token);
		}
	}
}