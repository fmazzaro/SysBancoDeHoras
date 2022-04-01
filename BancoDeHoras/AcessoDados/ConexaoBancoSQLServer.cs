using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace AcessoDados
{
    public class ConexaoBancoSQLServer
    {
        public static SqlConnection Conectar()
        {
            /* 
             * para conexão Local
             * 
            string conexao = "Data Source=DESKTOP-EPIOHMM;Initial Catalog=DB_BANCO_DE_HORAS;Integrated Security=True";

            SqlConnection sqlConnection = new SqlConnection(conexao);

            sqlConnection.Open();

            return sqlConnection;
            */

            SqlConnectionStringBuilder sb = new SqlConnectionStringBuilder();
            sb.UserID = "sa";
            sb.Password = "sql.2008*std";
            sb.DataSource = "server1";
            sb.InitialCatalog = "DB_BANCO_DE_HORAS";

            SqlConnection cn = new SqlConnection(sb.ConnectionString);

            cn.Open();

            return cn;
            
        }
    }
}
