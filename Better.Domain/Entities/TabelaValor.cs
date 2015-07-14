using System;

namespace Better.Domain.Entities
{
    public class TabelaValor
    {
        public int TabelaValorId { get; set; }
        public DateTime DataInicial { get; set; }

        public DateTime DataFinal { get; set; }

        public decimal ValorInicial { get; set; }

        public decimal ValorAdicional { get; set; }
    }
}
