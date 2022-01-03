using Importador.Models;
using System;
using System.Collections.Generic;
using System.Data;
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

                command.Parameters.AddWithValue("@CodigoId", pCodigo);
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

        public int InsertOrUpdate(EnderecosModel model)
        {
            int retorno = 0;

            try
            {

                string sql = string.Empty;

                if (model.CodigoId == 0)
                {
                    sql = Insert();
                }
                else
                {
                    sql = Update();
                }

                SqlCommand command = new SqlCommand();
                command.Connection = Conexao.connection;

                command.CommandText = sql.ToString();

                command.Parameters.AddWithValue("@CodigoId", model.CodigoId);
                command.Parameters.AddWithValue("@Endereco", model.Endereco);
                command.Parameters.AddWithValue("@id", 0).Direction = ParameterDirection.Output;
                Conexao.Conectar();

                command.ExecuteNonQuery();

                retorno = Convert.ToInt32(command.Parameters["@id"].Value);

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                Conexao.DesConectar();
            }

            return retorno;

        }

        private string Insert()
        {
            var sql = new StringBuilder();
            sql.AppendLine(" insert into Endereco ");
            sql.AppendLine(" (Endereco)");
            sql.AppendLine(" values ");
            sql.AppendLine(" (@Endereco ) ");
            sql.AppendLine(" SET @id = SCOPE_IDENTITY()");

            return sql.ToString();
        }

        private string Update()
        {
            var sql = new StringBuilder();
            sql.AppendLine(" update Endereco set ");
            sql.AppendLine(" Endereco = @Endereco");
            sql.AppendLine(" where ");
            sql.AppendLine(" CodigoId = @CodigoId");

            return sql.ToString();
        }

    }
}