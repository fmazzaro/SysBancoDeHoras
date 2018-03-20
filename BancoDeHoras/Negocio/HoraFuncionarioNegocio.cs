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
    public class HoraFuncionarioNegocio
    {
        private string _SQL;
        private SqlCommand cmd;
        private SqlDataReader dr;
        public List<Funcionario> ListaComboFuncionarioDaLoja (int idLoja)
        {
            _SQL = @"select Id_Func,NomeFuncionario FROM VW_FUNCIONARIO_COMPLETO 
                    WHERE IdLoja = @idLoja and Ativo = 1 
                    order by NomeFuncionario";

            cmd = new SqlCommand();
            cmd.Connection = ConexaoBancoSQLServer.Conectar();

            cmd.Parameters.AddWithValue("@idLoja", idLoja);

            cmd.CommandText = _SQL;

            SqlDataReader dr =  cmd.ExecuteReader();

            List<Funcionario> listaFuncionario = new List<Funcionario>();

            while (dr.Read())
            {
                Funcionario func = new Funcionario();

                func.id_Func = dr.GetInt32(dr.GetOrdinal("Id_Func"));
                func.nome = dr.GetString(dr.GetOrdinal("NomeFuncionario"));
                
                listaFuncionario.Add(func);
            }

            cmd.Connection.Close();
            cmd.Dispose();

            return listaFuncionario;
        }
        public List<Funcionario> ListaComboFuncionarioDaLojaAtivadoDesativado(int idLoja, bool ativo)
        {
            _SQL = @"select Id_Func,NomeFuncionario FROM VW_FUNCIONARIO_COMPLETO 
                    WHERE IdLoja = @idLoja and Ativo = @ativo 
                    order by NomeFuncionario";

            cmd = new SqlCommand();
            cmd.Connection = ConexaoBancoSQLServer.Conectar();

            cmd.Parameters.AddWithValue("@idLoja", idLoja);
            cmd.Parameters.AddWithValue("@ativo", ativo);

            cmd.CommandText = _SQL;

            SqlDataReader dr = cmd.ExecuteReader();

            List<Funcionario> listaFuncionario = new List<Funcionario>();

            while (dr.Read())
            {
                Funcionario func = new Funcionario();

                func.id_Func = dr.GetInt32(dr.GetOrdinal("Id_Func"));
                func.nome = dr.GetString(dr.GetOrdinal("NomeFuncionario"));

                listaFuncionario.Add(func);
            }

            cmd.Connection.Close();
            cmd.Dispose();

            return listaFuncionario;
        }
        public void InserirHoraFuncionario (HoraFuncionario horaFunc)
        {
            cmd = new SqlCommand();

            cmd.Connection = ConexaoBancoSQLServer.Conectar();

            cmd.CommandText = "PR_INSERIR_HORA_FUNCIONARIO";

                cmd.Parameters.AddWithValue("@idFunc", horaFunc.idfunc);
                cmd.Parameters.AddWithValue("@dataEntrada", horaFunc.data_entrada);
                cmd.Parameters.AddWithValue("@entrada", horaFunc.entrada);
                cmd.Parameters.AddWithValue("@idaAlmoco", horaFunc.ida_almoco);
                cmd.Parameters.AddWithValue("@voltaAlmoco", horaFunc.volta_almoco);
                cmd.Parameters.AddWithValue("@saida", horaFunc.saida);
                cmd.Parameters.AddWithValue("@horasUteis", horaFunc.qtdHora);
                cmd.Parameters.AddWithValue("@folga", horaFunc.folga);
                cmd.Parameters.AddWithValue("@obs", horaFunc.obs.ToUpper());


            cmd.CommandType = CommandType.StoredProcedure;

            cmd.ExecuteNonQuery();

            cmd.Parameters.Clear();
            cmd.Connection.Close();
        }
        public string SaldoFuncionarioTotal(int idFunc)
        {
            cmd = new SqlCommand();
            cmd.Connection = ConexaoBancoSQLServer.Conectar();

            cmd.CommandText = "PR_SALDO_EM_HORA_FUNCIONARIO_INTEGRAL_Finale";

            cmd.Parameters.AddWithValue("@IdFunc", idFunc);

            cmd.CommandType = CommandType.StoredProcedure;

            string saldo = cmd.ExecuteScalar().ToString();

            return saldo;
        } 
        public List<HoraFuncionario> GridCadastroHoras(DateTime dataInicio, DateTime fimDoMes, int idFunc)
        {
            _SQL = @"select 
                    Id_HF, Id_Func, Data_Entrada,Entrada,Ida_Almoco,Volta_Almoco,Saida,Qtd_Hora_Util,Folga,observacao 
                    from TblHoraFuncionario
                    where Id_Func = @idFunc and (Data_Entrada >= @dataInicio and Data_Entrada <= @fimDoMes)";

            cmd = new SqlCommand();
            cmd.Connection = ConexaoBancoSQLServer.Conectar();

            cmd.Parameters.Add("@dataInicio", SqlDbType.Date).Value = dataInicio;
            cmd.Parameters.Add("@idFunc",SqlDbType.Int).Value = idFunc;
            cmd.Parameters.Add("@fimDoMes", SqlDbType.Date).Value = fimDoMes;

            cmd.CommandText = _SQL;

            dr = cmd.ExecuteReader();

            List<HoraFuncionario> listaHoraFunc = new List<HoraFuncionario>();

            while (dr.Read())
            {
                HoraFuncionario hf = new HoraFuncionario();

                hf.id_HF = dr.GetInt32(0);
                hf.idfunc = dr.GetInt32(1);
                hf.data_entrada = dr.GetDateTime(2);
                hf.entrada = dr.GetTimeSpan(3);
                hf.ida_almoco = dr.GetTimeSpan(4);
                hf.volta_almoco = dr.GetTimeSpan(5);
                hf.saida = dr.GetTimeSpan(6);
                hf.qtdHora = dr.GetInt32(7);
                hf.folga = dr.GetBoolean(8);

                if (!dr.IsDBNull(dr.GetOrdinal("observacao")))
                {
                    hf.obs = dr.GetString(9);
                }

                listaHoraFunc.Add(hf);
            }

            cmd.Parameters.Clear();
            cmd.Connection.Close();

            return listaHoraFunc;
            
        }
        public string SaldoFuncionarioMesCadastro(int idFunc, string nomeMes, int ano)
        {
            cmd = new SqlCommand();
            cmd.Connection = ConexaoBancoSQLServer.Conectar();

            cmd.CommandText = "PR_SALDO_EM_HORA_FUNCIONARIO_POR_MES";

            nomeMes = nomeMesInglesAzure(nomeMes);

            cmd.Parameters.AddWithValue("@nomeMes", nomeMes);
            cmd.Parameters.AddWithValue("@IdFunc", idFunc);
            cmd.Parameters.AddWithValue("@ano", ano);

            cmd.CommandType = CommandType.StoredProcedure;

            string saldo = cmd.ExecuteScalar().ToString();

            return saldo;
        }
        public string NomeDaLojaIdFunc (int idFunc)
        {
            string nomeLoja = "";

            _SQL = @"select Loja from VW_FUNCIONARIO_COMPLETO
                     where Id_Func = @idFunc";

            cmd = new SqlCommand();
            cmd.Connection = ConexaoBancoSQLServer.Conectar();

            cmd.Parameters.AddWithValue("@idFunc", idFunc);

            cmd.CommandText = _SQL;

            nomeLoja = cmd.ExecuteScalar().ToString();

            cmd.Parameters.Clear();
            cmd.Connection.Close();

            return nomeLoja;
        }
        public string NomeFuncionarioIdFunc(int idFunc)
        {
            string nomeFunc = "";

            _SQL = @"select NomeFuncionario from VW_FUNCIONARIO_COMPLETO
                    where Id_Func = @idFunc";

            cmd = new SqlCommand();
            cmd.Connection = ConexaoBancoSQLServer.Conectar();

            cmd.Parameters.AddWithValue("@idFunc", idFunc);

            cmd.CommandText = _SQL;

            nomeFunc = cmd.ExecuteScalar().ToString();

            cmd.Parameters.Clear();
            cmd.Connection.Close();

            return nomeFunc;

        }
        public void AlterarHoraFuncionario (HoraFuncionario hf)
        {
            cmd = new SqlCommand();
            cmd.Connection = ConexaoBancoSQLServer.Conectar();

            cmd.CommandText = "PR_ALTERAR_HORA_FUNCIONARIO_ID_FUNC_DATA_ENTRADA";

            cmd.Parameters.AddWithValue("@idFunc", hf.idfunc);
            cmd.Parameters.AddWithValue("@dataEntrada", hf.data_entrada);
            cmd.Parameters.AddWithValue("@entrada", hf.entrada);
            cmd.Parameters.AddWithValue("@idaAlmoco", hf.ida_almoco);
            cmd.Parameters.AddWithValue("@voltaAlmoco", hf.volta_almoco);
            cmd.Parameters.AddWithValue("@saida", hf.saida);
            cmd.Parameters.AddWithValue("@horasUteis", hf.qtdHora);
            cmd.Parameters.AddWithValue("@folga", hf.folga);
            cmd.Parameters.AddWithValue("@obs", hf.obs.ToUpper());

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.ExecuteNonQuery();


            cmd.Parameters.Clear();
            cmd.Connection.Close();
        }
        public void ExcluirHoraFuncionario(HoraFuncionario hf)
        {
            cmd = new SqlCommand();
            cmd.Connection = ConexaoBancoSQLServer.Conectar();

            _SQL = @"delete from TblHoraFuncionario where Id_Func = @idFunc and Data_Entrada = @dataEntrada";

            cmd.CommandText = _SQL;

            cmd.Parameters.AddWithValue("@idFunc", hf.idfunc);
            cmd.Parameters.AddWithValue("@dataEntrada", hf.data_entrada);

            cmd.ExecuteNonQuery();


            cmd.Parameters.Clear();
            cmd.Connection.Close();
        }
        public List<HoraFuncionario> CarregarGridBotaoNaTela(string nomeMes, int idFunc, int ano)
        {
            _SQL = @"select 
                    Id_HF, Id_Func, Data_Entrada,Entrada,Ida_Almoco,Volta_Almoco,Saida,Qtd_Hora_Util,Folga, observacao
                    from TblHoraFuncionario
                    where Id_Func = @idFunc and DATENAME(MONTH,Data_Entrada) = @nomeMes and DATENAME(YEAR,Data_Entrada) = @ano
                    ORDER BY Data_Entrada";

            cmd = new SqlCommand();
            cmd.Connection = ConexaoBancoSQLServer.Conectar();

            //cmd.Parameters.Add("@nomeMes", SqlDbType.VarChar).Value = nomeMes;
            //cmd.Parameters.Add("@idFunc", SqlDbType.Int).Value =  idFunc;
            cmd.Parameters.AddWithValue("@idFunc", idFunc);
            cmd.Parameters.AddWithValue("@nomeMes", nomeMes);
            cmd.Parameters.AddWithValue("@ano", ano);

            cmd.CommandText = _SQL;

            dr = cmd.ExecuteReader();

            List<HoraFuncionario> listaHoraFunc = new List<HoraFuncionario>();

            while (dr.Read())
            {
                HoraFuncionario hf = new HoraFuncionario();

                hf.id_HF = dr.GetInt32(0);
                hf.idfunc = dr.GetInt32(1);
                hf.data_entrada = dr.GetDateTime(2);
                hf.entrada = dr.GetTimeSpan(3);
                hf.ida_almoco = dr.GetTimeSpan(4);
                hf.volta_almoco = dr.GetTimeSpan(5);
                hf.saida = dr.GetTimeSpan(6);
                hf.qtdHora = dr.GetInt32(7);
                hf.folga = dr.GetBoolean(8);

                if (!dr.IsDBNull(dr.GetOrdinal("observacao")))
                {
                    hf.obs = dr.GetString(9);
                }
                
                listaHoraFunc.Add(hf);
            }

            cmd.Parameters.Clear();
            cmd.Connection.Close();

            return listaHoraFunc;
        }

        public string nomeMesInglesAzure(string nomeMesPortugues)
        {
            string mes = "";
            switch (nomeMesPortugues.ToUpper())
            {
                case "JANEIRO":
                    mes = "January";
                    break;
                case "FEVEREIRO":
                    mes = "February";
                    break;
                case "MARÇO":
                    mes = "March";
                    break;
                case "ABRIL":
                    mes = "April";
                    break;
                case "MAIO":
                    mes = "May";
                    break;
                case "JUNHO":
                    mes = "June";
                    break;
                case "JULHO":
                    mes = "July";
                    break;
                case "AGOSTO":
                    mes = "August";
                    break;
                case "SETEMBRO":
                    mes = "September";
                    break;
                case "OUTUBRO":
                    mes = "October";
                    break;
                case "NOVEMBRO":
                    mes = "November";
                    break;
                case "DEZEMBRO":
                    mes = "December";
                    break;
                default:
                    mes = "VAZIO";
                    break;
                
            }

            return mes.ToUpper();
        }
    }
}
