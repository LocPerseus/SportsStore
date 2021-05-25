using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using SportsStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SportsStore.DAL
{
    public static class SeedData
    {
        /*
            The EnsurePopulated method obtains an ApplicationDbContext object through the
            IApplicationBuilder interface and uses it to check whether there are any Product objects in the database.
            If there are no objects, then the database is populated using a collection of Product objects using the
            AddRange method and then written to the database using the SaveChanges method. 
         */
        public static void EnsurePopulated(IApplicationBuilder app)
        {
            ApplicationDbContext context = app.ApplicationServices
                .GetRequiredService<ApplicationDbContext>();

            if (!context.Products.Any())
            {
                context.Products.AddRange(
                    new Product
                    {
                        Name = "Kayak",
                        Description = "A boat for one person",
                        Category = "Watersports",
                        Price = 275
                    },
                    new Product
                    {
                        Name = "Lifejacket",
                        Description = "Protective and fashionable",
                        Category = "Watersports",
                        Price = 48.95m
                    },
                    new Product
                    {
                        Name = "Soccer Ball",
                        Description = "FIFA-approved size and weight",
                        Category = "Soccer",
                        Price = 19.50m
                    },
                    new Product
                    {
                        Name = "Corner Flags",
                        Description = "Give your playing field a professional touch",
                        Category = "Soccer",
                        Price = 34.95m
                    },
                    new Product
                    {
                        Name = "Stadium",
                        Description = "Flat-packed 35,000-seat stadium",
                        Category = "Soccer",
                        Price = 79500
                    },
                    new Product
                    {
                        Name = "Thinking Cap",
                        Description = "Improve brain efficiency by 75%",
                        Category = "Chess",
                        Price = 16
                    },
                    new Product
                    {
                        Name = "Unsteady Chair",
                        Description = "Secretly give your opponent a disadvantage",
                        Category = "Chess",
                        Price = 29.95m
                    },
                    new Product
                    {
                        Name = "Human Chess Board",
                        Description = "A fun game for the family",
                        Category = "Chess",
                        Price = 75
                    },
                    new Product
                    {
                        Name = "Bling-Bling King",
                        Description = "Gold-plated, diamond-studded King",
                        Category = "Chess",
                        Price = 1200
                    }
                    );
                context.SaveChanges();
            }
        }
    }
}
