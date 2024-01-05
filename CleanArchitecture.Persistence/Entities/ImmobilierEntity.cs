using CleanArchitecture.Domain.Utility;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

[assembly: InternalsVisibleTo("CleanArchitecture.Test")]
[assembly: InternalsVisibleTo("DynamicProxyGenAssembly2")]
namespace CleanArchitecture.Persistence.Entities
{
    internal class ImmobilierEntity
    {

        [StringLength(29)]
        public string Id { get; set; }=string.Empty;
        [StringLength(16)]
        public string Reff { get; set; }= string.Empty;
        [StringLength(255)]
        public string Description { get; set; } = string.Empty;
        [StringLength(150)]
        public string Localisation { get; set; } = string.Empty;
        public int TypeImmobilier { get; set; }
        public int TypeVente { get; set; }
        [StringLength(120)]
        public string Image { get; set; } = string.Empty;
        [StringLength(300)]
        public string Photos { get; set; } = string.Empty;
        [StringLength(90)]
        public string Video { get; set; } = string.Empty;
        public bool Favorit { get; set; }
        [DataType(DataType.Currency)]
        public decimal Prix { get; set; }
        [StringLength(50)]
        public string Avance { get; set; } = string.Empty;
        [StringLength(29)]
        public string UtilisateurId { get; set; } = string.Empty;
        public bool Finaliser { get; set; }
        public DateTime DateDeCreation { get; set; }
        public DateTime DateDeModification { get; set; }
        public bool Publier { get; set; }
        [StringLength(400)]
        public string FullDescription { get; set; } = string.Empty;
    }
}
