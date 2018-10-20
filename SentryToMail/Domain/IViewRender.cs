namespace SentryToMail.API.Domain {
	public interface IViewRender {
		string Render<TModel>(string name, TModel model);
	}
}