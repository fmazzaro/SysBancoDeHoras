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

namespace FrmPrincipal
{
    public partial class FrmLogin : Form
    {
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            UsuarioNegocio usuarioNegocio = new UsuarioNegocio();           

            try
            {
                bool logado = usuarioNegocio.Logar(txtLogin.Text, txtSenha.Text);

                if (logado)
                {
                    MessageBox.Show("Bem vindo ao sistema");
                    FrmPrincipal frmPrincipal = new FrmPrincipal();
                    frmPrincipal.ShowDialog();
                    Close();

                }
                    
                else
                    MessageBox.Show("Login ou senha inválido");
            }
            catch (Exception erro)
            {

                MessageBox.Show("Erro: " + erro.Message);
            }

            

            
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            txtLogin.Text = ".papoula";
            
        }
    }
}
