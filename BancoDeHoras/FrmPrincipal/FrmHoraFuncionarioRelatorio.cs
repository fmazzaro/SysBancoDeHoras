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
    public partial class FrmHoraFuncionarioConsultar : Form
    {
        FuncionarioNegocio funcionarioNegocio;
        HoraFuncionarioNegocio horaFuncionarioNegocio;
        List<HoraFuncionario> listaHoraFuncionario;
        int idLoja = 0;
        public FrmHoraFuncionarioConsultar()
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

        private void cmbFuncionario_Click(object sender, EventArgs e)
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

                    if (UsuarioConectado.usuario.perfil != "A") {
                        cmbFunc.DataSource = horaFuncionarioNegocio.ListaComboFuncionarioDaLojaAtivadoDesativado(idLoja, ativadoDesativado);
                        
                    }
                    else
                    {
                        cmbFunc.DataSource = horaFuncionarioNegocio.ListaComboFuncionarioDaLojaAtivadoDesativado(Convert.ToInt32(cmbLoja.SelectedValue), ativadoDesativado);
                        
                    }

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

        private void FrmHoraFuncionarioConsultar_Load(object sender, EventArgs e)
        {
            rdbAtivo.Checked = true;
            txtSaldoFunc.Enabled = false;
            txtSaldoMes.Enabled = false;

            if(UsuarioConectado.usuario.perfil != "A")
            {
                AuxFrmHoraFuncConsultarNegocio auxNeg = new AuxFrmHoraFuncConsultarNegocio();
                AuxFrmHoraFuncionarioConsultar aux = new AuxFrmHoraFuncionarioConsultar();

                aux = auxNeg.GetNomeLoja_Id(UsuarioConectado.usuario.id_Func);
                cmbLoja.Enabled = false;
                cmbLoja.Text = aux.nomeLoja;
                idLoja = aux.idLoja;
                btnAlterar.Enabled = false;
                btnExcluir.Enabled = false;
                
            }
            
        }

        private void btnPesquisar_Click(object sender, EventArgs e)
        {
            //HoraFuncionarioNegocio
            // GridCadastroHoras(DateTime dataInicio, DateTime fimDoMes, int idFunc)
            try
            {
                if(cmbFunc.Text == "" || cmbLoja.Text == "")
                {
                    MessageBox.Show("Escolha a loja ou funcionário");
                }
                else
                {
                    
                    AtualizarGrid(dtpInicio.Value, dtpFim.Value, Convert.ToInt32(cmbFunc.SelectedValue));
                    atulazaHora();
                }
                
            }
            catch (Exception ex)
            {

                MessageBox.Show("Erro: " + ex.Message);
            }
            
        }

        public void AtualizarGrid(DateTime dataInicio, DateTime dataFim, int idFunc)
        {
            try
            {
                listaHoraFuncionario = new List<HoraFuncionario>();
                listaHoraFuncionario = horaFuncionarioNegocio.GridCadastroHoras(dataInicio, dataFim, idFunc);

                dgvPrincipal.DataSource = null;
                dgvPrincipal.DataSource = listaHoraFuncionario;
                //dgvPrincipal.Columns[0].Visible = false;
                //dgvPrincipal.Columns[1].Visible = false;

                dgvPrincipal.Update();
                dgvPrincipal.Refresh();

            }
            catch (Exception ex)
            {

                MessageBox.Show("Erro " + ex.Message);
            }

        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvPrincipal.SelectedRows.Count == 0)
                    MessageBox.Show("Nenhum Funcionário selecionado. No Grig...");
                else
                {
                    HoraFuncionario hf = (dgvPrincipal.SelectedRows[0].DataBoundItem as HoraFuncionario);
                    frmHoraFuncionarioAlterar frmHoraFuncionarioAlterar = new frmHoraFuncionarioAlterar(hf, AcaoNaTela.Alterar);
                    frmHoraFuncionarioAlterar.ShowDialog();
                    
                    AtualizarGrid(dtpInicio.Value, dtpFim.Value, Convert.ToInt32(cmbFunc.SelectedValue));
                    atulazaHora();

                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Erro: " + ex.Message);
            }
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvPrincipal.SelectedRows.Count == 0)
                    MessageBox.Show("Nenhum Funcionário selecionado. No Grig...");
                else
                {
                    DialogResult resultado = MessageBox.Show("Deseja excluir?", "Pergunta", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                    if (resultado == DialogResult.Yes)
                    {
                        horaFuncionarioNegocio = new HoraFuncionarioNegocio();

                        HoraFuncionario hf = (dgvPrincipal.SelectedRows[0].DataBoundItem as HoraFuncionario);
                        horaFuncionarioNegocio.ExcluirHoraFuncionario(hf);
                        MessageBox.Show("Funcionario excluido com sucesso!");

                        AtualizarGrid(dtpInicio.Value, dtpFim.Value, Convert.ToInt32(cmbFunc.SelectedValue));
                        atulazaHora();
                    }

                }
            }
            catch (Exception ex)
            {

                MessageBox.Show("Erro: " + ex.Message);
            }
        }

        public void atulazaHora()
        {
            int ano = dtpInicio.Value.Year;
            int idFunc = Convert.ToInt32(cmbFunc.SelectedValue);
            txtSaldoFunc.Text = horaFuncionarioNegocio.SaldoFuncionarioTotal(idFunc);
            txtSaldoMes.Text = horaFuncionarioNegocio.SaldoFuncionarioMesCadastro(idFunc, GetNomeMes(dtpInicio.Value), ano);
            //MessageBox.Show("Mês -> " + GetNomeMes(dtpInicio.Value) + " Id Func " + idFunc);
        }

        public string GetNomeMes(DateTime data)
        {
            string nomeMes = "";
            int mes = 0;

            mes = int.Parse(dtpInicio.Value.Month.ToString());
            switch (mes)
            {
                case 1:
                    nomeMes = "JANEIRO";
                    break;
                case 2:
                    nomeMes = "FEVEREIRO";
                    break;
                case 3:
                    nomeMes = "MARÇO";
                    break;
                case 4:
                    nomeMes = "ABRIL";
                    break;
                case 5:
                    nomeMes = "MAIO";
                    break;
                case 6:
                    nomeMes = "JUNHO";
                    break;
                case 7:
                    nomeMes = "JULHO";
                    break;
                case 8:
                    nomeMes = "AGOSTO";
                    break;
                case 9:
                    nomeMes = "SETEMBRO";
                    break;
                case 10:
                    nomeMes = "OUTUBRO";
                    break;
                case 11:
                    nomeMes = "NOVEMBRO";
                    break;
                case 12:
                    nomeMes = "DEZEMBRO";
                    break;
                default:
                    nomeMes = "VAZIO";
                    MessageBox.Show("Algum parametro errado...");
                    break;
            }

            return nomeMes;
        }

        private void btnImprimir_Click(object sender, EventArgs e)
        {
            printPreviewDialog1.ShowDialog();
        }

        private void printPreviewDialog1_Load(object sender, EventArgs e)
        {
            printPreviewDialog1.WindowState = FormWindowState.Maximized;
        }

        private string GetDataSemHora(DateTime data)
        {
            string d = data.ToString();
            d = d.Replace(' ', ';');
            string[] x = new string[0];
            x = d.Split(';');

            return x[0];
        }
        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            try
            {
                Font font = new Font("Arial", 15, FontStyle.Bold, GraphicsUnit.Pixel);
                Font font2 = new Font("Arial", 12, FontStyle.Regular, GraphicsUnit.Pixel);


                // top da págima ( razão social )
                e.Graphics.DrawString(cmbLoja.Text, font, Brushes.Black, 200, 50);


                e.Graphics.DrawString("BANCO DE HORAS DE " + GetNomeMes(dtpInicio.Value) + " " + dtpInicio.Value.Year, font, Brushes.Black, 200, 72);


                //NOME FUNCIONARIO
                e.Graphics.DrawString("FUNCIONARIO    : ", font, Brushes.Black, 30, 102);
                e.Graphics.DrawString(cmbFunc.Text, font, Brushes.Black, 200, 102);


                //FIM NOME FUNCIONARIO

                //CABEÇALHO DOS HORARIOS
                //data - entrada - (almoco -saída - entrada) - saida - Crédito - observação

                //titulos
                e.Graphics.DrawString("     DATA   ", font2, Brushes.Black, 30, 152);
                e.Graphics.DrawString("ENTRADA", font2, Brushes.Black, 115, 152);
                e.Graphics.DrawString("     ALMOÇO   ", font2, Brushes.Black, 210, 132);
                e.Graphics.DrawString("SAÍDA", font2, Brushes.Black, 195, 152);
                e.Graphics.DrawString("ENTRADA", font2, Brushes.Black, 255, 152);
                e.Graphics.DrawString("SAÍDA", font2, Brushes.Black, 340, 152);
                e.Graphics.DrawString("CRÉDITO", font2, Brushes.Black, 400, 152);
                e.Graphics.DrawString("OBSERVAÇÃO", font2, Brushes.Black, 460, 152);


                int alturaPg = 172;
                for (int i = 0; i < listaHoraFuncionario.Count; i++)
                {
                    e.Graphics.DrawString(GetDataSemHora(listaHoraFuncionario[i].data_entrada), font2, Brushes.Black, 30, alturaPg);
                    e.Graphics.DrawString(listaHoraFuncionario[i].entrada.ToString(), font2, Brushes.Black, 120, alturaPg);
                    e.Graphics.DrawString(listaHoraFuncionario[i].ida_almoco.ToString(), font2, Brushes.Black, 190, alturaPg);
                    e.Graphics.DrawString(listaHoraFuncionario[i].volta_almoco.ToString(), font2, Brushes.Black, 255, alturaPg);
                    e.Graphics.DrawString(listaHoraFuncionario[i].saida.ToString(), font2, Brushes.Black, 340, alturaPg);
                    TimeSpan hora;
                    if (listaHoraFuncionario[i].qtdHora / 60 == 7)
                    {
                        hora = new TimeSpan(7, 0, 0);
                    }
                    else
                    {
                        hora = new TimeSpan(5, 45, 0);
                    }
                    TimeSpan credito = (listaHoraFuncionario[i].saida - listaHoraFuncionario[i].entrada) - (listaHoraFuncionario[i].volta_almoco - listaHoraFuncionario[i].ida_almoco) - hora;
                    e.Graphics.DrawString(credito.ToString(), font2, Brushes.Black, 400, alturaPg);

                    e.Graphics.DrawString(listaHoraFuncionario[i].obs, font2, Brushes.Black, 460, alturaPg);

                    alturaPg += 15;
                }

                alturaPg += 50;
                //FIM DOS HORARIOS



                //RODA PÉ DA PÁGINA   900
                e.Graphics.DrawString("TOTAL DE HORAS DO MÊS                           " + txtSaldoMes.Text, font2, Brushes.Black, 30, alturaPg);
                alturaPg += 50;
                //950
                e.Graphics.DrawString("SALDO                                                           " + txtSaldoFunc.Text, font2, Brushes.Black, 30, alturaPg);
                alturaPg += 30;
                //980
                e.Graphics.DrawString("RECEBI O DEMONSTRATIVO ACIMA EM  ____/____/_____", font2, Brushes.Black, 400, alturaPg);
                alturaPg += 50;
                //1030
                e.Graphics.DrawString("___________________________________________________________", font2, Brushes.Black, 400, alturaPg);
                alturaPg += 30;
                //1060
                e.Graphics.DrawString(cmbFunc.Text, font, Brushes.Black, 400, alturaPg);
                //FIM DA PÁGINA 
            }
            catch (Exception err)
            {

                MessageBox.Show("Erro. " + err.Message);
            }

        }
    }
}
