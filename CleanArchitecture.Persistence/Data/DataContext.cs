using CleanArchitecture.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Persistence.Data
{
    public class DataContext:DbContext
    {
        public DataContext(DbContextOptions<DataContext> option) : base(option) { }

        public DbSet<Immobilier> immobiliers { get; set; }
        public DbSet<ImmobilierTypeImmobilier> immobilierTypeImmobiliers { get; set; }
        public DbSet<ImmobilierTypeVente> immobilierVente { get; set; }
        public DbSet<TypeImmobilier> typeImmobiliers { get; set; }
        public DbSet<TypeVente> typeVentes { get; set; }
        public DbSet<Utilisateur> Utilisateurs { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure entity mappings, relationships, etc.
        }
    }
}
