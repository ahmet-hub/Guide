using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Report.Infrastructure;
using Report.Infrastructure.Data;
using Report.Infrastructure.Interfaces;
using Report.Infrastructure.Kafka;
using ReportCreatorWorker.Options;

namespace ReportCreatorWorker
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    var kafkaOptions = new KafkaOptions();
                    hostContext.Configuration.Bind(nameof(KafkaOptions), kafkaOptions);
                    services.AddSingleton(kafkaOptions);
                    services.AddDbContext<AppDbContext>(options =>
                         options.UseNpgsql(hostContext.Configuration.GetConnectionString("DefaultConnection")), ServiceLifetime.Singleton);

                    services.AddSingleton(typeof(IRepository<>), typeof(EfRepository<>));
                    services.AddSingleton<IKafkaService, KafkaService>();
                    services.AddAutoMapper(typeof(Program));
                    services.AddHostedService<ReportCreatorWorker>();
                });
    }
}
