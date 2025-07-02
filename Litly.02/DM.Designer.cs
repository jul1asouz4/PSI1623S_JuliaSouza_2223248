namespace Litly._02
{
    partial class FormChat
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
            pnlMensagens = new Panel();
            listChats = new ListBox();
            btnPedidos = new Button();
            listSugestoesAmigos = new ListBox();
            btnSair = new Button();
            label1 = new Label();
            txtPesquisarChat = new TextBox();
            panelMensagens = new Panel();
            panelPerfil = new Panel();
            btnVerPerfil = new Button();
            lblStatusPerfil = new Label();
            lblNomePerfil = new Label();
            picPerfil = new PictureBox();
            btnEnviar = new Button();
            txtMensagem = new TextBox();
            flowMensagens = new FlowLayoutPanel();
            lblNomeContato = new Label();
            pnlMensagens.SuspendLayout();
            panelMensagens.SuspendLayout();
            panelPerfil.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)picPerfil).BeginInit();
            flowMensagens.SuspendLayout();
            SuspendLayout();
            // 
            // pnlMensagens
            // 
            pnlMensagens.BackColor = Color.LightSteelBlue;
            pnlMensagens.Controls.Add(listChats);
            pnlMensagens.Controls.Add(btnPedidos);
            pnlMensagens.Controls.Add(listSugestoesAmigos);
            pnlMensagens.Controls.Add(btnSair);
            pnlMensagens.Controls.Add(label1);
            pnlMensagens.Controls.Add(txtPesquisarChat);
            pnlMensagens.Dock = DockStyle.Left;
            pnlMensagens.Location = new Point(0, 0);
            pnlMensagens.Margin = new Padding(3, 4, 3, 4);
            pnlMensagens.Name = "pnlMensagens";
            pnlMensagens.Size = new Size(229, 748);
            pnlMensagens.TabIndex = 0;
            // 
            // listChats
            // 
            listChats.FormattingEnabled = true;
            listChats.Location = new Point(25, 409);
            listChats.Name = "listChats";
            listChats.Size = new Size(172, 204);
            listChats.TabIndex = 5;
            listChats.SelectedIndexChanged += listChats_SelectedIndexChanged_1;
            // 
            // btnPedidos
            // 
            btnPedidos.Location = new Point(25, 659);
            btnPedidos.Margin = new Padding(3, 4, 3, 4);
            btnPedidos.Name = "btnPedidos";
            btnPedidos.Size = new Size(173, 31);
            btnPedidos.TabIndex = 2;
            btnPedidos.Text = "Pedidos de amizade";
            btnPedidos.UseVisualStyleBackColor = true;
            btnPedidos.Click += btnPedidos_Click;
            // 
            // listSugestoesAmigos
            // 
            listSugestoesAmigos.FormattingEnabled = true;
            listSugestoesAmigos.Location = new Point(25, 109);
            listSugestoesAmigos.Name = "listSugestoesAmigos";
            listSugestoesAmigos.Size = new Size(172, 284);
            listSugestoesAmigos.TabIndex = 1;
            listSugestoesAmigos.SelectedIndexChanged += listSugestoesAmigos_SelectedIndexChanged;
            // 
            // btnSair
            // 
            btnSair.Location = new Point(63, 620);
            btnSair.Margin = new Padding(3, 4, 3, 4);
            btnSair.Name = "btnSair";
            btnSair.Size = new Size(86, 31);
            btnSair.TabIndex = 0;
            btnSair.Text = "Sair";
            btnSair.UseVisualStyleBackColor = true;
            btnSair.Click += btnSair_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(25, 24);
            label1.Name = "label1";
            label1.Size = new Size(96, 28);
            label1.TabIndex = 1;
            label1.Text = "Litly Chat";
            // 
            // txtPesquisarChat
            // 
            txtPesquisarChat.Location = new Point(25, 76);
            txtPesquisarChat.Margin = new Padding(3, 4, 3, 4);
            txtPesquisarChat.Name = "txtPesquisarChat";
            txtPesquisarChat.PlaceholderText = "Procurar conversas ";
            txtPesquisarChat.Size = new Size(172, 27);
            txtPesquisarChat.TabIndex = 1;
            txtPesquisarChat.TextChanged += txtPesquisarChat_TextChanged;
            // 
            // panelMensagens
            // 
            panelMensagens.BackColor = Color.LemonChiffon;
            panelMensagens.Controls.Add(panelPerfil);
            panelMensagens.Controls.Add(btnEnviar);
            panelMensagens.Controls.Add(txtMensagem);
            panelMensagens.Controls.Add(flowMensagens);
            panelMensagens.Dock = DockStyle.Fill;
            panelMensagens.Location = new Point(229, 0);
            panelMensagens.Margin = new Padding(3, 4, 3, 4);
            panelMensagens.Name = "panelMensagens";
            panelMensagens.Size = new Size(1008, 748);
            panelMensagens.TabIndex = 1;
            // 
            // panelPerfil
            // 
            panelPerfil.BackColor = Color.Cornsilk;
            panelPerfil.Controls.Add(btnVerPerfil);
            panelPerfil.Controls.Add(lblStatusPerfil);
            panelPerfil.Controls.Add(lblNomePerfil);
            panelPerfil.Controls.Add(picPerfil);
            panelPerfil.Dock = DockStyle.Right;
            panelPerfil.Location = new Point(667, 0);
            panelPerfil.Margin = new Padding(3, 4, 3, 4);
            panelPerfil.Name = "panelPerfil";
            panelPerfil.Size = new Size(341, 748);
            panelPerfil.TabIndex = 4;
            // 
            // btnVerPerfil
            // 
            btnVerPerfil.Location = new Point(102, 372);
            btnVerPerfil.Margin = new Padding(3, 4, 3, 4);
            btnVerPerfil.Name = "btnVerPerfil";
            btnVerPerfil.Size = new Size(135, 35);
            btnVerPerfil.TabIndex = 3;
            btnVerPerfil.Text = "Ver perfil";
            btnVerPerfil.UseVisualStyleBackColor = true;
            btnVerPerfil.Click += btnVerPerfil_Click_1;
            // 
            // lblStatusPerfil
            // 
            lblStatusPerfil.AutoSize = true;
            lblStatusPerfil.Location = new Point(149, 309);
            lblStatusPerfil.Name = "lblStatusPerfil";
            lblStatusPerfil.Size = new Size(50, 20);
            lblStatusPerfil.TabIndex = 2;
            lblStatusPerfil.Text = "label3";
            // 
            // lblNomePerfil
            // 
            lblNomePerfil.AutoSize = true;
            lblNomePerfil.Location = new Point(149, 252);
            lblNomePerfil.Name = "lblNomePerfil";
            lblNomePerfil.Size = new Size(50, 20);
            lblNomePerfil.TabIndex = 1;
            lblNomePerfil.Text = "label3";
            // 
            // picPerfil
            // 
            picPerfil.Location = new Point(102, 76);
            picPerfil.Margin = new Padding(3, 4, 3, 4);
            picPerfil.Name = "picPerfil";
            picPerfil.Size = new Size(135, 143);
            picPerfil.TabIndex = 0;
            picPerfil.TabStop = false;
            // 
            // btnEnviar
            // 
            btnEnviar.BackColor = Color.LightYellow;
            btnEnviar.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnEnviar.ForeColor = SystemColors.ActiveCaptionText;
            btnEnviar.Image = Properties.Resources.send__2_;
            btnEnviar.Location = new Point(545, 681);
            btnEnviar.Margin = new Padding(3, 4, 3, 4);
            btnEnviar.Name = "btnEnviar";
            btnEnviar.Size = new Size(115, 67);
            btnEnviar.TabIndex = 3;
            btnEnviar.TextImageRelation = TextImageRelation.TextBeforeImage;
            btnEnviar.UseVisualStyleBackColor = false;
            btnEnviar.Click += btnEnviar_Click;
            // 
            // txtMensagem
            // 
            txtMensagem.Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txtMensagem.Location = new Point(3, 681);
            txtMensagem.Margin = new Padding(3, 4, 3, 4);
            txtMensagem.Multiline = true;
            txtMensagem.Name = "txtMensagem";
            txtMensagem.Size = new Size(541, 65);
            txtMensagem.TabIndex = 2;
            txtMensagem.KeyDown += txtMensagem_KeyDown;
            // 
            // flowMensagens
            // 
            flowMensagens.AutoScroll = true;
            flowMensagens.BackColor = SystemColors.Info;
            flowMensagens.Controls.Add(lblNomeContato);
            flowMensagens.Dock = DockStyle.Fill;
            flowMensagens.FlowDirection = FlowDirection.TopDown;
            flowMensagens.Location = new Point(0, 0);
            flowMensagens.Margin = new Padding(3, 4, 3, 4);
            flowMensagens.Name = "flowMensagens";
            flowMensagens.Size = new Size(1008, 748);
            flowMensagens.TabIndex = 1;
            flowMensagens.WrapContents = false;
            flowMensagens.Paint += flowMensagens_Paint;
            // 
            // lblNomeContato
            // 
            lblNomeContato.AutoSize = true;
            lblNomeContato.Location = new Point(3, 0);
            lblNomeContato.Name = "lblNomeContato";
            lblNomeContato.Size = new Size(120, 20);
            lblNomeContato.TabIndex = 0;
            lblNomeContato.Text = "lblNomeContato";
            // 
            // FormChat
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1237, 748);
            Controls.Add(panelMensagens);
            Controls.Add(pnlMensagens);
            Margin = new Padding(3, 4, 3, 4);
            Name = "FormChat";
            Text = "DM";
            Load += DM_Load;
            pnlMensagens.ResumeLayout(false);
            pnlMensagens.PerformLayout();
            panelMensagens.ResumeLayout(false);
            panelMensagens.PerformLayout();
            panelPerfil.ResumeLayout(false);
            panelPerfil.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)picPerfil).EndInit();
            flowMensagens.ResumeLayout(false);
            flowMensagens.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnlMensagens;
        private Label label1;
        private TextBox txtPesquisarChat;
        private Panel panelMensagens;
        private Label lblNomeContato;
        private FlowLayoutPanel flowMensagens;
        private Button btnEnviar;
        private TextBox txtMensagem;
        private Panel panelPerfil;
        private Button btnVerPerfil;
        private Label lblStatusPerfil;
        private Label lblNomePerfil;
        private PictureBox picPerfil;
        private Button btnSair;
        private Button btnPedidos;
        private ListBox listSugestoesAmigos;
        private ListBox listChats;
        private ListBox listBox1;
        
        }
}