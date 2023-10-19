using Microsoft.EntityFrameworkCore;
using DRP_API.Models;
using System.Collections;

DotNetEnv.Env.TraversePath().Load();

var builder = WebApplication.CreateBuilder(args);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
// Add services to the container.
builder.Services.AddControllers();
string DbConnectionString = Environment.GetEnvironmentVariable("SQLSERVER_CONNECTION_STRING");

if (DbConnectionString != null)
{
  builder.Services.AddDbContext<CoreApiContext>(opt =>
      opt
          .UseSqlServer(DbConnectionString)
         .UseSnakeCaseNamingConvention()
          .UseLoggerFactory(LoggerFactory.Create(builder => builder.AddConsole()))
  );
}
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
