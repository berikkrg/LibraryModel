using LibraryData.Context;
using Microsoft.EntityFrameworkCore;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

//builder.Logging.ClearProviders();

//builder.Logging.AddConsole();

builder.Services.AddControllers();

var connectionString = builder.Configuration.GetConnectionString("LibraryConnectionString");
builder.Services.AddDbContext<LibraryDbContext>(options => options.UseSqlServer(connectionString));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Information()
    .WriteTo.Console()
    .CreateLogger();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();
//app.Run(async (context) =>
//{
//    var path = context.Request.Path;
//    app.Logger.LogCritical($"LogCritical {path}");
//    app.Logger.LogError($"LogError {path}");
//    app.Logger.LogInformation($"LogInformation {path}");
//    app.Logger.LogWarning($"LogWarning {path}");
    

//    //await context.Response.WriteAsync("Hello World!");
//});
app.Run();
