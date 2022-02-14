using GOT.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;

namespace GOT.Data
{
    public class GotDbContext : DbContext
    {
        public GotDbContext(DbContextOptions<GotDbContext> options) : base(options)
        {
        }

        public DbSet<LancuchGorski> MountRanges { get; set; }
        public DbSet<OdcinekTrasy> Tracks { get; set; }
        public DbSet<Przodownik> Leaders { get; set; }
        public DbSet<Punkt> Points { get; set; }
        public DbSet<SpisTrasPunktowanych> ScoredTracks { get; set; }
        public DbSet<Trasa> Routes { get; set; }
        public DbSet<Turysta> Tourists { get; set; }
        public DbSet<Uprawnienia> Permissions { get; set; }
        public DbSet<Wpis> Entries { get; set; }
        public DbSet<Wycieczka> Trips{ get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Seed();
        }
    }
}