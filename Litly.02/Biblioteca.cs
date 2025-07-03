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
    public partial class Biblioteca : Form
    {

        // Propriedade pública que expõe o ListBox listBoxLivros
        public ListBox ListBoxLivros => listBoxLivros;

        // Armazena o ID do utilizador logado
        int idUtilizadorLogado;
        public Biblioteca(int idLogado)
        {
            InitializeComponent(); // Inicializa os componentes visuais
            idUtilizadorLogado = idLogado; // Armazena o ID do utilizador para uso posterior
        }

        public void CarregarLivrosDoUtilizador()
        {
            string connString = "Server=(localdb)\\MSSQLLocalDB;Database=Litly;Trusted_Connection=True;";
            using (Microsoft.Data.SqlClient.SqlConnection conn = new Microsoft.Data.SqlClient.SqlConnection(connString))
            {
                conn.Open(); // Abre a conexão com a base de dados
                string query = "SELECT Titulo, Autor FROM Livros WHERE IdUtilizador = @IdUtilizador";
                Microsoft.Data.SqlClient.SqlCommand cmd = new Microsoft.Data.SqlClient.SqlCommand(query, conn);

                // Usa o ID da sessão atual (talvez seja melhor usar idUtilizadorLogado aqui para consistência)
                cmd.Parameters.AddWithValue("@IdUtilizador", Sessao.IdUtilizador);

                var reader = cmd.ExecuteReader();
                listBoxLivros.Items.Clear(); // Limpa a lista antes de preencher novamente

                while (reader.Read())
                {
                    string titulo = reader["Titulo"].ToString();
                    string autor = reader["Autor"].ToString();
                    listBoxLivros.Items.Add($"{titulo} - {autor}");  // Adiciona o livro ao ListBox
                }

                reader.Close();
            }
        }


        public void listBoxLivros_SelectedIndexChanged(object sender, EventArgs e)
        {


            string connString = "Server=(localdb)\\MSSQLLocalDB;Database=Litly;Trusted_Connection=True;";

            using (Microsoft.Data.SqlClient.SqlConnection conn = new Microsoft.Data.SqlClient.SqlConnection(connString))
            {
                try
                {
                    conn.Open();

                    string query = "SELECT Titulo, Autor FROM Livros WHERE IdUtilizador = @IdUtilizador";
                    Microsoft.Data.SqlClient.SqlCommand cmd = new Microsoft.Data.SqlClient.SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@IdUtilizador", Sessao.IdUtilizador);
                    CarregarLivrosDoUtilizador();



                    SqlDataReader reader = cmd.ExecuteReader();
                    listBoxLivros.Items.Clear();

                    if (!reader.HasRows)
                    {
                        MessageBox.Show("Você ainda não tem livros na sua biblioteca.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        reader.Close();

                    }

                    while (reader.Read())
                    {
                        string titulo = reader["Titulo"].ToString();
                        string autor = reader["Autor"].ToString();
                        listBoxLivros.Items.Add($"{titulo} - {autor}");

                    }

                    reader.Close();


                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao carregar a biblioteca: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void buttonAdicionar_Click(object sender, EventArgs e)
        {
            AdicionarLivros adicionarlivros = new AdicionarLivros(); // Abre o formulário para adicionar livros
            adicionarlivros.Show();
            this.Hide(); // Esconde o formulário atual
        }

        private void Biblioteca_Load(object sender, EventArgs e)
        {
            CarregarLivrosDoUtilizador();
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            // Oculta o formulário DetalhesLivros atual
            this.Hide();

            // Cria uma nova instância da PaginaPrincipal, passando o ID do utilizador logado
            // que está armazenado na classe estática Sessao.
            PaginaPrincipal principal = new PaginaPrincipal(Sessao.IdUtilizador);
            principal.Show(); // Exibe a PaginaPrincipal

            // Fecha o formulário DetalhesLivros completamente para liberar recursos
            this.Close();
        }

        private void btnExcluirLivro_Click(object sender, EventArgs e)
        {

        }
    }
}
