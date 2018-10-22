using System;
using System.Collections.Specialized;
using AutoMapper;
using SentryToMail.Utils.Extension;

namespace SentryToMail.Models.AutoMapper {
	public class SentryToMailModelProfile : Profile {
		public SentryToMailModelProfile() {
			CreateMap<SentryDataModel.SentryDataModel, MailModel>()
				.AfterMap((model, mailModel) => {
					if (mailModel.Id == Guid.Empty) {
						mailModel.Id = Guid.NewGuid();
					}
				})
				.AfterMap<TagMapper>();
		}
	}

	public class TagMapper : IMappingAction<SentryDataModel.SentryDataModel, MailModel> {
		public void Process(SentryDataModel.SentryDataModel source, MailModel destination) {
			NameValueCollection tags = source.Event.Tags.ToNameValue();
			destination.Environment = tags.FindValue(nameof(destination.Environment));
			destination.Module = tags.FindValue(nameof(destination.Module));
			destination.MachineName = tags.FindValue(nameof(destination.MachineName));
		}
	}
}