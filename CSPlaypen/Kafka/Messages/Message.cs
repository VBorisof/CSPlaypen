using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using Avro;

namespace CSPlaypen.Messages
{

    [DataContract(Name = "Message", Namespace = "Messages")]
    public class Message
    {
        [DataMember(Name = "Sender")]
        public string Sender { get; set; }
        [DataMember(Name = "Content")]
        public string Content { get; set; }

        public static string GetSchema()
        {
            return 
            @"{
                ""namespace"": ""Confluent.Kafka.Examples.AvroSpecific"",
                ""type"": ""record"",
                ""name"": ""Message"",
                ""fields"": [
                    {""name"": ""sender"",   ""type"": ""string""},
                    {""name"": ""content"",  ""type"": ""string""}
                ]
            }";
        }
    }
}
