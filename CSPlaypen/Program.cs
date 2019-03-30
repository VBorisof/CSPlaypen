using Confluent.Kafka;
using Newtonsoft.Json;
using System;
using System.Threading;
using CSPlaypen.Extensions;

namespace CSPlaypen
{
    static class Program
    {
        public static void Main()
        {
            var time = DateTime.Now;
            ConsoleEx.WriteLine($@"
[~] == PLAYPEN v.0.1. ==================== {time:HH:mm:ss} == [~]
", ConsoleColor.Green);
 
            time = DateTime.Now;
            new Playpen().Run();
            var timePassed = DateTime.Now - time;

            ConsoleEx.WriteLine($@"
[~] == DONE in {timePassed.TotalSeconds:0.000000}s ============================= [~]
", ConsoleColor.Green);

            Console.Read();
            Console.WriteLine("Bye!");
        }
    }
}