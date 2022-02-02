using HotelBookingSystem.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;

namespace HotelBookingSystem.Data.Context
{
    public partial class BookingContext : DbContext
    {
        public BookingContext()
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            base.OnModelCreating(builder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .AddJsonFile("appsetting.{environment}.json", true)
                .Build();

            var connectionString = configuration.GetConnectionString("BookingDatabase");
            optionsBuilder.UseSqlServer(connectionString);
        }
    }
}
