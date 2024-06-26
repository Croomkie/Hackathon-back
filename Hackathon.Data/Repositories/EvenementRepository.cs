﻿using Hackathon.Data.Interfaces;
using Hackathon.Data.Models;
using Hackathon.Shared.Enum;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using static System.Net.Mime.MediaTypeNames;

namespace Hackathon.Data.Repositories
{
    public class EvenementRepository(HackathonDbContext context) : IEvenementRepository
    {
        private readonly HackathonDbContext _context = context;

        public async Task<IEnumerable<Evenement>> GetEvenement()
        {
            return await _context.Evenements
                .Include(e => e.Ecole)
                .Include(e => e.ImageEvenement)
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

        public async Task CreateEvenementVisiteur(string email, int evenementId, int? ecoleId)
        {
            using var transaction = await _context.Database.BeginTransactionAsync();
            try
            {
                int visiteurId;
                //Vérifier si le visiteur existe
                Visiteur? visiteurExist = await _context.Visiteurs.SingleOrDefaultAsync(v => v.Email == email);
                visiteurId = visiteurExist != null ? visiteurExist.VisiteurId : 0;

                if (visiteurExist == null)
                {
                    Visiteur visiteur = new()
                    {
                        Email = email,
                        EcoleId = ecoleId
                    };

                    //Creation du visiteur
                    await _context.Visiteurs.AddAsync(visiteur);
                    await _context.SaveChangesAsync();

                    visiteurId = visiteur.VisiteurId;
                }

                EvenementVisiteur evenementVisiteur = new()
                {
                    EvenementId = evenementId,
                    VisiteurId = visiteurId,
                    Status = Shared.Enum.Status.EnAttente
                };

                //Creation de l'evenementVisiteur
                await _context.EvenementVisiteur.AddAsync(evenementVisiteur);
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

        public async Task UpdateEvenementVisiteur(int evenementId, int visiteurId, Status status)
        {
            EvenementVisiteur? evenementVisiteur = await _context.EvenementVisiteur.SingleOrDefaultAsync(x => x.EvenementId == evenementId && x.VisiteurId == visiteurId);

            if (evenementVisiteur != null)
            {
                evenementVisiteur.Status = status;
                await _context.SaveChangesAsync();
            }
        }

        public async Task UpdateEvenementWithImage(int id, Evenement evenement, IFormFileCollection? images)
        {
            evenement.EvenementId = id;

            // Attacher l'objet updatedAtelier au contexte
            _context.Evenements.Attach(evenement);

            // Marquer l'objet comme modifié
            _context.Entry(evenement).State = EntityState.Modified;

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

                    var imageToInsert = new ImageEvenement()
                    {
                        EvenementId = evenement.EvenementId,
                        ContentType = image.ContentType,
                        Data = base64Data,
                        FileName = image.FileName
                    };

                    _context.ImageEvenements.Add(imageToInsert);
                }
                // Sauvegarder les nouvelles images ajoutées
                await _context.SaveChangesAsync();
            }
        }
    }
}
