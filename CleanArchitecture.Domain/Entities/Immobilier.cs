using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Domain.Entities
{
    public class Immobilier
    {
        public Immobilier()
        {
            Id = "kd";
        }

        public string Id { get; set; }
        public string Reff { get; set; } = "";
        public string Description { get; set; } = "";
        public string Localisation { get; set; } = "";
        public int TypeImmobilier { get; set; }
        public int TypeVente { get; set; }
        public string Image { get; set; } = "";
        public string Photos { get; set; } = "";
        public string Video { get; set; } = "";
        public bool Favorit { get; set; }
        public decimal Prix { get; set; }
        public string Avance { get; set; } = "";
        public string UtilisateurId { get; set; } = "";
        public bool Finaliser { get; set; }
        public DateTime DateDeCreation { get; set; }
        public DateTime DateDeModification { get; set; }
        public bool Publier { get; set; }
        public string FullDescription { get; set; } = "";
    }
}
