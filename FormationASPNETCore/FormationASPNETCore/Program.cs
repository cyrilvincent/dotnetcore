using FormationASPNETCore;
using FormationASPNETCore.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using NLog;
using NLog.Web;

var logger = LogManager.Setup().LoadConfigurationFromAppSettings().GetCurrentClassLogger();
logger.Debug("Init main");

var builder = WebApplication.CreateBuilder(args);

builder.Logging.ClearProviders();
builder.Host.UseNLog();

Injections.InjectServices(builder.Services);

builder.Services.AddControllers();

var connectionString = builder.Configuration.GetConnectionString("FormationDb");
Injections.InjectDbContext(builder.Services, connectionString);

//builder.Services.AddScoped<IMediaService, MediaService>(); // A déporter dans classe statique

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(); // <GenerateDocumentationFile>true dans csproj pour avoir le commentaires ou dans propriétés du projet build / sortie / fichier de documentation

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
