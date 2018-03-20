namespace FrmPrincipal
{
    partial class FrmHoraFuncionarioAlterarCadastrar
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmHoraFuncionarioAlterarCadastrar));
            this.cmbLoja = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.cmbFunc = new System.Windows.Forms.ComboBox();
            this.dtpDataEntrada = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtHoraSaida = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtHoraEntrada = new System.Windows.Forms.TextBox();
            this.txtIdaAlmoco = new System.Windows.Forms.TextBox();
            this.txtVoltaAlmoco = new System.Windows.Forms.TextBox();
            this.cmbHoraUtil = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.rdbSim = new System.Windows.Forms.RadioButton();
            this.btnInserir = new System.Windows.Forms.Button();
            this.dgvPrincipal = new System.Windows.Forms.DataGridView();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.rdbNao = new System.Windows.Forms.RadioButton();
            this.btnAlterar = new System.Windows.Forms.Button();
            this.btnExcluir = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.txtSaldoMes = new System.Windows.Forms.TextBox();
            this.txtSaldoFunc = new System.Windows.Forms.TextBox();
            this.btnNovo = new System.Windows.Forms.Button();
            this.btnCarregaGrid = new System.Windows.Forms.Button();
            this.printPreviewDialog1 = new System.Windows.Forms.PrintPreviewDialog();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            this.btnImprimir = new System.Windows.Forms.Button();
            this.txtObs = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPrincipal)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // cmbLoja
            // 
            this.cmbLoja.FormattingEnabled = true;
            this.cmbLoja.Location = new System.Drawing.Point(67, 20);
            this.cmbLoja.Name = "cmbLoja";
            this.cmbLoja.Size = new System.Drawing.Size(289, 21);
            this.cmbLoja.TabIndex = 0;
            this.cmbLoja.Click += new System.EventHandler(this.cmbLoja_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(24, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(27, 13);
            this.label1.TabIndex = 16;
            this.label1.Text = "Loja";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(372, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 13);
            this.label2.TabIndex = 28;
            this.label2.Text = "Funcionario";
            // 
            // cmbFunc
            // 
            this.cmbFunc.FormattingEnabled = true;
            this.cmbFunc.Location = new System.Drawing.Point(437, 20);
            this.cmbFunc.Name = "cmbFunc";
            this.cmbFunc.Size = new System.Drawing.Size(336, 21);
            this.cmbFunc.TabIndex = 1;
            this.cmbFunc.Click += new System.EventHandler(this.cmbFunc_Click);
            // 
            // dtpDataEntrada
            // 
            this.dtpDataEntrada.Location = new System.Drawing.Point(123, 73);
            this.dtpDataEntrada.Name = "dtpDataEntrada";
            this.dtpDataEntrada.Size = new System.Drawing.Size(233, 20);
            this.dtpDataEntrada.TabIndex = 2;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(24, 79);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 13);
            this.label3.TabIndex = 17;
            this.label3.Text = "Data Entrada";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(24, 144);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 13);
            this.label4.TabIndex = 18;
            this.label4.Text = "Hora Entrada";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(24, 177);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(60, 13);
            this.label5.TabIndex = 19;
            this.label5.Text = "Ida Almoço";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(24, 213);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(69, 13);
            this.label6.TabIndex = 20;
            this.label6.Text = "Volta Almoço";
            // 
            // txtHoraSaida
            // 
            this.txtHoraSaida.Location = new System.Drawing.Point(104, 254);
            this.txtHoraSaida.Name = "txtHoraSaida";
            this.txtHoraSaida.Size = new System.Drawing.Size(45, 20);
            this.txtHoraSaida.TabIndex = 6;
            this.txtHoraSaida.Text = "18:00";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(24, 254);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(62, 13);
            this.label7.TabIndex = 21;
            this.label7.Text = "Hora Saída";
            // 
            // txtHoraEntrada
            // 
            this.txtHoraEntrada.Location = new System.Drawing.Point(104, 141);
            this.txtHoraEntrada.Name = "txtHoraEntrada";
            this.txtHoraEntrada.Size = new System.Drawing.Size(45, 20);
            this.txtHoraEntrada.TabIndex = 3;
            this.txtHoraEntrada.Text = "10:00";
            // 
            // txtIdaAlmoco
            // 
            this.txtIdaAlmoco.Location = new System.Drawing.Point(104, 177);
            this.txtIdaAlmoco.Name = "txtIdaAlmoco";
            this.txtIdaAlmoco.Size = new System.Drawing.Size(45, 20);
            this.txtIdaAlmoco.TabIndex = 4;
            this.txtIdaAlmoco.Text = "14:00";
            // 
            // txtVoltaAlmoco
            // 
            this.txtVoltaAlmoco.Location = new System.Drawing.Point(104, 213);
            this.txtVoltaAlmoco.Name = "txtVoltaAlmoco";
            this.txtVoltaAlmoco.Size = new System.Drawing.Size(45, 20);
            this.txtVoltaAlmoco.TabIndex = 5;
            this.txtVoltaAlmoco.Text = "15:00";
            // 
            // cmbHoraUtil
            // 
            this.cmbHoraUtil.FormattingEnabled = true;
            this.cmbHoraUtil.Items.AddRange(new object[] {
            "6",
            "7"});
            this.cmbHoraUtil.Location = new System.Drawing.Point(104, 301);
            this.cmbHoraUtil.Name = "cmbHoraUtil";
            this.cmbHoraUtil.Size = new System.Drawing.Size(59, 21);
            this.cmbHoraUtil.TabIndex = 7;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(24, 301);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(62, 13);
            this.label8.TabIndex = 22;
            this.label8.Text = "Horas Utéis";
            // 
            // rdbSim
            // 
            this.rdbSim.AutoSize = true;
            this.rdbSim.Location = new System.Drawing.Point(6, 17);
            this.rdbSim.Name = "rdbSim";
            this.rdbSim.Size = new System.Drawing.Size(42, 17);
            this.rdbSim.TabIndex = 0;
            this.rdbSim.Text = "Sim";
            this.rdbSim.UseVisualStyleBackColor = true;
            // 
            // btnInserir
            // 
            this.btnInserir.Location = new System.Drawing.Point(27, 377);
            this.btnInserir.Name = "btnInserir";
            this.btnInserir.Size = new System.Drawing.Size(121, 33);
            this.btnInserir.TabIndex = 10;
            this.btnInserir.Text = "Inserir";
            this.btnInserir.UseVisualStyleBackColor = true;
            this.btnInserir.Click += new System.EventHandler(this.btnInserir_Click);
            // 
            // dgvPrincipal
            // 
            this.dgvPrincipal.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPrincipal.EditMode = System.Windows.Forms.DataGridViewEditMode.EditProgrammatically;
            this.dgvPrincipal.Location = new System.Drawing.Point(169, 141);
            this.dgvPrincipal.MultiSelect = false;
            this.dgvPrincipal.Name = "dgvPrincipal";
            this.dgvPrincipal.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvPrincipal.Size = new System.Drawing.Size(604, 181);
            this.dgvPrincipal.TabIndex = 15;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdbNao);
            this.groupBox1.Controls.Add(this.rdbSim);
            this.groupBox1.Location = new System.Drawing.Point(27, 328);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(136, 37);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Folga";
            // 
            // rdbNao
            // 
            this.rdbNao.AutoSize = true;
            this.rdbNao.Location = new System.Drawing.Point(84, 17);
            this.rdbNao.Name = "rdbNao";
            this.rdbNao.Size = new System.Drawing.Size(45, 17);
            this.rdbNao.TabIndex = 1;
            this.rdbNao.Text = "Não";
            this.rdbNao.UseVisualStyleBackColor = true;
            // 
            // btnAlterar
            // 
            this.btnAlterar.Location = new System.Drawing.Point(533, 427);
            this.btnAlterar.Name = "btnAlterar";
            this.btnAlterar.Size = new System.Drawing.Size(92, 87);
            this.btnAlterar.TabIndex = 12;
            this.btnAlterar.Text = "Alterar";
            this.btnAlterar.UseVisualStyleBackColor = true;
            this.btnAlterar.Click += new System.EventHandler(this.btnAlterar_Click);
            // 
            // btnExcluir
            // 
            this.btnExcluir.Location = new System.Drawing.Point(681, 427);
            this.btnExcluir.Name = "btnExcluir";
            this.btnExcluir.Size = new System.Drawing.Size(92, 87);
            this.btnExcluir.TabIndex = 13;
            this.btnExcluir.Text = "Excluir";
            this.btnExcluir.UseVisualStyleBackColor = true;
            this.btnExcluir.Click += new System.EventHandler(this.btnExcluir_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(24, 449);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(57, 13);
            this.label9.TabIndex = 23;
            this.label9.Text = "Saldo Mês";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(225, 449);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(92, 13);
            this.label10.TabIndex = 25;
            this.label10.Text = "Saldo Funcionário";
            // 
            // txtSaldoMes
            // 
            this.txtSaldoMes.Location = new System.Drawing.Point(27, 481);
            this.txtSaldoMes.Name = "txtSaldoMes";
            this.txtSaldoMes.Size = new System.Drawing.Size(65, 20);
            this.txtSaldoMes.TabIndex = 24;
            // 
            // txtSaldoFunc
            // 
            this.txtSaldoFunc.Location = new System.Drawing.Point(228, 481);
            this.txtSaldoFunc.Name = "txtSaldoFunc";
            this.txtSaldoFunc.Size = new System.Drawing.Size(65, 20);
            this.txtSaldoFunc.TabIndex = 26;
            // 
            // btnNovo
            // 
            this.btnNovo.Location = new System.Drawing.Point(389, 427);
            this.btnNovo.Name = "btnNovo";
            this.btnNovo.Size = new System.Drawing.Size(92, 87);
            this.btnNovo.TabIndex = 11;
            this.btnNovo.Text = "Novo";
            this.btnNovo.UseVisualStyleBackColor = true;
            this.btnNovo.Click += new System.EventHandler(this.btnNovo_Click);
            // 
            // btnCarregaGrid
            // 
            this.btnCarregaGrid.Location = new System.Drawing.Point(587, 70);
            this.btnCarregaGrid.Name = "btnCarregaGrid";
            this.btnCarregaGrid.Size = new System.Drawing.Size(75, 23);
            this.btnCarregaGrid.TabIndex = 27;
            this.btnCarregaGrid.Text = "Carrega Grid";
            this.btnCarregaGrid.UseVisualStyleBackColor = true;
            this.btnCarregaGrid.Click += new System.EventHandler(this.btnCarregaGrid_Click);
            // 
            // printPreviewDialog1
            // 
            this.printPreviewDialog1.AutoScrollMargin = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.AutoScrollMinSize = new System.Drawing.Size(0, 0);
            this.printPreviewDialog1.ClientSize = new System.Drawing.Size(400, 300);
            this.printPreviewDialog1.Document = this.printDocument1;
            this.printPreviewDialog1.Enabled = true;
            this.printPreviewDialog1.Icon = ((System.Drawing.Icon)(resources.GetObject("printPreviewDialog1.Icon")));
            this.printPreviewDialog1.Name = "printPreviewDialog1";
            this.printPreviewDialog1.Visible = false;
            this.printPreviewDialog1.Load += new System.EventHandler(this.printPreviewDialog1_Load);
            // 
            // printDocument1
            // 
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.printDocument1_PrintPage);
            // 
            // btnImprimir
            // 
            this.btnImprimir.Location = new System.Drawing.Point(437, 70);
            this.btnImprimir.Name = "btnImprimir";
            this.btnImprimir.Size = new System.Drawing.Size(75, 23);
            this.btnImprimir.TabIndex = 14;
            this.btnImprimir.Text = "Imprimir";
            this.btnImprimir.UseVisualStyleBackColor = true;
            this.btnImprimir.Click += new System.EventHandler(this.btnImprimir_Click);
            // 
            // txtObs
            // 
            this.txtObs.Location = new System.Drawing.Point(169, 361);
            this.txtObs.Multiline = true;
            this.txtObs.Name = "txtObs";
            this.txtObs.Size = new System.Drawing.Size(604, 49);
            this.txtObs.TabIndex = 9;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(169, 337);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(65, 13);
            this.label11.TabIndex = 29;
            this.label11.Text = "Observação";
            // 
            // FrmHoraFuncionarioAlterarCadastrar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(812, 526);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.txtObs);
            this.Controls.Add(this.btnImprimir);
            this.Controls.Add(this.btnCarregaGrid);
            this.Controls.Add(this.btnNovo);
            this.Controls.Add(this.txtSaldoFunc);
            this.Controls.Add(this.txtSaldoMes);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.btnExcluir);
            this.Controls.Add(this.btnAlterar);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dgvPrincipal);
            this.Controls.Add(this.btnInserir);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.cmbHoraUtil);
            this.Controls.Add(this.txtVoltaAlmoco);
            this.Controls.Add(this.txtIdaAlmoco);
            this.Controls.Add(this.txtHoraEntrada);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txtHoraSaida);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.dtpDataEntrada);
            this.Controls.Add(this.cmbFunc);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbLoja);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FrmHoraFuncionarioAlterarCadastrar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmHoraFuncionarioCadastro";
            this.Load += new System.EventHandler(this.FrmHoraFuncionarioAlterarCadastrar_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPrincipal)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbLoja;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cmbFunc;
        private System.Windows.Forms.DateTimePicker dtpDataEntrada;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtHoraSaida;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtHoraEntrada;
        private System.Windows.Forms.TextBox txtIdaAlmoco;
        private System.Windows.Forms.TextBox txtVoltaAlmoco;
        private System.Windows.Forms.ComboBox cmbHoraUtil;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.RadioButton rdbSim;
        private System.Windows.Forms.Button btnInserir;
        private System.Windows.Forms.DataGridView dgvPrincipal;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton rdbNao;
        private System.Windows.Forms.Button btnAlterar;
        private System.Windows.Forms.Button btnExcluir;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.TextBox txtSaldoMes;
        private System.Windows.Forms.TextBox txtSaldoFunc;
        private System.Windows.Forms.Button btnNovo;
        private System.Windows.Forms.Button btnCarregaGrid;
        private System.Windows.Forms.PrintPreviewDialog printPreviewDialog1;
        private System.Drawing.Printing.PrintDocument printDocument1;
        private System.Windows.Forms.Button btnImprimir;
        private System.Windows.Forms.TextBox txtObs;
        private System.Windows.Forms.Label label11;
    }
}