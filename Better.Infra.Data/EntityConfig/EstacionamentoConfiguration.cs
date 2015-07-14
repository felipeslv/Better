using System.Data.Entity.ModelConfiguration;
using Better.Domain.Entities;

namespace Better.Infra.Data.EntityConfig
{
    class EstacionamentoConfiguration : EntityTypeConfiguration<Estacionamento>
    {
        public EstacionamentoConfiguration()
        {
            HasKey(e => e.EstacionamentoId);
        }
    }
}
