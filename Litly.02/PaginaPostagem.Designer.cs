namespace Litly._02
{
    partial class PaginaPostagem
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
            IblTitulo = new Label();
            txtTitulo = new TextBox();
            IblConteudo = new Label();
            txtConteudo = new TextBox();
            IblAutor = new Label();
            txtAutor = new TextBox();
            IblData = new Label();
            txtData = new TextBox();
            button1 = new Button();
            label5 = new Label();
            SuspendLayout();
            // 
            // IblTitulo
            // 
            IblTitulo.AutoSize = true;
            IblTitulo.Location = new Point(279, 97);
            IblTitulo.Name = "IblTitulo";
            IblTitulo.Size = new Size(38, 15);
            IblTitulo.TabIndex = 0;
            IblTitulo.Text = "Titulo";
            // 
            // txtTitulo
            // 
            txtTitulo.Location = new Point(370, 94);
            txtTitulo.Name = "txtTitulo";
            txtTitulo.ReadOnly = true;
            txtTitulo.Size = new Size(100, 23);
            txtTitulo.TabIndex = 1;
            // 
            // IblConteudo
            // 
            IblConteudo.AutoSize = true;
            IblConteudo.Location = new Point(279, 154);
            IblConteudo.Name = "IblConteudo";
            IblConteudo.Size = new Size(60, 15);
            IblConteudo.TabIndex = 2;
            IblConteudo.Text = "Conteúdo";
            // 
            // txtConteudo
            // 
            txtConteudo.Location = new Point(370, 160);
            txtConteudo.Multiline = true;
            txtConteudo.Name = "txtConteudo";
            txtConteudo.ReadOnly = true;
            txtConteudo.ScrollBars = ScrollBars.Vertical;
            txtConteudo.Size = new Size(100, 23);
            txtConteudo.TabIndex = 3;
            // 
            // IblAutor
            // 
            IblAutor.AutoSize = true;
            IblAutor.Location = new Point(279, 211);
            IblAutor.Name = "IblAutor";
            IblAutor.Size = new Size(37, 15);
            IblAutor.TabIndex = 4;
            IblAutor.Text = "Autor";
            // 
            // txtAutor
            // 
            txtAutor.Location = new Point(370, 226);
            txtAutor.Name = "txtAutor";
            txtAutor.ReadOnly = true;
            txtAutor.Size = new Size(100, 23);
            txtAutor.TabIndex = 5;
            // 
            // IblData
            // 
            IblData.AutoSize = true;
            IblData.Location = new Point(279, 268);
            IblData.Name = "IblData";
            IblData.Size = new Size(90, 15);
            IblData.TabIndex = 6;
            IblData.Text = "Data de Criação";
            // 
            // txtData
            // 
            txtData.Location = new Point(370, 292);
            txtData.Name = "txtData";
            txtData.ReadOnly = true;
            txtData.Size = new Size(100, 23);
            txtData.TabIndex = 7;
            // 
            // button1
            // 
            button1.Location = new Point(296, 358);
            button1.Name = "button1";
            button1.Size = new Size(156, 46);
            button1.TabIndex = 8;
            button1.Text = "button1";
            button1.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(279, 41);
            label5.Name = "label5";
            label5.Size = new Size(202, 25);
            label5.TabIndex = 9;
            label5.Text = "Detalhes da Postagem";
            // 
            // PaginaPostagem
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LightSteelBlue;
            ClientSize = new Size(800, 450);
            Controls.Add(label5);
            Controls.Add(button1);
            Controls.Add(txtData);
            Controls.Add(IblData);
            Controls.Add(txtAutor);
            Controls.Add(IblAutor);
            Controls.Add(txtConteudo);
            Controls.Add(IblConteudo);
            Controls.Add(txtTitulo);
            Controls.Add(IblTitulo);
            Name = "PaginaPostagem";
            Text = "PaginaPostagem";
            Load += PaginaPostagem_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label IblTitulo;
        private TextBox txtTitulo;
        private Label IblConteudo;
        private TextBox txtConteudo;
        private Label IblAutor;
        private TextBox txtAutor;
        private Label IblData;
        private TextBox txtData;
        private Button button1;
        private Label label5;
    }
}