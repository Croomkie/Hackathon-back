using Hackathon.Data.Interfaces;
using Hackathon.Data.Models;
using Microsoft.EntityFrameworkCore;

namespace Hackathon.Data.Repositories
{
    public class EvenementRepository(HackathonDbContext context) : IEvenementRepository
    {
        private readonly HackathonDbContext _context = context;

        public async Task<IEnumerable<Evenement>> GetEvenement()
        {
            return await _context.Evenements
                .Include(e => e.Ecole)
                .Include(e => e.Visiteur)
                .Include(e => e.Atelier)
                    .ThenInclude(a => a!.Image)
                .ToListAsync();
        }

        public async Task<IEnumerable<EvenementVisiteur>> GetEvenementVisiteur()
        {
            return await _context.EvenementVisiteur
                .Include(e => e.Visiteur)
                    .ThenInclude(v => v!.Ecole)
                .Include(e => e.Evenement)
                    .ThenInclude(e => e.Ecole)
                .Include(e => e.Evenement)
                    .ThenInclude(e => e.Atelier)
                        .ThenInclude(a => a!.Image)
                .ToListAsync();
        }
    }
}
