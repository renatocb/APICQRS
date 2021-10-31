using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using CQRS.Domain.Entities;
using CQRS.Infrastructure.Context;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;

namespace Context
{
    public class PreDb
    {
        public static void PrePopulation(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.CreateScope())
            {
                SeedData(serviceScope.ServiceProvider.GetService<AppDbContext>());
            }
        }
        private static void SeedData(AppDbContext context)
        {
            if (!context.Imoveis.Any())
            {
                Console.WriteLine("Seeding data...");
                string json = new WebClient().DownloadString("http://grupozap-code-challenge.s3-website-us-east-1.amazonaws.com/sources/source-2.json");
                List<Imoveis> imoveis = JsonConvert.DeserializeObject<List<Imoveis>>(json);
                context.Imoveis.AddRange(imoveis);
                context.SaveChanges();
            }
            else
            {
                Console.WriteLine("We already have data");
            }
        }




    }
}