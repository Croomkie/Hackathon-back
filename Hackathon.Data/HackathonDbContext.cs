using Hackathon.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Hackathon.Data
{
    public class HackathonDbContext : IdentityDbContext<Utilisateur, IdentityRole, string>
    {
        public HackathonDbContext(DbContextOptions<HackathonDbContext> options)
    : base(options)
        {
        }

        public DbSet<Utilisateur> Utilisateurs { get; set; }
        public DbSet<Atelier> Ateliers { get; set; }
        public DbSet<Vin> Vins { get; set; }
        public DbSet<Visiteur> Visiteurs { get; set; }
        public DbSet<EvenementVisiteur> EvenementVisiteur { get; set; }
        public DbSet<Ecole> Ecoles { get; set; }
        public DbSet<Evenement> Evenements { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<ImageEvenement> ImageEvenements { get; set; }
        public DbSet<HomeDescription> HomeDescriptions { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Evenement>()
                .HasMany(e => e.Visiteur)
                .WithMany(v => v.Evenement)
                .UsingEntity<EvenementVisiteur>();
        }
    }
}
