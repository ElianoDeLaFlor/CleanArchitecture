using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Persistence.Entities
{
    public class ImmobilierTypeVenteEntity
    {
        public int Id { get; set; }
        public int TypeVenteId { get; set; }
        public string ImmobilierId { get; set; } = "";
    }
}
