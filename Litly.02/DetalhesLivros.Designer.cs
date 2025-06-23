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
            lblTitulo.Location = new Point(326, 113);
            lblTitulo.Name = "lblTitulo";
            lblTitulo.Size = new Size(175, 32);
            lblTitulo.TabIndex = 0;
            lblTitulo.Text = "Exemplo Titulo";
            // 
            // lblAutor
            // 
            lblAutor.AutoSize = true;
            lblAutor.BackColor = Color.Cornsilk;
            lblAutor.Location = new Point(374, 169);
            lblAutor.Name = "lblAutor";
            lblAutor.Size = new Size(46, 20);
            lblAutor.TabIndex = 1;
            lblAutor.Text = "Autor";
            // 
            // lblSinopse
            // 
            lblSinopse.AutoSize = true;
            lblSinopse.BackColor = Color.Cornsilk;
            lblSinopse.Location = new Point(237, 268);
            lblSinopse.Name = "lblSinopse";
            lblSinopse.Size = new Size(61, 20);
            lblSinopse.TabIndex = 2;
            lblSinopse.Text = "Sinopse";
            // 
            // lblAno
            // 
            lblAno.AutoSize = true;
            lblAno.BackColor = Color.Cornsilk;
            lblAno.Location = new Point(237, 339);
            lblAno.Name = "lblAno";
            lblAno.Size = new Size(113, 20);
            lblAno.TabIndex = 3;
            lblAno.Text = "Ano publicação";
            // 
            // btnVoltar
            // 
            btnVoltar.Location = new Point(638, 512);
            btnVoltar.Margin = new Padding(3, 4, 3, 4);
            btnVoltar.Name = "btnVoltar";
            btnVoltar.Size = new Size(181, 33);
            btnVoltar.TabIndex = 4;
            btnVoltar.Text = "Voltar";
            btnVoltar.UseVisualStyleBackColor = true;
            btnVoltar.Click += btnVoltar_Click;
            // 
            // panel1
            // 
            panel1.BackColor = Color.Cornsilk;
            panel1.Location = new Point(217, 81);
            panel1.Margin = new Padding(3, 4, 3, 4);
            panel1.Name = "panel1";
            panel1.Size = new Size(385, 405);
            panel1.TabIndex = 5;
            // 
            // DetalhesLivros
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LightSteelBlue;
            ClientSize = new Size(914, 600);
            Controls.Add(btnVoltar);
            Controls.Add(lblAno);
            Controls.Add(lblSinopse);
            Controls.Add(lblAutor);
            Controls.Add(lblTitulo);
            Controls.Add(panel1);
            Margin = new Padding(3, 4, 3, 4);
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