using System;
using System.Collections.Generic;
using System.Linq;
using Better.Domain.Entities;
using Better.Domain.Interfaces.Repositories;
using Better.Domain.Interfaces.Services;

namespace Better.Domain.Services
{
    public class TabelaValorService : ServiceBase<TabelaValor> , ITabelaValorService
    {
        private readonly ITabelaValorRepository tabelaValorRepository;

        public TabelaValorService(ITabelaValorRepository tabelaValorRepository)
            :base(tabelaValorRepository)
        {
            this.tabelaValorRepository = tabelaValorRepository;
        }

        public TabelaValor BuscarPorData(IEnumerable<TabelaValor> tabelas)
        {
            return tabelas.Last(d => DateTime.Now >= d.DataInicial && DateTime.Now <= d.DataFinal);
        }
    }
}
