using ImportacaoDados.DAOs;
using Importador.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ImportacaoDados.Services
{
    public class EnderecosService : IDisposable
    {
        private EnderecoRepository _repo;
        private EnderecoRepository repo
        {
            get
            {
                if (_repo == null)
                {
                    _repo = new EnderecoRepository();
                }
                return _repo;
            }
        }


        public EnderecosModel ObterPorKey(int pCodigo, string pDescricao)
        {
            var result = repo.ObterPorKey(pCodigo, pDescricao);

            return result;
        }
        public IList<EnderecosModel> ObterDados(int pCodigo, string pDescricao)
        {
            var result = repo.ObterDados(pCodigo, pDescricao);

            return result;
        }

        public int InsertOrUpdate(EnderecosModel model)
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