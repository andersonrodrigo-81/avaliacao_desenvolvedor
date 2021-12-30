using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Importador.Models
{
    [Table("Endereco")]
    public class EnderecosModel
    {
        [Key]
        [Display(Name = "Código")]
        [Column("CodigoId")]
        public int CodigoId { get; set; }

        [Display(Name = "Endereço")]
        [Column("Endereco")]
        public string Endereco { get; set; }
    }
}