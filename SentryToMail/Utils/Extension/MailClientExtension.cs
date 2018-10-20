using System.Net.Mail;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SentryToMail.API.Configurations;
using SentryToMail.API.Domain;

namespace SentryToMail.API.Utils.Extension {
	public static class MailClientExtension {
		public static IServiceCollection AddSmtpClient(this IServiceCollection serviceCollection) {
			return serviceCollection
				.AddScoped<IMailClient>(provider => {
					var configuration = provider.GetService<IConfiguration>();
					var smtpClientConfiguration = configuration.GetSection(nameof(MailClient)).Get<SmtpClientConfiguration>();
					return new MailClient(smtpClientConfiguration.Host, smtpClientConfiguration.Port);
				});
		}
	}
}