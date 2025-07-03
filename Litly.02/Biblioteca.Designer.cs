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
            listBoxLivros.Location = new Point(139, 127);
            listBoxLivros.Margin = new Padding(3, 4, 3, 4);
            listBoxLivros.Name = "listBoxLivros";
            listBoxLivros.Size = new Size(636, 364);
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
            buttonAdicionar.Location = new Point(597, 531);
            buttonAdicionar.Margin = new Padding(3, 4, 3, 4);
            buttonAdicionar.Name = "buttonAdicionar";
            buttonAdicionar.Size = new Size(179, 29);
            buttonAdicionar.TabIndex = 1;
            buttonAdicionar.Text = "Adicionar livros";
            buttonAdicionar.UseVisualStyleBackColor = true;
            buttonAdicionar.Click += buttonAdicionar_Click;
            // 
            // btnVoltar
            // 
            btnVoltar.Location = new Point(139, 531);
            btnVoltar.Margin = new Padding(3, 4, 3, 4);
            btnVoltar.Name = "btnVoltar";
            btnVoltar.Size = new Size(179, 29);
            btnVoltar.TabIndex = 2;
            btnVoltar.Text = "Voltar a pagina principal\r\n";
            btnVoltar.UseVisualStyleBackColor = true;
            btnVoltar.Click += btnVoltar_Click;
            // 
            // Biblioteca
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Info;
            ClientSize = new Size(954, 628);
            Controls.Add(btnVoltar);
            Controls.Add(buttonAdicionar);
            Controls.Add(listBoxLivros);
            Margin = new Padding(3, 4, 3, 4);
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