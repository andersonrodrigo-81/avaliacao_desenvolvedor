using ImportacaoDados.DAOs;
using Importador.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ImportacaoDados.Services
{
    public class FornecedoresService : IDisposable
    {
        private FornecedoresRepository _repo;
        private FornecedoresRepository repo
        {
            get
            {
                if (_repo == null)
                {
                    _repo = new FornecedoresRepository();
                }
                return _repo;
            }
        }

        public FornecedoresModel ObterPorKey(int pCodigo, string pDescricao)
        {
            var result = repo.ObterPorKey(pCodigo, pDescricao);

            return result;
        }
        public IList<FornecedoresModel> ObterDados(int pCodigo, string pDescricao)
        {
            var result = repo.ObterDados(pCodigo, pDescricao);

            return result;
        }

        public int InsertOrUpdate(FornecedoresModel model)
        {
            return repo.InsertOrUpdate(model);
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