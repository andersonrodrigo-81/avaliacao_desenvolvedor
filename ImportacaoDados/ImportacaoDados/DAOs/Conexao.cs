using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ImportacaoDados.DAOs
{
    public class Conexao
    {
        static string con = System.Configuration.ConfigurationManager.ConnectionStrings["ConnectionDefault"].ConnectionString;
        public static SqlConnection connection = new SqlConnection(con);

        public static void Conectar()
        {
            if (connection.State == System.Data.ConnectionState.Closed)
            {
                connection.Open();
            }
            
        }

        public static void DesConectar()
        {
            if (connection.State == System.Data.ConnectionState.Open)
            {
                connection.Close();
            }
        }
    }
}