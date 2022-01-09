using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ViewModels.Models;

namespace ViewModels.DataAccess
{
    public class ApplicationContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
        }

        public DbSet<Person> People { get; set; }
        public DbSet<Country> Countries { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Language> Languages { get; set; }
        public DbSet<PersonLanguage> PersonLanguages { get; set; }
        public override DbSet<ApplicationUser> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<PersonLanguage>()
                .HasKey(personLanguage => new {personLanguage.PersonId, personLanguage.LanguageId});
            modelBuilder.Entity<PersonLanguage>()
                .HasOne(personLanguage => personLanguage.Person)
                .WithMany(person => person.PersonLanguages)
                .HasForeignKey(personLanguage => personLanguage.PersonId);

            modelBuilder.Entity<PersonLanguage>()
                .HasOne(personLanguage => personLanguage.Language)
                .WithMany(language => language.PersonLanguages)
                .HasForeignKey(personLanguage => personLanguage.LanguageId);
            Seeder.Seed(modelBuilder);
        }
    }
}