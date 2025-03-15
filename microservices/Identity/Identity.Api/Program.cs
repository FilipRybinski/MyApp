using Identity.Application;
using Identity.Infrastructure;
using Shared.Infrastructure;
using Shared.Infrastructure.Configuration;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddSharedConfiguration(builder.Environment);

builder.Services
    .AddApplication()
    .AddInfrastructure(builder.Configuration)
    .AddControllers();

var app = builder.Build();

app.UseSharedInfrastructure();

app.Run();