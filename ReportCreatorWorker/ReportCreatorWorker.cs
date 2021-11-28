using AutoMapper;
using Confluent.Kafka;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using Report.Domain.Dtos;
using Report.Domain.Enums;
using Report.Infrastructure.Interfaces;
using ReportCreatorWorker.Options;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace ReportCreatorWorker
{
    public class ReportCreatorWorker : BackgroundService
    {
        private readonly ILogger<ReportCreatorWorker> _logger;
        private static ConsumeResult<Ignore, string> _consumeResult;
        private readonly IRepository<Report.Domain.Entities.Report> _repository;
        private readonly IMapper _mapper;
        private readonly KafkaOptions _kafkaOptions;

        public ReportCreatorWorker(
            IRepository<Report.Domain.Entities.Report> repository,
            IMapper mapper,
            KafkaOptions kafkaOptions,
            ILogger<ReportCreatorWorker> logger
            )
        {
            _repository = repository;
            _mapper = mapper;
            _kafkaOptions = kafkaOptions;
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _logger.LogInformation("Working Report Background Service");

            while (!stoppingToken.IsCancellationRequested)
            {
                var conf = new ConsumerConfig
                {
                    GroupId = _kafkaOptions.GroupId,
                    BootstrapServers = _kafkaOptions.Endpoint,
                    AutoOffsetReset = AutoOffsetReset.Earliest,
                    EnableAutoCommit = false
                };

                using var consumerBuilder = new ConsumerBuilder<Ignore, string>(conf).Build();

                consumerBuilder.Subscribe(_kafkaOptions.ReportTopic);

                var cancellationToken = new CancellationTokenSource();

                Console.CancelKeyPress += (_, e) =>
                {
                    e.Cancel = true;
                    cancellationToken.Cancel();
                };

                try
                {
                    while (true)
                    {
                        try
                        {
                            _consumeResult = consumerBuilder.Consume(cancellationToken.Token);

                            var kafkaMessage = _consumeResult.Message;

                            _logger.LogInformation($"Start Topic: {_consumeResult.Topic}");

                            if (!kafkaMessage.Value.Any())
                                continue;

                            var report = JsonConvert.DeserializeObject<ReportDto>(kafkaMessage.Value,
                                new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });

                            if (report != null)
                            {
                                var excelPath = CreateExcel(report);

                                var reportEntity = _mapper.Map<Report.Domain.Entities.Report>(report);
                                reportEntity.Statu = excelPath is not null ? Enum.GetName(Statu.Completed) : Enum.GetName(Statu.Fail);
                                reportEntity.UpdateTime = DateTime.Now;
                                reportEntity.Path = excelPath is not null ? excelPath : null;

                                await UpdateReportAsync(_mapper.Map<Report.Domain.Entities.Report>(reportEntity));
                            }

                            consumerBuilder.Commit(_consumeResult);
                        }
                        catch (ConsumeException ex)
                        {
                            _logger.LogError("ConsumeException Try: " + ex.Error.Reason);
                        }
                    }
                }
                catch (OperationCanceledException)
                {
                    consumerBuilder.Close();
                }
            }
        }

        private string CreateExcel(ReportDto report)
        {

            try
            {
                var str = JsonConvert.SerializeObject(report);
                string path = $@"C:\Users\Monster\{report.Id}.csv";
                Aspose.Cells.Workbook workbook = new Aspose.Cells.Workbook();

                Aspose.Cells.Cells cells = workbook.Worksheets[0].Cells;

                Aspose.Cells.Utility.JsonLayoutOptions importOptions = new Aspose.Cells.Utility.JsonLayoutOptions();
                importOptions.ConvertNumericOrDate = true;
                importOptions.ArrayAsTable = true;
                importOptions.IgnoreArrayTitle = true;
                importOptions.IgnoreObjectTitle = true;
                Aspose.Cells.Utility.JsonUtility.ImportData(str, cells, 0, 0, importOptions);
                workbook.Save(path);

                _logger.LogInformation($"New excel file created :{path}");
                return path;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Excel Create Exception{ex.Message}");
                return null;
            }
        }

        private async Task UpdateReportAsync(Report.Domain.Entities.Report report)
        {
            await _repository.UpdateAsync(report);
        }
    }
}
