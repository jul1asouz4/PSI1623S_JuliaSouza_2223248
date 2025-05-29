using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Litly._02
{
    public partial class AdicionarLivros : Form
    {

        

        public AdicionarLivros()
        {
            InitializeComponent();


        }

        

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            string titulo = txtTitulo.Text.Trim();
            string autor = txtAutor.Text.Trim();
            string capaUrl = txtCapaUrl.Text.Trim();
            string sinopse = txtSinopse.Text.Trim();
            DateTime dataPublicacao = dtpDataPublicacao.Value;
            int idUtilizador = Sessao.IdUtilizador; 


            if (string.IsNullOrEmpty(titulo) || string.IsNullOrEmpty(autor))
            {
                MessageBox.Show("Título e Autor são obrigatórios.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string connString = "Server=(localdb)\\MSSQLLocalDB;Database=Litly;Trusted_Connection=True;";

            try
            {
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();


                    string insertQuery = "INSERT INTO Livros (Titulo, Autor, CapaURL, Sinopse, DataPublicacao, IdUtilizador) " +
                                         "VALUES (@Titulo, @Autor, @CapaURL, @Sinopse, @DataPublicacao, @IdUtilizador)";
                    SqlCommand cmd = new SqlCommand(insertQuery, conn);
                    cmd.Parameters.AddWithValue("@Titulo", titulo);
                    cmd.Parameters.AddWithValue("@Autor", autor);
                    cmd.Parameters.AddWithValue("@CapaURL", capaUrl);
                    cmd.Parameters.AddWithValue("@Sinopse", sinopse);
                    cmd.Parameters.AddWithValue("@DataPublicacao", dataPublicacao);
                    cmd.Parameters.AddWithValue("@IdUtilizador", Sessao.IdUtilizador);
                    int rowsAffected = cmd.ExecuteNonQuery();
                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Livro adicionado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        
                        foreach (Form form in Application.OpenForms)
                        {
                            if (form is Biblioteca biblioteca)
                            {
                                biblioteca.ListBoxLivros.Items.Add($"{titulo} - {autor}");
                                break;
                            }
                        }
                        this.Close(); 
                    }
                    else
                    {
                        MessageBox.Show("Erro ao adicionar o livro.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
