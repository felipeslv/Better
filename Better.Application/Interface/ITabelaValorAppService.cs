using System;
using System.Collections.Generic;
using Better.Domain.Entities;

namespace Better.Application.Interface
{
    public interface ITabelaValorAppService : IAppServiceBase<TabelaValor>
    {
        TabelaValor BuscarPorData();
    }
}
