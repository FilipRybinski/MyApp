using FeeTracker.Application;
using FeeTracker.Infrastructure;
using Shared.Infrastructure;
using Shared.Infrastructure.Configuration;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddSharedConfiguration(builder.Environment);

builder.Services
    .AddApplication()
    .AddInfrastructure(builder.Configuration)
    .AddControllers();
builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

app.UseSharedInfrastructure();

app.Run();