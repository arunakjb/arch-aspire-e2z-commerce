using E2Z.Api.EndPoints;
using E2Z.Api.Infrastructure.Identity;
using E2Z.DB.ORM.Context;
using E2Z.Workers.Redis;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi;

var builder = WebApplication.CreateBuilder(args);

// Register DbContext
builder.Services.AddDbContext<E2ZDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

// Register Redis Cache
builder.Services.AddSingleton<IRedisConnectionManager>(options =>
{
    var configuration = builder.Configuration.GetConnectionString("RedisConnection");
    return new RedisConnectionManager(configuration!);
});

// Register Endpoints
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "E2Z API",
        Version = "v1",
        Description = "E2Z Commerce API"
    });
});

// Register User Context
builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<IUserContext, UserContext>();

var app = builder.Build();

// Configure Swagger middleware
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "E2Z API v1");
        options.RoutePrefix = string.Empty;
    });
}

app.MapEndpoints();
app.Run();