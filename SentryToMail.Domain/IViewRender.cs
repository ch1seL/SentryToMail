namespace SentryToMail.Domain {
	public interface IViewRender {
		string Render<TModel>(string name, TModel model);
	}
}