using System.Collections.Generic;
using Better.Domain.Entities;

namespace Better.Domain.Interfaces.Services
{
    public interface IEstacionamentoService : IServiceBase<Estacionamento>
    {
        IEnumerable<Estacionamento> BuscarPorPlaca(string placa);

        decimal GetTotal(Estacionamento estacionamento);

    }
}
