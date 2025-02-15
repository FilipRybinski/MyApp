using FeatureFlags.Application;
using Shared.Configuration;
using Shared.Infrastructure;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddSharedConfiguration(builder.Environment);

builder.Services
    .AddApplication(builder.Configuration)
    .AddSharedInfrastructure(builder.Configuration)
    .AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();