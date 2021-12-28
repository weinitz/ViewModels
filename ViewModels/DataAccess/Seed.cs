using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using ViewModels.Models;

namespace ViewModels.DataAccess
{
    public static class Seed
    {
        public static void PopulateDataBase(IApplicationBuilder application)
        {
            using var serviceScope = application.ApplicationServices.CreateScope();
            var context = serviceScope.ServiceProvider.GetService<ApplicationContext>();
            if (context != null)
                SeedData(serviceScope.ServiceProvider.GetService<ApplicationContext>() ??
                         throw new InvalidOperationException());
        }

        private static void SeedData(ApplicationContext context)
        {
            if (context.Countries.Any())
            {
                Console.WriteLine("Data is already seeded");
                return;
            }

            Console.WriteLine("Seeding...");
            var sweden = new Country
            {
                Name = "Sweden", Cities = new List<City>
                {
                    new City {Name = "Halmstad"},
                    new City {Name = "Malmö"},
                    new City {Name = "Helsingborg"}
                }
            };
            context.Countries.AddRange(
                sweden
            );

            context.People.AddRange(
                new Person
                {
                    Name = "Tim", City = sweden.Cities[0], PhoneNumber = "112"
                },
                new Person {Name = "Johan", City = sweden.Cities[1], PhoneNumber = "114-114"},
                new Person {Name = "Leif", City = sweden.Cities[2], PhoneNumber = "118-118"}
            );

            context.SaveChanges();
        }
    }
}
