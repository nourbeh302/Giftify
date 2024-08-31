using Application;
using Infrastructure;
using Microsoft.OpenApi.Models;
using Serilog;
using System.Reflection;
using WebApi.Extensions;
using WebApi.Filters;
using WebApi.Helpers;
using WebApi.Middlewares;
using WebApi.OperationFilters;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseSerilog((context, loggerConfig) => 
    loggerConfig.ReadFrom.Configuration(context.Configuration));

builder.Services.AddHttpClient();

// Add anti-forgery
builder.Services.AddAntiforgery(options => options.HeaderName = "XSRF-TOKEN");

builder.Services.AddMemoryCache();

builder.Services.AddTransient<IFileManager, FileManager>();

builder.Services
    .AddApplication(builder.Configuration)
    .AddInfrastructure(builder.Configuration)
    .AddPaymentGateway();

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.OperationFilter<AddAntiforgeryHeaderOperationFilter>();
    options.DocumentFilter<TitleDocumentFilter>();

    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = SecuritySchemeType.Http,
        Scheme = "bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Please enter a valid token"
    });

    options.OperationFilter<AddBearerAuthenticationHeaderOperationFilter>();
});

// Add authentication extension method
builder.Services.AddAuthentication(builder.Configuration);

// Add authorization roles and policies
builder.Services.AddAuthorizationBuilder()
    .AddPolicy("user-access", policy => policy.RequireClaim("role", "User"))
    .AddPolicy("admin-access", policy => policy.RequireClaim("role", "Administrator"));

// Register the endpoints
builder.Services.AddEndpoints(Assembly.GetExecutingAssembly());

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAntiforgery();

app.UseMiddleware<RequestLoggingMiddleware>();

app.UseSerilogRequestLogging();

app.UseAuthentication();
app.UseAuthorization();

app.UseStaticFiles();

app.MapEndpoints();


app.Run();
