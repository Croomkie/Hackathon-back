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
                .Include(e => e.Atelier)
                    .ThenInclude(a => a.Image)
                .ToListAsync();
        }
    }
}
