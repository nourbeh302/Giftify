using Application.Common.Payment;
using Domain.Gifts;
using Domain.Orders;
using Domain.Products;
using Domain.Users;
using Infrastructure.Data;
using Infrastructure.Payment;
using Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Infrastructure;

public static partial class AssemblyReference
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<ApplicationDbContext>(options =>
        {
            string connectionString = configuration.GetConnectionString("DefaultConnection") ?? 
                throw new InvalidOperationException("Could not resolve the connection string");

            options
                .UseSqlServer(connectionString)
                .UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
        });

        services.AddScoped<UserRepository>();
        services.AddScoped<IUserRepository, CachedUserRepository>();
        
        services.AddScoped<ProductRepository>();
        services.AddScoped<IProductRepository, CachedProductRepository>();

        services.AddScoped<ReviewRepository>();
        services.AddScoped<IReviewRepository, CachedReviewRepository>();

        services.AddScoped<IGiftRepository, GiftRepository>();

        services.AddScoped<IOrderRepository, OrderRepository>();


        return services;
    }
}

public static partial class AssemblyReference
{
    public static IServiceCollection AddPaymentGateway(this IServiceCollection services)
    {
        services.AddScoped<IPaymentAuthTokenProvider, PaymentAuthTokenProvider>();
        services.AddScoped<IPaymentOrderManager, PaymentOrderManager>();
        services.AddScoped<IPaymentKeyProvider, PaymentKeyProvider>();

        services.AddScoped<IPaymentProvider, PaymentProvider>();

        return services;
    }
}