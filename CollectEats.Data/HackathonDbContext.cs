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
        public DbSet<AtelierVisiteur> AtelierVisiteurs { get; set; }
        public DbSet<Ecole> Ecoles { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Atelier>()
                .HasMany(a => a.Visiteur)
                .WithMany(v => v.Atelier)
                .UsingEntity<AtelierVisiteur>();
        }
    }
}
