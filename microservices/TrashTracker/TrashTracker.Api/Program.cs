using Shared.Infrastructure;
using Shared.Infrastructure.Configuration;
using TrashTracker.Application;
using TrashTracker.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddSharedConfiguration(builder.Environment);

builder.Services
    .AddTrashTrackerApplication()
    .AddTrashTrackerInfrastructure(builder.Configuration)
    .AddControllers();

var app = builder.Build();

app.UseSharedInfrastructure();

app.Run();