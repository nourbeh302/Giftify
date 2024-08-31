using Application.Common.Authentication;
using Application.Common.Email;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Application;

public static class AssemblyReference
{
    public static IServiceCollection AddApplication(
        this IServiceCollection services,
        IConfiguration configuration)
    {
        Assembly assembly = typeof(AssemblyReference).Assembly;

        services.AddMediatR(configuration => configuration.RegisterServicesFromAssembly(assembly));

        services.Configure<SmtpSettings>(settings =>
        {
            settings.Host = configuration["Smtp:Host"] ?? throw new InvalidOperationException("Could not resolve the host");
            settings.Port = int.Parse(configuration["Smtp:Port"]!);
            settings.Username = configuration["Smtp:Username"] ?? throw new InvalidOperationException("Could not resolve the username");
            settings.Password = configuration["Smtp:Password"] ?? throw new InvalidOperationException("Could not resolve the password");
        });

        services.AddSingleton<IPasswordHasher, PasswordHasher>();
        services.AddSingleton<IJwtProvider, JwtProvider>();
        services.AddSingleton<IEmailSender, EmailSender>();
        services.AddSingleton<IPinGenerator, PinGenerator>();

        return services;
    }
}