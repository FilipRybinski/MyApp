using Shared.Infrastructure;
using Shared.Infrastructure.Configuration;
using TokenRegistry.Application;
using TokenRegistry.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddSharedConfiguration(builder.Environment);

builder.Services
    .AddTokenRegistryApplication()
    .AddTokenRegistryInfrastructure(builder.Configuration)
    .AddControllers();

var app = builder.Build();

app.UseSharedInfrastructure();

app.Run();