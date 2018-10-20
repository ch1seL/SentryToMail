using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SentryToMail.Configurations;

namespace SentryToMail.Utils.Extension {
	public static class TokenMiddlewareExtensions {
		public static IApplicationBuilder UseToken<T>(this IApplicationBuilder builder) {
			var configuration = builder.ApplicationServices.GetRequiredService<IConfiguration>();
			var securitySettings = configuration.GetSection(nameof(SecuritySettings)).Get<SecuritySettings>();
			return string.IsNullOrWhiteSpace(securitySettings.Token) ? builder : builder.UseMiddleware<T>(securitySettings);
		}
	}
}