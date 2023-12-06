using CleanArchitecture.Domain.Models;
using CleanArchitecture.Persistence.Entities;
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

        internal DbSet<ImmobilierEntity> immobiliers { get; set; }
        /*internal DbSet<ImmobilierTypeImmobilierEntity> immobilierTypeImmobiliers { get; set; }
        internal DbSet<ImmobilierTypeVenteEntity> immobilierVente { get; set; }
        internal DbSet<TypeImmobilierEntity> typeImmobiliers { get; set; }
        internal DbSet<TypeVenteEntity> typeVentes { get; set; }
        internal DbSet<UtilisateurEntity> Utilisateurs { get; set; }*/

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configure entity mappings, relationships, etc.
        }
    }
}
