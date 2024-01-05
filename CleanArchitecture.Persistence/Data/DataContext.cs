using CleanArchitecture.Domain.Models;
using CleanArchitecture.Persistence.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CleanArchitecture.Persistence.Data
{
    public class DataContext:IdentityUserContext<IdentityUser>
    {
        public DataContext()
        {
            
        }
        public DataContext(DbContextOptions<DataContext> option) : base(option) { }

        internal DbSet<ImmobilierEntity> Immobiliers { get; set; }
        /*internal DbSet<ImmobilierTypeImmobilierEntity> immobilierTypeImmobiliers { get; set; }
        internal DbSet<ImmobilierTypeVenteEntity> immobilierVente { get; set; }
        internal DbSet<TypeImmobilierEntity> typeImmobiliers { get; set; }
        internal DbSet<TypeVenteEntity> typeVentes { get; set; }
        internal DbSet<UtilisateurEntity> Utilisateurs { get; set; }*/

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<ImmobilierEntity>().Property(p => p.Prix).HasPrecision(18, 4);
            
        }
    }
}
