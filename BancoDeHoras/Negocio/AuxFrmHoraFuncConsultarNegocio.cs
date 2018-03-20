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
    public class AuxFrmHoraFuncConsultarNegocio
    {
        private string _SQL;
        private SqlCommand cmd;
        private SqlDataReader dr;

        public AuxFrmHoraFuncionarioConsultar GetNomeLoja_Id(int idFunc)
        {
            AuxFrmHoraFuncionarioConsultar ax = new AuxFrmHoraFuncionarioConsultar();
            _SQL = @"select 
                    IdLoja, Loja
                    from VW_FUNCIONARIO_COMPLETO
                    where Id_Func = @idFunc";

            cmd = new SqlCommand();
            cmd.Connection = ConexaoBancoSQLServer.Conectar();

            cmd.Parameters.Add("@idFunc", SqlDbType.Int).Value = idFunc;

            cmd.CommandText = _SQL;
            dr = cmd.ExecuteReader();
            //vai retornar apneas um registro, devido o filtro where a cima
            if (dr.Read())
            {
                ax.idLoja = int.Parse(dr["IdLoja"].ToString());
                ax.nomeLoja = dr["Loja"].ToString();
            }


            return ax;
        }
    }
}
