using System;

namespace Better.Domain.Entities
{
    public class Estacionamento
    {
        public int EstacionamentoId { get; set; }
        public string Placa { get; set; }
        public int TabelaValorId { get; set; }
        public DateTime DataEntrada { get; set; }
        public DateTime? DataSaida { get; set; }

        public virtual TabelaValor TabelaValor { get; set; }

        public decimal GetTotal()
        {
            DateTime dataFinal = (DataSaida == null) ? DateTime.Now : (DateTime) DataSaida;
            TimeSpan totalHoras = (TimeSpan) (dataFinal - DataEntrada);

            if (totalHoras.Hours >= 1)
            {
                if (totalHoras.Hours == 1)
                {
                    if (dataFinal.Minute > 10)
                    {
                        return TabelaValor.ValorInicial + TabelaValor.ValorAdicional;
                    }
                    return TabelaValor.ValorInicial;
                }
                else
                {
                    if (dataFinal.Minute > 10)
                    {
                        return TabelaValor.ValorInicial + (TabelaValor.ValorAdicional * (totalHoras.Hours - 1)) + TabelaValor.ValorAdicional;
                    }
                    return TabelaValor.ValorInicial + (TabelaValor.ValorAdicional*(totalHoras.Hours - 1));
                }
            }
            else
            {
                if (dataFinal.Minute <=30)
                {
                    return TabelaValor.ValorInicial/2;
                }
                return TabelaValor.ValorInicial;

            }

        }
        
    }
}
