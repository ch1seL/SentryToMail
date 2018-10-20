using System.Collections.Specialized;
using AutoMapper;
using SentryToMail.API.Utils.Extension;

namespace SentryToMail.API.Model.AutoMapper {
	public class SentryToMailModelProfile : Profile {
		public SentryToMailModelProfile() {
			CreateMap<SentryDataModel, MailModel>()
				.AfterMap<TagMapper>();
		}
	}

	public class TagMapper : IMappingAction<SentryDataModel, MailModel> {
		public void Process(SentryDataModel source, MailModel destination) {
			NameValueCollection tags = source.Event.Tags.ToNameValue();
			destination.Environment = tags[nameof(destination.Environment)];
			destination.Module = tags[nameof(destination.Module)];
		}
	}
}