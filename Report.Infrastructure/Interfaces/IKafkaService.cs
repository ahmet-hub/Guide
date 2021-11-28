using System.Threading.Tasks;

namespace Report.Infrastructure.Interfaces
{
    public interface IKafkaService
    {
        Task<bool> Producer(string topic, object message);
    }
}
