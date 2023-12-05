using CleanArchitecture.Domain.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Persistence.Entities
{
    public class ImmobilierEntity
    {

        public string Id { get; set; } = string.Empty;
        public string Reff { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Localisation { get; set; } = string.Empty;
        public int TypeImmobilier { get; set; }
        public int TypeVente { get; set; }
        public string Image { get; set; } = string.Empty;
        public string Photos { get; set; } = string.Empty;
        public string Video { get; set; } = string.Empty;
        public bool Favorit { get; set; }
        public decimal Prix { get; set; }
        public string Avance { get; set; } = string.Empty;
        public string UtilisateurId { get; set; } = string.Empty;
        public bool Finaliser { get; set; }
        public DateTime DateDeCreation { get; set; }
        public DateTime DateDeModification { get; set; }
        public bool Publier { get; set; }
        public string FullDescription { get; set; } = string.Empty;
    }
}
