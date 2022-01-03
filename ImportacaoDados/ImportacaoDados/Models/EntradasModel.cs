using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Importador.Models
{
    [Table("Entradas")]
    public class EntradasModel
    {
        [Key]
        [Display(Name = "Código")]
        [Column("CodigoId")]
        public int CodigoId { get; set; }

        [Display(Name = "Data")]
        [Column("DataImportacao")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime DataImportacao { get; set; }

        [Column("CodigoComprador")]
        public int CodigoComprador { get; set; }
        public string NomeComprador { get; set; }

        [Column("CodigoItem")]
        public int CodigoItem { get; set; }
        public string DescricaoItem { get; set; }

        [Column("CodigoFornecedor")]
        public int CodigoFornecedor { get; set; }
        public string NomeFornecedor { get; set; }

        [Column("CodigoEndereco")]
        public int CodigoEndereco { get; set; }
        public string Endereco { get; set; }

        [Display(Name = "Quantidade")]
        [Column("Quantidade")]
        public int Quantidade { get; set; }

        [Display(Name = "Valor")]
        [Column("Valor")]
        public decimal Valor { get; set; }

        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime DataInicio { get; set; }

        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime DataFim { get; set; }
    }
}