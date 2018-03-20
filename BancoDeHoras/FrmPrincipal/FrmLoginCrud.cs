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
    public partial class FrmLoginCrud : Form
    {
        FuncionarioNegocio funcionarioNegocio;
        HoraFuncionarioNegocio horaFuncionarioNegocio;
        LoginNegocio loginNegocio;
        private bool simNao = false;
        public FrmLoginCrud()
        {
            InitializeComponent();
        }

        private void cmbLoja_Click(object sender, EventArgs e)
        {
            try
            {
                LojaNegocio lojaNegocio = new LojaNegocio();

                funcionarioNegocio = new FuncionarioNegocio();

                cmbLoja.DataSource = lojaNegocio.ListarLojasCombo();
                cmbLoja.DisplayMember = "Nome";
                cmbLoja.ValueMember = "Id_Loja";
                cmbLoja.SelectedValue = "Id_Loja";


            }
            catch (Exception ex)
            {

                MessageBox.Show("Erro: " + ex.Message);
            }
        }

        private void cmbFunc_Click(object sender, EventArgs e)
        {
            try
            {
                bool ativadoDesativado = false;

                if (!rdbDesativado.Checked)
                    ativadoDesativado = true;

                if (cmbLoja.Text == "")
                {
                    MessageBox.Show("Escolha uma loja ");
                }
                else
                {

                    horaFuncionarioNegocio = new HoraFuncionarioNegocio();


                    cmbFunc.DataSource = horaFuncionarioNegocio.ListaComboFuncionarioDaLojaAtivadoDesativado(Convert.ToInt32(cmbLoja.SelectedValue), ativadoDesativado);
                    cmbFunc.DisplayMember = "Nome";
                    cmbFunc.ValueMember = "Id_Func";
                    cmbFunc.SelectedValue = "Id_Func";
                }


            }
            catch (Exception ex)
            {

                MessageBox.Show("Erro: " + ex.Message);
            }
        }

        private void FrmLoginCrud_Load(object sender, EventArgs e)
        {
            txtIdLogin.Enabled = false;
            txtIdFunc.Enabled = false;
            rdbAtivo.Checked = true;
            BloquearCampos();
            btnCadastrar.Enabled = false;
            rdbSim.Checked = true;

        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {
            try
            {
                InserirLogin();
                               
                DialogResult resultado = MessageBox.Show("Cadastrar uma outro Login?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (resultado == DialogResult.No)
                {
                    LimparCampos();
                    BloquearCampos();
                    btnCadastrar.Enabled = false;
                }

                AtualizarGrid("", true);
              
            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro: " + erro.Message);
            }

        }

        private void InserirLogin()
        {
            Login login = new Login();
            loginNegocio = new LoginNegocio();

            if (cmbFunc.Text == "")
                MessageBox.Show("Por favor, Insira o funcionario");
            else
            {
                if (txtUsuario.Text == "" || txtSenha.Text == "" || cmbPerfil.Text == "")
                    MessageBox.Show("Preencha o login, senha ou Perfil");
                else
                {
                    
                    login.idFunc = Convert.ToInt32(cmbFunc.SelectedValue);
                    login.usuario = txtUsuario.Text + ".papoula";
                    login.senha = txtSenha.Text;
                    login.perfil = cmbPerfil.Text;
                    login.ativo = true;

                    loginNegocio.InserirLogin(login);

                    MessageBox.Show("Login Cadastrado com sucesso!");
                }
            }

        }

        public void LimparCampos()
        {
            txtNomeFunc.Clear();
            txtSenha.Clear();
            txtUsuario.Clear();
            cmbFunc.Text = "";
            cmbLoja.Text = "";
            cmbPerfil.Text= "";
            txtIdFunc.Text = "";
            txtIdLogin.Text = "";
        }

        public void BloquearCampos()
        {
            //txtNome.Enabled = false;
            txtSenha.Enabled = false;
            txtUsuario.Enabled = false;
            cmbFunc.Enabled = false;
            cmbLoja.Enabled = false;
            cmbPerfil.Enabled = false;


        }

        public void LiberarCampos()
        {
            txtNomeFunc.Enabled = true;
            txtSenha.Enabled = true;
            txtUsuario.Enabled = true;
            cmbFunc.Enabled = true;
            cmbLoja.Enabled = true;
            cmbPerfil.Enabled = true;


        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            LiberarCampos();
            LimparCampos();
            rdbAtivo.Checked = true;
            rdbAtivo.Enabled = true;
            rdbDesativado.Enabled = false;
            btnCadastrar.Enabled = true;
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            LiberarCampos();
            try
            {
                if (dgvPrincipal.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Nenhuma Login Selecionado.");
                }
                else
                {
                    loginNegocio = new LoginNegocio();

                    Login login = new Login();

                    if (txtIdLogin.Text == "")
                        MessageBox.Show("Não foi possivel alterar.");
                    else
                    {
                        simNao = false;
                        login.idLogin = int.Parse(txtIdLogin.Text);
                        login.idFunc = int.Parse(txtIdFunc.Text);
                        login.usuario = txtUsuario.Text;
                        login.senha = txtSenha.Text;
                        login.perfil = cmbPerfil.Text;
                                                
                        if (!rdbDesativado.Checked)
                            simNao = true;

                        login.ativo = simNao;

                        loginNegocio.AlterarLogin(login);
                    }

                    AtualizarGrid("", true);

                    LimparCampos();
                    BloquearCampos();

                   
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Erro: " + ex.Message);
            }
        }

        public void AtualizarGrid(string nome, bool ativo)
        {
            List<Login> listLogin = new List<Login>();
            loginNegocio = new LoginNegocio();

            listLogin = loginNegocio.SelecionarLoginPorNome(nome, ativo);

            dgvPrincipal.DataSource = null;
            dgvPrincipal.DataSource = listLogin;

            dgvPrincipal.Update();
            dgvPrincipal.Refresh();
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (dgvPrincipal.SelectedRows.Count == 0)
            {
                MessageBox.Show("Nenhuma Login Selecionada.");
            }
            else
            {

                if (txtIdLogin.Text == "")
                    MessageBox.Show("Não foi possivel excluir.");
                else
                {
                    DialogResult resultado = MessageBox.Show("Deseja excluir?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (resultado == DialogResult.Yes)
                    {
                        try
                        {
                            Login login = new Login();
                            loginNegocio = new LoginNegocio();

                            login = (dgvPrincipal.SelectedRows[0].DataBoundItem as Login);

                            loginNegocio.ExcluirLogin(login);

                            MessageBox.Show("Funcioário Cód " + login.idFunc + " excluido com sucesso!");

                            AtualizarGrid("", true);
                        }
                        catch (Exception erro)
                        {

                            MessageBox.Show("Erro. " + erro.Message);
                        }
                    }
                }
            }
        }

        private void dgvPrincipal_SelectionChanged(object sender, EventArgs e)
        {
            
            if (dgvPrincipal.SelectedRows.Count > 0)
            {
                LiberarCampos();
                loginNegocio = new LoginNegocio();
                Login login = new Login();
                login = (dgvPrincipal.SelectedRows[0].DataBoundItem as Login);

                txtIdLogin.Text = login.idLogin.ToString();
                txtIdFunc.Text = login.idFunc.ToString();

                cmbFunc.Text = login.nomeFunc;
                cmbFunc.SelectedValue = login.idFunc;

                txtUsuario.Text = login.usuario;
                txtSenha.Text = login.senha;
                cmbPerfil.Text = login.perfil;
                cmbLoja.Text = login.loja;

                cmbFunc.Enabled = false;
                cmbLoja.Enabled = false;
                
                if (login.ativo)
                    rdbAtivo.Checked = true;
                else
                    rdbDesativado.Checked = true;
                
            }
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            string nomeFunc = txtNomeFunc.Text;

            BloquearCampos();
            LimparCampos();
            try
            {
                simNao = false;

                if (!rdbNao.Checked)
                    simNao = true;

                AtualizarGrid(nomeFunc, simNao);
            }
            catch (Exception erro)
            {
                MessageBox.Show("Erro: " + erro.Message);

            }
        }
    }
}
