using System;
using System.Collections.Generic;
using System.Linq;
using Better.Application.Interface;
using Better.Domain.Entities;
using Better.Domain.Interfaces.Services;

namespace Better.Application
{
    public class TabelaValorAppService : AppServiceBase<TabelaValor> , ITabelaValorAppService
    {
        private readonly ITabelaValorService _tabelaValorService;

        public TabelaValorAppService(ITabelaValorService tabelaValorService)
            :base(tabelaValorService)
        {
            _tabelaValorService = tabelaValorService;
        }

        public TabelaValor BuscarPorData()
        {
            return _tabelaValorService.BuscarPorData(_tabelaValorService.GetAll());
        }
    }
}
