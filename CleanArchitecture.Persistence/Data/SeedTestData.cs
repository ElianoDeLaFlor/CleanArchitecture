using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Persistence.Data
{
    public static class SeedTestData
    {
        public static DataContext InitializeTestDatabase(this DataContext context)
        {

            if (!context.Immobiliers.Any())
            {
                context.Immobiliers.Add(
                    new Entities.ImmobilierEntity
                    {
                        Id = "12345678-90ab-cdef-1234-567890abcdef",
                        Reff = "IMMO-001",
                        Description = "Modern apartment with city views and balcony.",
                        Localisation = "Port Louis, Mauritius",
                        TypeImmobilier = 2, // Apartment
                        TypeVente = 1, // For Sale
                        Image = "https://example.com/images/apartment.jpg",
                        Photos = "[https://example.com/images/photo1.jpg, https://example.com/images/photo2.jpg]",
                        Video = "",
                        Favorit = false,
                        Prix = 500000,
                        Avance = "1 mois",
                        UtilisateurId = "user-456",
                        Finaliser = false,
                        DateDeCreation = new DateTime(2023, 12, 14),
                        DateDeModification = new DateTime(2023, 12, 14),
                        Publier = true,
                        FullDescription = "Spacious living room, 2 bedrooms, 1 bathroom, fully equipped kitchen..."
                    }
                    );
                context.Immobiliers.Add(

                new Entities.ImmobilierEntity
                {
                    Id = "98765432-10fe-dcba-0987-6543210fedcba",
                    Reff = "IMMO-002",
                    Description = "Cozy bungalow with garden and private pool.",
                    Localisation = "Flic en Flac, Mauritius",
                    TypeImmobilier = 3, // Bungalow
                    TypeVente = 2, // For Rent
                    Image = "https://example.com/images/bungalow.jpg",
                    Photos = "[https://example.com/images/photo3.jpg, https://example.com/images/photo4.jpg]",
                    Video = "",
                    Favorit = false,
                    Prix = 2000,
                    Avance = "1 month",
                    UtilisateurId = "user-789",
                    Finaliser = false,
                    DateDeCreation = new DateTime(2023, 12, 13),
                    DateDeModification = new DateTime(2023, 12, 13),
                    Publier = true,
                    FullDescription = "Open-plan living area, 1 bedroom, 1 bathroom, private garden with pool..."
                }
                );

                context.SaveChanges();
            }

            return context;
        }
    }
}
