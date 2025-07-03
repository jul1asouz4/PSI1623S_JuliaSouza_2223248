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
            flowLayoutPosts = new FlowLayoutPanel();
            lblBio = new Label();
            label3 = new Label();
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
            lblNome.Location = new Point(776, 381);
            lblNome.Name = "lblNome";
            lblNome.Size = new Size(71, 32);
            lblNome.TabIndex = 0;
            lblNome.Text = "label1";
            lblNome.Click += IblNome_Click;
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Font = new Font("Segoe UI Semilight", 14.25F);
            lblEmail.Location = new Point(776, 439);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(71, 32);
            lblEmail.TabIndex = 2;
            lblEmail.Text = "label1";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold);
            label1.Location = new Point(587, 381);
            label1.Name = "label1";
            label1.Size = new Size(80, 32);
            label1.TabIndex = 4;
            label1.Text = "Nome";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold);
            label2.Location = new Point(587, 439);
            label2.Name = "label2";
            label2.Size = new Size(72, 32);
            label2.TabIndex = 5;
            label2.Text = "Email";
            // 
            // pictureBoxFotoPerfil
            // 
            pictureBoxFotoPerfil.Location = new Point(600, 17);
            pictureBoxFotoPerfil.Margin = new Padding(3, 4, 3, 4);
            pictureBoxFotoPerfil.Name = "pictureBoxFotoPerfil";
            pictureBoxFotoPerfil.Size = new Size(242, 280);
            pictureBoxFotoPerfil.SizeMode = PictureBoxSizeMode.Zoom;
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
            panel1.Location = new Point(67, 31);
            panel1.Margin = new Padding(3, 4, 3, 4);
            panel1.Name = "panel1";
            panel1.Size = new Size(1522, 995);
            panel1.TabIndex = 9;
            panel1.Paint += panel1_Paint;
            // 
            // flowLayoutPosts
            // 
            flowLayoutPosts.AutoScroll = true;
            flowLayoutPosts.BackColor = Color.LightSteelBlue;
            flowLayoutPosts.Location = new Point(107, 612);
            flowLayoutPosts.Margin = new Padding(3, 4, 3, 4);
            flowLayoutPosts.Name = "flowLayoutPosts";
            flowLayoutPosts.Size = new Size(1289, 344);
            flowLayoutPosts.TabIndex = 14;
            // 
            // lblBio
            // 
            lblBio.AutoSize = true;
            lblBio.Font = new Font("Segoe UI Semilight", 14.25F);
            lblBio.Location = new Point(776, 493);
            lblBio.Name = "lblBio";
            lblBio.Size = new Size(71, 32);
            lblBio.TabIndex = 13;
            lblBio.Text = "label1";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold);
            label3.Location = new Point(594, 493);
            label3.Name = "label3";
            label3.Size = new Size(49, 32);
            label3.TabIndex = 12;
            label3.Text = "Bio";
            // 
            // btnSalvarImagem
            // 
            btnSalvarImagem.Location = new Point(730, 340);
            btnSalvarImagem.Name = "btnSalvarImagem";
            btnSalvarImagem.Size = new Size(133, 27);
            btnSalvarImagem.TabIndex = 11;
            btnSalvarImagem.Text = "Salvar Foto";
            btnSalvarImagem.UseVisualStyleBackColor = true;
            btnSalvarImagem.Click += btnSalvarImagem_Click;
            // 
            // button1
            // 
            button1.Location = new Point(591, 340);
            button1.Margin = new Padding(3, 4, 3, 4);
            button1.Name = "button1";
            button1.Size = new Size(133, 27);
            button1.TabIndex = 10;
            button1.Text = "Carregar Foto";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // button3
            // 
            button3.Location = new Point(1466, 1032);
            button3.Name = "button3";
            button3.Size = new Size(160, 45);
            button3.TabIndex = 10;
            button3.Text = "Voltar ao principal";
            button3.UseVisualStyleBackColor = true;
            button3.Click += button3_Click;
            // 
            // PerfilUtilizador
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LightSteelBlue;
            ClientSize = new Size(1675, 1108);
            Controls.Add(button3);
            Controls.Add(panel1);
            Margin = new Padding(3, 4, 3, 4);
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