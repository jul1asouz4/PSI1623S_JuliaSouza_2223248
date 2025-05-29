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
            label3 = new Label();
            txtBio = new TextBox();
            SuspendLayout();
            // 
            // lblNome
            // 
            lblNome.AutoSize = true;
            lblNome.Font = new Font("Segoe UI Semilight", 14.25F);
            lblNome.Location = new Point(446, 78);
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
            lblEmail.Location = new Point(446, 116);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(58, 25);
            lblEmail.TabIndex = 2;
            lblEmail.Text = "label1";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold);
            label1.Location = new Point(283, 78);
            label1.Name = "label1";
            label1.Size = new Size(65, 25);
            label1.TabIndex = 4;
            label1.Text = "Nome";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold);
            label2.Location = new Point(283, 116);
            label2.Name = "label2";
            label2.Size = new Size(59, 25);
            label2.TabIndex = 5;
            label2.Text = "Email";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI Semibold", 14.25F, FontStyle.Bold);
            label3.Location = new Point(283, 160);
            label3.Name = "label3";
            label3.Size = new Size(39, 25);
            label3.TabIndex = 6;
            label3.Text = "Bio";
            // 
            // txtBio
            // 
            txtBio.Location = new Point(446, 165);
            txtBio.Multiline = true;
            txtBio.Name = "txtBio";
            txtBio.ReadOnly = true;
            txtBio.Size = new Size(138, 23);
            txtBio.TabIndex = 7;
            // 
            // PerfilUtilizador
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.LightSteelBlue;
            ClientSize = new Size(800, 450);
            Controls.Add(txtBio);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(lblEmail);
            Controls.Add(lblNome);
            Name = "PerfilUtilizador";
            Text = "PerfilUtilizador";
            Load += PerfilUtilizador_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label lblNome;
        private Label lblEmail;
        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox txtBio;
    }
}