using E2Z.Api.Extensions;
using E2Z.Api.Infrastructure.Identity;
using E2Z.Api.Services;
using E2Z.Api.Services.Interfaces;
using E2Z.DB.ORM.Context;
using E2Z.DB.ORM.Repositories;
using E2Z.DB.ORM.Repositories.Interfaces;
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

// Register Repositories
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<ICartRepository, CartRepository>();
builder.Services.AddScoped<IDeliveryDetailRepository, DeliveryDetailRepository>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IProductImageRepository, ProductImageRepository>();
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IReturnDetailRepository, ReturnDetailRepository>();
builder.Services.AddScoped<ITransactionRepository, TransactionRepository>();
builder.Services.AddScoped<IUserFavoriteRepository, UserFavoriteRepository>();
builder.Services.AddScoped<IUserProfileRepository, UserProfileRepository>();
builder.Services.AddScoped<IUserRecentActivityRepository, UserRecentActivityRepository>();
builder.Services.AddScoped<IUserReviewImageRepository, UserReviewImageRepository>();
builder.Services.AddScoped<IUserReviewRepository, UserReviewRepository>();

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
    options.ResolveConflictingActions(apiDescriptions => apiDescriptions.First());
});

// Register User Context
builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<IUserContext, UserContext>();

// Register Services
builder.Services.AddScoped<ICartService, CartService>();
builder.Services.AddScoped<IDeliveryDetailService, DeliveryDetailService>();
builder.Services.AddScoped<IOrderService, OrderService>();
builder.Services.AddScoped<IProductImageService, ProductImageService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<IReturnDetailService, ReturnDetailService>();
builder.Services.AddScoped<ITransactionService, TransactionService>();
builder.Services.AddScoped<IUserFavoriteService, UserFavoriteService>();
builder.Services.AddScoped<IUserProfileService, UserProfileService>();
builder.Services.AddScoped<IUserRecentActivityService, UserRecentActivityService>();
builder.Services.AddScoped<IUserReviewImageService, UserReviewImageService>();
builder.Services.AddScoped<IUserReviewService, UserReviewService>();

builder.Services.AddEndpointsApiExplorer();
var app = builder.Build();

// Map Endpoints
app.RegisterEndpoints();

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


app.Run();