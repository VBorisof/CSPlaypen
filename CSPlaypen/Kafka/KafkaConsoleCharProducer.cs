using Confluent.Kafka;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace CSPlaypen.Kafka
{
    class KafkaConsoleCharProducer
    {
        static async Task Start()
        {
            var config = new ProducerConfig
            {
                BootstrapServers = "209.97.184.81:9094",
                Debug = "all"
            };

            //using (var serdeProvider = new AvroSerdeProvider(new AvroSerdeProviderConfig { SchemaRegistryUrl = "192.168.56.101:8081" }))
            using (var p = new Producer<Null, string>(config))
            {
                #region LOGGING -- COMMENTED OUT
                //p.OnLog += (_, e) => {
                //    Console.WriteLine($"[{e.Level}] {e.Message}");
                //};
                //p.OnError += (_, e) => {
                //    Console.WriteLine($"[ERROR] {e}");
                //};
                //p.OnStatistics += (_, s) => {
                //    Console.WriteLine($"[STATS] {s}");
                //};
                #endregion

                ConsoleKeyInfo key;
                while ((key = Console.ReadKey()).KeyChar != 'Q')
                {
                    p.BeginProduce("TEST", new Message<Null, string> { Value = new string(new[] { key.KeyChar }) });

                    #region WAIT-FOR-DELIVERY -- COMMENTED OUT
                    //try
                    //{
                    //    var deliveryReport = await p.ProduceAsync("TEST", new Message<Null, string> { Value = $"{key.KeyChar}" });
                    //    Console.WriteLine($"Delivered message '{deliveryReport.Value}' to {deliveryReport.TopicPartitionOffset}");
                    //}
                    //catch (KafkaException e)
                    //{
                    //    Console.WriteLine($"Delivery failed: {e.Error.Reason}");
                    //}
                    #endregion
                }
            }
        }
    }
}
