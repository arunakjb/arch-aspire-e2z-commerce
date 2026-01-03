
var builder = DistributedApplication.CreateBuilder(args);

var redis = builder.AddRedis("RedisConnection", port: 6379);

var api = builder.AddProject<Projects.E2Z_Api>("ak-e2z-api-dev001")
    .WithReference(redis);

builder.Build().Run();
