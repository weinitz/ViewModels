using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ViewModels.Models;

namespace ViewModels.DataAccess
{
    public static class Seeder
    {
        public static void Seed(ModelBuilder builder)
        {
            builder.Entity<IdentityRole>().HasData(new IdentityRole{ Name = "User" , NormalizedName = "USER"});
            builder.Entity<IdentityRole>().HasData(new IdentityRole{ Name = "Admin", NormalizedName = "ADMIN"});
            builder.Entity<Language>().HasData(new List<Language>
            {
                new Language {Id = 1, Name = "Swedish"},
                new Language {Id = 2, Name = "English"}
            });


            builder.Entity<Country>().HasData(new Country
            {
                Id = 1, Name = "Sweden"
            });


            builder.Entity<City>().HasData(new List<City>
            {
                new City {Id = 1, Name = "Halmstad", CountryId = 1},
                new City {Id = 2, Name = "Malmö", CountryId = 1},
                new City {Id = 3, Name = "Helsingborg", CountryId = 1}
            });

            builder.Entity<Person>().HasData(new List<Person>
            {
                new Person
                {
                    Id = 1, Name = "Tim", CityId = 1, PhoneNumber = "112"
                },
                new Person
                {
                    Id = 2, Name = "Johan", CityId = 2, PhoneNumber = "114-114"
                },
                new Person
                {
                    Id = 3, Name = "Leif", CityId = 3, PhoneNumber = "118-118"
                }
            });

            builder.Entity<PersonLanguage>().HasData(
                new List<PersonLanguage>
                {
                    new PersonLanguage {LanguageId = 1, PersonId = 1},
                    new PersonLanguage {LanguageId = 1, PersonId = 2},
                    new PersonLanguage {LanguageId = 1, PersonId = 3}
                });
        }
    }
}