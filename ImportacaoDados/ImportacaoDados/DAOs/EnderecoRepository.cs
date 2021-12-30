using Importador.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;

namespace ImportacaoDados.DAOs
{
    public class EnderecoRepository 
    {

        public EnderecosModel ObterPorKey(int pCodigo, string pDescricao)
        {
            var result = ObterDados(pCodigo, pDescricao);

            if (result != null && result.Count > 0)
            {
                return result.First();
            }

            return new EnderecosModel();
        }
        public IList<EnderecosModel> ObterDados(int pCodigo, string pDescricao)
        {
            List<EnderecosModel> listaRetorno = new List<EnderecosModel>();

            try
            {

                SqlCommand command = new SqlCommand();
                command.Connection = Conexao.connection;

                var sql = new StringBuilder();
                sql.AppendLine(" Select ");
                sql.AppendLine("  CodigoId, Endereco");
                sql.AppendLine(" From Endereco ");
                sql.AppendLine(" Where 1 = 1 ");

                if (pCodigo > 0)
                    sql.AppendLine($" And CodigoId = @pCodigo");

                if (!string.IsNullOrEmpty(pDescricao))
                    sql.AppendLine($" And Endereco = @pDescricao");

                command.CommandText = sql.ToString();

                command.Parameters.AddWithValue("@pCodigo", pCodigo);
                command.Parameters.AddWithValue("@pDescricao", pDescricao);

                Conexao.Conectar();

                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    EnderecosModel linha = new EnderecosModel();

                    linha.CodigoId = Convert.ToInt32(reader["CodigoId"]);
                    linha.Endereco = reader["Endereco"].ToString();

                    listaRetorno.Add(linha);
                }

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                Conexao.DesConectar();
            }

            return listaRetorno;
        }

    }
}