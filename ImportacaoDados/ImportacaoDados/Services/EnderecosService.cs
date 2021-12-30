using ImportacaoDados.DAOs;
using Importador.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ImportacaoDados.Services
{
    public class EnderecosService
    {
        private EnderecoRepository _repo;

        public EnderecosModel ObterPorKey(int pCodigo, string pDescricao)
        {
            var result = _repo.ObterPorKey(pCodigo, pDescricao);

            return result;
        }
        public IList<EnderecosModel> ObterDados(int pCodigo, string pDescricao)
        {
            var result = _repo.ObterDados(pCodigo, pDescricao);

            return result;
        }
    }
}