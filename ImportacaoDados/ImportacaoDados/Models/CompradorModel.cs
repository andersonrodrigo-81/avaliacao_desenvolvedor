using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Importador.Models
{
    [Table("Comprador")]
    public class CompradorModel
    {
        [Key]
        [Display(Name ="Código")]
        [Column("CodigoId")]
        public int CodigoId { get; set; }

        [Display(Name = "Nome")]
        [Column("NomeComprador")]
        public string NomeComprador { get; set; }
    }
}