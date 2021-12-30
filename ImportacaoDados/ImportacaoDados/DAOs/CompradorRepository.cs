using Importador.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;

namespace ImportacaoDados.DAOs
{
    public class CompradorRepository 
    {

        public CompradorModel ObterPorKey(int pCodigo, string pDescricao)
        {
            var result = ObterDados(pCodigo, pDescricao);

            if (result != null && result.Count > 0)
            {
                return result.First();
            }

            return new CompradorModel();
        }
        public IList<CompradorModel> ObterDados(int pCodigo, string pDescricao)
        {
            List<CompradorModel> listaRetorno = new List<CompradorModel>();

            try
            {

                SqlCommand command = new SqlCommand();
                command.Connection = Conexao.connection;

                var sql = new StringBuilder();
                sql.AppendLine(" Select ");
                sql.AppendLine("  CodigoId, NomeComprador");
                sql.AppendLine(" From Comprador ");
                sql.AppendLine(" Where 1 = 1 ");

                if (pCodigo > 0)
                    sql.AppendLine($" And CodigoId = @pCodigo");

                if (!string.IsNullOrEmpty(pDescricao))
                    sql.AppendLine($" And NomeComprador = @pDescricao");

                command.CommandText = sql.ToString();

                command.Parameters.AddWithValue("@pCodigo", pCodigo);
                command.Parameters.AddWithValue("@pDescricao", pDescricao);

                Conexao.Conectar();

                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    CompradorModel comprador = new CompradorModel();

                    comprador.CodigoId = Convert.ToInt32(reader["CodigoId"]);
                    comprador.NomeComprador = reader["NomeComprador"].ToString();

                    listaRetorno.Add(comprador);
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