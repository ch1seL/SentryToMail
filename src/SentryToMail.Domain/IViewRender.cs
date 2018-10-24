using System.Threading.Tasks;

namespace SentryToMail.Domain {
	public interface IViewRender {
		Task<string> RenderAsync<TModel>(string name, TModel model);
	}
}