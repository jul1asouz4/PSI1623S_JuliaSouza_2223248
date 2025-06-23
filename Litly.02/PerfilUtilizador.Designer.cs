namespace Litly._02
{
    partial class PerfilUtilizador
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
            lblNome = new Label();
            lblEmail = new Label();
            label1 = new Label();
            label2 = new Label();
            pictureBoxFotoPerfil = new PictureBox();
            panel1 = new Panel();
            btnSalvarImagem = new Button();
            button1 = new Button();
            button3 = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBoxFotoPerfil).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // lblNome
            // 
            lblNome.AutoSize = true;
            lblNome.Font = new Font("Segoe UI Semilight", 14.25F);
            lblNome.Location = new Point(221, 207);
            lblNome.Name = "lblNome";
            lblNome.Size = new Size(58, 25);
            lblNome.TabIndex = 0;
            lblNome.Text = "label1";
            lblNome.Click += IblNome_Click;
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Font = new Font("Segoe UI Semilight", 14.25F);
            lblEmail.Location = new Point(221, 250);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(58, 25);
            lblEmail.TabIndex = 2;
            lblEmail.Text = "label1";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold);
            label1.Location = new Point(56, 207);
            label1.Name = "label1";
            label1.Size = new Size(65, 25);
            label1.TabIndex = 4;
            label1.Text = "Nome";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold);
            label2.Location = new Point(56, 250);
            label2.Name = "label2";
            label2.Size = new Size(59, 25);
            label2.TabIndex = 5;
            label2.Text = "Email";
            // 
            // pictureBoxFotoPerfil
            // 
            pictureBoxFotoPerfil.Location = new Point(288, 36);
            pictureBoxFotoPerfil.Name = "pictureBoxFotoPerfil";
            pictureBoxFotoPerfil.Size = new Size(147, 131);
            pictureBoxFotoPerfil.TabIndex = 8;
            pictureBoxFotoPerfil.TabStop = false;
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.Info;
            panel1.Controls.Add(btnSalvarImagem);
            panel1.Controls.Add(button1);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(lblEmail);
            panel1.Controls.Add(lblNome);
            panel1.Location = new Point(176, 23);
            panel1.Name = "panel1";
            panel1.Size = new Size(377, 378);
            panel1.TabIndex = 9;
            // 
            // btnSalvarImagem
            // 
            btnSalvarImagem.Location = new Point(185, 162);
            btnSalvarImagem.Margin = new Padding(3, 2, 3, 2);
            btnSalvarImagem.Name = "btnSalvarImagem";
            btnSalvarImagem.Size = new Size(116, 20);
            btnSalvarImagem.TabIndex = 11;
            btnSalvarImagem.Text = "Salvar Foto";
            btnSalvarImagem.UseVisualStyleBackColor = true;
            btnSalvarImagem.Click += btnSalvarImagem_Click;
            // 
            // button1
            // 
            button1.Location = new Point(63, 162);
            button1.Name = "button1";
            button1.Size = new Size(116, 20);
            button1.TabIndex = 10;
            button1.Text = "Carregar Foto";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button3
            // 
            button3.Location = new Point(507, 416);
            button3.Margin = new Padding(3, 2, 3, 2);
            button3.Name = "button3";
            button3.Size = new Size(140, 22);
            button3.TabIndex = 10;
            button3.Text = "Voltar ao principal";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // PerfilUtilizador
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LightSteelBlue;
            ClientSize = new Size(737, 450);
            Controls.Add(button3);
            Controls.Add(pictureBoxFotoPerfil);
            Controls.Add(panel1);
            Name = "PerfilUtilizador";
            Text = "PerfilUtilizador";
            Load += PerfilUtilizador_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBoxFotoPerfil).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label lblNome;
        private Label lblEmail;
        private Label label1;
        private Label label2;
        private PictureBox pictureBoxFotoPerfil;
        private Panel panel1;
        private Button button1;
        private Button btnSalvarImagem;
        private Button button3;
    }
}