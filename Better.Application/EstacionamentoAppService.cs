
using System.Collections.Generic;
using Better.Application.Interface;
using Better.Domain.Entities;
using Better.Domain.Interfaces.Services;

namespace Better.Application
{
    public class EstacionamentoAppService : AppServiceBase<Estacionamento>,IEstacionamentoAppService
    {
        private readonly IEstacionamentoService _estacionamentoService;

        public EstacionamentoAppService(IEstacionamentoService estacionamentoService)
            :base(estacionamentoService)
        {
            _estacionamentoService = estacionamentoService;
        }

        public IEnumerable<Estacionamento> BuscarPorPlaca(string placa)
        {
            return _estacionamentoService.BuscarPorPlaca(placa);
        }

        public decimal GetTotal(Estacionamento estacionamento)
        {
            return estacionamento.GetTotal();
        }
    }
}
