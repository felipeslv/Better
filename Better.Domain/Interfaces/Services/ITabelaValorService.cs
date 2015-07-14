using System;
using System.Collections.Generic;
using Better.Domain.Entities;

namespace Better.Domain.Interfaces.Services
{
    public interface ITabelaValorService : IServiceBase<TabelaValor>
    {
        TabelaValor BuscarPorData(IEnumerable<TabelaValor> tabelas);
    }
}
