using ImportacaoDados.ViewModel;
using Importador.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ImportacaoDados.Mapper
{
    public static class EntradasByImportacaoVMMapper
    {
        public static EntradasModel MapperEntradasByImportacaoVM(this ImportacaoViewModel vm)
        {
            return new EntradasModel()
            {
                DataImportacao = DateTime.Now,
                CodigoComprador = vm.CodigoComprador,
                CodigoItem = vm.CodigoItem,
                CodigoFornecedor = vm.CodigoItem,
                CodigoEndereco = vm.CodigoEndereco,
                Quantidade = vm.Quantidade,
                Valor = vm.Valor

            };
        }
    }
}