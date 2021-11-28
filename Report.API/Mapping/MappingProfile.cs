using AutoMapper;
using Report.Domain.Dtos;

namespace Report.API.Mapping
{
    public class MappingProfile : Profile

    {
        public MappingProfile()
        {
            CreateMap<ReportDto, Domain.Entities.Report>();
            CreateMap<Domain.Entities.Report, ReportDto>();
        }
    }
}
