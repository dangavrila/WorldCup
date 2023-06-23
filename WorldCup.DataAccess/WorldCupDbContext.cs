using Microsoft.EntityFrameworkCore;
using WorldCup.DataAccess.Entities;

namespace WorldCup.DataAccess
{
    public sealed class WorldCupDbContext: DbContext
    {
        public DbSet<Country> Countries { get; set; }
        public DbSet<Team> Teams { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Draw> Draws { get; set; }
        public DbSet<DrawDetail> DrawDetails { get; set; }

        public WorldCupDbContext(DbContextOptions<WorldCupDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //SeedData(modelBuilder);

            base.OnModelCreating(modelBuilder);
        }

        private void SeedData(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Country>().HasData(
                new Country() { Id = 1, Name = "Germany" },
                new Country() { Id = 2, Name = "Turkey" },
                new Country() { Id = 3, Name = "France" },
                new Country() { Id = 4, Name = "Netherlands" },
                new Country() { Id = 5, Name = "Portugal" },
                new Country() { Id = 6, Name = "Italy" },
                new Country() { Id = 7, Name = "Spain" },
                new Country() { Id = 8, Name = "Belgium" });

            modelBuilder.Entity<Team>().HasData(
                new Team() { Id = 1, Name = "Adesso Berlin", CountryId = 1 },
                new Team() { Id = 2, Name = "Adesso Frankfurt", CountryId = 1 },
                new Team() { Id = 3, Name = "Adesso Munich", CountryId = 1 },
                new Team() { Id = 4, Name = "Adesso Dormund", CountryId = 1 },
                new Team() { Id = 5, Name = "Adesso Istanbul", CountryId = 2 },
                new Team() { Id = 6, Name = "Adesso Ankara", CountryId = 2 },
                new Team() { Id = 7, Name = "Adesso Izmir", CountryId = 2 },
                new Team() { Id = 8, Name = "Adesso Antalya", CountryId = 2 },
                new Team() { Id = 9, Name = "Adesso Paris", CountryId = 3 },
                new Team() { Id = 10, Name = "Adesso Marsilya", CountryId = 3 },
                new Team() { Id = 11, Name = "Adesso Nice", CountryId = 3 },
                new Team() { Id = 12, Name = "Adesso Lyon", CountryId = 3 },
                new Team() { Id = 13, Name = "Adesso Amsterdam", CountryId = 4 },
                new Team() { Id = 14, Name = "Adesso Rotterdam", CountryId = 4 },
                new Team() { Id = 15, Name = "Adesso Lahey", CountryId = 4 },
                new Team() { Id = 16, Name = "Adesso Eindhoven", CountryId = 4 },
                new Team() { Id = 17, Name = "Adesso Lisbon", CountryId = 5 },
                new Team() { Id = 18, Name = "Adesso Porto", CountryId = 5 },
                new Team() { Id = 19, Name = "Adesso Braga", CountryId = 5 },
                new Team() { Id = 20, Name = "Adesso Coimbra", CountryId = 5 },
                new Team() { Id = 21, Name = "Adesso Roma", CountryId = 6 },
                new Team() { Id = 22, Name = "Adesso Milano", CountryId = 6 },
                new Team() { Id = 23, Name = "Adesso Venedik", CountryId = 6 },
                new Team() { Id = 24, Name = "Adesso Napoli", CountryId = 6 },
                new Team() { Id = 25, Name = "Adesso Sevilla", CountryId = 7 },
                new Team() { Id = 26, Name = "Adesso Madrid", CountryId = 7 },
                new Team() { Id = 27, Name = "Adesso Barcelona", CountryId = 7 },
                new Team() { Id = 28, Name = "Adesso Granada", CountryId = 7 },
                new Team() { Id = 29, Name = "Adesso Brussel", CountryId = 8 },
                new Team() { Id = 30, Name = "Adesso Bruges", CountryId = 8 },
                new Team() { Id = 31, Name = "Adesso Gent", CountryId = 8 },
                new Team() { Id = 32, Name = "Adesso Antwerp", CountryId = 8 }
            );

            modelBuilder.Entity<Group>().HasData(
                new { Id = 1, Name = "A" },
                new { Id = 2, Name = "B" },
                new { Id = 3, Name = "C" },
                new { Id = 4, Name = "D" },
                new { Id = 5, Name = "E" },
                new { Id = 6, Name = "F" },
                new { Id = 7, Name = "G" },
                new { Id = 8, Name = "H" });
        }
    }
}