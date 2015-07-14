using System;
using System.ComponentModel.DataAnnotations;

namespace Better.MVC.ViewModels
{
    public class TabelaValorViewModel
    {
        [Key]
        public int TabelaValorId { get; set; }
        [Required(ErrorMessage = "Prencha um valor")]
        public DateTime DataInicial { get; set; }
        [Required(ErrorMessage = "Prencha um valor")]
        public DateTime DataFinal { get; set; }
        [DataType(DataType.Currency)]
        [Required(ErrorMessage = "Prencha um valor")]
        public decimal ValorInicial { get; set; }
        [DataType(DataType.Currency)]
        [Required(ErrorMessage = "Prencha um valor")]
        public decimal ValorAdicional { get; set; }
    }
}