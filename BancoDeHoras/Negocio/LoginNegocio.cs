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
    public class LoginNegocio
    {
        private string _SQL;
        private SqlCommand cmd;
        private SqlDataReader dr;
        private Login login;

        public void InserirLogin(Login login)
        {
            cmd = new SqlCommand();

            cmd.Connection = ConexaoBancoSQLServer.Conectar();
            _SQL = @"insert into TblLogin (Id_Func, Usuario, Senha, Perfil, Ativo)
                    values
                    (@Id_Func, @Usuario, @Senha, @Perfil, @Ativo)";

            cmd.CommandText = _SQL;
            cmd.Parameters.Add("@Id_Func", SqlDbType.Int).Value = login.idFunc;
            cmd.Parameters.Add("@Usuario", SqlDbType.VarChar, 25).Value = login.usuario.ToUpper();
            cmd.Parameters.Add("@Senha", SqlDbType.VarChar, 25).Value = login.senha.ToUpper();
            cmd.Parameters.Add("@Perfil", SqlDbType.Char, 1).Value = login.perfil.ToUpper();
            cmd.Parameters.Add("@Ativo", SqlDbType.Bit, 1).Value = login.ativo;

            cmd.ExecuteNonQuery();

            cmd.Parameters.Clear();
            cmd.Connection.Close();

        }

        public void AlterarLogin(Login login)
        {
            cmd = new SqlCommand();

            cmd.Connection = ConexaoBancoSQLServer.Conectar();
            _SQL = @"update TblLogin set 
                    Usuario = @Usuario, Senha = @Senha, Perfil = @Perfil, Ativo = @Ativo
                    where Id_Func = @Id_Func ";

            cmd.CommandText = _SQL;

            cmd.Parameters.Add("@Id_Func", SqlDbType.Int).Value = login.idFunc;
            cmd.Parameters.Add("@Usuario", SqlDbType.VarChar, 25).Value = login.usuario.ToUpper();
            cmd.Parameters.Add("@Senha", SqlDbType.VarChar, 25).Value = login.senha.ToUpper();
            cmd.Parameters.Add("@Perfil", SqlDbType.Char, 1).Value = login.perfil.ToUpper();
            cmd.Parameters.Add("@Ativo", SqlDbType.Bit, 1).Value = login.ativo;

            cmd.ExecuteNonQuery();

            cmd.Parameters.Clear();
            cmd.Connection.Close();
        }

        public void ExcluirLogin(Login login)
        {
            cmd = new SqlCommand();

            cmd.Connection = ConexaoBancoSQLServer.Conectar();
            _SQL = @"delete from TblLogin where Id_Func = @Id_Func";

            cmd.CommandText = _SQL;

            cmd.Parameters.Add("@Id_Func", SqlDbType.Int).Value = login.idFunc;


            cmd.ExecuteNonQuery();

            cmd.Parameters.Clear();
            cmd.Connection.Close();
        }

        public List<Login> SelecionarLoginPorNome(string nomeFuncLogin, bool ativo)
        {

            _SQL = @"select 
                    lg.Id_Login, lg.Id_Func,fc.NomeFuncionario, lg.Usuario, lg.Senha, fc.Loja,lg.Perfil, lg.Ativo 
                    from TblLogin lg inner join VW_FUNCIONARIO_COMPLETO fc
                    on lg.Id_Func = fc.Id_Func
                    where fc.NomeFuncionario like '%'+@nomeFuncLogin+'%' and lg.Ativo = @ativo";

            cmd = new SqlCommand();
            cmd.Connection = ConexaoBancoSQLServer.Conectar();

            cmd.Parameters.Add("@nomeFuncLogin", SqlDbType.VarChar, 60).Value = nomeFuncLogin.ToUpper();
            cmd.Parameters.Add("@ativo", SqlDbType.Bit, 1).Value = ativo;

            cmd.CommandText = _SQL;

            dr = cmd.ExecuteReader();

            List<Login> listaLogin = new List<Login>();

            while (dr.Read())
            {
                login = new Login();
                login.idLogin = int.Parse(dr["Id_Login"].ToString());
                login.idFunc = int.Parse(dr["Id_Func"].ToString());
                login.nomeFunc = dr["NomeFuncionario"].ToString();
                login.usuario = dr["Usuario"].ToString();
                login.senha = dr["Senha"].ToString();
                login.loja = dr["Loja"].ToString();
                login.perfil = dr["Perfil"].ToString();
                login.ativo = bool.Parse(dr["Ativo"].ToString());

                listaLogin.Add(login);

            }

            cmd.Parameters.Clear();
            cmd.Connection.Close();

            return listaLogin;
        }
    }
}
