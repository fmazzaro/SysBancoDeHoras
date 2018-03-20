using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Negocio;
using ObjetoTransferencia;
namespace FrmPrincipal
{
    public partial class frmHoraFuncionarioAlterar : Form
    {
        //string nomeLoja, nomeFunc;
        HoraFuncionarioNegocio hfn;
        HoraFuncionario horaFunc;
        public frmHoraFuncionarioAlterar(HoraFuncionario hf, AcaoNaTela acaoNaTela)
        {
            InitializeComponent();

            if(acaoNaTela == AcaoNaTela.Alterar)
            {
                hfn = new HoraFuncionarioNegocio();
                horaFunc = new HoraFuncionario();
                horaFunc = hf;

                txtNomeLoja.Text = hfn.NomeDaLojaIdFunc(hf.idfunc);
                txtNomeFunc.Text = hfn.NomeFuncionarioIdFunc(hf.idfunc);

                dtpDataEntrada.Value = hf.data_entrada;
                txtEntrada.Text = hf.entrada.ToString();
                txtIdaAlmoco.Text = hf.ida_almoco.ToString();
                txtVoltaAlmoco.Text = hf.volta_almoco.ToString();
                txtSaida.Text = hf.saida.ToString();

                if (hf.folga)
                    rdbSim.Checked = true;
                else
                    rdbNao.Checked = true;

                if (hf.qtdHora % 60 == 0)
                    cmbHoraUtil.Text = "7";
                else
                    cmbHoraUtil.Text = "6";

                txtObs.Text = hf.obs;
            }
                   

            
        }

        private void frmHoraFuncionarioAlterar_Load(object sender, EventArgs e)
        {
            txtNomeLoja.Enabled = false;
            txtNomeFunc.Enabled = false;
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtEntrada.Text != "")
                    horaFunc.entrada = TimeSpan.Parse(txtEntrada.Text);
                if (txtIdaAlmoco.Text != "")
                    horaFunc.ida_almoco = TimeSpan.Parse(txtIdaAlmoco.Text);
                if (txtVoltaAlmoco.Text != "")
                    horaFunc.volta_almoco = TimeSpan.Parse(txtVoltaAlmoco.Text);
                if (txtSaida.Text != "")
                    horaFunc.saida = TimeSpan.Parse(txtSaida.Text);

                horaFunc.qtdHora = Convert.ToInt32(cmbHoraUtil.Text);

                if(rdbNao.Checked || rdbSim.Checked)
                {
                    if (rdbNao.Checked)
                        horaFunc.folga = false;
                    else
                        horaFunc.folga = true;
                }

                horaFunc.obs = txtObs.Text;

                hfn = new HoraFuncionarioNegocio();

                hfn.AlterarHoraFuncionario(horaFunc);

                MessageBox.Show("Funcionário alterado com sucesso!");

                Close();
            }
            catch (Exception ex)
            {

                MessageBox.Show("Erro: " + ex.Message);
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
