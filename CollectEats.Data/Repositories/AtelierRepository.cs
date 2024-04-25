using Hackathon.Data.Interfaces;
using Hackathon.Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using System;

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
                .Include(e => e.ImageEvenement)
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

        public async Task UpdateImageEvenement(int evenementId, IFormFileCollection images)
        {
            var evenement = await _context.Evenements.FindAsync(evenementId) ?? throw new Exception("Evenement introuvable");

            foreach (var image in images)
            {
                using var memoryStream = new MemoryStream();
                await image.CopyToAsync(memoryStream);
                var base64Data = Convert.ToBase64String(memoryStream.ToArray());

                var imageToInsert = new ImageEvenement()
                {
                    EvenementId = evenement.EvenementId,
                    ContentType = image.ContentType,
                    Data = base64Data,
                    FileName = image.FileName
                };

                _context.ImageEvenements.Add(imageToInsert);
            }

            await _context.SaveChangesAsync();
        }


        public async Task CreateAtelierWithImage(Atelier atelier, IFormFileCollection? images)
        {
            using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                // Effectuer les opérations de base de données ici
                // Ajouter la commande au contexte
                await _context.Ateliers.AddAsync(atelier);
                await _context.SaveChangesAsync();

                int atelierId = atelier.AtelierId;

                if (images != null)
                {
                    // Ajouter les détails de la commande
                    foreach (var image in images)
                    {
                        using var memoryStream = new MemoryStream();
                        await image.CopyToAsync(memoryStream);
                        var base64Data = Convert.ToBase64String(memoryStream.ToArray());

                        var imageToInsert = new Image()
                        {
                            AtelierId = atelierId,
                            ContentType = image.ContentType,
                            Data = base64Data,
                            FileName = image.FileName
                        };

                        _context.Images.Add(imageToInsert);
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

        public async Task UpdateAtelierWithImage(int id, Atelier updatedAtelier, IFormFileCollection? images)
        {
            updatedAtelier.AtelierId = id;

            // Attacher l'objet updatedAtelier au contexte
            _context.Ateliers.Attach(updatedAtelier);

            // Marquer l'objet comme modifié
            _context.Entry(updatedAtelier).State = EntityState.Modified;

            // Sauvegarder les modifications de l'atelier
            await _context.SaveChangesAsync();

            // Traitement des images
            if (images != null)
            {
                foreach (var image in images)
                {
                    using var memoryStream = new MemoryStream();
                    await image.CopyToAsync(memoryStream);
                    var base64Data = Convert.ToBase64String(memoryStream.ToArray());

                    var imageToInsert = new Image()
                    {
                        AtelierId = updatedAtelier.AtelierId,
                        ContentType = image.ContentType,
                        Data = base64Data,
                        FileName = image.FileName
                    };

                    _context.Images.Add(imageToInsert);
                }
                // Sauvegarder les nouvelles images ajoutées
                await _context.SaveChangesAsync();
            }
        }

    }
}
