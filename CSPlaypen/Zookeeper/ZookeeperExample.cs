using System;
using System.Text;
using System.Threading.Tasks;
using org.apache.zookeeper; // NuGet: ZooKeeperNetEx

namespace CSPlaypen.Zookeeper
{
    // Watcher will notify us of events we get from ZooKeeper
    class MyWatcher : Watcher
    {
        public override async Task process(WatchedEvent @event)
        {
            Console.WriteLine($"Process event: {@event}");
        }
    }

    class ZookeeperExample
    {
        async Task Run()
        {
            // Create a new ZK client.
            var zookeeper = new ZooKeeper("192.168.178.25:2181", sessionTimeout: 3000, new MyWatcher());
            // Use it to request a config setting.
            var connectionData = await zookeeper.getDataAsync("/common-settings/connectionString");
            // Convert the received data from bytes to string.
            var connectionString = Encoding.UTF8.GetString(connectionData.Data);

            Console.WriteLine($"Got connectionString {connectionString}.");
            Console.Read();
        }
    }
}
