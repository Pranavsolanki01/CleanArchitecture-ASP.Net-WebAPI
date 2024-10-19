using CleanArchitecture.Application.Services;
using CleanArchitecture.Domain.Interface;
using CleanArchitecture.Infrastructure.Data;
using CleanArchitecture.Infrastructure.Repositories;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// now resolve the dependency for the database connectivity or access
builder.Services.AddDbContext<BlogDbContext>(options =>
	options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection") ?? 
	throw new InvalidOperationException("Connection String 'DefaultConnection' not found") ));



// registering the service for the dependency for the repositories
// the dependency for the repositories is resolved by the AddScoped method or the AddTransient method
// as i want to make the services are created each time they are requested, i will use the AddTransient method
builder.Services.AddTransient<IBlogRepository, BlogRepository>();
builder.Services.AddTransient<IBlogService, BlogService>();

builder.Services.AddControllers();
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
