using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

using ObjetoTransferencia;
using AcessoDados;
namespace Negocio
{
    public class LojaNegocio
    {
        private string _SQL;
        private SqlCommand cmd;
        private SqlDataReader dr;
        public void InserirLoja (Loja loja)
        {
            cmd = new SqlCommand();
            
            cmd.Connection = ConexaoBancoSQLServer.Conectar();
            _SQL = @"insert into TblLoja (Nome,Razao,cnpj,Endereco,Ativo) 
                     values 
                    (@nome, @razao, @cnpj, @endereco, @ativo)";

            cmd.CommandText = _SQL;            

            cmd.Parameters.Add("@nome", SqlDbType.VarChar, 100).Value = loja.nome.ToUpper();
            cmd.Parameters.Add("@razao", SqlDbType.VarChar, 100).Value = loja.razao.ToUpper();
            cmd.Parameters.Add("@cnpj", SqlDbType.VarChar, 13).Value = loja.cnpj;
            cmd.Parameters.Add("@endereco", SqlDbType.VarChar, 100).Value = loja.endereco.ToUpper();
            cmd.Parameters.Add("@ativo", SqlDbType.Bit, 1).Value = loja.ativo;

            cmd.ExecuteNonQuery();

            cmd.Parameters.Clear();
            cmd.Connection.Close();
            
        }

        public void AlterarLoja(Loja loja)
        {
            cmd = new SqlCommand();

            cmd.Connection = ConexaoBancoSQLServer.Conectar();
            _SQL = @"update TblLoja set  
                    nome = @nome, Razao = @razao, cnpj = @cnpj, endereco = @endereco, ativo = @ativo
                    where Id_Loja = @Id_Loja";

            cmd.CommandText = _SQL;

            cmd.Parameters.Add("@Id_Loja", SqlDbType.Int).Value = loja.id_Loja;
            cmd.Parameters.Add("@nome", SqlDbType.VarChar, 100).Value = loja.nome.ToUpper();
            cmd.Parameters.Add("@razao", SqlDbType.VarChar, 100).Value = loja.razao.ToUpper();
            cmd.Parameters.Add("@cnpj", SqlDbType.VarChar, 13).Value = loja.cnpj;
            cmd.Parameters.Add("@endereco", SqlDbType.VarChar, 100).Value = loja.endereco.ToUpper();
            cmd.Parameters.Add("@ativo", SqlDbType.Bit, 1).Value = loja.ativo;

            cmd.ExecuteNonQuery();

            cmd.Parameters.Clear();
            cmd.Connection.Close();

        }

        public List<Loja> SelecionarLojaPorNome (string nomeLoja, bool ativa)
        {
            _SQL = @"
                    select 
                    Id_Loja,Nome,Razao,cnpj,Endereco,Ativo
                    from TblLoja
                    where Nome like '%'+@nomeLoja+'%' and Ativo = @ativa";

            cmd = new SqlCommand();
            cmd.Connection = ConexaoBancoSQLServer.Conectar();

            cmd.Parameters.Add("@nomeLoja", SqlDbType.VarChar, 20).Value = nomeLoja.ToUpper();
            cmd.Parameters.Add("@ativa", SqlDbType.Bit, 1).Value = ativa;

            cmd.CommandText = _SQL;

            dr = cmd.ExecuteReader();

            List<Loja> listaLoja = new List<Loja>();

            while (dr.Read())
            {
                Loja loja = new Loja();
                loja.id_Loja = int.Parse(dr["Id_Loja"].ToString());
                loja.nome = dr["Nome"].ToString();

                if(!dr.IsDBNull(dr.GetOrdinal("Razao")))
                    loja.razao = dr["Razao"].ToString();

                if (!dr.IsDBNull(dr.GetOrdinal("cnpj")))
                    loja.cnpj = dr["cnpj"].ToString();

                if (!dr.IsDBNull(dr.GetOrdinal("Endereco")))
                    loja.endereco = dr["Endereco"].ToString();

                loja.ativo = bool.Parse(dr["Ativo"].ToString());
                listaLoja.Add(loja);
            }

            cmd.Parameters.Clear();
            cmd.Connection.Close();

            return listaLoja;
        }

        public void ExcluirLoja(Loja loja)
        {
            cmd = new SqlCommand();

            cmd.Connection = ConexaoBancoSQLServer.Conectar();
            _SQL = @"delete from TblLoja where Id_Loja = @idLoja";

            cmd.CommandText = _SQL;

            cmd.Parameters.Add("@idLoja", SqlDbType.Int).Value = loja.id_Loja;
            

            cmd.ExecuteNonQuery();

            cmd.Parameters.Clear();
            cmd.Connection.Close();
        }

        public List<Loja> ListarLojasCombo()
        {

            _SQL = @"select Id_Loja,Nome from TblLoja where Ativo = 1 order by Nome";

            cmd = new SqlCommand();
            cmd.Connection = ConexaoBancoSQLServer.Conectar();
            cmd.CommandText = _SQL;

            SqlDataReader dr = cmd.ExecuteReader();
            List<Loja> listaLoja = new List<Loja>();

            while (dr.Read())
            {
                Loja loja = new Loja();
                loja.id_Loja = dr.GetInt32(dr.GetOrdinal("Id_Loja"));
                loja.nome = dr.GetString(dr.GetOrdinal("Nome"));
                listaLoja.Add(loja);
            }

            cmd.Connection.Close();
            cmd.Dispose();

            return listaLoja;
        }

        public string SelecionarNomeLojaPorId (int idLoja)
        {
            string nomeLoja = "";
            _SQL = @"select Nome from TblLoja where Id_Loja = @Id_Loja";

            cmd = new SqlCommand();
            cmd.Connection = ConexaoBancoSQLServer.Conectar();

            cmd.Parameters.AddWithValue("@Id_Loja", idLoja);

            cmd.CommandText = _SQL;

            nomeLoja = cmd.ExecuteScalar().ToString();

            cmd.Parameters.Clear();
            cmd.Connection.Close();
            
            return nomeLoja;
        }
        public int SelecionarLojaPorNomeDevolvendoId (string nome)
        {
            int idLoja = 0;
            _SQL = @"select 
                     Id_Loja from TblLoja 
                    where Nome like '%'+@nomeLoja+'%' ";

            cmd = new SqlCommand();
            cmd.Connection = ConexaoBancoSQLServer.Conectar();

            cmd.Parameters.AddWithValue("@nomeLoja", nome.ToUpper());

            cmd.CommandText = _SQL;

            idLoja = int.Parse(cmd.ExecuteScalar().ToString());

            cmd.Parameters.Clear();
            cmd.Connection.Close();
            return idLoja;
        }

        
    }
}
