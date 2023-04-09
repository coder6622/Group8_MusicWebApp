using Carter;
using MusicApp.WebApi.Endpoints;
using MusicApp.WebApi.Extensions;
using TatBlog.WebApi.Mapsters;
using TatBlog.WebApi.Validations;

var builder = WebApplication.CreateBuilder(args);

{
  builder
    .ConfigureCors()
    .ConfigureServices()
    .ConfigureSwaggerOpenApi()
    .ConfigureMapster()
    .ConfigureFluentValidation();
}


var app = builder.Build();

{
  app.SetupRequestPipeline();

  app.MapCarter();

  app.UseDataSeeder();

  app.Run();
}


