using Microsoft.AspNetCore.Antiforgery;

namespace WebApi.Endpoints.Auth
{
    public class GetXsrfToken : IEndpoint
    {
        public void MapEndpoint(IEndpointRouteBuilder app)
        {
            app.MapGet("/xsrf/token", (HttpContext context) =>
            {
                var antiforgery = context.RequestServices.GetRequiredService<IAntiforgery>();
                var tokens = antiforgery.GetAndStoreTokens(context);

                context.Response.Cookies.Append("XSRF-TOKEN", tokens.RequestToken!, new CookieOptions
                {
                    HttpOnly = false,
                });

                return Results.Json(tokens.RequestToken);
            })
                .WithName(nameof(GetXsrfToken))
                .WithTags(Tags.Auth);
        }
    }
}
