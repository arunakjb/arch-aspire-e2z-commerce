namespace E2Z.Workers.Redis
{
    public interface IRedisConnectionManager
    {
        Task SetValueAsync<T>(string key, T value, TimeSpan? expiry = null);
        Task<T?> GetValueAsync<T>(string key);
    }
}
