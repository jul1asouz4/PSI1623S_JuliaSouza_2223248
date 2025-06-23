namespace Litly._02
{
    partial class frmAmigos
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
            textBox1 = new TextBox();
            btnProcurar = new Button();
            utilizadores = new ListBox();
            btnSeguir = new Button();
            Pedidos = new ListBox();
            btnAceitar = new Button();
            btnRecusar = new Button();
            Amigos = new ListBox();
            btnAbrirChat = new Button();
            btnVoltar = new Button();
            btnRemover = new Button();
            SuspendLayout();
            // 
            // textBox1
            // 
            textBox1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBox1.Location = new Point(167, 38);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(433, 29);
            textBox1.TabIndex = 0;
            // 
            // btnProcurar
            // 
            btnProcurar.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            btnProcurar.Image = Properties.Resources.lupaa;
            btnProcurar.Location = new Point(613, 38);
            btnProcurar.Name = "btnProcurar";
            btnProcurar.Size = new Size(75, 29);
            btnProcurar.TabIndex = 1;
            btnProcurar.UseVisualStyleBackColor = true;
            btnProcurar.Click += btnProcurar_Click;
            // 
            // utilizadores
            // 
            utilizadores.FormattingEnabled = true;
            utilizadores.ItemHeight = 15;
            utilizadores.Location = new Point(167, 73);
            utilizadores.Name = "utilizadores";
            utilizadores.Size = new Size(433, 64);
            utilizadores.TabIndex = 2;
            // 
            // btnSeguir
            // 
            btnSeguir.BackColor = Color.LightGreen;
            btnSeguir.Location = new Point(459, 102);
            btnSeguir.Name = "btnSeguir";
            btnSeguir.Size = new Size(129, 23);
            btnSeguir.TabIndex = 3;
            btnSeguir.Text = "Adicionar Amigo";
            btnSeguir.UseVisualStyleBackColor = false;
            btnSeguir.Click += btnSeguir_Click;
            // 
            // Pedidos
            // 
            Pedidos.FormattingEnabled = true;
            Pedidos.ItemHeight = 15;
            Pedidos.Location = new Point(167, 167);
            Pedidos.Name = "Pedidos";
            Pedidos.Size = new Size(433, 64);
            Pedidos.TabIndex = 4;
            // 
            // btnAceitar
            // 
            btnAceitar.BackColor = Color.PaleGreen;
            btnAceitar.Location = new Point(432, 199);
            btnAceitar.Name = "btnAceitar";
            btnAceitar.Size = new Size(75, 23);
            btnAceitar.TabIndex = 5;
            btnAceitar.Text = "Aceitar";
            btnAceitar.UseVisualStyleBackColor = false;
            btnAceitar.Click += btnAceitar_Click;
            // 
            // btnRecusar
            // 
            btnRecusar.BackColor = Color.FromArgb(255, 111, 97);
            btnRecusar.Location = new Point(513, 199);
            btnRecusar.Name = "btnRecusar";
            btnRecusar.Size = new Size(75, 23);
            btnRecusar.TabIndex = 6;
            btnRecusar.Text = "Recusar";
            btnRecusar.UseVisualStyleBackColor = false;
            btnRecusar.Click += btnRecusar_Click;
            // 
            // Amigos
            // 
            Amigos.FormattingEnabled = true;
            Amigos.ItemHeight = 15;
            Amigos.Location = new Point(167, 262);
            Amigos.Name = "Amigos";
            Amigos.Size = new Size(433, 64);
            Amigos.TabIndex = 7;
            Amigos.SelectedIndexChanged += Amigos_SelectedIndexChanged;
            // 
            // btnAbrirChat
            // 
            btnAbrirChat.Location = new Point(432, 290);
            btnAbrirChat.Name = "btnAbrirChat";
            btnAbrirChat.Size = new Size(75, 23);
            btnAbrirChat.TabIndex = 8;
            btnAbrirChat.Text = "Abrir chat";
            btnAbrirChat.UseVisualStyleBackColor = true;
            btnAbrirChat.Click += button3_Click;
            // 
            // btnVoltar
            // 
            btnVoltar.Location = new Point(637, 384);
            btnVoltar.Name = "btnVoltar";
            btnVoltar.Size = new Size(122, 23);
            btnVoltar.TabIndex = 9;
            btnVoltar.Text = "Voltar ao principal";
            btnVoltar.UseVisualStyleBackColor = true;
            btnVoltar.Click += btnVoltar_Click;
            // 
            // btnRemover
            // 
            btnRemover.BackColor = Color.FromArgb(255, 111, 97);
            btnRemover.Location = new Point(513, 291);
            btnRemover.Margin = new Padding(3, 2, 3, 2);
            btnRemover.Name = "btnRemover";
            btnRemover.Size = new Size(75, 22);
            btnRemover.TabIndex = 10;
            btnRemover.Text = "Remover";
            btnRemover.UseVisualStyleBackColor = false;
            // 
            // frmAmigos
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Info;
            ClientSize = new Size(800, 450);
            Controls.Add(btnRemover);
            Controls.Add(btnVoltar);
            Controls.Add(btnAbrirChat);
            Controls.Add(Amigos);
            Controls.Add(btnRecusar);
            Controls.Add(btnAceitar);
            Controls.Add(Pedidos);
            Controls.Add(btnSeguir);
            Controls.Add(utilizadores);
            Controls.Add(btnProcurar);
            Controls.Add(textBox1);
            Name = "frmAmigos";
            Text = "Pedidos de amizades / Amigos";
            Load += frmAmigos_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox textBox1;
        private Button btnProcurar;
        private ListBox utilizadores;
        private Button btnSeguir;
        private ListBox Pedidos;
        private Button btnAceitar;
        private Button btnRecusar;
        private ListBox Amigos;
        private Button btnAbrirChat;
        private Button btnVoltar;
        private Button btnRemover;
    }
}