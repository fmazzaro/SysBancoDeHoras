using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ObjetoTransferencia;
using AcessoDados;
using System.Data;
using System.Data.SqlClient;
namespace Negocio
{
    public class FuncionarioNegocio
    {
        private string _SQL;
        private SqlCommand cmd;
        private SqlDataReader dr;
       
        public void InserirFuncionario (Funcionario funcionario)
        {
            
            //bool cadastro = false;
            cmd = new SqlCommand();
            cmd.Connection = ConexaoBancoSQLServer.Conectar();
            
            cmd.CommandText = "PR_INSERIR_PESSOA_E_FUNCIONARIO";
            
            cmd.Parameters.AddWithValue("@Cpf", funcionario.cpf.ToUpper());
            cmd.Parameters.AddWithValue("@Nome", funcionario.nome.ToUpper());
            cmd.Parameters.AddWithValue("@sexo", funcionario.sexo.ToUpper());
            cmd.Parameters.AddWithValue("@funcao", funcionario.funcao.ToUpper());

            //if(funcionario.id_Gerente.ToString() != "")
                cmd.Parameters.AddWithValue("@IdGerente", 0);

            cmd.Parameters.AddWithValue("@idLoja", funcionario.id_Loja);
            cmd.Parameters.AddWithValue("@dataContrato", funcionario.dataContrato);

            cmd.CommandType = CommandType.StoredProcedure;
            
            cmd.ExecuteNonQuery();

                                 
            cmd.Parameters.Clear();
            cmd.Connection.Close();
            
            
        }

        public Funcionario NomeGerenteCombo(int idLoja)
        {
            cmd = new SqlCommand();

            Funcionario funcionario = null;

            cmd.Connection = ConexaoBancoSQLServer.Conectar();

            _SQL = @"select 
                    p.Nome,f.Id_Func
                    from TblFuncionario as f inner join TblPessoa as p
                    on f.Id_Pessoa = p.Id_Pessoa
                    inner join TblLoja as l on f.Id_Loja = l.Id_Loja
                    where f.Funcao = 'GERENTE' and l.Id_Loja = @idLoja and f.Ativo = 1";

            cmd.CommandText = _SQL;

            cmd.Parameters.Add("@idLoja", SqlDbType.Int).Value = idLoja;

            dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                funcionario = new Funcionario();
                funcionario.nome = dr["Nome"].ToString();
                funcionario.id_Func = Convert.ToInt32(dr["Id_Func"].ToString());

                FuncionarioGerenteCombo.func = funcionario;
            }

            //nomeGerente = cmd.ExecuteScalar().ToString();

            cmd.Parameters.Clear();
            cmd.Connection.Close();

            return funcionario;
        }

        public List<Funcionario> SelecionarFuncionarioPorNome (string nome, bool ativo, int idLoja)
        {
            _SQL = @"select 
                    Id_Func,NomeFuncionario,Funcao,Cpf,Sexo,id_Gerente,Ativo,idLoja,Id_Pessoa, DataContrato
                    from VW_FUNCIONARIO_COMPLETO
                    where NomeFuncionario like '%' + @nomefunc + '%' and Ativo = @ativo and idLoja = @idLoja";

            
            cmd = new SqlCommand();
            cmd.Connection = ConexaoBancoSQLServer.Conectar();

            cmd.Parameters.AddWithValue("@nomefunc", nome);
            cmd.Parameters.AddWithValue("@ativo", ativo);
            cmd.Parameters.AddWithValue("@idLoja", idLoja);
            cmd.CommandText = _SQL;

            dr = cmd.ExecuteReader();

            List<Funcionario> ListaFuncionarios = new List<Funcionario>();
                        
            while (dr.Read())
            {
                Funcionario func = new Funcionario();

                func.id_Func = int.Parse(dr["Id_Func"].ToString());
                func.nome = dr["NomeFuncionario"].ToString();
                func.funcao = dr["Funcao"].ToString();
                func.cpf = dr["Cpf"].ToString();
                func.sexo = dr["Sexo"].ToString();

                if (!dr.IsDBNull(dr.GetOrdinal("id_Gerente")))
                    func.id_Gerente = int.Parse(dr["id_Gerente"].ToString());

                if (!dr.IsDBNull(dr.GetOrdinal("Ativo")))
                    func.ativo = Convert.ToBoolean(dr["Ativo"].ToString());
                func.id_Loja = int.Parse(dr["idLoja"].ToString());

                if (!dr.IsDBNull(dr.GetOrdinal("Id_Pessoa")))
                    func.id_Pessoa = int.Parse(dr["Id_Pessoa"].ToString());

                if (!dr.IsDBNull(dr.GetOrdinal("DataContrato")))
                    func.dataContrato = Convert.ToDateTime(dr["DataContrato"].ToString());

                ListaFuncionarios.Add(func);
            }


            cmd.Parameters.Clear();
            cmd.Connection.Close();

            return ListaFuncionarios;
            /*
             
            _SQL = " select Id_Func,NomeFuncionario,Funcao,Cpf,Sexo,id_Gerewhante,Ativo,idLoja ";
            _SQL += " from VW_FUNCIONARIO_COMPLETO where ";
            _SQL+ = " NomeFuncionario like @nomefunc and Ativo = @ativo and idLoja = @idLoja";

            //
            cmd = new SqlCommand();
            cmd.Connection = ConexaoBancoSQLServer.Conectar();

            cmd.Parameters.AddWithValue("@nomefunc", string.Format("%{0}%", nome));
            cmd.Parameters.AddWithValue("@ativo", ativo);
            cmd.Parameters.AddWithValue("@idLoja", idLoja);        
            cmd.CommandText = _SQL;

            dr = cmd.ExecuteReader();


            List<Funcionario> ListaFuncionarios = new List<Funcionario>();

            while (dr.Read())
            {
                Funcionario func = new Funcionario();

                func.id_Func = dr.dr.GetInt32(0);
                func.nome = dr.GetString(1);                        
                func.funcao = dr.GetString(2);
                func.cpf = dr.GetString(3);
                func.sexo = dr.GetString(4);
                func.id_Gerente = dr.IsDBNull(5) == false ? dr.GetBoolean(5) : false;
                func.ativo = dr.IsDBNull(6) == false ? dr.GetBoolean(6) : false;
                func.id_Loja = dr.dr.GetInt32(7);
                ListaFuncionarios.Add(func);
            }

            return ListaFuncionarios;
             */

        }

        public void ExcluirFuncionario (Funcionario funcionario)
        {
            cmd = new SqlCommand();
            cmd.Connection = ConexaoBancoSQLServer.Conectar();

            _SQL = @"
                        DELETE FROM TblFuncionario WHERE Id_Func = @idFunc
            
                        DELETE FROM TblPessoa WHERE Id_Pessoa = @idPessoa";

            cmd.CommandText = _SQL;

            cmd.Parameters.AddWithValue("@idFunc", funcionario.id_Func);
            cmd.Parameters.AddWithValue("@idPessoa", funcionario.id_Pessoa);
                        
            cmd.ExecuteNonQuery();


            cmd.Parameters.Clear();
            cmd.Connection.Close();
        }

        public string SelecionarFuncionarioIdPessoaParaAlteracao(int idFunc)
        {
            string nomeGerente = "";
            _SQL = @"select 
                    [Nome Gerente] as Gerente
                    from VW_FUNCIONARIO_COMPLETO as F inner join VW_FUNCIOANARIO_GERENTE_NOMES as G
                    on f.Id_Pessoa = G.Id_Pessoa
                    where G.IdSubordinado = @IdSubordinado";


            cmd = new SqlCommand();
            cmd.Connection = ConexaoBancoSQLServer.Conectar();

            cmd.Parameters.AddWithValue("@IdSubordinado", idFunc);
            
            cmd.CommandText = _SQL;

            nomeGerente = cmd.ExecuteScalar().ToString();

            cmd.Parameters.Clear();
            cmd.Connection.Close();
            
            return nomeGerente;
            
        }

        public void AlterarFuncionario(Funcionario funcionario)
        {
            cmd = new SqlCommand();
            cmd.Connection = ConexaoBancoSQLServer.Conectar();

            cmd.CommandText = "PR_ALTERAR_PESSOA_E_FUNCIONARIO_ID_FUNC";

            cmd.Parameters.AddWithValue("@Cpf", funcionario.cpf.ToUpper());
            cmd.Parameters.AddWithValue("@Nome", funcionario.nome.ToUpper());
            cmd.Parameters.AddWithValue("@sexo", funcionario.sexo.ToUpper());
            cmd.Parameters.AddWithValue("@idFunc", funcionario.id_Func);
            cmd.Parameters.AddWithValue("@funcao", funcionario.funcao.ToUpper());
            cmd.Parameters.AddWithValue("@dataContrato", funcionario.dataContrato);

            if (funcionario.id_Gerente > 0)
                cmd.Parameters.AddWithValue("@IdGerente", funcionario.id_Gerente);

            cmd.Parameters.AddWithValue("@ativo", funcionario.ativo);
            cmd.Parameters.AddWithValue("@idLoja", funcionario.id_Loja);


            cmd.CommandType = CommandType.StoredProcedure;

            cmd.ExecuteNonQuery();


            cmd.Parameters.Clear();
            cmd.Connection.Close();
        }

        public int SelecionarGerentePorNomeDevolvendoId(int idLoja)
        {
            int idGerente = 0;
            _SQL = @"select Id_Func from TblFuncionario
                    WHERE Funcao = 'GERENTE' AND Id_Loja = @Id_Loja
                    ";
            


            cmd = new SqlCommand();
            cmd.Connection = ConexaoBancoSQLServer.Conectar();

            //cmd.Parameters.AddWithValue("@funcao", string.Format("%{0}%", funcao));
            cmd.Parameters.AddWithValue("@Id_Loja", idLoja);

           // cmd.Parameters.Add("@funcao", SqlDbType.VarChar, 30).Value = funcao;
            //cmd.Parameters.Add("@Id_Loja", SqlDbType.Int).Value = idLoja;
            cmd.CommandText = _SQL;
            
            idGerente = Convert.ToInt32(cmd.ExecuteScalar().ToString());

            cmd.Parameters.Clear();
            cmd.Connection.Close();

            return idGerente;

            /*
             
            _SQL = " select Id_Func,NomeFuncionario,Funcao,Cpf,Sexo,id_Gerewhante,Ativo,idLoja ";
            _SQL += " from VW_FUNCIONARIO_COMPLETO where ";
            _SQL+ = " NomeFuncionario like @nomefunc and Ativo = @ativo and idLoja = @idLoja";

            //
            cmd = new SqlCommand();
            cmd.Connection = ConexaoBancoSQLServer.Conectar();

            cmd.Parameters.AddWithValue("@nomefunc", string.Format("%{0}%", nome));
            cmd.Parameters.AddWithValue("@ativo", ativo);
            cmd.Parameters.AddWithValue("@idLoja", idLoja);        
            cmd.CommandText = _SQL;

            dr = cmd.ExecuteReader();


            List<Funcionario> ListaFuncionarios = new List<Funcionario>();

            while (dr.Read())
            {
                Funcionario func = new Funcionario();

                func.id_Func = dr.dr.GetInt32(0);
                func.nome = dr.GetString(1);                        
                func.funcao = dr.GetString(2);
                func.cpf = dr.GetString(3);
                func.sexo = dr.GetString(4);
                func.id_Gerente = dr.IsDBNull(5) == false ? dr.GetBoolean(5) : false;
                func.ativo = dr.IsDBNull(6) == false ? dr.GetBoolean(6) : false;
                func.id_Loja = dr.dr.GetInt32(7);
                ListaFuncionarios.Add(func);
            }

            return ListaFuncionarios;
             */

        }

        
    }
}
