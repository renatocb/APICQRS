
using System;
using CQRS.Domain.Entities;
using CQRS.Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace CQRS.Tests.MockRepository
{
    public class FakeRepositoryVivaRealmoveis
    {
        public AppDbContext CreateFakeRepositorySaleRulesWorking()
        {
            var dbOptBuilder = GetDbOptionsBuilder();
            var dbContext = new AppDbContext(dbOptBuilder.Options);
            dbContext.Imoveis.Add(new Imoveis
            {
                UsableAreas = 3600,
                ListingType = "USED",
                CreatedAt = Convert.ToDateTime("2016-11-16T04:14:02Z"),
                ListingStatus = "ACTIVE",
                Id = "some-id",
                ParkingSpaces = 1,
                UpdatedAt = Convert.ToDateTime("2016-11-16T04:14:02Z"),
                Owner = false,
                Address = new Address
                {
                    City = "",
                    Neighborhood = "",
                    GeoLocation = new GeoLocation
                    {
                        Precision = "ROOFTOP",
                        Location = new Location
                        {
                            Lat = -23.502555,
                            Lon = -46.716542
                        }
                    }
                },
                BathRooms = 2,
                BedRooms = 3,
                PricingInfos = new PricingInfos
                {
                    YearlyIptu = "0",
                    BusinessType = "SALE",
                    Price = "600000",
                    MonthlyCondoFee = "495",
                    RentalTotalPrice = "0"
                },
            }
            );
            dbContext.SaveChanges();
            return dbContext;
        }        

        public AppDbContext CreateFakeRepositorySaleRulesNotWorking()
        {
            var dbOptBuilder = GetDbOptionsBuilder();
            var dbContext = new AppDbContext(dbOptBuilder.Options);
            dbContext.Imoveis.Add(new Imoveis
            {
                UsableAreas = 3400,
                ListingType = "USED",
                CreatedAt = Convert.ToDateTime("2016-11-16T04:14:02Z"),
                ListingStatus = "ACTIVE",
                Id = "some-id",
                ParkingSpaces = 1,
                UpdatedAt = Convert.ToDateTime("2016-11-16T04:14:02Z"),
                Owner = false,
                Address = new Address
                {
                    City = "",
                    Neighborhood = "",
                    GeoLocation = new GeoLocation
                    {
                        Precision = "ROOFTOP",
                        Location = new Location
                        {
                            Lat = -23.502555,
                            Lon = -46.716542
                        }
                    }
                },
                BathRooms = 2,
                BedRooms = 3,
                PricingInfos = new PricingInfos
                {
                    YearlyIptu = "0",
                    BusinessType = "SALE",
                    Price = "750000",
                    MonthlyCondoFee = "495",
                    RentalTotalPrice = "0"
                },
            }
            );
            dbContext.SaveChanges();
            return dbContext;
        }

        public AppDbContext CreateFakeRepositoryRentalRulesWorking()
        {
            var dbOptBuilder = GetDbOptionsBuilder();
            var dbContext = new AppDbContext(dbOptBuilder.Options);
            dbContext.Imoveis.Add(new Imoveis
            {
                UsableAreas = 3000,
                ListingType = "USED",
                CreatedAt = Convert.ToDateTime("2016-11-16T04:14:02Z"),
                ListingStatus = "ACTIVE",
                Id = "some-id",
                ParkingSpaces = 1,
                UpdatedAt = Convert.ToDateTime("2016-11-16T04:14:02Z"),
                Owner = false,
                Address = new Address
                {
                    City = "",
                    Neighborhood = "",
                    GeoLocation = new GeoLocation
                    {
                        Precision = "ROOFTOP",
                        Location = new Location
                        {
                            Lat = -23.502555,
                            Lon = -46.716542
                        }
                    }
                },
                BathRooms = 2,
                BedRooms = 3,
                PricingInfos = new PricingInfos
                {
                    YearlyIptu = "810",
                    BusinessType = "RENTAL",
                    Price = "0",
                    MonthlyCondoFee = "940",
                    RentalTotalPrice = "3000"
                },
            }
            );
            dbContext.SaveChanges();
            return dbContext;
        }

        public AppDbContext CreateFakeRepositoryRentalRulesNotWorking()
        {
            var dbOptBuilder = GetDbOptionsBuilder();
            var dbContext = new AppDbContext(dbOptBuilder.Options);
            dbContext.Imoveis.Add(new Imoveis
            {
                UsableAreas = 4000,
                ListingType = "USED",
                CreatedAt = Convert.ToDateTime("2016-11-16T04:14:02Z"),
                ListingStatus = "ACTIVE",
                Id = "some-id",
                ParkingSpaces = 1,
                UpdatedAt = Convert.ToDateTime("2016-11-16T04:14:02Z"),
                Owner = false,
                Address = new Address
                {
                    City = "",
                    Neighborhood = "",
                    GeoLocation = new GeoLocation
                    {
                        Precision = "ROOFTOP",
                        Location = new Location
                        {
                            Lat = -23.502555,
                            Lon = -46.716542
                        }
                    }
                },
                BathRooms = 2,
                BedRooms = 3,
                PricingInfos = new PricingInfos
                {
                    YearlyIptu = "810",
                    BusinessType = "RENTAL",
                    Price = "0",
                    MonthlyCondoFee = "940",
                    RentalTotalPrice = "5000"
                },
            }
            );
            dbContext.SaveChanges();
            return dbContext;
        }

        private static DbContextOptionsBuilder<AppDbContext> GetDbOptionsBuilder()
        {
            string dbName = Guid.NewGuid().ToString();
            var serviceProvider = new ServiceCollection()
                .AddEntityFrameworkInMemoryDatabase()
                .BuildServiceProvider();
            var builder = new DbContextOptionsBuilder<AppDbContext>();
            builder.UseInMemoryDatabase(dbName)
                   .UseInternalServiceProvider(serviceProvider);
            return builder;
        }
    }
}