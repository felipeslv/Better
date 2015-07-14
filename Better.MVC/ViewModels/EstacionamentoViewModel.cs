

using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Better.MVC.ViewModels
{
    public class EstacionamentoViewModel
    {
        [Key]
        public int EstacionamentoId { get; set; }
        public string Placa { get; set; }

        [ScaffoldColumn(false)]
        public DateTime? DataEntrada { get; set; }

        [ScaffoldColumn(false)]
        public DateTime? DataSaida { get; set; }

        public decimal TotalPagar { get; set; }

        public virtual TabelaValorViewModel TabelaValor { get; set; }


    }
}