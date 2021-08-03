using HotelListing.Configuations.Entities;
using HotelListing.Data;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HotelListing.Models
{
    public class HotelListingDbContext : IdentityDbContext<ApiUser>
    {
        private readonly string connString;
        public HotelListingDbContext()
        {
            IConfigurationBuilder builder = new ConfigurationBuilder();
            builder.AddJsonFile(Path.Combine(Directory.GetCurrentDirectory(), "appsettings.json"));

            var root = builder.Build();
            connString = root.GetConnectionString("sqlConnection");
        }
        public HotelListingDbContext(DbContextOptions<HotelListingDbContext> options)
            : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(connString);
            }
        }

        public DbSet<Country> Countries { get; set; }
        public DbSet<Hotel> Hotels { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.ApplyConfiguration(new RoleConfiguration());

            builder.Entity<Country>().HasData(
                new Country
                {
                    Id = 1,
                    Name = "South Africa",
                    ShortName = "ZAR"
                },
                new Country
                {
                    Id = 2,
                    Name = "Australia",
                    ShortName = "AUS"
                },
                new Country
                {
                    Id = 3,
                    Name = "United States of America",
                    ShortName = "USA"
                });

            builder.Entity<Hotel>().HasData(
                new Hotel
                {
                    Id =1,
                    Address = "Durban",
                    CountryId = 1,
                    Name = "Hilton Hotel",
                    Rating = 4.5
                },
                new Hotel
                {
                    Id = 2,
                    Address = "Sydney",
                    CountryId = 2,
                    Name = "Sydney Hotel",
                    Rating = 4.0
                },
                new Hotel
                {
                    Id = 3,
                    Address = "New York",
                    CountryId = 3,
                    Name = "Holiday Inn",
                    Rating = 4.7
                });
        }
    }
}
