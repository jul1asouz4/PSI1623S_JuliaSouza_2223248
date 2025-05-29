namespace Litly._02
{
    partial class Resgistro
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
            textNome = new TextBox();
            label4 = new Label();
            textSenha = new TextBox();
            button2 = new Button();
            textEmail = new TextBox();
            button1 = new Button();
            label1 = new Label();
            label3 = new Label();
            label2 = new Label();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.Cornsilk;
            panel1.Controls.Add(textNome);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(textSenha);
            panel1.Controls.Add(button2);
            panel1.Controls.Add(textEmail);
            panel1.Controls.Add(button1);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label2);
            panel1.Location = new Point(225, 34);
            panel1.Name = "panel1";
            panel1.Size = new Size(316, 487);
            panel1.TabIndex = 0;
            // 
            // textNome
            // 
            textNome.Location = new Point(49, 177);
            textNome.Name = "textNome";
            textNome.Size = new Size(219, 23);
            textNome.TabIndex = 8;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.ForeColor = Color.Black;
            label4.Location = new Point(49, 144);
            label4.Name = "label4";
            label4.Size = new Size(40, 15);
            label4.TabIndex = 7;
            label4.Text = "Nome";
            // 
            // textSenha
            // 
            textSenha.Location = new Point(51, 323);
            textSenha.Name = "textSenha";
            textSenha.PasswordChar = '*';
            textSenha.Size = new Size(217, 23);
            textSenha.TabIndex = 6;
            // 
            // button2
            // 
            button2.FlatStyle = FlatStyle.Flat;
            button2.ForeColor = Color.Black;
            button2.Location = new Point(70, 374);
            button2.Name = "button2";
            button2.Size = new Size(179, 36);
            button2.TabIndex = 1;
            button2.Text = "Ja tem conta? Entre.";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // textEmail
            // 
            textEmail.Location = new Point(51, 250);
            textEmail.Name = "textEmail";
            textEmail.Size = new Size(217, 23);
            textEmail.TabIndex = 5;
            // 
            // button1
            // 
            button1.ForeColor = Color.Black;
            button1.Location = new Point(97, 416);
            button1.Name = "button1";
            button1.Size = new Size(115, 38);
            button1.TabIndex = 4;
            button1.Text = "Resgistar";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Black;
            label1.Location = new Point(29, 17);
            label1.Name = "label1";
            label1.Size = new Size(255, 90);
            label1.TabIndex = 0;
            label1.Text = "Crie uma conta na maior \r\n       plataforma de \r\n    histórias do mundo";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.ForeColor = Color.Black;
            label3.Location = new Point(51, 293);
            label3.Name = "label3";
            label3.Size = new Size(39, 15);
            label3.TabIndex = 2;
            label3.Text = "Senha";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.ForeColor = Color.Black;
            label2.Location = new Point(51, 221);
            label2.Name = "label2";
            label2.Size = new Size(36, 15);
            label2.TabIndex = 1;
            label2.Text = "Email";
            // 
            // Resgistro
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LightSteelBlue;
            ClientSize = new Size(800, 595);
            Controls.Add(panel1);
            ForeColor = Color.IndianRed;
            Name = "Resgistro";
            Text = "Resgistro";
            Load += Resgistro_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Button button1;
        private Label label3;
        private Label label2;
        private Label label1;
        private TextBox textSenha;
        private TextBox textEmail;
        private Button button2;
        private TextBox textNome;
        private Label label4;
    }
}