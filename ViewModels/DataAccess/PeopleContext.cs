using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using ViewModels.Models;

namespace ViewModels.DataAccess
{
    public class PeopleContext : DbContext
    {
        public PeopleContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Person> People { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Person>().HasData(new List<Person>
            {
                new Person
                    {Id = 1, Name = "Tim", City = "Halmstad", PhoneNumber = "112"},
                new Person
                    {Id = 2, Name = "Johan", City = "Malmö", PhoneNumber = "114-114"},
                new Person
                    {Id = 3, Name = "Leif", City = "Helsingborg", PhoneNumber = "118-118"},
            });
        }
    }
}