using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Application.Mappers
{
    public class ImmobilierDto
    {
        public string Description { get; set; } = string.Empty;
        public string Localisation { get; set; } = string.Empty;
        public int TypeImmobilier { get; set; }
        public int TypeVente { get; set; }
        public string Image { get; set; } = string.Empty;
        public string Photos { get; set; } = string.Empty;
        public string Video { get; set; } = string.Empty;
        public decimal Prix { get; set; }
        public string Avance { get; set; } = string.Empty;
        public string UtilisateurId { get; set; } = string.Empty;
        public bool Publier { get; set; }
        public string FullDescription { get; set; } = string.Empty;
    }
}
