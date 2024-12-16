using FormationAPI;
using Microsoft.EntityFrameworkCore;
using NLog.Web;
using NLog;
using NLog.Extensions.Logging;


//var logger = LogManager.Setup().LoadConfigurationFromAppSettings().GetCurrentClassLogger();
//logger.Debug("Init main");

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddLogging(logging =>
{
    logging.ClearProviders();
    logging.SetMinimumLevel(Microsoft.Extensions.Logging.LogLevel.Trace);
});

// Add NLog as the logger provider
builder.Services.AddSingleton<ILoggerProvider, NLogLoggerProvider>();

// Add services to the container.

builder.Services.AddControllers();

var connectionString = builder.Configuration.GetConnectionString("FormationDb")!;
//builder.Services.AddDbContext<FormationDbContext>(options =>
//{
//    options.UseSqlServer(connectionString)
//           .LogTo(Console.WriteLine);
//});
Injections.InjectDbContext(builder.Services, connectionString);
Injections.InjectBankService(builder.Services);
Injections.InjectGestionCompteService(builder.Services);
Injections.InjectGestionUseService(builder.Services);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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

app.Run();
