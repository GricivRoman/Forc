using Forc.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var relativePathToConfig = @"../ForcWebApi";
var pathToConfig = Path.GetFullPath(relativePathToConfig);


var config = new ConfigurationBuilder()
    .SetBasePath(pathToConfig)
    .AddJsonFile("appsettings.json", optional: false)
    .Build();

builder.Services.AddDbContext<DataContext>(opt =>
{
    opt.UseNpgsql(config.GetConnectionString("ForcDB"));
});

AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

var app = builder.Build();

app.Run();
