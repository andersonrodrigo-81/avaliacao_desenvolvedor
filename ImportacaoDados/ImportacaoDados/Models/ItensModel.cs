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
        public int CodigoId { get; set; }
        
        [MaxLength(200)]
        [Display(Name = "Descrição")]
        public string DescricaoItem { get; set; }
    }
}