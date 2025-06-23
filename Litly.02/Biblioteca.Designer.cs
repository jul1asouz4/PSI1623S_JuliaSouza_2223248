namespace Litly._02
{
    partial class Biblioteca
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
            components = new System.ComponentModel.Container();
            listBoxLivros = new ListBox();
            bibliotecaBindingSource1 = new BindingSource(components);
            bibliotecaBindingSource = new BindingSource(components);
            buttonAdicionar = new Button();
            btnVoltar = new Button();
            ((System.ComponentModel.ISupportInitialize)bibliotecaBindingSource1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)bibliotecaBindingSource).BeginInit();
            SuspendLayout();
            // 
            // listBoxLivros
            // 
            listBoxLivros.FormattingEnabled = true;
            listBoxLivros.ItemHeight = 15;
            listBoxLivros.Location = new Point(122, 95);
            listBoxLivros.Name = "listBoxLivros";
            listBoxLivros.Size = new Size(557, 274);
            listBoxLivros.TabIndex = 0;
            listBoxLivros.SelectedIndexChanged += listBoxLivros_SelectedIndexChanged;
            // 
            // bibliotecaBindingSource1
            // 
            bibliotecaBindingSource1.DataSource = typeof(Biblioteca);
            // 
            // bibliotecaBindingSource
            // 
            bibliotecaBindingSource.DataSource = typeof(Biblioteca);
            // 
            // buttonAdicionar
            // 
            buttonAdicionar.Location = new Point(522, 398);
            buttonAdicionar.Name = "buttonAdicionar";
            buttonAdicionar.Size = new Size(157, 22);
            buttonAdicionar.TabIndex = 1;
            buttonAdicionar.Text = "Adicionar livros";
            buttonAdicionar.UseVisualStyleBackColor = true;
            buttonAdicionar.Click += buttonAdicionar_Click;
            // 
            // btnVoltar
            // 
            btnVoltar.Location = new Point(122, 398);
            btnVoltar.Name = "btnVoltar";
            btnVoltar.Size = new Size(157, 22);
            btnVoltar.TabIndex = 2;
            btnVoltar.Text = "Voltar a pagina principal\r\n";
            btnVoltar.UseVisualStyleBackColor = true;
            btnVoltar.Click += btnVoltar_Click;
            // 
            // Biblioteca
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Info;
            ClientSize = new Size(835, 471);
            Controls.Add(btnVoltar);
            Controls.Add(buttonAdicionar);
            Controls.Add(listBoxLivros);
            Name = "Biblioteca";
            Text = "Biblioteca";
            Load += Biblioteca_Load;
            ((System.ComponentModel.ISupportInitialize)bibliotecaBindingSource1).EndInit();
            ((System.ComponentModel.ISupportInitialize)bibliotecaBindingSource).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private ListBox listBoxLivros;
        private Button buttonAdicionar;
        private BindingSource bibliotecaBindingSource;
        private BindingSource bibliotecaBindingSource1;
        private Button btnVoltar;
    }
}