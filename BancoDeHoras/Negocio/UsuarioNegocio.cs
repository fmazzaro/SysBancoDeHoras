using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

using AcessoDados;
using ObjetoTransferencia;
namespace Negocio
{
    public class UsuarioNegocio
    {
        private string _SQL;

        public bool Logar(string usuario, string senha)
        {
            bool logado = false;
            Usuario usu = null;

            SqlCommand cmd = new SqlCommand();
            cmd.Connection = ConexaoBancoSQLServer.Conectar();

            _SQL = @"select 
                    Id_Func,Usuario,Senha,Perfil, Ativo
                    from TblLogin
                    where Usuario = @Usuario and Senha = @Senha and ativo = 1";

            cmd.CommandText = _SQL;

            cmd.Parameters.Add("@Usuario", SqlDbType.VarChar, 25).Value = usuario.ToUpper();
            cmd.Parameters.Add("@Senha", SqlDbType.VarChar, 25).Value = senha.ToUpper();


            SqlDataReader dr = cmd.ExecuteReader();
            
            // como vai rodar apenas uma vez, não vou colocar o while, pois só vai retornar apenas 1 linha do banco
            if (dr.Read())
            {
                usu = new Usuario();
                usu.id_Func = Convert.ToInt32(dr["Id_Func"].ToString());
                usu.nomeUsuario = dr["Usuario"].ToString();
                usu.senha = dr["Senha"].ToString();
                usu.perfil = dr["Perfil"].ToString();
                usu.ativo = Convert.ToBoolean(dr["Ativo"].ToString());

                logado = true;
                UsuarioConectado.usuario = usu;
            }

            cmd.Parameters.Clear();
            cmd.Connection.Close();

            return logado;
        }
    }
}
