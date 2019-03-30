using System;
using System.Threading;
using Confluent.Kafka;
using Newtonsoft.Json;

namespace CSPlaypen.Kafka
{
    public enum Enumerator
    {
        SomeType = 0,
        SomeOtherType = 1
    }

    public class Message
    {
        public Enumerator Enumerator { get; set; }
        public string State { get; set; }

        public override string ToString()
        {
            return $"{{\n    MESSAGE: {Enumerator} ({(int) Enumerator}),\n    \"{ State }\"\n}}";
        }
    }

    class Consumer
    {
        public static void Consume()
        {
            var _consumerConfig = new ConsumerConfig
            {
                GroupId = "mt4-event-consumer",
                BootstrapServers = "209.97.184.81:19092,209.97.184.81:29092,209.97.184.81:39092"
            };

            // Setup a kafka consumer here for all entries without a date...
            using (var consumer = new Consumer<Ignore, string>(_consumerConfig))
            {
                consumer.Subscribe("test-topic");

                // For each consumed entry, we want to call ProcessNotification(entry);
                var thread = new Thread(() =>
                {
                    while (true)
                    {
                        try
                        { 
                            var result = consumer.Consume();
                            var json = result.Message.Value;

                            var message = (Message) JsonConvert.DeserializeObject(json, typeof(Message));

                            Console.WriteLine($"Consumed message {message}");
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine($"Exception encountered: {e}");
                        }
                    }
                });
                thread.Start();
                Console.ReadKey();
            }
        }
    }
}