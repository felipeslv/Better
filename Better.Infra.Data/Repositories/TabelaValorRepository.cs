using System;
using System.Collections.Generic;
using System.Linq;
using Better.Domain.Entities;
using Better.Domain.Interfaces.Repositories;

namespace Better.Infra.Data.Repositories
{
    public class TabelaValorRepository : RepositoryBase<TabelaValor>, ITabelaValorRepository
    {
        public IEnumerable<TabelaValor> BuscarPorData(DateTime data)
        {
            return Db.TabelaValores.Where(d => data >= d.DataInicial && data <= d.DataFinal);
        }
    }
}
