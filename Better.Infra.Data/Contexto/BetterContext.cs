using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using Better.Domain.Entities;
using Better.Infra.Data.EntityConfig;

namespace Better.Infra.Data.Contexto
{
    public class BetterContext : DbContext
    {
        public BetterContext()
            :base("Better")
        {

        }
        public DbSet<Estacionamento> Estacionamentos { get; set; }
        public DbSet<TabelaValor> TabelaValores { get; set; } 


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
            modelBuilder.Conventions.Remove<ManyToManyCascadeDeleteConvention>();

            //forca reconhecimento da pk
            modelBuilder.Properties()
                .Where(p => p.Name == p.ReflectedType.Name + "Id")
                .Configure(p => p.IsKey());

            modelBuilder.Properties<string>().
                Configure(p => p.HasColumnType("varchar"));

            modelBuilder.Properties<string>().
                Configure(p => p.HasMaxLength(100));

            modelBuilder.Configurations.Add(new EstacionamentoConfiguration());
            modelBuilder.Configurations.Add(new TabelaValorConfiguration());

        }

        public override int SaveChanges()
        {
            //para nao perder tempo com data inicial jogando datenow
            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("DataInicial") != null))
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("DataInicial").CurrentValue = DateTime.Now;
                }

                if (entry.State == EntityState.Modified)
                {
                    entry.Property("DataInicial").IsModified = false;
                }
            }
            return base.SaveChanges();
        }
    }
}
