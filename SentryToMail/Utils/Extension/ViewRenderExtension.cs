using Microsoft.Extensions.DependencyInjection;
using SentryToMail.API.Domain;

namespace SentryToMail.API.Utils.Extension {
	public static class ViewRenderExtension {
		public static IServiceCollection AddViewRender(this IServiceCollection serviceCollection) {
			return serviceCollection
				.AddTransient<IViewRender, ViewRender>();
		}
	}
}