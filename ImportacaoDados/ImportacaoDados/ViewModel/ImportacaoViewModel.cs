using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ImportacaoDados.ViewModel
{
    public class ImportacaoViewModel
    {
        public int CodigoId { get; set; }
        public DateTime DataImportacao { get; set; }
        public int CodigoComprador { get; set; }
        public string NomeComprador { get; set; }
        public int CodigoItem { get; set; }
        public string NomeItem { get; set; }
        public int CodigoFornecedor { get; set; }
        public string NomeFornecedor { get; set; }
        public int CodigoEndereco { get; set; }
        public string NomeEndereco { get; set; }
        public int Quantidade { get; set; }
        public decimal Valor { get; set; }

    }
}