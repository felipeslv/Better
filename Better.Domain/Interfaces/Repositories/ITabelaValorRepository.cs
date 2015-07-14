using System;
using System.Collections.Generic;
using Better.Domain.Entities;

namespace Better.Domain.Interfaces.Repositories
{
    public interface ITabelaValorRepository : IRepositoryBase<TabelaValor>
    {
        IEnumerable<TabelaValor> BuscarPorData(DateTime data);
    }
}
