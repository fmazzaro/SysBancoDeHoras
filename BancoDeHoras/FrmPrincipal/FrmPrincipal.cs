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
    public partial class FrmPrincipal : Form
    {
        public FrmPrincipal()
        {
            InitializeComponent();

            
        }

        private void menuSair_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Até mais " + UsuarioConectado.usuario.nomeUsuario);
            Close();
        }

        private void FrmPrincipal_Load(object sender, EventArgs e)
        {
            

            lblNomeUsuario.Text = "Olá " + UsuarioConectado.usuario.nomeUsuario;
            if(UsuarioConectado.usuario.perfil != "A")
            {
                menuLoja.Enabled = false;
                menuLogin.Enabled = false;
                menuFuncCadastro.Enabled = false;
                menuFuncHoraAltCadExc.Enabled = false;
                menuFuncAltConsExc.Enabled = false;

            }

            
        }

        private void lojaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmLojaCrud frmLojaCrud = new FrmLojaCrud();
            frmLojaCrud.ShowDialog();
        }

        private void menuCadastroFunc_Click(object sender, EventArgs e)
        {
            FrmFuncionarioCadastrar frmFuncionarioAlterarCadastrar = new FrmFuncionarioCadastrar();
            frmFuncionarioAlterarCadastrar.ShowDialog();
        }

        private void alterarConsultarExcluirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmFuncionarioConsultarExcluir frmFuncionarioConsultarExcluir = new FrmFuncionarioConsultarExcluir();
            frmFuncionarioConsultarExcluir.ShowDialog();
        }

        private void loginToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmLoginCrud frmLoginCrud = new FrmLoginCrud();
            frmLoginCrud.ShowDialog();
        }

        private void alterarCadastrarHoraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmHoraFuncionarioAlterarCadastrar frmHoraFuncionarioAlterarCadastrar = new FrmHoraFuncionarioAlterarCadastrar();
            frmHoraFuncionarioAlterarCadastrar.ShowDialog();
        }

        private void consultarExcluirHoraToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmHoraFuncionarioConsultar frmHoraFuncionarioConsultar = new FrmHoraFuncionarioConsultar();
            frmHoraFuncionarioConsultar.ShowDialog();
        }
    }
}
