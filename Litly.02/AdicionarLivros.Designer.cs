namespace Litly._02
{
    partial class AdicionarLivros
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
            panel1 = new Panel();
            dtpDataPublicacao = new DateTimePicker();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            txtSinopse = new TextBox();
            txtCapaUrl = new TextBox();
            btnAdicionar = new Button();
            label3 = new Label();
            label2 = new Label();
            txtAutor = new TextBox();
            txtTitulo = new TextBox();
            label1 = new Label();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.Info;
            panel1.Controls.Add(dtpDataPublicacao);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(txtSinopse);
            panel1.Controls.Add(txtCapaUrl);
            panel1.Controls.Add(btnAdicionar);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(txtAutor);
            panel1.Controls.Add(txtTitulo);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(144, 76);
            panel1.Name = "panel1";
            panel1.Size = new Size(488, 484);
            panel1.TabIndex = 0;
            // 
            // dtpDataPublicacao
            // 
            dtpDataPublicacao.Location = new Point(116, 331);
            dtpDataPublicacao.Name = "dtpDataPublicacao";
            dtpDataPublicacao.Size = new Size(233, 23);
            dtpDataPublicacao.TabIndex = 14;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(116, 313);
            label6.Name = "label6";
            label6.Size = new Size(108, 15);
            label6.TabIndex = 13;
            label6.Text = "Data de publicação";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(116, 253);
            label5.Name = "label5";
            label5.Size = new Size(48, 15);
            label5.TabIndex = 9;
            label5.Text = "Sinopse";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(116, 193);
            label4.Name = "label4";
            label4.Size = new Size(58, 15);
            label4.TabIndex = 8;
            label4.Text = "Capa URL";
            // 
            // txtSinopse
            // 
            txtSinopse.Location = new Point(115, 271);
            txtSinopse.Name = "txtSinopse";
            txtSinopse.Size = new Size(234, 23);
            txtSinopse.TabIndex = 7;
            // 
            // txtCapaUrl
            // 
            txtCapaUrl.Location = new Point(115, 211);
            txtCapaUrl.Name = "txtCapaUrl";
            txtCapaUrl.Size = new Size(234, 23);
            txtCapaUrl.TabIndex = 6;
            // 
            // btnAdicionar
            // 
            btnAdicionar.Location = new Point(183, 383);
            btnAdicionar.Name = "btnAdicionar";
            btnAdicionar.Size = new Size(106, 23);
            btnAdicionar.TabIndex = 5;
            btnAdicionar.Text = "Adicionar";
            btnAdicionar.UseVisualStyleBackColor = true;
            btnAdicionar.Click += btnAdicionar_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(115, 135);
            label3.Name = "label3";
            label3.Size = new Size(37, 15);
            label3.TabIndex = 4;
            label3.Text = "Autor";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(115, 73);
            label2.Name = "label2";
            label2.Size = new Size(38, 15);
            label2.TabIndex = 3;
            label2.Text = "Titulo";
            // 
            // txtAutor
            // 
            txtAutor.Location = new Point(115, 151);
            txtAutor.Name = "txtAutor";
            txtAutor.Size = new Size(234, 23);
            txtAutor.TabIndex = 2;
            // 
            // txtTitulo
            // 
            txtTitulo.Location = new Point(115, 91);
            txtTitulo.Name = "txtTitulo";
            txtTitulo.Size = new Size(234, 23);
            txtTitulo.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(183, 20);
            label1.Name = "label1";
            label1.Size = new Size(127, 21);
            label1.TabIndex = 0;
            label1.Text = "Adicionar Livros";
            // 
            // AdicionarLivros
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LightSteelBlue;
            ClientSize = new Size(800, 715);
            Controls.Add(panel1);
            Name = "AdicionarLivros";
            Text = "AdicionarLivros";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label label1;
        private Button btnAdicionar;
        private Label label3;
        private Label label2;
        private TextBox txtAutor;
        private TextBox txtTitulo;
        private DateTimePicker dtpDataPublicacao;
        private Label label6;
        private Label label5;
        private Label label4;
        private TextBox txtSinopse;
        private TextBox txtCapaUrl;
    }
}