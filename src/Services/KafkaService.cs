using System;
using System.Threading.Tasks;
using Confluent.Kafka;
using Newtonsoft.Json;
using src.Carro;

namespace src.Services
{
    public class KafkaService : IKafkaService
    {
        public async Task<string> SendMessage(CarRequest carRequest)
        {
            var key = Guid.NewGuid().ToString();

            var carObjectMessage = JsonConvert.SerializeObject(carRequest);
            
            var config = new ProducerConfig
            {
                BootstrapServers = "localhost:9092",
                MessageTimeoutMs = 5000,
                MessageSendMaxRetries = 5
            };

            ProducerBuilder<string, string> kafkaProducer = new ProducerBuilder<string, string>(config);

            using(var producer = kafkaProducer.Build())
            {
                try
                {
                    var sendResult = producer.ProduceAsync("kafka-topic",
                        new Message<string, string> {Key = key, Value = carObjectMessage}).GetAwaiter().GetResult();

                    await Task.Delay(100);
                    return key;
                }

                catch(ProduceException<string, string> e)
                {
                    return $"Delivery messaging failed: {e.Error.Reason}";
                }
            }
        }
    }
}