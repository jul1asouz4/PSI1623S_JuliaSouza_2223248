namespace Litly._02
{
    partial class DetalhesLivros
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
            lblTitulo = new Label();
            lblAutor = new Label();
            lblSinopse = new Label();
            lblAno = new Label();
            btnVoltar = new Button();
            panel1 = new Panel();
            SuspendLayout();
            // 
            // lblTitulo
            // 
            lblTitulo.AutoSize = true;
            lblTitulo.BackColor = Color.Cornsilk;
            lblTitulo.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblTitulo.Location = new Point(285, 85);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(140, 25);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Exemplo Titulo";
            // 
            // lblAutor
            // 
            lblAutor.AutoSize = true;
            lblAutor.BackColor = Color.Cornsilk;
            lblAutor.Location = new Point(327, 127);
            lblAutor.Name = "lblAutor";
            lblAutor.Size = new Size(37, 15);
            lblAutor.TabIndex = 1;
            lblAutor.Text = "Autor";
            // 
            // lblSinopse
            // 
            lblSinopse.AutoSize = true;
            lblSinopse.BackColor = Color.Cornsilk;
            lblSinopse.Location = new Point(207, 201);
            lblSinopse.Name = "lblSinopse";
            lblSinopse.Size = new Size(48, 15);
            lblSinopse.TabIndex = 2;
            lblSinopse.Text = "Sinopse";
            // 
            // lblAno
            // 
            lblAno.AutoSize = true;
            lblAno.BackColor = Color.Cornsilk;
            lblAno.Location = new Point(207, 254);
            lblAno.Name = "lblAno";
            lblAno.Size = new Size(90, 15);
            lblAno.TabIndex = 3;
            lblAno.Text = "Ano publicação";
            // 
            // btnVoltar
            // 
            btnVoltar.Location = new Point(558, 384);
            btnVoltar.Name = "btnVoltar";
            btnVoltar.Size = new Size(158, 25);
            btnVoltar.TabIndex = 4;
            btnVoltar.Text = "Voltar";
            btnVoltar.UseVisualStyleBackColor = true;
            btnVoltar.Click += btnVoltar_Click;
            // 
            // panel1
            // 
            panel1.BackColor = Color.Cornsilk;
            panel1.Location = new Point(190, 61);
            panel1.Name = "panel1";
            panel1.Size = new Size(337, 304);
            panel1.TabIndex = 5;
            // 
            // DetalhesLivros
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LightSteelBlue;
            ClientSize = new Size(800, 450);
            Controls.Add(btnVoltar);
            Controls.Add(lblAno);
            Controls.Add(lblSinopse);
            Controls.Add(lblAutor);
            Controls.Add(lblTitulo);
            Controls.Add(panel1);
            Name = "DetalhesLivros";
            Text = "DetalhesLivros";
            Load += DetalhesLivros_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblTitulo;
        private Label lblAutor;
        private Label lblSinopse;
        private Label lblAno;
        private Button btnVoltar;
        private Panel panel1;
    }
}