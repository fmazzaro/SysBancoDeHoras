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
    public partial class FrmFuncionarioConsultarExcluir : Form
    {
        FuncionarioNegocio funcionarioNegocio;
        
       // bool AtivoDesativo;
        public FrmFuncionarioConsultarExcluir()
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

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            try
            {
                bool AtivoDesativo = false;
                
                if (!rdbDesativado.Checked)
                    AtivoDesativo = true;

                if (cmbLoja.Text == "")
                    MessageBox.Show("Escolha uma loja");
                else
                    AtualizarGrid(txtNome.Text, AtivoDesativo, Convert.ToInt32(cmbLoja.SelectedValue));
                    

            }
            catch (Exception ex)
            {

                MessageBox.Show("Erro: " + ex.Message);
            }
            

        }

        public void AtualizarGrid(string nome, bool ativo, int idLoja)
        {
            List<Funcionario> listaFuncionario = new List<Funcionario>();
            funcionarioNegocio = new FuncionarioNegocio();
            
            listaFuncionario = funcionarioNegocio.SelecionarFuncionarioPorNome(nome, ativo, idLoja);

            dgvPrincipal.DataSource = null;
            dgvPrincipal.DataSource = listaFuncionario;

           
            dgvPrincipal.Columns[0].Visible = false;            
            dgvPrincipal.Columns[2].Visible = false;
            dgvPrincipal.Columns[3].Visible = false;
            dgvPrincipal.Columns[4].Visible = false;
            dgvPrincipal.Columns[5].Visible = false;

            /*
                [0] id_Func
                [1] funcao
                [2] id_Gerente
                [3] ativo
                [4] id_Loja
                [5] id_Pessoa
                [6] cpf
                [7] nome
                [8] sexo
             */
            dgvPrincipal.Update();
            dgvPrincipal.Refresh();

            
            
        }
        private void btnAlterar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvPrincipal.SelectedRows.Count == 0)
                    MessageBox.Show("Nenhum Funcionário selecionado");
                else
                {
                    Funcionario funcionario = (dgvPrincipal.SelectedRows[0].DataBoundItem as Funcionario);
                    FrmFuncionarioAlterar frmFuncionarioAlterar = new FrmFuncionarioAlterar(funcionario, AcaoNaTela.Alterar);
                    frmFuncionarioAlterar.ShowDialog();
                                        
                    AtualizarGrid(txtNome.Text, true, funcionario.id_Loja);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Erro " + ex.Message);
            }
        }

        private void FrmFuncionarioConsultarExcluir_Load(object sender, EventArgs e)
        {
            rdbAtivado.Checked = true;
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvPrincipal.SelectedRows.Count == 0)
                    MessageBox.Show("Nenhum Funcionário selecionado");
                else
                {

                    DialogResult resultado = MessageBox.Show("Deseja excluir?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if(resultado == DialogResult.Yes)
                    {
                        Funcionario funcionario = (dgvPrincipal.SelectedRows[0].DataBoundItem as Funcionario);
                        funcionarioNegocio.ExcluirFuncionario(funcionario);

                        MessageBox.Show("Funcionário Excluido com sucesso! ");
                        AtualizarGrid(txtNome.Text, true, Convert.ToInt32(cmbLoja.SelectedValue));
                    }
                    
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Erro " + ex.Message);
            }

            
            
        }
    }
}
