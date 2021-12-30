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
        public DateTime DataImportacao { get; set; }

        [Column("CodigoComprador")]
        public int CodigoComprador { get; set; }

        [Column("CodigoItem")]
        public int CodigoItem { get; set; }

        [Column("CodigoFornecedor")]
        public int CodigoFornecedor { get; set; }

        [Column("CodigoEndereco")]
        public int CodigoEndereco { get; set; }

        [Display(Name = "Quantidade")]
        [Column("Quantidade")]
        public int Quantidade { get; set; }

        [Display(Name = "Valor")]
        [Column("Valor")]
        public decimal Valor { get; set; }
    }
}