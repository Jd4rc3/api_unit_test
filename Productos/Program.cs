using Productos;

var builder = WebApplication.CreateBuilder(args);

var startup = new Startup(builder.Configuration);

startup.ConfigurationService(builder.Services);

var app = builder.Build();

startup.Configuration(app, app.Environment);

app.Run();

