using ImportacaoDados.DAOs;
using ImportacaoDados.Mapper;
using ImportacaoDados.ViewModel;
using Importador.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ImportacaoDados.Services
{
    public class EntradasService : IDisposable
    {
        private EntradasRepository _repo;
        private EntradasRepository repo
        {
            get
            {
                if (_repo == null)
                {
                    _repo = new EntradasRepository();
                }
                return _repo;
            }
        }

        public EntradasModel ObterPorKey(EntradasModel pEntidade)
        {
            var result = repo.ObterPorKey(pEntidade);

            return result;
        }
        public IList<EntradasModel> ObterDados(EntradasModel pEntidade)
        {
            var result = repo.ObterDados(pEntidade);

            return result;
        }

        public bool GravarDados(List<ImportacaoViewModel> listaImportada)
        {
            
            foreach (ImportacaoViewModel item in listaImportada)
            {
                //PreencherDados
                PreencherComprador(item);
                PreencherEndereco(item);
                PreencherFornecedor(item);
                PreencherItem(item);

                var gravar = repo.InsertOrUpdate(item.MapperEntradasByImportacaoVM());
            }

            return true;

        }

        private void PreencherComprador(ImportacaoViewModel item)
        {
            using (CompradorService svc = new CompradorService())
            {
                var result = svc.ObterPorKey(0, item.NomeComprador);

                if (result != null && result.CodigoId > 0)
                {
                    item.CodigoComprador = result.CodigoId;
                }
                else
                {
                    item.CodigoComprador = svc.InsertOrUpdate(new CompradorModel() { NomeComprador = item.NomeComprador });
                }
            }
        }

        private void PreencherEndereco(ImportacaoViewModel item)
        {
            using (EnderecosService svc = new EnderecosService())
            {
                var result = svc.ObterPorKey(0, item.NomeEndereco);

                if (result != null && result.CodigoId > 0)
                {
                    item.CodigoEndereco = result.CodigoId;
                }
                else
                {
                    item.CodigoEndereco = svc.InsertOrUpdate(new EnderecosModel() { Endereco = item.NomeEndereco });
                }
            }
        }

        private void PreencherFornecedor(ImportacaoViewModel item)
        {
            using (FornecedoresService svc = new FornecedoresService())
            {
                var result = svc.ObterPorKey(0, item.NomeFornecedor);

                if (result != null && result.CodigoId > 0)
                {
                    item.CodigoFornecedor = result.CodigoId;
                }
                else
                {
                    item.CodigoFornecedor = svc.InsertOrUpdate(new FornecedoresModel() { NomeFornecedor = item.NomeFornecedor });
                }
            }
        }

        private void PreencherItem(ImportacaoViewModel item)
        {
            using (ItensService svc = new ItensService())
            {
                var result = svc.ObterPorKey(0, item.NomeItem);

                if (result != null && result.CodigoId > 0)
                {
                    item.CodigoItem = result.CodigoId;
                }
                else
                {
                    item.CodigoItem = svc.InsertOrUpdate(new ItensModel() { DescricaoItem = item.NomeItem });
                }
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (disposing)
            {

            }
        }
    }
}