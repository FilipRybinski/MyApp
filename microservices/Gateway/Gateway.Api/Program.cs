using Gateway.Api.CORS;
using Shared.Infrastructure.Configuration;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddSharedConfiguration(builder.Environment);

builder.Services
    .AddReverseProxy()
    .LoadFromConfig(builder.Configuration.GetSection("ReverseProxy"));

builder.Services.AddCorsPolicy(builder.Configuration);

var app = builder.Build();

app.UseCorsPolicy();

app.Run();
