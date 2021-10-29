using System;
using CQRS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json.Serialization;

namespace CQRS.Infrastructure.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        { }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Imoveis>()
                .Property(e => e.Images)
                .HasConversion(
                v => string.Join(',', v),
                v => v.Split(',', StringSplitOptions.RemoveEmptyEntries));

            modelBuilder.Entity<Imoveis>()
                .Property(e => e.Address)
                .HasConversion(
                v => JsonConvert.SerializeObject(v,
                new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() }),
                v => JsonConvert.DeserializeObject<Address>(v,
                new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() }));

            modelBuilder.Entity<Imoveis>()
                .Property(e => e.PricingInfos)
                .HasConversion(
                v => JsonConvert.SerializeObject(v,
                new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() }),
                v => JsonConvert.DeserializeObject<PricingInfos>(v,
                new JsonSerializerSettings { ContractResolver = new CamelCasePropertyNamesContractResolver() }));                
        }
        public DbSet<Imoveis> Imoveis { get; set; }

    }
}
