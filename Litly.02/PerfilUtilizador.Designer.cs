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
            lblBio = new Label();
            label3 = new Label();
            btnSalvarImagem = new Button();
            button1 = new Button();
            button3 = new Button();
            flowLayoutPosts = new FlowLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)pictureBoxFotoPerfil).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // lblNome
            // 
            lblNome.AutoSize = true;
            lblNome.Font = new Font("Segoe UI Semilight", 14.25F);
            lblNome.Location = new Point(679, 286);
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
            lblEmail.Location = new Point(679, 329);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(58, 25);
            lblEmail.TabIndex = 2;
            lblEmail.Text = "label1";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold);
            label1.Location = new Point(514, 286);
            label1.Name = "label1";
            label1.Size = new Size(65, 25);
            label1.TabIndex = 4;
            label1.Text = "Nome";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold);
            label2.Location = new Point(514, 329);
            label2.Name = "label2";
            label2.Size = new Size(59, 25);
            label2.TabIndex = 5;
            label2.Text = "Email";
            // 
            // pictureBoxFotoPerfil
            // 
            pictureBoxFotoPerfil.Location = new Point(525, 13);
            pictureBoxFotoPerfil.Name = "pictureBoxFotoPerfil";
            pictureBoxFotoPerfil.Size = new Size(212, 210);
            pictureBoxFotoPerfil.TabIndex = 8;
            pictureBoxFotoPerfil.TabStop = false;
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.Info;
            panel1.Controls.Add(flowLayoutPosts);
            panel1.Controls.Add(lblBio);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(btnSalvarImagem);
            panel1.Controls.Add(pictureBoxFotoPerfil);
            panel1.Controls.Add(button1);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(lblEmail);
            panel1.Controls.Add(lblNome);
            panel1.Location = new Point(59, 23);
            panel1.Name = "panel1";
            panel1.Size = new Size(1332, 746);
            panel1.TabIndex = 9;
            panel1.Paint += panel1_Paint;
            // 
            // lblBio
            // 
            lblBio.AutoSize = true;
            lblBio.Font = new Font("Segoe UI Semilight", 14.25F);
            lblBio.Location = new Point(679, 370);
            lblBio.Name = "lblBio";
            lblBio.Size = new Size(58, 25);
            lblBio.TabIndex = 13;
            lblBio.Text = "label1";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold);
            label3.Location = new Point(520, 370);
            label3.Name = "label3";
            label3.Size = new Size(39, 25);
            label3.TabIndex = 12;
            label3.Text = "Bio";
            // 
            // btnSalvarImagem
            // 
            btnSalvarImagem.Location = new Point(639, 255);
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
            button1.Location = new Point(517, 255);
            button1.Name = "button1";
            button1.Size = new Size(116, 20);
            button1.TabIndex = 10;
            button1.Text = "Carregar Foto";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button3
            // 
            button3.Location = new Point(1283, 774);
            button3.Margin = new Padding(3, 2, 3, 2);
            button3.Name = "button3";
            button3.Size = new Size(140, 34);
            button3.TabIndex = 10;
            button3.Text = "Voltar ao principal";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // flowLayoutPosts
            // 
            flowLayoutPosts.AutoScroll = true;
            flowLayoutPosts.BackColor = Color.LightSteelBlue;
            flowLayoutPosts.Location = new Point(94, 459);
            flowLayoutPosts.Name = "flowLayoutPosts";
            flowLayoutPosts.Size = new Size(1128, 258);
            flowLayoutPosts.TabIndex = 14;
            // 
            // PerfilUtilizador
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LightSteelBlue;
            ClientSize = new Size(1466, 831);
            Controls.Add(button3);
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
        private Label lblBio;
        private Label label3;
        private FlowLayoutPanel flowLayoutPosts;
    }
}