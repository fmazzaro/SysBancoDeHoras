namespace FrmPrincipal
{
    partial class FrmPrincipal
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
            this.menuPrincipal = new System.Windows.Forms.MenuStrip();
            this.menuLoja = new System.Windows.Forms.ToolStripMenuItem();
            this.menuFuncionario = new System.Windows.Forms.ToolStripMenuItem();
            this.menuFuncCadastro = new System.Windows.Forms.ToolStripMenuItem();
            this.menuFuncAltConsExc = new System.Windows.Forms.ToolStripMenuItem();
            this.menuFuncHoraAltCadExc = new System.Windows.Forms.ToolStripMenuItem();
            this.menuFuncRelaHora = new System.Windows.Forms.ToolStripMenuItem();
            this.menuLogin = new System.Windows.Forms.ToolStripMenuItem();
            this.menuSair = new System.Windows.Forms.ToolStripMenuItem();
            this.lblNomeUsuario = new System.Windows.Forms.Label();
            this.menuPrincipal.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuPrincipal
            // 
            this.menuPrincipal.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuLoja,
            this.menuFuncionario,
            this.menuLogin,
            this.menuSair});
            this.menuPrincipal.Location = new System.Drawing.Point(0, 0);
            this.menuPrincipal.Name = "menuPrincipal";
            this.menuPrincipal.Size = new System.Drawing.Size(932, 24);
            this.menuPrincipal.TabIndex = 1;
            this.menuPrincipal.Text = "menuStrip1";
            // 
            // menuLoja
            // 
            this.menuLoja.Name = "menuLoja";
            this.menuLoja.Size = new System.Drawing.Size(41, 20);
            this.menuLoja.Text = "Loja";
            this.menuLoja.Click += new System.EventHandler(this.lojaToolStripMenuItem_Click);
            // 
            // menuFuncionario
            // 
            this.menuFuncionario.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuFuncCadastro,
            this.menuFuncAltConsExc,
            this.menuFuncHoraAltCadExc,
            this.menuFuncRelaHora});
            this.menuFuncionario.Name = "menuFuncionario";
            this.menuFuncionario.Size = new System.Drawing.Size(82, 20);
            this.menuFuncionario.Text = "Funcionario";
            // 
            // menuFuncCadastro
            // 
            this.menuFuncCadastro.Name = "menuFuncCadastro";
            this.menuFuncCadastro.Size = new System.Drawing.Size(249, 22);
            this.menuFuncCadastro.Text = "Cadastro";
            this.menuFuncCadastro.Click += new System.EventHandler(this.menuCadastroFunc_Click);
            // 
            // menuFuncAltConsExc
            // 
            this.menuFuncAltConsExc.Name = "menuFuncAltConsExc";
            this.menuFuncAltConsExc.Size = new System.Drawing.Size(249, 22);
            this.menuFuncAltConsExc.Text = "Alterar - Consultar - Excluir";
            this.menuFuncAltConsExc.Click += new System.EventHandler(this.alterarConsultarExcluirToolStripMenuItem_Click);
            // 
            // menuFuncHoraAltCadExc
            // 
            this.menuFuncHoraAltCadExc.Name = "menuFuncHoraAltCadExc";
            this.menuFuncHoraAltCadExc.Size = new System.Drawing.Size(249, 22);
            this.menuFuncHoraAltCadExc.Text = "Alterar - Cadastrar - Excluir- Hora";
            this.menuFuncHoraAltCadExc.Click += new System.EventHandler(this.alterarCadastrarHoraToolStripMenuItem_Click);
            // 
            // menuFuncRelaHora
            // 
            this.menuFuncRelaHora.Name = "menuFuncRelaHora";
            this.menuFuncRelaHora.Size = new System.Drawing.Size(249, 22);
            this.menuFuncRelaHora.Text = "Relatório - Hora";
            this.menuFuncRelaHora.Click += new System.EventHandler(this.consultarExcluirHoraToolStripMenuItem_Click);
            // 
            // menuLogin
            // 
            this.menuLogin.Name = "menuLogin";
            this.menuLogin.Size = new System.Drawing.Size(49, 20);
            this.menuLogin.Text = "Login";
            this.menuLogin.Click += new System.EventHandler(this.loginToolStripMenuItem_Click);
            // 
            // menuSair
            // 
            this.menuSair.Name = "menuSair";
            this.menuSair.Size = new System.Drawing.Size(38, 20);
            this.menuSair.Text = "Sair";
            this.menuSair.Click += new System.EventHandler(this.menuSair_Click);
            // 
            // lblNomeUsuario
            // 
            this.lblNomeUsuario.AutoSize = true;
            this.lblNomeUsuario.Location = new System.Drawing.Point(630, 10);
            this.lblNomeUsuario.Name = "lblNomeUsuario";
            this.lblNomeUsuario.Size = new System.Drawing.Size(74, 13);
            this.lblNomeUsuario.TabIndex = 3;
            this.lblNomeUsuario.Text = "Nome Usuario";
            // 
            // FrmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(932, 440);
            this.Controls.Add(this.lblNomeUsuario);
            this.Controls.Add(this.menuPrincipal);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuPrincipal;
            this.Name = "FrmPrincipal";
            this.Text = "FrmPrincipal";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmPrincipal_Load);
            this.menuPrincipal.ResumeLayout(false);
            this.menuPrincipal.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuPrincipal;
        private System.Windows.Forms.ToolStripMenuItem menuLoja;
        private System.Windows.Forms.ToolStripMenuItem menuFuncionario;
        private System.Windows.Forms.ToolStripMenuItem menuLogin;
        private System.Windows.Forms.ToolStripMenuItem menuSair;
        private System.Windows.Forms.Label lblNomeUsuario;
        private System.Windows.Forms.ToolStripMenuItem menuFuncCadastro;
        private System.Windows.Forms.ToolStripMenuItem menuFuncAltConsExc;
        private System.Windows.Forms.ToolStripMenuItem menuFuncHoraAltCadExc;
        private System.Windows.Forms.ToolStripMenuItem menuFuncRelaHora;
    }
}

