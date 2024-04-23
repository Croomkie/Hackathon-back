using Hackathon.Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Hackathon.Data.Repositories
{
    public class VisiteurRepository : IVisiteurRepository
    {
        private readonly HackathonDbContext _context;

        public VisiteurRepository(HackathonDbContext context) { _context = context; }

        public async Task<IList<string>> ListeEmailVisiteurEvenement(int evenementId)
        {
            var emails = await _context.EvenementVisiteur
                   .Where(ev => ev.EvenementId == evenementId)
                   .Include(ev => ev.Visiteur)
                   .Select(ev => ev.Visiteur.Email)
                   .ToListAsync();

            return emails;
        }
    }
}
