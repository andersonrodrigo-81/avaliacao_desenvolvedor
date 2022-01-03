using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Importador.Models
{
    [Table("Item")]
    public class ItensModel
    {
        [Key]
        [Display(Name = "Código")]
        [Column("CodigoId")]
        public int CodigoId { get; set; }
        
        [MaxLength(200)]
        [Display(Name = "Descrição")]
        [Column("DescricaoItem")]
        public string DescricaoItem { get; set; }
    }
}