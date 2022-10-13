using Booking_System.Context;
using Booking_System.Storage;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var configuration = builder.Configuration;

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<DbApplicationContext>(options =>
options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IBookingStorage, BookingStorage>();
builder.Services.AddScoped<ICustomerStorage, CustomerStorage>();
builder.Services.AddScoped<IEmployeeStorage, EmployeeStorage>();
builder.Services.AddScoped<INotifications, Notifications>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.Run();