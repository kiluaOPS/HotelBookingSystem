using HotelBookingSystem;
using HotelBookingSystem.Data.Context;
using HotelBookingSystem.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
/*
 * could use in memory database if needed
services.AddDbContext<BookingContext>(options => {

    options.UseInMemoryDatabase("booking-in-memory-db");

}); */
builder.Services.AddDbContext<BookingContext>();

//Dependency Injection of Services
builder.Services.AddScoped<IRoomService, RoomService>();
builder.Services.AddScoped<IHotelService, HotelService>();
builder.Services.AddScoped<IBookingService, BookingService>();


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
