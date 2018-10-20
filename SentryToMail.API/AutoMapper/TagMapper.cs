using System.Collections.Specialized;
using AutoMapper;
using SentryToMail.Models;
using SentryToMail.Models.SentryDataModel;
using SentryToMail.Utils.Extension;

namespace SentryToMail.API.AutoMapper {
	public class TagMapper : IMappingAction<SentryDataModel, MailModel> {
		public void Process(SentryDataModel source, MailModel destination) {
			NameValueCollection tags = source.Event.Tags.ToNameValue();
			destination.Environment = tags[nameof(destination.Environment)];
			destination.Module = tags[nameof(destination.Module)];
		}
	}
}