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
            btnPublicar = new Button();
            label5 = new Label();
            panel1 = new Panel();
            btnRemoverImagem = new Button();
            btnSelecionarImagem = new Button();
            pictureBoxPostagem = new PictureBox();
            btnVoltar = new Button();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxPostagem).BeginInit();
            SuspendLayout();
            // 
            // IblTitulo
            // 
            IblTitulo.AutoSize = true;
            IblTitulo.BackColor = Color.Cornsilk;
            IblTitulo.Location = new Point(133, 91);
            IblTitulo.Name = "IblTitulo";
            IblTitulo.Size = new Size(47, 20);
            IblTitulo.TabIndex = 0;
            IblTitulo.Text = "Titulo";
            // 
            // txtTitulo
            // 
            txtTitulo.Location = new Point(194, 80);
            txtTitulo.Margin = new Padding(3, 4, 3, 4);
            txtTitulo.Name = "txtTitulo";
            txtTitulo.ReadOnly = true;
            txtTitulo.Size = new Size(114, 27);
            txtTitulo.TabIndex = 1;
            // 
            // IblConteudo
            // 
            IblConteudo.AutoSize = true;
            IblConteudo.BackColor = Color.Cornsilk;
            IblConteudo.Location = new Point(422, 97);
            IblConteudo.Name = "IblConteudo";
            IblConteudo.Size = new Size(74, 20);
            IblConteudo.TabIndex = 2;
            IblConteudo.Text = "Conteúdo";
            // 
            // txtConteudo
            // 
            txtConteudo.Location = new Point(505, 87);
            txtConteudo.Margin = new Padding(3, 4, 3, 4);
            txtConteudo.Multiline = true;
            txtConteudo.Name = "txtConteudo";
            txtConteudo.ReadOnly = true;
            txtConteudo.ScrollBars = ScrollBars.Vertical;
            txtConteudo.Size = new Size(114, 29);
            txtConteudo.TabIndex = 3;
            // 
            // IblAutor
            // 
            IblAutor.AutoSize = true;
            IblAutor.BackColor = Color.Cornsilk;
            IblAutor.Location = new Point(133, 160);
            IblAutor.Name = "IblAutor";
            IblAutor.Size = new Size(46, 20);
            IblAutor.TabIndex = 4;
            IblAutor.Text = "Autor";
            // 
            // txtAutor
            // 
            txtAutor.Location = new Point(194, 149);
            txtAutor.Margin = new Padding(3, 4, 3, 4);
            txtAutor.Name = "txtAutor";
            txtAutor.ReadOnly = true;
            txtAutor.Size = new Size(114, 27);
            txtAutor.TabIndex = 5;
            // 
            // IblData
            // 
            IblData.AutoSize = true;
            IblData.BackColor = Color.Cornsilk;
            IblData.Location = new Point(395, 167);
            IblData.Name = "IblData";
            IblData.Size = new Size(116, 20);
            IblData.TabIndex = 6;
            IblData.Text = "Data de Criação";
            // 
            // txtData
            // 
            txtData.Location = new Point(505, 156);
            txtData.Margin = new Padding(3, 4, 3, 4);
            txtData.Name = "txtData";
            txtData.ReadOnly = true;
            txtData.Size = new Size(114, 27);
            txtData.TabIndex = 7;
            // 
            // btnPublicar
            // 
            btnPublicar.Location = new Point(279, 456);
            btnPublicar.Margin = new Padding(3, 4, 3, 4);
            btnPublicar.Name = "btnPublicar";
            btnPublicar.Size = new Size(178, 61);
            btnPublicar.TabIndex = 8;
            btnPublicar.Text = "Publicar";
            btnPublicar.UseVisualStyleBackColor = true;
            btnPublicar.Click += btnPublicar_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.Cornsilk;
            label5.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(259, 20);
            label5.Name = "label5";
            label5.Size = new Size(257, 32);
            label5.TabIndex = 9;
            label5.Text = "Detalhes da Postagem";
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.Info;
            panel1.Controls.Add(btnRemoverImagem);
            panel1.Controls.Add(btnSelecionarImagem);
            panel1.Controls.Add(btnPublicar);
            panel1.Controls.Add(pictureBoxPostagem);
            panel1.Controls.Add(txtTitulo);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(txtData);
            panel1.Controls.Add(IblTitulo);
            panel1.Controls.Add(IblData);
            panel1.Controls.Add(IblConteudo);
            panel1.Controls.Add(txtAutor);
            panel1.Controls.Add(txtConteudo);
            panel1.Controls.Add(IblAutor);
            panel1.Location = new Point(59, 37);
            panel1.Margin = new Padding(3, 4, 3, 4);
            panel1.Name = "panel1";
            panel1.Size = new Size(763, 536);
            panel1.TabIndex = 10;
            panel1.Paint += panel1_Paint;
            // 
            // btnRemoverImagem
            // 
            btnRemoverImagem.BackColor = Color.FromArgb(255, 111, 97);
            btnRemoverImagem.Location = new Point(371, 391);
            btnRemoverImagem.Margin = new Padding(3, 4, 3, 4);
            btnRemoverImagem.Name = "btnRemoverImagem";
            btnRemoverImagem.Size = new Size(86, 31);
            btnRemoverImagem.TabIndex = 12;
            btnRemoverImagem.Text = "Remover";
            btnRemoverImagem.UseVisualStyleBackColor = false;
            btnRemoverImagem.Click += btnRemoverImagem_Click;
            // 
            // btnSelecionarImagem
            // 
            btnSelecionarImagem.BackColor = Color.PaleGreen;
            btnSelecionarImagem.Location = new Point(279, 391);
            btnSelecionarImagem.Margin = new Padding(3, 4, 3, 4);
            btnSelecionarImagem.Name = "btnSelecionarImagem";
            btnSelecionarImagem.Size = new Size(86, 31);
            btnSelecionarImagem.TabIndex = 11;
            btnSelecionarImagem.Text = "Adicionar";
            btnSelecionarImagem.UseVisualStyleBackColor = false;
            btnSelecionarImagem.Click += btnSelecionarImagem_Click;
            // 
            // pictureBoxPostagem
            // 
            pictureBoxPostagem.Location = new Point(279, 229);
            pictureBoxPostagem.Margin = new Padding(3, 4, 3, 4);
            pictureBoxPostagem.Name = "pictureBoxPostagem";
            pictureBoxPostagem.Size = new Size(178, 153);
            pictureBoxPostagem.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxPostagem.TabIndex = 10;
            pictureBoxPostagem.TabStop = false;
            // 
            // btnVoltar
            // 
            btnVoltar.Location = new Point(632, 580);
            btnVoltar.Name = "btnVoltar";
            btnVoltar.Size = new Size(127, 29);
            btnVoltar.TabIndex = 11;
            btnVoltar.Text = "Voltar ";
            btnVoltar.UseVisualStyleBackColor = true;
            btnVoltar.Click += btnVoltar_Click;
            // 
            // PaginaPostagem
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LightSteelBlue;
            ClientSize = new Size(914, 629);
            Controls.Add(btnVoltar);
            Controls.Add(panel1);
            Margin = new Padding(3, 4, 3, 4);
            Name = "PaginaPostagem";
            Text = "PaginaPostagem";
            Load += PaginaPostagem_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBoxPostagem).EndInit();
            ResumeLayout(false);
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
        private Button btnPublicar;
        private Label label5;
        private Panel panel1;
        private Button btnVoltar;
        private PictureBox pictureBoxPostagem;
        private Button btnRemoverImagem;
        private Button btnSelecionarImagem;
    }
}