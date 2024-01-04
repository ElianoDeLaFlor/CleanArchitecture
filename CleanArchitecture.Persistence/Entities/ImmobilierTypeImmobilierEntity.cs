using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Persistence.Entities
{
    internal class ImmobilierTypeImmobilierEntity
    {
        public int Id { get; set; }
        public int TypeImmobilierId { get; set; }
        public string ImmobilierId { get; set; } = "";
    }
}
