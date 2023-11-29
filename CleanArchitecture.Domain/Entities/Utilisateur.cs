using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Domain.Entities
{
    public class Utilisateur
    {
        public Utilisateur()
        {
            Id = "sa";
        }
        public string Id { get; set; }
        public string Nom { get; set; } = "";
        public DateTime DateDeCreation { get; set; }
        public DateTime DateDeModification { get; set; }
        public string Pseudo { get; set; } = "";
        public string MotDePasse { get; set; } = "";
    }
}
