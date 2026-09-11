using CodingExercise.Santander.FirebaseIONewsServices.Implementations;
using CodingExercise.Santander.FirebaseIONewsServices.Interfaces;
using CodingExercise.Santander.FirebaseIONewsServices.Mapper;
using CodingExercise.Santander.FirebaseIONewsServices.Models;
using CodingExercise.Santander.HackerNews.BusinessServices.Implementations;
using CodingExercise.Santander.HackerNews.BusinessServices.Interfaces;
using CodingExercise.Santander.HackerNews.Models.DomainModels;
using CodingExercise.Santander.HackerNews.Models.Settings;
using CodingExercise.Santander.HackerNews.WebAPI.Extensions;
using Serilog;

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .CreateBootstrapLogger();

try
{
    Log.Information("Building and Starting Web Application for Hacker News RESTful Services ...");

    var builder = WebApplication.CreateBuilder(args);

    builder.Services.AddSerilog((services, logConfigurer) =>
        logConfigurer
            .ReadFrom.Configuration(builder.Configuration)
            .ReadFrom.Services(services)
    );

    // Register IOptions Settings
    builder.Services.Configure<HackerNewsSettings>(builder.Configuration.GetSection("HackerNewsSettings"));
    builder.Services.AddProblemDetails(options =>
    {
        options.CustomizeProblemDetails = ctx =>
        {
            ctx.ProblemDetails.Extensions["traceId"] = ctx.HttpContext.TraceIdentifier;
            ctx.ProblemDetails.Extensions["timestamp"] = DateTime.UtcNow;
            ctx.ProblemDetails.Instance = $"{ctx.HttpContext.Request.Method} {ctx.HttpContext.Request.Path}";
        };
    });

    // Add services to the container.
    builder.Services.AddTransient<IMapper<HNBestStoryEntity, HNBestStory>, HNBestStoryMapper>();
    builder.Services.AddTransient<IMapper<HNUserEntity, HNUser>, HNUserMapper>();

    builder.Services.AddScoped<IHNBestStoriesService, HNBestStoriesService>();
    builder.Services.AddScoped<IHackerNewsOrchestrationServices, HackerNewsOrchestrationServices>();

    builder.Services.AddControllers();

    // Configure OpenAPI Scalar UI
    builder.Services.AddMicrosoftOpenApi();

    var app = builder.Build();

    // Configure OpenAPI Scalar UI
    app.UseMicrosoftOpenApiUI();

    app.UseHttpsRedirection();

    app.UseAuthorization();

    app.MapControllers();

    app.Run();
}
catch (Exception excep)
{
    Log.Fatal(excep, "Server terminated unexpectedly");
}
finally
{
    Log.CloseAndFlush();
}
