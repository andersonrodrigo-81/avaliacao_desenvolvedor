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

        public EntradasModel ObterPorKey(EntradasModel pEntidade)
        {
            var result = ObterDados(pEntidade);

            if (result != null && result.Count > 0)
            {
                return result.First();
            }

            return new EntradasModel();
        }
        public IList<EntradasModel> ObterDados(EntradasModel pEntidade)
        {
            List<EntradasModel> listaRetorno = new List<EntradasModel>();

            try
            {

                SqlCommand command = new SqlCommand();
                command.Connection = Conexao.connection;

                var sql = new StringBuilder();
                sql.AppendLine(" Select ");
                sql.AppendLine("  Entradas.CodigoId, Entradas.DataImportacao, Entradas.CodigoComprador, Entradas.CodigoItem, ");
                sql.AppendLine("  Entradas.CodigoFornecedor, Entradas.CodigoEndereco, Entradas.Quantidade, Entradas.Valor, ");
                sql.AppendLine("  Comprador.NomeComprador, Item.DescricaoItem, Fornecedor.NomeFornecedor, Endereco.Endereco ");
                sql.AppendLine(" From Entradas ");
                sql.AppendLine("    inner join Comprador on ");
                sql.AppendLine("        Comprador.CodigoId = Entradas.CodigoComprador ");
                sql.AppendLine("    inner join Item on ");
                sql.AppendLine("        Item.CodigoId = Entradas.CodigoItem ");
                sql.AppendLine("    inner join Fornecedor on ");
                sql.AppendLine("        Fornecedor.CodigoId = Entradas.CodigoFornecedor ");
                sql.AppendLine("    inner join Endereco on ");
                sql.AppendLine("        Endereco.CodigoId = Entradas.CodigoEndereco ");
                sql.AppendLine(" Where 1 = 1 ");

                if (pEntidade.CodigoId > 0)
                    sql.AppendLine($" And CodigoId = @pCodigo");

                sql.AppendLine($" And Cast(DataImportacao as date) BETWEEN @pDataInicio and @pDataFim ");

                command.CommandText = sql.ToString();

                command.Parameters.AddWithValue("@pCodigo", pEntidade.CodigoId);
                command.Parameters.AddWithValue("@pDataInicio", pEntidade.DataInicio);
                command.Parameters.AddWithValue("@pDataFim", pEntidade.DataFim);

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
                    linha.NomeComprador = reader["NomeComprador"].ToString();
                    linha.DescricaoItem = reader["DescricaoItem"].ToString();
                    linha.NomeFornecedor = reader["NomeFornecedor"].ToString();
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

        public bool InsertOrUpdate(EntradasModel model)
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
                command.Parameters.AddWithValue("@DataImportacao", model.DataImportacao);
                command.Parameters.AddWithValue("@CodigoComprador", model.CodigoComprador);
                command.Parameters.AddWithValue("@CodigoItem", model.CodigoItem);
                command.Parameters.AddWithValue("@CodigoFornecedor", model.CodigoFornecedor);
                command.Parameters.AddWithValue("@CodigoEndereco", model.CodigoEndereco);
                command.Parameters.AddWithValue("@Quantidade", model.Quantidade);
                command.Parameters.AddWithValue("@Valor", model.Valor);


                Conexao.Conectar();

                retorno = command.ExecuteNonQuery();

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                Conexao.DesConectar();
            }

            return retorno > -1;

        }

        private string Insert()
        {
            var sql = new StringBuilder();
            sql.AppendLine(" insert into Entradas ");
            sql.AppendLine(" (DataImportacao, CodigoComprador, CodigoItem, CodigoFornecedor, CodigoEndereco, Quantidade, Valor)");
            sql.AppendLine(" values ");
            sql.AppendLine(" (@DataImportacao, @CodigoComprador, @CodigoItem, @CodigoFornecedor, @CodigoEndereco, @Quantidade, @Valor)");

            return sql.ToString();
        }

        private string Update()
        {
            var sql = new StringBuilder();
            sql.AppendLine(" update Entradas set ");
            sql.AppendLine(" DataImportacao = @DataImportacao ,");
            sql.AppendLine(" CodigoComprador = @CodigoComprador ,");
            sql.AppendLine(" CodigoItem = @CodigoItem ,");
            sql.AppendLine(" CodigoFornecedor = @CodigoFornecedor ,");
            sql.AppendLine(" CodigoEndereco = @CodigoEndereco ,");
            sql.AppendLine(" Quantidade = @Quantidade ,");
            sql.AppendLine(" Valor = @Valor ");

            sql.AppendLine(" where ");
            sql.AppendLine(" CodigoId = @CodigoId");

            return sql.ToString();
        }

    }
}