using Microsoft.CodeAnalysis.Differencing;
using StackExchange.Redis;
using System;

namespace BugTracker.Services
{
    public class RedisService
    {
        public string QueryRedisData()
        {
            var redisConfig = ConfigurationOptions.Parse("localhost");
            var redis = ConnectionMultiplexer.Connect(redisConfig);
            var db = redis.GetDatabase();

            // Example: Set a value
            db.StringSet("myKey", "Hello, Redis!");

            // Example: Get a value
            var value = db.StringGet("myKey");
            Console.WriteLine(value);

            return value;
        }

    }
}
