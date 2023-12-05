using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Domain.Models
{
    public class ImmobilierTypeImmobilier
    {
        public int Id { get; set; }
        public int TypeImmobilierId { get; set; }
        public string ImmobilierId { get; set; } = string.Empty;
    }
}
