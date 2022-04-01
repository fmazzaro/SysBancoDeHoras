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
    public partial class FrmHoraFuncionarioAlterarCadastrar : Form
    {
        FuncionarioNegocio funcionarioNegocio;
        HoraFuncionarioNegocio horaFuncionarioNegocio;
        List<HoraFuncionario> listaHoraFuncionario;//= new List<HoraFuncionario>();

        //esse bloco é para pegar os valores da dada e passar para a consulta
        //int i = 0; //para poder pegar o mes de inicio no botao salvar
        //DateTime diaInicio ; // guarda a primeira data da inserção
        //DateTime fimDoMes; //guarda a ultima data 
        int ano; // para usar no and do where, para poder carregar o grid com o  mês e o ano do cadastro de hora do func
        int idFuncionario;
        public FrmHoraFuncionarioAlterarCadastrar()
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
                    // AtualizarGrid(diaInicio, fimDoMes, idFuncionario);
                    RecarregarGrid();
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

                    if(resultado == DialogResult.Yes)
                    {
                        horaFuncionarioNegocio = new HoraFuncionarioNegocio();

                        HoraFuncionario hf = (dgvPrincipal.SelectedRows[0].DataBoundItem as HoraFuncionario);
                        horaFuncionarioNegocio.ExcluirHoraFuncionario(hf);
                        MessageBox.Show("Funcionario excluido com sucesso!");
                        //AtualizarGrid(diaInicio, fimDoMes, idFuncionario);
                        RecarregarGrid();
                        atulazaHora();
                    }                                      
                   
                }
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
                if (cmbLoja.Text == "")
                {
                    MessageBox.Show("Escolha uma loja ");
                }
                else
                {
                                      
                    horaFuncionarioNegocio = new HoraFuncionarioNegocio();

                    cmbFunc.DataSource = horaFuncionarioNegocio.ListaComboFuncionarioDaLoja(Convert.ToInt32(cmbLoja.SelectedValue));
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

        private void btnInserir_Click(object sender, EventArgs e)
        {
            try
            {
                /*
                if(i == 0)
                {
                    i++;
                    diaInicio = new DateTime(dtpDataEntrada.Value.Year, dtpDataEntrada.Value.Month, dtpDataEntrada.Value.Day);
                    var ultimoDia = DateTime.DaysInMonth(diaInicio.Year, diaInicio.Month);
                    fimDoMes = new DateTime(diaInicio.Year, diaInicio.Month, ultimoDia);
                    idFuncionario = Convert.ToInt32(cmbFunc.SelectedValue);
                    ano = dtpDataEntrada.Value.Year;
                }   
                */

                idFuncionario = Convert.ToInt32(cmbFunc.SelectedValue);
                ano = dtpDataEntrada.Value.Year;

                //verificando se algum campo desses estão vazios
                if (cmbLoja.Text != "" && cmbFunc.Text != "" && cmbHoraUtil.Text != "")
                {
                    HoraFuncionario horaFuncionario = new HoraFuncionario();
                                        

                    horaFuncionario.idfunc = Convert.ToInt32(cmbFunc.SelectedValue);
                    horaFuncionario.data_entrada = dtpDataEntrada.Value;

                    if (txtHoraEntrada.Text != "")
                        horaFuncionario.entrada = TimeSpan.Parse(txtHoraEntrada.Text);

                    if (txtIdaAlmoco.Text != "")
                        horaFuncionario.ida_almoco = TimeSpan.Parse(txtIdaAlmoco.Text);

                    if (txtVoltaAlmoco.Text != "")
                        horaFuncionario.volta_almoco = TimeSpan.Parse(txtVoltaAlmoco.Text);

                    if (txtHoraSaida.Text != "")
                        horaFuncionario.saida = TimeSpan.Parse(txtHoraSaida.Text);
                    double min = TimeSpan.Parse(cmbHoraUtil.Text).TotalMinutes;

                    horaFuncionario.qtdHora = Convert.ToInt32(min);

                    if (rdbJustSim.Checked || rdbJustNao.Checked)
                    {
                        if (rdbJustNao.Checked)
                            horaFuncionario.justificado = false;
                        else
                            horaFuncionario.justificado = true;
                    }

                    if (rdbNao.Checked || rdbSim.Checked)
                    {
                        if (rdbNao.Checked)
                            horaFuncionario.folga = false;
                        else
                        {
                            horaFuncionario.folga = true;
                        }
                            
                    }

                    horaFuncionario.obs = txtObs.Text;
                    
                    horaFuncionarioNegocio = new HoraFuncionarioNegocio();

                    horaFuncionarioNegocio.InserirHoraFuncionario(horaFuncionario);

                    MessageBox.Show("Cadastrado com sucesso ");

                    
                    //AtualizarGrid(diaInicio, fimDoMes, idFuncionario);
                    RecarregarGrid();
                    
                    txtObs.Text = "";
                }
                else
                    MessageBox.Show("Erro: Loja, Hora util ou Funcionário não selecionado!" );
                

               

            }
            catch (Exception ex)
            {

                MessageBox.Show("Erro " + ex.Message);
            }
        }

        private void FrmHoraFuncionarioAlterarCadastrar_Load(object sender, EventArgs e)
        {
            rdbNao.Checked = true;
            txtSaldoFunc.Enabled = false;
            txtSaldoMes.Enabled = false;
            btnCarregaGrid.Enabled = false;
            rdbJustNao.Checked = true;
        }

        /*VAI SAIR 
        public void AtualizarGrid(DateTime dataInicio, DateTime dataFim, int idFunc)
        {
            try
            {

                listaHoraFuncionario = null;
                listaHoraFuncionario = horaFuncionarioNegocio.GridCadastroHoras(dataInicio, dataFim,idFunc);                

                dgvPrincipal.DataSource = null;
                dgvPrincipal.DataSource = listaHoraFuncionario;                
                dgvPrincipal.Columns[0].Visible = false;
                //dgvPrincipal.Columns[1].Visible = false;
               
                dgvPrincipal.Update();
                dgvPrincipal.Refresh();
                                
            }
            catch (Exception ex)
            {

                MessageBox.Show("Erro " + ex.Message);
            }
            
        }
        */

        private void btnNovo_Click(object sender, EventArgs e)
        {
            cmbFunc.Text = "";
            cmbHoraUtil.Text = "";
            cmbHoraUtil.Text = "";
            txtHoraEntrada.Clear();
            txtHoraSaida.Clear();
            txtIdaAlmoco.Clear();
            txtSaldoFunc.Clear();
            txtSaldoMes.Clear();
            txtVoltaAlmoco.Clear();
            dgvPrincipal.DataSource = null;
            //i = 0;
            idFuncionario = 0;
            
        }

        public void atulazaHora()
        {
            txtSaldoFunc.Text = horaFuncionarioNegocio.SaldoFuncionarioTotal(idFuncionario);
            txtSaldoMes.Text = horaFuncionarioNegocio.SaldoFuncionarioMesCadastro(idFuncionario, GetNomeMes(), ano);
        }

        public string GetNomeMes()
        {
            string nomeMes = "";
            int mes = 0;

            /*
            if (dgvPrincipal.RowCount == 0)//
                mes = 0;
            else
                mes = int.Parse(fimDoMes.Month.ToString());
                */
            mes = int.Parse(dtpDataEntrada.Value.Month.ToString());
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

        public void RecarregarGrid()
        {
            try
            {
                string nomeMes = GetNomeMes();
                
                horaFuncionarioNegocio = new HoraFuncionarioNegocio();
                listaHoraFuncionario = new List<HoraFuncionario>();
                listaHoraFuncionario = horaFuncionarioNegocio.CarregarGridBotaoNaTela(horaFuncionarioNegocio.nomeMesInglesAzure(nomeMes), idFuncionario, ano);

                dgvPrincipal.DataSource = null;
                dgvPrincipal.DataSource = listaHoraFuncionario;
                dgvPrincipal.Update();
                dtpDataEntrada.Refresh();
                

                atulazaHora();
            }
            catch (Exception ex)
            {

                MessageBox.Show("Erro: " + ex.Message);
            }


        }

        private void btnCarregaGrid_Click(object sender, EventArgs e)
        {
            RecarregarGrid();
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
                Font font3 = new Font("Arial", 15, FontStyle.Bold, GraphicsUnit.Pixel);


                // top da págima ( razão social )
                e.Graphics.DrawString(cmbLoja.Text, font, Brushes.Black, 30, 50);


                e.Graphics.DrawString("BANCO DE HORAS DE " + GetNomeMes() + " " + dtpDataEntrada.Value.Year, font, Brushes.Black, 30, 72);


                //NOME FUNCIONARIO
                e.Graphics.DrawString("FUNCIONÁRIO    : ", font, Brushes.Black, 30, 102);
                e.Graphics.DrawString(cmbFunc.Text, font, Brushes.Black, 200, 102);


                //FIM NOME FUNCIONARIO

                //CABEÇALHO DOS HORARIOS
                //data - entrada - (almoco -saída - entrada) - saida - HORAS DIA - Crédito - observação

                //titulos
                e.Graphics.DrawString("     DATA   ", font2, Brushes.Black, 30, 152);
                e.Graphics.DrawString("ENTRADA", font2, Brushes.Black, 115, 152);
                e.Graphics.DrawString("     ALMOÇO   ", font2, Brushes.Black, 200, 132);
                e.Graphics.DrawString("SAÍDA", font2, Brushes.Black, 185, 152);
                e.Graphics.DrawString("ENTRADA", font2, Brushes.Black, 255, 152);
                e.Graphics.DrawString("SAÍDA", font2, Brushes.Black, 325, 152);
                e.Graphics.DrawString("SALDO DIA", font2, Brushes.Black, 380, 152);
                e.Graphics.DrawString("JUST?", font2, Brushes.Black, 450, 152);
                e.Graphics.DrawString("OBSERVAÇÃO", font2, Brushes.Black, 510, 152);

                int alturaPg = 172;
                for (int i = 0; i < listaHoraFuncionario.Count; i++)
                {
                    e.Graphics.DrawString(GetDataSemHora(listaHoraFuncionario[i].data_entrada), font2, Brushes.Black, 30, alturaPg);
                    e.Graphics.DrawString(listaHoraFuncionario[i].entrada.ToString(@"hh\:mm"), font2, Brushes.Black, 115, alturaPg);
                    e.Graphics.DrawString(listaHoraFuncionario[i].ida_almoco.ToString(@"hh\:mm"), font2, Brushes.Black, 185, alturaPg);
                    e.Graphics.DrawString(listaHoraFuncionario[i].volta_almoco.ToString(@"hh\:mm"), font2, Brushes.Black, 255, alturaPg);
                    e.Graphics.DrawString(listaHoraFuncionario[i].saida.ToString(@"hh\:mm"), font2, Brushes.Black, 325, alturaPg);
                    TimeSpan hora;
                    hora = TimeSpan.FromMinutes(Convert.ToDouble(listaHoraFuncionario[i].qtdHora));
                    //                    e.Graphics.DrawString(hora.ToString(@"hh\:mm"), font2, Brushes.Black, 395, alturaPg);
                    //if (listaHoraFuncionario[i].qtdHora / 60 == 7)
                    //{
                    //    hora = new TimeSpan(7, 0, 0);
                    //}
                    //else
                    //{
                    //    hora = new TimeSpan(5, 45, 0);
                    //}
                    TimeSpan credito = (listaHoraFuncionario[i].saida - listaHoraFuncionario[i].entrada) - (listaHoraFuncionario[i].volta_almoco - listaHoraFuncionario[i].ida_almoco) - hora;
                    if (credito != TimeSpan.Zero)
                    {
        //                if (listaHoraFuncionario[i].justificado) credito = TimeSpan.Zero;
                        if (credito < TimeSpan.Zero)
                        {
                            e.Graphics.DrawString(credito.ToString("\\-hh\\:mm"), font2, listaHoraFuncionario[i].justificado? Brushes.LightGray : Brushes.Red, 380, alturaPg);
                        }
                        else
                        {
                            e.Graphics.DrawString(credito.ToString(@"\ hh\:mm"), font2, Brushes.Green, 380, alturaPg);
                        }
                    }
                    e.Graphics.DrawString(listaHoraFuncionario[i].justificado ? "X":" ", font2, Brushes.Black, 450, alturaPg);

                    e.Graphics.DrawString(listaHoraFuncionario[i].obs, font2, Brushes.Black, 510, alturaPg);

                    alturaPg += 15;
                }

                alturaPg += 50;
                //FIM DOS HORARIOS

                //TimeSpan saldoMes = new TimeSpan();
                //saldoMes = TimeSpan.Parse(txtSaldoMes.Text);
                bool neg = txtSaldoMes.Text.StartsWith("-");

                //RODA PÉ DA PÁGINA   900
                e.Graphics.DrawString("TOTAL DE HORAS DO MÊS:", font3, Brushes.Black, 30, alturaPg);
                e.Graphics.DrawString(txtSaldoMes.Text, font3, neg ? Brushes.Red : Brushes.Green, 255, alturaPg);
                alturaPg += 50;
                //950
                //TimeSpan saldoTotal = new TimeSpan();
                //saldoTotal = TimeSpan.Parse(txtSaldoFunc.Text);
                neg = txtSaldoFunc.Text.StartsWith("-");
                e.Graphics.DrawString("SALDO:", font3, Brushes.Black, 30, alturaPg);
                e.Graphics.DrawString(txtSaldoFunc.Text, font3, neg ? Brushes.Red : Brushes.Green, 255, alturaPg);
                alturaPg += 50;
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

        private void cmbHoraUtil_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
        /*
DateTime data = new DateTime(dtpDataEntrada.Value.Year,dtpDataEntrada.Value.Month,dtpDataEntrada.Value.Day);
var ultimoDia = DateTime.DaysInMonth(data.Year, data.Month);
DateTime dataUltimoDia = new DateTime(data.Year, data.Month, ultimoDia);

MessageBox.Show("1- " + data);
MessageBox.Show("2- " + ultimoDia);
MessageBox.Show("3- " + dataUltimoDia);
*/

    }
}
