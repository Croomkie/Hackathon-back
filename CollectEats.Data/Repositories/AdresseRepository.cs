//using CollectEats.Data.Interfaces;
//using Microsoft.EntityFrameworkCore;

//namespace CollectEats.Data.Repositories
//{
//    public class AdresseRepository : IAdresseRepository
//    {
//        private readonly CollectEatsDbContext _context;

//        public AdresseRepository(CollectEatsDbContext context) { _context = context; }

//        public async Task<bool> IsAddressExistAsync(Guid adresseId)
//        {
//             return await _context.Adresses.AnyAsync(a => a.AdresseId == adresseId);
//        }
//    }
//}
