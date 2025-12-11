using Microsoft.EntityFrameworkCore;
using MovieLibrary.Application.Services;
using MovieLibrary.Core.Abstractions;
using MovieLibrary.DataAccess;
using MovieLibrary.DataAccess.Repositories;
using Serilog;
using Serilog.Core;

var builder = WebApplication.CreateBuilder(args);

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .WriteTo.File("log.txt", rollingInterval: RollingInterval.Day)
    .CreateLogger();

builder.Services.AddOpenApi();
builder.Logging.AddSerilog();
builder.Services.AddControllers();
builder.Services.AddDbContext<MovieLibraryDbContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString(nameof(MovieLibraryDbContext)));
});
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddOpenApi();
builder.Services.AddScoped<IMovieService, MovieService>();
builder.Services.AddScoped<IMovieRepository, MovieRepository>();
var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.MapOpenApi();

}

//app.UseAuthorization();

app.MapControllers();

app.Run();
