using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Persistence.Entities
{
    internal class UtilisateurEntity
    {
        public string Id { get; set; } = string.Empty;
        public string Nom { get; set; } = string.Empty;
        public DateTime DateDeCreation { get; set; }
        public DateTime DateDeModification { get; set; }
        public string Pseudo { get; set; } = string.Empty;
        public string MotDePasse { get; set; } = string.Empty;
    }
}
