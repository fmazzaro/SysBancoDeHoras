namespace FrmPrincipal
{
    partial class FrmFuncionarioCadastrar
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
            this.txtNome = new System.Windows.Forms.TextBox();
            this.txtCpf = new System.Windows.Forms.TextBox();
            this.rdtMasculino = new System.Windows.Forms.RadioButton();
            this.rdtFeminino = new System.Windows.Forms.RadioButton();
            this.cmbFuncao = new System.Windows.Forms.ComboBox();
            this.rdtAtivo = new System.Windows.Forms.RadioButton();
            this.rdtDesativado = new System.Windows.Forms.RadioButton();
            this.cmbGerente = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cmbLoja = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.btnSalvar = new System.Windows.Forms.Button();
            this.btnCancelar = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.txtIdFunc = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.dtpDataContrato = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtNome
            // 
            this.txtNome.Location = new System.Drawing.Point(186, 23);
            this.txtNome.Name = "txtNome";
            this.txtNome.Size = new System.Drawing.Size(296, 20);
            this.txtNome.TabIndex = 0;
            // 
            // txtCpf
            // 
            this.txtCpf.Location = new System.Drawing.Point(81, 61);
            this.txtCpf.Name = "txtCpf";
            this.txtCpf.Size = new System.Drawing.Size(90, 20);
            this.txtCpf.TabIndex = 1;
            // 
            // rdtMasculino
            // 
            this.rdtMasculino.AutoSize = true;
            this.rdtMasculino.Location = new System.Drawing.Point(6, 19);
            this.rdtMasculino.Name = "rdtMasculino";
            this.rdtMasculino.Size = new System.Drawing.Size(73, 17);
            this.rdtMasculino.TabIndex = 0;
            this.rdtMasculino.Text = "Masculino";
            this.rdtMasculino.UseVisualStyleBackColor = true;
            // 
            // rdtFeminino
            // 
            this.rdtFeminino.AutoSize = true;
            this.rdtFeminino.Location = new System.Drawing.Point(105, 19);
            this.rdtFeminino.Name = "rdtFeminino";
            this.rdtFeminino.Size = new System.Drawing.Size(67, 17);
            this.rdtFeminino.TabIndex = 1;
            this.rdtFeminino.Text = "Feminino";
            this.rdtFeminino.UseVisualStyleBackColor = true;
            // 
            // cmbFuncao
            // 
            this.cmbFuncao.FormattingEnabled = true;
            this.cmbFuncao.Items.AddRange(new object[] {
            "Gerente",
            "Supervisor",
            "Vendedor",
            "Vendedor Responsavél"});
            this.cmbFuncao.Location = new System.Drawing.Point(81, 119);
            this.cmbFuncao.Name = "cmbFuncao";
            this.cmbFuncao.Size = new System.Drawing.Size(139, 21);
            this.cmbFuncao.TabIndex = 2;
            // 
            // rdtAtivo
            // 
            this.rdtAtivo.AutoSize = true;
            this.rdtAtivo.Checked = true;
            this.rdtAtivo.Location = new System.Drawing.Point(273, 163);
            this.rdtAtivo.Name = "rdtAtivo";
            this.rdtAtivo.Size = new System.Drawing.Size(61, 17);
            this.rdtAtivo.TabIndex = 7;
            this.rdtAtivo.TabStop = true;
            this.rdtAtivo.Text = "Ativado";
            this.rdtAtivo.UseVisualStyleBackColor = true;
            // 
            // rdtDesativado
            // 
            this.rdtDesativado.AutoSize = true;
            this.rdtDesativado.Location = new System.Drawing.Point(353, 163);
            this.rdtDesativado.Name = "rdtDesativado";
            this.rdtDesativado.Size = new System.Drawing.Size(79, 17);
            this.rdtDesativado.TabIndex = 10;
            this.rdtDesativado.Text = "Desativado";
            this.rdtDesativado.UseVisualStyleBackColor = true;
            // 
            // cmbGerente
            // 
            this.cmbGerente.FormattingEnabled = true;
            this.cmbGerente.Location = new System.Drawing.Point(293, 119);
            this.cmbGerente.Name = "cmbGerente";
            this.cmbGerente.Size = new System.Drawing.Size(189, 21);
            this.cmbGerente.TabIndex = 6;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(145, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 13;
            this.label1.Text = "Nome";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(25, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(27, 13);
            this.label2.TabIndex = 14;
            this.label2.Text = "CPF";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(25, 119);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 15;
            this.label3.Text = "Função";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(242, 119);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 13);
            this.label4.TabIndex = 18;
            this.label4.Text = "Gerente";
            // 
            // cmbLoja
            // 
            this.cmbLoja.FormattingEnabled = true;
            this.cmbLoja.Location = new System.Drawing.Point(81, 159);
            this.cmbLoja.Name = "cmbLoja";
            this.cmbLoja.Size = new System.Drawing.Size(151, 21);
            this.cmbLoja.TabIndex = 3;
            this.cmbLoja.Click += new System.EventHandler(this.cmbLoja_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(25, 159);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(27, 13);
            this.label5.TabIndex = 16;
            this.label5.Text = "Loja";
            // 
            // btnSalvar
            // 
            this.btnSalvar.Location = new System.Drawing.Point(293, 197);
            this.btnSalvar.Name = "btnSalvar";
            this.btnSalvar.Size = new System.Drawing.Size(75, 86);
            this.btnSalvar.TabIndex = 8;
            this.btnSalvar.Text = "Salvar";
            this.btnSalvar.UseVisualStyleBackColor = true;
            this.btnSalvar.Click += new System.EventHandler(this.btnSalvar_Click);
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(407, 198);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(75, 86);
            this.btnCancelar.TabIndex = 9;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.rdtMasculino);
            this.groupBox1.Controls.Add(this.rdtFeminino);
            this.groupBox1.Location = new System.Drawing.Point(254, 52);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(190, 48);
            this.groupBox1.TabIndex = 5;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Sexo";
            // 
            // txtIdFunc
            // 
            this.txtIdFunc.Location = new System.Drawing.Point(81, 23);
            this.txtIdFunc.Name = "txtIdFunc";
            this.txtIdFunc.Size = new System.Drawing.Size(43, 20);
            this.txtIdFunc.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(25, 23);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(40, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Código";
            // 
            // dtpDataContrato
            // 
            this.dtpDataContrato.Location = new System.Drawing.Point(28, 228);
            this.dtpDataContrato.Name = "dtpDataContrato";
            this.dtpDataContrato.Size = new System.Drawing.Size(245, 20);
            this.dtpDataContrato.TabIndex = 4;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(24, 197);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(73, 13);
            this.label7.TabIndex = 17;
            this.label7.Text = "Data Contrato";
            // 
            // FrmFuncionarioCadastrar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(512, 307);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.dtpDataContrato);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtIdFunc);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnSalvar);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cmbLoja);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.cmbGerente);
            this.Controls.Add(this.rdtDesativado);
            this.Controls.Add(this.rdtAtivo);
            this.Controls.Add(this.cmbFuncao);
            this.Controls.Add(this.txtCpf);
            this.Controls.Add(this.txtNome);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "FrmFuncionarioCadastrar";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Cadastro Funcionario";
            this.Load += new System.EventHandler(this.FrmFuncionarioAlterarCadastrar_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtNome;
        private System.Windows.Forms.TextBox txtCpf;
        private System.Windows.Forms.RadioButton rdtMasculino;
        private System.Windows.Forms.RadioButton rdtFeminino;
        private System.Windows.Forms.ComboBox cmbFuncao;
        private System.Windows.Forms.RadioButton rdtAtivo;
        private System.Windows.Forms.RadioButton rdtDesativado;
        private System.Windows.Forms.ComboBox cmbGerente;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cmbLoja;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button btnSalvar;
        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtIdFunc;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.DateTimePicker dtpDataContrato;
        private System.Windows.Forms.Label label7;
    }
}