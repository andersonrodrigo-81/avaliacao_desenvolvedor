using Importador.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;

namespace ImportacaoDados.DAOs
{
    public class EntradasRepository
    {

        public EntradasModel ObterPorKey(int pCodigo, DateTime pData)
        {
            var result = ObterDados(pCodigo, pData);

            if (result != null && result.Count > 0)
            {
                return result.First();
            }

            return new EntradasModel();
        }
        public IList<EntradasModel> ObterDados(int pCodigo, DateTime pData)
        {
            List<EntradasModel> listaRetorno = new List<EntradasModel>();

            try
            {

                SqlCommand command = new SqlCommand();
                command.Connection = Conexao.connection;

                var sql = new StringBuilder();
                sql.AppendLine(" Select ");
                sql.AppendLine("  CodigoId, DataImportacao, CodigoComprador, CodigoItem, CodigoFornecedor, CodigoEndereco, Quantidade, Valor");
                sql.AppendLine(" From Entradas ");
                sql.AppendLine(" Where 1 = 1 ");

                if (pCodigo > 0)
                    sql.AppendLine($" And CodigoId = @pCodigo");

                if (pData > DateTime.MinValue)
                    sql.AppendLine($" And DataImportacao = @pData");

                command.CommandText = sql.ToString();

                command.Parameters.AddWithValue("@pCodigo", pCodigo);
                command.Parameters.AddWithValue("@pData", pData);

                Conexao.Conectar();

                var reader = command.ExecuteReader();

                while (reader.Read())
                {
                    EntradasModel linha = new EntradasModel();

                    linha.CodigoId = Convert.ToInt32(reader["CodigoId"]);
                    DateTime.TryParse(reader["DataImportacao"].ToString(), out DateTime data);
                    linha.DataImportacao = data;
                    linha.CodigoComprador = Convert.ToInt32(reader["CodigoComprador"]);
                    linha.CodigoItem = Convert.ToInt32(reader["CodigoItem"]);
                    linha.CodigoFornecedor = Convert.ToInt32(reader["CodigoFornecedor"]);
                    linha.CodigoEndereco = Convert.ToInt32(reader["CodigoEndereco"]);
                    linha.Quantidade = Convert.ToInt32(reader["Quantidade"]);
                    linha.Valor = Convert.ToDecimal(reader["Valor"]);

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