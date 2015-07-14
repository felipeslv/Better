
using System.Collections.Generic;
using Better.Domain.Entities;

namespace Better.Application.Interface
{
    public interface IEstacionamentoAppService : IAppServiceBase<Estacionamento>
    {
        IEnumerable<Estacionamento> BuscarPorPlaca(string placa);

        decimal GetTotal(Estacionamento estacionamento);
    }
}
