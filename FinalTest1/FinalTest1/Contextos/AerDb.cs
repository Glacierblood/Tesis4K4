using FinalTest1.Models.Entidades;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace FinalTest1.Contextos
{
    public class AerDb : DbContext
    {
         public AerDb()
            : base("DefaultConnection")
        {/*
            Database.SetInitializer<AerDb>(null); // Remove default initializer
            Configuration.LazyLoadingEnabled = false;
            Configuration.ProxyCreationEnabled = false;*/
        }

         public DbSet<Especie> Especies { get; set; }
         public DbSet<Raza> Razas { get; set; }
         public DbSet<Animal> Animales { get; set; }
         public DbSet<Tamanio> Tamanios { get; set; }
         public DbSet<Accion> Acciones { get; set; }
         public DbSet<RegistroAccion> RegistroAcciones { get; set; }

         public System.Data.Entity.DbSet<FinalTest1.Models.Entidades.TipoAdopcion> TipoAdopcions { get; set; }

         public System.Data.Entity.DbSet<FinalTest1.Models.Entidades.EstadoAdopcion> EstadoAdopcions { get; set; }

         public System.Data.Entity.DbSet<FinalTest1.Models.Entidades.Adopcion> Adopcions { get; set; }
        /*
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
         {
             base.OnModelCreating(modelBuilder);

             //modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();

             // IMPORTANT: we are mapping the entity User to the same table as the entity ApplicationUser
             modelBuilder.Entity<IdentityUserLogin>().ToTable("AspNetUser");
             modelBuilder.Entity<IdentityUserRole>().ToTable("AspNeRole");
             
         }
         * */

    }
}