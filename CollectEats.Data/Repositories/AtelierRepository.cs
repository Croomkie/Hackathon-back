using Hackathon.Data.Interfaces;
using Hackathon.Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace Hackathon.Data.Repositories
{
    public class AtelierRepository(HackathonDbContext context) : IAtelierRepository
    {
        private readonly HackathonDbContext _context = context;

        public async Task<IEnumerable<Atelier>> GetAtelier()
        {
            return await _context.Ateliers
                .Include(a => a.Image)
                .ToListAsync();
        }

        public async Task<IEnumerable<Evenement>> GetEvenementAtelier(int atelierId)
        {
            return await _context.Evenements
                .Where(e => e.AtelierId == atelierId)
                .ToListAsync();
        }

        public async Task UpdateImageAtelier(int atelierId, IFormFileCollection images)
        {
            var atelier = await _context.Ateliers.FindAsync(atelierId) ?? throw new Exception("Atelier introuvable");

            foreach (var image in images)
            {
                using var memoryStream = new MemoryStream();
                await image.CopyToAsync(memoryStream);
                var base64Data = Convert.ToBase64String(memoryStream.ToArray());

                var imageToInsert = new Image()
                {
                    AtelierId = atelier.AtelierId,
                    ContentType = image.ContentType,
                    Data = base64Data,
                    FileName = image.FileName
                };

                _context.Images.Add(imageToInsert);
            }

            await _context.SaveChangesAsync();
        }
    }
}
