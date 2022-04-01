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
    public partial class FrmFuncionarioCadastrar : Form
    {
        FuncionarioNegocio funcionarioNegocio;
        Funcionario funcGerenteCombo;
        public FrmFuncionarioCadastrar()
        {
            InitializeComponent();
        }

        private void FrmFuncionarioAlterarCadastrar_Load(object sender, EventArgs e)
        {
            txtIdFunc.Enabled = false;
            rdtDesativado.Enabled = false;
            rdtAtivo.Checked = true;
           // cmbGerente.Enabled = false;
        }

        private void cmbLoja_Click(object sender, EventArgs e)
        {
            try
            {
                LojaNegocio lojaNegocio = new LojaNegocio();

                //funcionarioNegocio = new FuncionarioNegocio();

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

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                    Funcionario funcionario = new Funcionario();
                    funcionarioNegocio = new FuncionarioNegocio();

                    funcionario.id_Gerente = 2;
                    funcionario.nome = txtNome.Text;
                    funcionario.cpf = txtCpf.Text;
                    funcionario.funcao = cmbFuncao.Text;
                    funcionario.id_Loja = Convert.ToInt32(cmbLoja.SelectedValue);


                    if (rdtFeminino.Checked == true || rdtMasculino.Checked == true)
                    {
                        if (rdtFeminino.Checked == true)
                            funcionario.sexo = "F";
                        else
                            funcionario.sexo = "M";
                    }

                    funcionario.dataContrato = dtpDataContrato.Value;

                    funcionarioNegocio.InserirFuncionario(funcionario);

                    MessageBox.Show("Funcionário cadastrado com sucesso!");

                    DialogResult resultado = MessageBox.Show("Deseja Cadastrar outro funcionário?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (resultado == DialogResult.No)
                        LimparCampos();

 


            }
            catch (Exception erro)
            {
                
                MessageBox.Show("Erro: " + erro.Message);
            }
            

        }

        private void LimparCampos()
        {
            txtCpf.Clear();
            txtNome.Clear();
            cmbFuncao.Text = "";
            cmbGerente.Text = "";
            cmbLoja.Text = "";
        }

        private void cmbGerente_Click(object sender, EventArgs e)
        {

        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
