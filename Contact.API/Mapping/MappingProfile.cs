using AutoMapper;
using Contact.Domain.Dtos.Communication;
using Contact.Domain.Dtos.Contact;
using Contact.Domain.Entities;
using System;

namespace Contact.API.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Domain.Entities.Contact, ContactDto>();
            CreateMap<Domain.Entities.Contact, ContactCreateDto>();
            CreateMap<Domain.Entities.Contact, ContactUpdateDto>();
            CreateMap<Domain.Entities.Contact, ContactDetailDto>()
                .ForMember(x => x.CommunicationDtos, y => y.MapFrom(x => x.Communications));

            CreateMap<ContactDto, Domain.Entities.Contact>();
            CreateMap<ContactCreateDto, Domain.Entities.Contact>()
                .ForMember(x => x.CreationTime, y => y.MapFrom(x => DateTime.Now));
            CreateMap<ContactUpdateDto, Domain.Entities.Contact>();
            CreateMap<ContactDetailDto, Domain.Entities.Contact>();

            CreateMap<CommunicationCreateDto, Communication>()
                .ForMember(x => x.CreationTime, y => y.MapFrom(x => DateTime.Now));
            CreateMap<Communication, CommunicationDto>();
            CreateMap<CommunicationDto, Communication>();
        }
    }
}
