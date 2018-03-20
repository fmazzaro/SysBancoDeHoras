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
    public partial class FrmFuncionarioAlterar : Form
    {
        FuncionarioNegocio funcionarioNegocio ;
        Funcionario funcGerenteCombo;
        
        public FrmFuncionarioAlterar(Funcionario funcionario, AcaoNaTela acaoNaTela)
        {
            InitializeComponent();

            if(acaoNaTela == AcaoNaTela.Alterar)
            {
                funcionarioNegocio = new FuncionarioNegocio();
                LojaNegocio lojaNegocio = new LojaNegocio();

                txtIdPessoa.Text = funcionario.id_Pessoa.ToString();
                txtIdFunc.Text = funcionario.id_Func.ToString();
                txtCPF.Text = funcionario.cpf.ToString();
                txtNome.Text = funcionario.nome.ToString();
                                
                if (funcionario.sexo == "M")
                    rdbMasculino.Checked = true;
                else
                    rdbFeminino.Checked = true;

                cmbFuncao.Text = funcionario.funcao.ToString();

                if (funcionario.ativo)
                    rdbAtivado.Checked = true;
                else
                    rdbDesativado.Checked = true;

                if(cmbFuncao.Text.ToUpper() != "GERENTE")
                    cmbGerente.Text = funcionarioNegocio.SelecionarFuncionarioIdPessoaParaAlteracao(funcionario.id_Func);

                cmbLoja.Text = lojaNegocio.SelecionarNomeLojaPorId(funcionario.id_Loja);

                dtpDataContrato.Value = funcionario.dataContrato;
            }

        }

        private void FrmFuncionarioAlterar_Load(object sender, EventArgs e)
        {
            txtIdFunc.Enabled = false;
            txtIdPessoa.Enabled = false;
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

        private void cmbGerente_Click(object sender, EventArgs e)
        {
            try
            {
                funcionarioNegocio = new FuncionarioNegocio();

                funcGerenteCombo = funcionarioNegocio.NomeGerenteCombo(Convert.ToInt32(cmbLoja.SelectedValue));
                // MessageBox.Show("erro " + funcionarioNegocio.NomeGerenteCombo(Convert.ToInt32(cmbLoja.SelectedValue)));
                cmbGerente.Text = funcGerenteCombo.nome;
            }
            catch (Exception)
            {

                MessageBox.Show("erro: Loja sem gerente");
                cmbGerente.Text = "";
            }
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            try
            {
                Funcionario funcionario = new Funcionario();
                LojaNegocio lojaNegocio = new LojaNegocio();
                FuncionarioNegocio funcNego = new FuncionarioNegocio();

                funcionario.id_Func = Convert.ToInt32(txtIdFunc.Text);
                funcionario.nome = txtNome.Text;
                funcionario.cpf = txtCPF.Text;
                funcionario.funcao = cmbFuncao.Text;
                
                if (Convert.ToInt32(cmbLoja.SelectedValue) <= 0)
                    funcionario.id_Loja = lojaNegocio.SelecionarLojaPorNomeDevolvendoId(cmbLoja.Text);
                 else
                    funcionario.id_Loja = Convert.ToInt32(cmbLoja.SelectedValue);
                    
                
                if (Convert.ToInt32(cmbGerente.SelectedValue) <= 0)
                    funcionario.id_Gerente = funcNego.SelecionarGerentePorNomeDevolvendoId(funcionario.id_Loja);
                else
                    funcionario.id_Gerente = Convert.ToInt32(cmbGerente.SelectedValue);
                    
                if (rdbFeminino.Checked == true || rdbMasculino.Checked == true)
                {
                    if (rdbFeminino.Checked == true)
                        funcionario.sexo = "F";
                    else
                        funcionario.sexo = "M";
                }

                if (rdbAtivado.Checked == true || rdbDesativado.Checked == true)
                {
                    if (rdbAtivado.Checked == true)
                        funcionario.ativo = true;
                    else
                        funcionario.ativo = false;
                }

                funcionario.dataContrato = dtpDataContrato.Value;

                funcNego.AlterarFuncionario(funcionario);

                MessageBox.Show("Funcionário alterado com sucesso!");

                Close();
                

            }
            catch (Exception erro)
            {

                MessageBox.Show("Erro: " + erro.Message);
            }
        }
    }
}
