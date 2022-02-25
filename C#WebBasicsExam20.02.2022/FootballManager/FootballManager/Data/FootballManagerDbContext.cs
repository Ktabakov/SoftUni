namespace FootballManager.Data
{
    using FootballManager.Data.Models;
    using Microsoft.EntityFrameworkCore;
    public class FootballManagerDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=.;Database=FootballManager;User Id = sa; Password=SoftUn!2021;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<UserPlayer>()
                .HasKey(t => new { t.PlayerId, t.UserId });
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Player> Players { get; set; }

        public DbSet<UserPlayer> UserPlayers { get; set; }
    }
}
