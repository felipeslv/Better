using System.Data.Entity.ModelConfiguration;
using Better.Domain.Entities;

namespace Better.Infra.Data.EntityConfig 
{
    class TabelaValorConfiguration : EntityTypeConfiguration<TabelaValor>
    {
        public TabelaValorConfiguration()
        {
            HasKey(t => t.TabelaValorId);

            Property(t => t.ValorAdicional)
                .IsRequired();
            Property(t => t.ValorInicial)
               .IsRequired();
            Property(t => t.DataInicial)
                .IsRequired();
            Property(t => t.DataFinal)
                .IsRequired();
        }
    }
}
