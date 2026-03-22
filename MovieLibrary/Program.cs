using System.Text;
using FluentValidation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Movie_Library.Contracts;
using Movie_Library.Contracts.Reviews;
using Movie_Library.Contracts.Validators;
using MovieLibrary.Application.Services;
using MovieLibrary.Core.Abstractions;
using MovieLibrary.DataAccess;
using MovieLibrary.DataAccess.Repositories;
using MovieLibrary.Infrastructure;
using Serilog;
using Serilog.Core;

var builder = WebApplication.CreateBuilder(args);

Log.Logger = new LoggerConfiguration()
    .WriteTo.Console()
    .WriteTo.File("log.txt", rollingInterval: RollingInterval.Day)
    .CreateLogger();


builder.Services.Configure<JwtOptions>(builder.Configuration.GetSection(nameof(JwtOptions)));
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

builder.Services.AddScoped<IValidator<ReviewRequest> 
    ,ReviewRequestValidator>();
builder.Services.AddScoped<IValidator<UpdateReviewRequest> 
    ,UpdateReviewRequestValidator>();
builder.Services.AddScoped<IValidator<MovieRequest> 
    ,MovieRequestValidator>();

builder.Services.AddScoped<IJwtProvider, JwtProvider>();
builder.Services.AddScoped<IPasswordHasher, PasswordHasher>();

builder.Services.AddScoped<IReviewService, ReviewService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IMovieService, MovieService>();
builder.Services.AddScoped<IAuthService, AuthService>();

builder.Services.AddScoped<IReviewRepository, ReviewRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IMovieRepository, MovieRepository>();

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.MapOpenApi();

}

//app.UseAuthentication();
//app.UseAuthorization();

app.MapControllers();

app.Run();
