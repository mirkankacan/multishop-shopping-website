using StackExchange.Redis;
using System.Threading.Tasks;

namespace MultiShop.Basket.Settings
{
    public class RedisService
    {
        private ConnectionMultiplexer _connectionMultiplexer;

        public RedisService(string host, int port)
        {
            _host = host;
            _port = port;
        }

        public string _host { get; set; }
        public int _port { get; set; }

        public async Task ConnectAsync() => _connectionMultiplexer = await ConnectionMultiplexer.ConnectAsync($"{_host}:{_port}");
        public IDatabase GetDb(int db = 1) => _connectionMultiplexer.GetDatabase(0);
    }
}
