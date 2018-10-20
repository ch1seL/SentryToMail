using System.Net.Mail;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SentryToMail.Configurations;

namespace SentryToMail.Utils.Extension {
	public static class SmtpClientExtension {
		public static IServiceCollection AddSmtpClient(this IServiceCollection serviceCollection) {
			return serviceCollection
				.AddScoped(provider => {
					var configuration = provider.GetService<IConfiguration>();
					var smtpClientConfiguration = configuration.GetSection(nameof(SmtpClient)).Get<SmtpClientConfiguration>();
					return new SmtpClient(smtpClientConfiguration.Host, smtpClientConfiguration.Port);
				});
		}
	}
}