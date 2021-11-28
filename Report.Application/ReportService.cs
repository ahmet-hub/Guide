using AutoMapper;
using Microsoft.Extensions.Configuration;
using Report.Application.Interfaces;
using Report.Domain.Dtos;
using Report.Domain.Enums;
using Report.Domain.Models;
using Report.Infrastructure.Interfaces;
using System;
using System.Threading.Tasks;

namespace Report.Application
{
    public class ReportService : IReportService
    {
        private readonly IRepository<Domain.Entities.Report> _repository;
        private readonly IHttpService _httpService;
        private readonly IKafkaService _kafkaService;
        private readonly IMapper _mapper;
        private readonly string _topic = string.Empty;
        private readonly string _url = string.Empty;
        public ReportService(IRepository<Domain.Entities.Report> repository,
            IMapper mapper,
            IHttpService httpService,
            IKafkaService kafkaService, IConfiguration configuration
           )
        {
            _repository = repository;
            _mapper = mapper;
            _httpService = httpService;
            _kafkaService = kafkaService;
            _topic = configuration["KafkaOptions:ReportTopic"];
            _url = configuration["ContactApi:Url"];
        }
        public async Task<Response<ReportDto>> GetAsync(Guid reportId)
        {
            return Response.Ok(_mapper.Map<ReportDto>(await _repository.GetAsync(reportId)), "");
        }

        public async Task<Response<Guid>> GenerateReportAsync(string location)
        {
            var url = new Uri(string.Format(_url, location));
            var response = await GetReportAsync(url);

            var entity = await CreateReportAsync(new Domain.Entities.Report { Statu = Enum.GetName(Statu.InProgress), CreationTime = DateTime.Now });

            var sendKafka = new ReportDto
            {
                Id = entity.Id,
                PersonCount = response.ReportResponse.PersonCount,
                PhoneCount = response.ReportResponse.PhoneCount,
            };

            await _kafkaService.Producer(_topic, sendKafka);

            return Response.Ok(entity.Id, "");
        }

        private async Task<ReportResponseModel> GetReportAsync(Uri uri)
        {
            return await _httpService.GetAsync<ReportResponseModel>(uri);
        }

        private async Task<Domain.Entities.Report> CreateReportAsync(Domain.Entities.Report report)
        {
            return await _repository.AddAsync(report);
        }

    }
}
