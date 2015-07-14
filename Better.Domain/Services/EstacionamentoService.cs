using System.Collections.Generic;
using Better.Domain.Entities;
using Better.Domain.Interfaces.Repositories;
using Better.Domain.Interfaces.Services;

namespace Better.Domain.Services
{
    public class EstacionamentoService : ServiceBase<Estacionamento>,IEstacionamentoService
    {
        private readonly IEstacionamentoRepository _estacionamentoRepository;

        public EstacionamentoService(IEstacionamentoRepository estacionamentoRepository)
            : base(estacionamentoRepository)
        {
            _estacionamentoRepository = estacionamentoRepository;
        }
        //implementar
        public IEnumerable<Estacionamento> BuscarPorPlaca(string placa)
        {
            return _estacionamentoRepository.BuscarPorPlaca(placa);
        }

        public decimal GetTotal(Estacionamento estacionamento)
        {
            return estacionamento.GetTotal();
        }
    }
}
