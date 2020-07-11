using System.Threading.Tasks;
using src.Carro;

namespace src.Services
{
    public interface IKafkaService
    {
        Task<string> SendMessage(CarRequest carRequest);
    }
}