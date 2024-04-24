using Hackathon.Data.Interfaces;
using Hackathon.Data.Models;
using Microsoft.AspNetCore.Http;
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
                    .ThenInclude(e => e.ImageEvenement)
                .Include(e => e.Evenement)
                    .ThenInclude(e => e.Atelier)
                        .ThenInclude(a => a!.Image)
                .ToListAsync();
        }
        public async Task CreateEvenementWithImage(Evenement evenement, IFormFileCollection? images)
        {
            using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                await _context.Evenements.AddAsync(evenement);
                await _context.SaveChangesAsync();

                int evenementId = evenement.EvenementId;

                if (images != null)
                {
                    // Ajouter les détails de la commande
                    foreach (var image in images)
                    {
                        using var memoryStream = new MemoryStream();
                        await image.CopyToAsync(memoryStream);
                        var base64Data = Convert.ToBase64String(memoryStream.ToArray());

                        var imageToInsert = new ImageEvenement()
                        {
                            EvenementId = evenementId,
                            ContentType = image.ContentType,
                            Data = base64Data,
                            FileName = image.FileName
                        };

                        _context.ImageEvenements.Add(imageToInsert);
                    }
                }

                await _context.SaveChangesAsync();

                // Si tout se passe bien, validez la transaction
                await transaction.CommitAsync();
            }
            catch
            {
                // En cas d'erreur, on annule la transaction
                await transaction.RollbackAsync();
                throw;
            }
        }
    }
}
