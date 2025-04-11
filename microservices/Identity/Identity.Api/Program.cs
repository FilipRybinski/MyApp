using Identity.Application;
using Identity.Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
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