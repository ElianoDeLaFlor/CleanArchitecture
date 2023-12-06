using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Persistence.Entities
{
    internal class TypeVenteEntity
    {
        public int Id { get; set; }
        public string Label { get; set; } = "";
        public int ItemCount { get; set; }
        public DateTime DateDeCreation { get; set; }
        public DateTime DateDeModification { get; set; }
    }
}
