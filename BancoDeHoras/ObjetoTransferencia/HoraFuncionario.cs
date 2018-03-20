using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjetoTransferencia
{
    public class HoraFuncionario
    {
       
        public DateTime data_entrada { get; set; }
        public TimeSpan entrada { get; set; }
        public TimeSpan ida_almoco { get; set; }
        public TimeSpan volta_almoco { get; set; }
        public TimeSpan saida { get; set; }
        public string obs { get; set; }
        public bool folga { get; set; }
        public int qtdHora { get; set; }
        public int id_HF { get; set; }
        public int idfunc { get; set; }
    }
}
