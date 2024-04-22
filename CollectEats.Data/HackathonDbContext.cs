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

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
