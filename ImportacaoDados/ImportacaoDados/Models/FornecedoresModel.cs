using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Importador.Models
{
    [Table("Fornecedor")]
    public class FornecedoresModel
    {
        [Key]
        [Display(Name = "Código")]
        [Column("CodigoId")]
        public int CodigoId { get; set; }

        [Display(Name = "Nome")]
        [Column("NomeFornecedor")]
        public string NomeFornecedor { get; set; }
    }
}