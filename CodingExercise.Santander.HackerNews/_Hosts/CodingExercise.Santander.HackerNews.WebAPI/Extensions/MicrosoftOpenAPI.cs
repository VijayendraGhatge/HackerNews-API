using Microsoft.OpenApi;
using Scalar.AspNetCore;

namespace CodingExercise.Santander.HackerNews.WebAPI.Extensions
{
    public static class MicrosoftOpenAPI
    {
        public static void AddMicrosoftOpenApi(this IServiceCollection services)
        {
            // Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
            services.AddOpenApi(options =>
            {
                options.AddDocumentTransformer((document, context, cancellationToken) =>
                {
                    document.Info.Version = "1.0";
                    document.Info.Title = "HN Best Stories API Service";
                    document.Info.Description = "This is HN Best Stories API Service documentation";
                    document.Servers.Add(new OpenApiServer
                    {
                        Description = "Development Server of HN Best Stories API Service"
                    });
                    document.Info.TermsOfService = new Uri("https://localhost/terms");
                    document.Info.Contact = new OpenApiContact
                    {
                        Name = "Vijayendra Ghatge",
                        Email = "vijayendra.ghatge@gmail.com",
                    };

                    document.Info.License = new OpenApiLicense
                    {
                        Name = "MIT License",
                        Url = new Uri("https://opensource.org/licenses/MIT")
                    };

                    return Task.CompletedTask;
                });
            });
        }

        public static void UseMicrosoftOpenApiUI(this WebApplication app, bool forNonProd = true)
        {
            if (!app.Environment.IsProduction())
            {
                app.MapOpenApi();
                app.MapScalarApiReference(options =>
                {
                    options.WithTitle("HN Best Stories API");
                    options
                        .WithTheme(ScalarTheme.Kepler)
                        .HideDarkModeToggle = true;
                });
            }
        }
    }
}
