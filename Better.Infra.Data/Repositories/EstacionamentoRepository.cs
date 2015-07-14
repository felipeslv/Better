using System.Collections.Generic;
using System.Linq;
using Better.Domain.Entities;
using Better.Domain.Interfaces.Repositories;

namespace Better.Infra.Data.Repositories
{
    public class EstacionamentoRepository : RepositoryBase<Estacionamento>,IEstacionamentoRepository
    {
        public IEnumerable<Estacionamento> BuscarPorPlaca(string placa)
        {
            return Db.Estacionamentos.Where(p => p.Placa == placa);
        }
    }
}
