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

        public int InsertOrUpdate(CompradorModel model)
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
                command.Parameters.AddWithValue("@NomeComprador", model.NomeComprador);
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
            sql.AppendLine(" insert into Comprador ");
            sql.AppendLine(" (NomeComprador)" );
            sql.AppendLine(" values ");
            sql.AppendLine(" (@NomeComprador ) ");
            sql.AppendLine(" SET @id = SCOPE_IDENTITY()");

            return sql.ToString();
        }

        private string Update()
        {
            var sql = new StringBuilder();
            sql.AppendLine(" update Comprador set ");
            sql.AppendLine(" NomeComprador = @NomeComprador");
            sql.AppendLine(" where ");
            sql.AppendLine(" CodigoId = @CodigoId");

            return sql.ToString();
        }

    }
}