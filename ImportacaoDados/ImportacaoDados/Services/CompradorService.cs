using ImportacaoDados.DAOs;
using Importador.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ImportacaoDados.Services
{
    public class CompradorService : IDisposable
    {
        private CompradorRepository _repo;
        private CompradorRepository repo
        {
            get
            {
                if (_repo == null)
                {
                    _repo = new CompradorRepository();
                }
                return _repo;
            }
        }

        public CompradorModel ObterPorKey(int pCodigo, string pDescricao)
        {
            var result = repo.ObterPorKey(pCodigo, pDescricao);

            return result;
        }
        public IList<CompradorModel> ObterDados(int pCodigo, string pDescricao)
        {
            var result = repo.ObterDados(pCodigo, pDescricao);

            return result;
        }

        public int InsertOrUpdate(CompradorModel model)
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