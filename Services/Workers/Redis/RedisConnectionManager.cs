using StackExchange.Redis;
using System.Text.Json;

namespace E2Z.Workers.Redis
{
    public class RedisConnectionManager: IRedisConnectionManager
    {
        private readonly ConnectionMultiplexer
            _connection;
        private readonly IDatabase database;

        public RedisConnectionManager(string connectionString)
        {
            _connection = ConnectionMultiplexer.Connect(connectionString);
            database = _connection.GetDatabase();
        }

        public async Task SetValueAsync<T>(string key, T value, TimeSpan? expiry = null)
        {
            var bytes = JsonSerializer.SerializeToUtf8Bytes(value);
            await database.StringSetAsync(key, bytes);
        }

        public async Task<T?> GetValueAsync<T>(string key)
        {
            var bytes = await database.StringGetAsync(key);
            if (bytes.IsNullOrEmpty)
                return default;
            return JsonSerializer.Deserialize<T>((byte[])bytes!);
        }
    }
}
