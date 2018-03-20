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
    public partial class FrmLojaCrud : Form
    {
        private Loja loja;
        private LojaNegocio lojaNegocio;
        private bool simNao = false;
        public FrmLojaCrud()
        {
            InitializeComponent();
        }

        

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void FrmLojaCrud_Load(object sender, EventArgs e)
        {
            txtIdLoja.Enabled = false;
            BloquearCampos();
            btnCadastrar.Enabled = false;
            rbtSim.Checked = true;
        }

        private void btnCadastrar_Click(object sender, EventArgs e)
        {

            try
            {
                InserirLoja();
                MessageBox.Show("Loja Cadastrada com sucesso!");

                DialogResult resultado = MessageBox.Show("Cadastrar uma outra Loja?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

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

        private void BloquearCampos()
        {
            txtCNPJ.Enabled = false;
            txtEndereco.Enabled = false;
            txtNomeLoja.Enabled = false;
            txtRazaoSocial.Enabled = false;
            rbtAtivo.Enabled = false;
            rbtDesativado.Enabled = false;
        }

        private void LiberarCampos()
        {
            txtCNPJ.Enabled = true;
            txtEndereco.Enabled = true;
            txtNomeLoja.Enabled = true;
            txtRazaoSocial.Enabled = true;
            rbtAtivo.Enabled = true;
            rbtDesativado.Enabled = true;
        }
        private void LimparCampos()
        {
            txtCNPJ.Clear();
            txtEndereco.Clear();
            txtNomeLoja.Clear();
            txtRazaoSocial.Clear();
            txtIdLoja.Clear();
            rbtAtivo.Checked = false;
            rbtDesativado.Checked = false;
        }
        private void InserirLoja()
        {
            loja = new Loja();
            lojaNegocio = new LojaNegocio();

            loja.cnpj = txtCNPJ.Text;
            loja.endereco = txtEndereco.Text;

            if (txtNomeLoja.Text == "")
                txtNomeLoja.Text = null;
            else
                loja.nome = txtNomeLoja.Text;

            loja.razao = txtRazaoSocial.Text;
            loja.ativo = true;

            lojaNegocio.InserirLoja(loja);
        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            LiberarCampos();
            LimparCampos();
            rbtAtivo.Checked = true;
            rbtAtivo.Enabled = false;
            rbtDesativado.Enabled = false;
            btnCadastrar.Enabled = true;
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            BloquearCampos();
            LimparCampos();
            try
            {
                simNao = false;
                if (!rbtNao.Checked)
                    simNao = true;

                AtualizarGrid(txtPesquisarNomeLoja.Text, simNao);
            }
            catch (Exception erro)
            {

                MessageBox.Show("Erro: " + erro.Message);
            }

            
        }

        public void AtualizarGrid(string nomeLoja, bool ativo)
        {
            List<Loja> listaLoja = new List<Loja>();
            lojaNegocio = new LojaNegocio();
            
            listaLoja = lojaNegocio.SelecionarLojaPorNome(nomeLoja, ativo);

            dgvPrincipal.DataSource = null;
            dgvPrincipal.DataSource = listaLoja;

            dgvPrincipal.Update();
            dgvPrincipal.Refresh();
        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            LiberarCampos();
            try
            {
                if (dgvPrincipal.SelectedRows.Count == 0)
                {
                    MessageBox.Show("Nenhuma Loja Selecionada.");
                }
                else
                {
                    lojaNegocio = new LojaNegocio();

                    loja = new Loja();

                    if (txtIdLoja.Text == "")
                        MessageBox.Show("Não foi possivel alterar.");
                    else
                    {
                        simNao = false;
                        loja.id_Loja = int.Parse(txtIdLoja.Text);
                        loja.nome = txtNomeLoja.Text;
                        loja.razao = txtRazaoSocial.Text;
                        loja.endereco = txtEndereco.Text;
                        loja.cnpj = txtCNPJ.Text;

                        if (!rbtDesativado.Checked)
                            simNao = true;

                        loja.ativo = simNao;

                        lojaNegocio.AlterarLoja(loja);
                    }

                    AtualizarGrid("", true);

                    LimparCampos();
                    BloquearCampos();

                    /*
                   // pegando o valor do grid
                    MessageBox.Show(dgvPrincipal.SelectedCells[0].Value.ToString());
                    MessageBox.Show(dgvPrincipal.SelectedCells[1].Value.ToString());
                    MessageBox.Show(dgvPrincipal.SelectedCells[2].Value.ToString());
                    //dgvPrincipal.Columns["razao"].Visible = false;
                   */

                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Erro: " + ex.Message);
            }

            
        }

        private void dgvPrincipal_SelectionChanged(object sender, EventArgs e)
        {

            
            if(dgvPrincipal.SelectedRows.Count > 0)
            {
                LiberarCampos();

                loja = new Loja();
                loja = (dgvPrincipal.SelectedRows[0].DataBoundItem as Loja);

                txtIdLoja.Text = loja.id_Loja.ToString();
                txtNomeLoja.Text = loja.nome;
                txtRazaoSocial.Text = loja.razao;
                txtCNPJ.Text = loja.cnpj;
                txtEndereco.Text = loja.endereco;

                if (loja.ativo)
                    rbtAtivo.Checked = true;
                else
                    rbtDesativado.Checked = true;
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if (dgvPrincipal.SelectedRows.Count == 0)
            {
                MessageBox.Show("Nenhuma Loja Selecionada.");
            }
            else
            {

                if (txtIdLoja.Text == "")
                    MessageBox.Show("Não foi possivel excluir.");
                else
                {
                    DialogResult resultado = MessageBox.Show("Deseja excluir?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if(resultado == DialogResult.Yes)
                    {
                        try
                        {
                            loja = new Loja();
                            lojaNegocio = new LojaNegocio();

                            loja = (dgvPrincipal.SelectedRows[0].DataBoundItem as Loja);

                            lojaNegocio.ExcluirLoja(loja);

                            MessageBox.Show("Código " + loja.id_Loja + " excluido com sucesso!");

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
    }
}
