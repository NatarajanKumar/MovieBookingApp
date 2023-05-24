using Microsoft.Extensions.Configuration;
using MovieBookingApp.API.Entities;
using MovieBookingApp.API.Models;
using MovieBookingApp.API.Repository.Contract;
using MovieBookingApp.API.Repository.Implementation;
using MovieBookingApp.API.Services.Contract;
using MovieBookingApp.API.Services.Implementation;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
// Add services to the container.
builder.Services.Configure<DBConfiguration>(builder.Configuration.GetSection("DBConfiguration"));
builder.Services.AddSingleton<IMongoDbContext,MongoDbContext>();
// Add repositories
builder.Services.AddTransient<IMovieRepository, MovieRepository>();
builder.Services.AddTransient<ITicketRepository, TicketRepository>();
builder.Services.AddTransient<IUserRepository, UserRepository>();
// Add services
builder.Services.AddTransient<IMovieService, MovieService>();
builder.Services.AddTransient<ITicketService, TicketService>();
builder.Services.AddTransient<IUserService, UserService>();

//configure JWT authentication
builder.Services.AddAuthentication("Bearer")
    .AddJwtBearer("Bearer", options =>
    {
        options.Authority = "https://localhost:5001";
        options.TokenValidationParameters.ValidateAudience= false;
    });
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("Admin", policy => policy.RequireClaim("role", "admin"));
    options.AddPolicy("User", policy => policy.RequireClaim("role", "user"));
});

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

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
