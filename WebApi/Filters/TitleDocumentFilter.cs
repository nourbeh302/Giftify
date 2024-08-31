using Microsoft.OpenApi.Models;
using Swashbuckle.AspNetCore.SwaggerGen;

namespace WebApi.Filters;

public class TitleDocumentFilter : IDocumentFilter
{
    public void Apply(OpenApiDocument swaggerDoc, DocumentFilterContext context)
    {
        swaggerDoc.Info.Title = "Giftify";
        swaggerDoc.Info.Description =
            """
            Giftify is an application that allows users to create and manage personalized gifts. 
            Users can bundle products into a gift, track orders, and manage shipping and billing addresses.
            """;
    }
}
