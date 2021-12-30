using ImportacaoDados.DAOs;
using Importador.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ImportacaoDados.Services
{
    public class EntradasService
    {
        private EntradasRepository _repo;

        public EntradasModel ObterPorKey(int pCodigo, DateTime pData)
        {
            var result = _repo.ObterPorKey(pCodigo, pData);

            return result;
        }
        public IList<EntradasModel> ObterDados(int pCodigo, DateTime pData)
        {
            var result = _repo.ObterDados(pCodigo, pData);

            return result;
        }
    }
}