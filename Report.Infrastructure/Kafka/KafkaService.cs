using Confluent.Kafka;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Report.Infrastructure.Interfaces;
using System;
using System.Globalization;
using System.Threading.Tasks;

namespace Report.Infrastructure.Kafka
{
    public class KafkaService : IKafkaService
    {
        private readonly IProducer<string, string> _producer;

        public KafkaService(IConfiguration configuration)
        {
            var configProducer = new ProducerConfig
            {
                BootstrapServers = configuration["KafkaOptions:Endpoint"],
            };

            _producer ??= new ProducerBuilder<string, string>(configProducer).Build();
        }

        public async Task<bool> Producer(string topic, object message)
        {
            try
            {
                await _producer.ProduceAsync(topic, new Message<string, string>
                {
                    Key = DateTime.Now.ToString(CultureInfo.InvariantCulture),
                    Value = JsonConvert.SerializeObject(message)
                });

                _producer.Flush(TimeSpan.FromSeconds(10));

                return true;
            }

            catch
            {
                return false;
            }
        }
    }
}
