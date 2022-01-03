using ImportacaoDados.DAOs;
using Importador.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ImportacaoDados.Services
{
    public class ItensService : IDisposable
    {
        private ItensRepository _repo;
        private ItensRepository repo
        {
            get
            {
                if (_repo == null)
                {
                    _repo = new ItensRepository();
                }
                return _repo;
            }
        }
        public ItensModel ObterPorKey(int pCodigo, string pDescricao)
        {
            var result = repo.ObterPorKey(pCodigo, pDescricao);

            return result;
        }
        public IList<ItensModel> ObterDados(int pCodigo, string pDescricao)
        {
            var result = repo.ObterDados(pCodigo, pDescricao);

            return result;
        }

        public int InsertOrUpdate(ItensModel model)
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