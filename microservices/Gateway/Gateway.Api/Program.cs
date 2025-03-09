using Gateway.Api.ReverseProxy;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddReverseProxy(builder.Configuration);
var app = builder.Build();
app.UseReverseProxy();
app.Run();
