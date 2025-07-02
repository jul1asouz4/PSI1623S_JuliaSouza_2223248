namespace Litly._02
{
    partial class PaginaPrincipal
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
            label1 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            buttonPost = new Button();
            buttonHome = new Button();
            buttonBiblioteca = new Button();
            buttonDM = new Button();
            buttonPerfil = new Button();
            button1 = new Button();
            panel1 = new Panel();
            button2 = new Button();
            label11 = new Label();
            label10 = new Label();
            label9 = new Label();
            txtBrowse = new TextBox();
            btnBrowse = new Button();
            cmbTipoBusca = new ComboBox();
            listResultados = new ListBox();
            label8 = new Label();
            label7 = new Label();
            flowLayoutPanelPosts = new FlowLayoutPanel();
            panel1.SuspendLayout();
            flowLayoutPanelPosts.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(3, 0);
            label1.Name = "label1";
            label1.Size = new Size(252, 21);
            label1.TabIndex = 8;
            label1.Text = "Livros mais populares da semana.";
            label1.Click += label1_Click;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(236, 1221);
            label3.Name = "label3";
            label3.Size = new Size(46, 21);
            label3.TabIndex = 12;
            label3.Text = "Arte.";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(608, 1221);
            label4.Name = "label4";
            label4.Size = new Size(166, 21);
            label4.TabIndex = 13;
            label4.Text = "Melhores livros 2025.";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label5.Location = new Point(244, 1242);
            label5.Name = "label5";
            label5.Size = new Size(211, 21);
            label5.TabIndex = 14;
            label5.Text = "Publicação de demostração";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold);
            label6.Location = new Point(622, 1253);
            label6.Name = "label6";
            label6.Size = new Size(211, 21);
            label6.TabIndex = 15;
            label6.Text = "Publicação de demostração";
            // 
            // buttonPost
            // 
            buttonPost.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            buttonPost.Image = Properties.Resources.Webp_net_resizeimage__3_;
            buttonPost.ImageAlign = ContentAlignment.MiddleRight;
            buttonPost.Location = new Point(12, 399);
            buttonPost.Name = "buttonPost";
            buttonPost.Size = new Size(160, 35);
            buttonPost.TabIndex = 2;
            buttonPost.Text = "Publicar";
            buttonPost.TextImageRelation = TextImageRelation.ImageBeforeText;
            buttonPost.UseVisualStyleBackColor = true;
            buttonPost.Click += button6_Click;
            // 
            // buttonHome
            // 
            buttonHome.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            buttonHome.Image = Properties.Resources.home;
            buttonHome.ImageAlign = ContentAlignment.MiddleRight;
            buttonHome.Location = new Point(12, 157);
            buttonHome.Name = "buttonHome";
            buttonHome.Size = new Size(160, 35);
            buttonHome.TabIndex = 1;
            buttonHome.Text = "Principal";
            buttonHome.TextImageRelation = TextImageRelation.ImageBeforeText;
            buttonHome.UseCompatibleTextRendering = true;
            buttonHome.UseVisualStyleBackColor = true;
            buttonHome.Click += button1_Click;
            // 
            // buttonBiblioteca
            // 
            buttonBiblioteca.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            buttonBiblioteca.Image = Properties.Resources.menu;
            buttonBiblioteca.ImageAlign = ContentAlignment.MiddleRight;
            buttonBiblioteca.Location = new Point(12, 198);
            buttonBiblioteca.Name = "buttonBiblioteca";
            buttonBiblioteca.Size = new Size(160, 35);
            buttonBiblioteca.TabIndex = 2;
            buttonBiblioteca.Text = "Biblioteca";
            buttonBiblioteca.TextImageRelation = TextImageRelation.ImageBeforeText;
            buttonBiblioteca.UseVisualStyleBackColor = true;
            buttonBiblioteca.Click += buttonBiblioteca_Click;
            // 
            // buttonDM
            // 
            buttonDM.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            buttonDM.Image = Properties.Resources.Chat;
            buttonDM.ImageAlign = ContentAlignment.MiddleRight;
            buttonDM.Location = new Point(12, 317);
            buttonDM.Name = "buttonDM";
            buttonDM.Size = new Size(160, 35);
            buttonDM.TabIndex = 2;
            buttonDM.Text = "DM";
            buttonDM.TextImageRelation = TextImageRelation.ImageBeforeText;
            buttonDM.UseVisualStyleBackColor = true;
            buttonDM.Click += button4_Click;
            // 
            // buttonPerfil
            // 
            buttonPerfil.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            buttonPerfil.Image = Properties.Resources.user;
            buttonPerfil.ImageAlign = ContentAlignment.MiddleRight;
            buttonPerfil.Location = new Point(12, 358);
            buttonPerfil.Name = "buttonPerfil";
            buttonPerfil.Size = new Size(160, 35);
            buttonPerfil.TabIndex = 2;
            buttonPerfil.Text = "Perfil";
            buttonPerfil.TextImageRelation = TextImageRelation.ImageBeforeText;
            buttonPerfil.UseVisualStyleBackColor = true;
            buttonPerfil.Click += buttonPerfil_Click;
            // 
            // button1
            // 
            button1.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold);
            button1.Location = new Point(12, 749);
            button1.Name = "button1";
            button1.Size = new Size(83, 32);
            button1.TabIndex = 19;
            button1.Text = "Sair";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click_1;
            // 
            // panel1
            // 
            panel1.BackColor = Color.LightSteelBlue;
            panel1.Controls.Add(button2);
            panel1.Controls.Add(label11);
            panel1.Controls.Add(label10);
            panel1.Controls.Add(label9);
            panel1.Controls.Add(buttonHome);
            panel1.Controls.Add(button1);
            panel1.Controls.Add(buttonBiblioteca);
            panel1.Controls.Add(buttonDM);
            panel1.Controls.Add(buttonPerfil);
            panel1.Controls.Add(buttonPost);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(212, 798);
            panel1.TabIndex = 20;
            // 
            // button2
            // 
            button2.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold);
            button2.Image = Properties.Resources.high_five__1_;
            button2.ImageAlign = ContentAlignment.MiddleLeft;
            button2.Location = new Point(13, 440);
            button2.Margin = new Padding(3, 2, 3, 2);
            button2.Name = "button2";
            button2.Size = new Size(159, 35);
            button2.TabIndex = 27;
            button2.Text = "Amizades";
            button2.TextImageRelation = TextImageRelation.ImageBeforeText;
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label11.Location = new Point(12, 293);
            label11.Name = "label11";
            label11.Size = new Size(63, 21);
            label11.TabIndex = 22;
            label11.Text = "Pessoal";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label10.Location = new Point(12, 129);
            label10.Name = "label10";
            label10.Size = new Size(65, 21);
            label10.TabIndex = 21;
            label10.Text = "Explore";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI Semibold", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label9.Location = new Point(12, 24);
            label9.Name = "label9";
            label9.Size = new Size(52, 30);
            label9.TabIndex = 21;
            label9.Text = "Litly";
            // 
            // txtBrowse
            // 
            txtBrowse.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtBrowse.Location = new Point(407, 45);
            txtBrowse.Name = "txtBrowse";
            txtBrowse.Size = new Size(367, 33);
            txtBrowse.TabIndex = 21;
            txtBrowse.Text = "Pesquisar";
            txtBrowse.TextChanged += txtBrowse_TextChanged;
            // 
            // btnBrowse
            // 
            btnBrowse.Image = Properties.Resources.lupaa;
            btnBrowse.Location = new Point(780, 45);
            btnBrowse.Name = "btnBrowse";
            btnBrowse.Size = new Size(75, 33);
            btnBrowse.TabIndex = 22;
            btnBrowse.UseVisualStyleBackColor = true;
            btnBrowse.Click += btnBrowse_Click;
            // 
            // cmbTipoBusca
            // 
            cmbTipoBusca.Font = new Font("Segoe UI", 14.25F);
            cmbTipoBusca.FormattingEnabled = true;
            cmbTipoBusca.Location = new Point(272, 45);
            cmbTipoBusca.Name = "cmbTipoBusca";
            cmbTipoBusca.Size = new Size(129, 33);
            cmbTipoBusca.TabIndex = 25;
            // 
            // listResultados
            // 
            listResultados.FormattingEnabled = true;
            listResultados.ItemHeight = 15;
            listResultados.Location = new Point(407, 84);
            listResultados.Name = "listResultados";
            listResultados.Size = new Size(367, 19);
            listResultados.TabIndex = 26;
            listResultados.SelectedIndexChanged += listResultados_SelectedIndexChanged;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label8.Location = new Point(1001, 1242);
            label8.Name = "label8";
            label8.Size = new Size(211, 21);
            label8.TabIndex = 18;
            label8.Text = "Publicação de demostração";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.Location = new Point(989, 1221);
            label7.Name = "label7";
            label7.Size = new Size(166, 21);
            label7.TabIndex = 17;
            label7.Text = "Melhores livros 2025.";
            // 
            // flowLayoutPanelPosts
            // 
            flowLayoutPanelPosts.AutoScroll = true;
            flowLayoutPanelPosts.Controls.Add(label1);
            flowLayoutPanelPosts.Location = new Point(254, 153);
            flowLayoutPanelPosts.Name = "flowLayoutPanelPosts";
            flowLayoutPanelPosts.Size = new Size(1036, 572);
            flowLayoutPanelPosts.TabIndex = 27;
            // 
            // PaginaPrincipal
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Info;
            ClientSize = new Size(1330, 798);
            Controls.Add(listResultados);
            Controls.Add(cmbTipoBusca);
            Controls.Add(btnBrowse);
            Controls.Add(txtBrowse);
            Controls.Add(panel1);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(flowLayoutPanelPosts);
            Name = "PaginaPrincipal";
            Text = " ";
            Load += PaginaPrincipal_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            flowLayoutPanelPosts.ResumeLayout(false);
            flowLayoutPanelPosts.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label1;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Button buttonPost;
        private Button buttonHome;
        private Button buttonBiblioteca;
        private Button buttonDM;
        private Button buttonPerfil;
        private Button button1;
        private Panel panel1;
        private Label label11;
        private Label label10;
        private Label label9;
        private TextBox txtBrowse;
        private Button btnBrowse;
        private ComboBox cmbTipoBusca;
        private ListBox listResultados;
        private Button button2;
        private Label label8;
        private Label label7;
        private FlowLayoutPanel flowLayoutPanelPosts;
    }
}