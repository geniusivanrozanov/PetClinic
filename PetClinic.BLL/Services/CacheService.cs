using System.Text.Json;
using Microsoft.Extensions.Configuration;
using PetClinic.BLL.Interfaces;
using StackExchange.Redis;

namespace PetClinic.BLL.Services;

public class CacheService : ICacheService
{
    private readonly IDatabase _cacheDb;
    private readonly IConfiguration _config;

    public CacheService(IConfiguration config)
    {
        _config = config;
        var redis = ConnectionMultiplexer.Connect(_config["RedisConfig:ConnectionPort"]);
        _cacheDb = redis.GetDatabase();
    }

    public async Task<T?> GetDataAsync<T>(string key)
    {
        var value = await _cacheDb.StringGetAsync(key);

        if (string.IsNullOrEmpty(value))
        {
            return default;
        }
 
        return JsonSerializer.Deserialize<T>(value!);
    }
    
    public async Task<bool> SetDataAsync<T>(string key, T value, DateTimeOffset expirationTime)
    {
        var expiryTime = expirationTime.DateTime.Subtract(DateTime.Now);
        
        return await _cacheDb.StringSetAsync(key, JsonSerializer.Serialize(value), expiryTime);
    }

    public async Task<object> RemoveDataAsync(string key)
    {
        var isExist = await _cacheDb.KeyExistsAsync(key);

        if (!isExist)
        {
            return false;
        }

        return await _cacheDb.KeyDeleteAsync(key);
    }
}
