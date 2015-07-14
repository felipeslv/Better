using System.Collections.Generic;
using Better.Domain.Entities;

namespace Better.Domain.Interfaces.Repositories
{
    public interface IEstacionamentoRepository : IRepositoryBase<Estacionamento>
    {
        IEnumerable<Estacionamento> BuscarPorPlaca(string placa);
    }
}
