using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjetoTransferencia
{
    public class Funcionario : Pessoa
    {
        public int id_Func { get; set; }
        public string funcao { get; set; }
        public int id_Gerente { get; set; }
        public bool ativo { get; set; }
        public int id_Loja { get; set; }       
        public DateTime dataContrato { get; set; }
    }
}
