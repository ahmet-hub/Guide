using AutoMapper;
using Report.Domain.Dtos;

namespace ReportCreatorWorker.Mapping
{
    public class MappingProfile : Profile

    {
        public MappingProfile()
        {
            CreateMap<ReportDto, Report.Domain.Entities.Report>();
            CreateMap<Report.Domain.Entities.Report, ReportDto>();
        }
    }
}
