using System.Net.Mail;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SentryToMail.API.Configurations;
using SentryToMail.API.Domain;

namespace SentryToMail.API.Utils.Extension {
	public static class ServiceCollectionExtension {
		public static IServiceCollection AddSmtpClient(this IServiceCollection serviceCollection) {
			return serviceCollection
				.AddScoped<IMailClient>(provider => {
					var configuration = provider.GetService<IConfiguration>();
					var smtpClientConfiguration = configuration.GetSection(nameof(SmtpClient)).Get<SmtpClientConfiguration>();
					return new MailClient(smtpClientConfiguration.Host, smtpClientConfiguration.Port);
				});
		}

		public static IServiceCollection AddViewRender(this IServiceCollection serviceCollection) {
			return serviceCollection
				.AddTransient<IViewRender, ViewRender>();
		}
	}
}