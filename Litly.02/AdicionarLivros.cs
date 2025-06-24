using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using Microsoft.Data.SqlClient;
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
            


            if (string.IsNullOrEmpty(titulo) || string.IsNullOrEmpty(autor))
            {
                MessageBox.Show("Título e Autor são obrigatórios.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string connString = "Server=(localdb)\\MSSQLLocalDB;Database=Litly;Trusted_Connection=True;";

            try
            {
                using (Microsoft.Data.SqlClient.SqlConnection conn = new Microsoft.Data.SqlClient.SqlConnection(connString))
                {
                    conn.Open();


                    string insertQuery = "INSERT INTO Livros (Titulo, Autor, CapaURL, Sinopse, DataPublicacao, IdUtilizador) " +
                                         "VALUES (@Titulo, @Autor, @CapaURL, @Sinopse, @DataPublicacao, @IdUtilizador)";
                    Microsoft.Data.SqlClient.SqlCommand cmd = new Microsoft.Data.SqlClient.SqlCommand(insertQuery, conn);
                    cmd.Parameters.AddWithValue("@Titulo", titulo);
                    cmd.Parameters.AddWithValue("@Autor", autor);
                    cmd.Parameters.AddWithValue("@CapaURL", capaUrl);
                    cmd.Parameters.AddWithValue("@Sinopse", sinopse);
                    cmd.Parameters.AddWithValue("@DataPublicacao", dataPublicacao);
                    cmd.Parameters.AddWithValue("@IdUtilizador", Sessao.IdUtilizador);
                    int rowsAffected = cmd.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        // Atualiza a ListBox da Biblioteca antes de perguntar ao utilizador
                        foreach (Form form in Application.OpenForms)
                        {
                            if (form is Biblioteca biblioteca)
                            {
                                // Chame o método CarregarLivrosDoUtilizador() para recarregar a lista completa,
                                // garantindo que a lista está sempre atualizada.
                                biblioteca.CarregarLivrosDoUtilizador();
                                break;
                            }
                        }

                        // Pergunta ao utilizador se deseja adicionar outro livro
                        DialogResult dialogResult = MessageBox.Show(
                            "Livro adicionado com sucesso!\n\nDeseja adicionar outro livro?",
                            "Sucesso",
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question
                        );

                        if (dialogResult == DialogResult.Yes)
                        {
                            // Limpa os campos para adicionar outro livro
                            txtTitulo.Clear();
                            txtAutor.Clear();
                            txtCapaUrl.Clear();
                            txtSinopse.Clear();
                            dtpDataPublicacao.Value = DateTime.Now; // Define a data para a data atual
                            txtTitulo.Focus(); // Coloca o foco no primeiro campo
                        }
                        else
                        {
                            // Se o utilizador escolher 'Não', volta para a Biblioteca
                            // Reutiliza a lógica do btnVoltar_Click
                            VoltarParaBiblioteca();
                        }
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

        private void VoltarParaBiblioteca()
        {
            this.Hide();

            // Tenta encontrar uma instância existente da Biblioteca
            Biblioteca bibliotecaForm = Application.OpenForms.OfType<Biblioteca>().FirstOrDefault();

            if (bibliotecaForm != null)
            {
                // Se a Biblioteca já está aberta, apenas a mostra
                bibliotecaForm.CarregarLivrosDoUtilizador(); // Garante que a lista está atualizada
                bibliotecaForm.Show();
            }
            else
            {
                // Se não está aberta, cria uma nova instância
                Biblioteca biblioteca = new Biblioteca(Sessao.IdUtilizador);
                biblioteca.Show();
            }

            this.Close(); // Fecha o formulário AdicionarLivros
        }

        private void AdicionarLivros_Load(object sender, EventArgs e)
        {

        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            this.Hide();

            // Cria uma nova instância da Biblioteca, passando o ID do utilizador logado
            // que está armazenado na classe estática Sessao.
            Biblioteca biblioteca = new Biblioteca(Sessao.IdUtilizador);
            biblioteca.Show(); // Exibe a Biblioteca

            // Fecha o formulário DetalhesLivros (ou o formulário onde este botão está)
            // para liberar recursos.
            this.Close();
        }
    }
}
