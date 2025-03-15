using QueueMailer.Application;
using QueueMailer.Infrastructure;
using Shared.Infrastructure;
using Shared.Infrastructure.Configuration;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddSharedConfiguration(builder.Environment);

builder.Services
    .AddQueueMailerApplication()
    .AddQueueMailerInfrastructure(builder.Configuration)
    .AddControllers();

var app = builder.Build();

app.UseSharedInfrastructure();

app.Run();