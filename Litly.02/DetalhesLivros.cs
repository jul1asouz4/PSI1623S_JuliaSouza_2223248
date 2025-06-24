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
    public partial class DetalhesLivros : Form
    {
        // Atributo privado para armazenar o título do livro (não está sendo usado no trecho atual)
        private string titulolivro;

        // Construtor da classe DetalhesLivros, recebe os dados do livro por parâmetro
        public DetalhesLivros(string titulo, string autor, string sinopse)
        {
            InitializeComponent(); // Inicializa os componentes do formulário
            lblTitulo.Text = titulo;   // Define o texto do rótulo do título com o valor passado
            lblAutor.Text = autor;     // Define o texto do rótulo do autor com o valor passado
            lblSinopse.Text = sinopse; // Define o texto do rótulo da sinopse com o valor passado

        }

        // Método privado para carregar os detalhes do livro a partir do banco de dados
        private void CarregarDetalhesLivros(String titulo)
        {
            string connString = "Server=(localdb)\\MSSQLLocalDB;Database=Litly;Trusted_Connection=True;";
            using (Microsoft.Data.SqlClient.SqlConnection conn = new Microsoft.Data.SqlClient.SqlConnection(connString))
            {
                conn.Open();
                // Consulta SQL para buscar o livro pelo título
                string query = "SELECT * FROM Livros WHERE Titulo = @Titulo";
                // Criação do comando SQL com a consulta e a conexão
                using (Microsoft.Data.SqlClient.SqlCommand cmd = new Microsoft.Data.SqlClient.SqlCommand(query, conn))
                {
                    // Adiciona o parâmetro @Titulo à consulta, com o valor passado para o método
                    cmd.Parameters.AddWithValue("@Titulo", titulo);
                    // Executa a consulta e obtém os resultados
                    using (Microsoft.Data.SqlClient.SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // Atualiza os rótulos do formulário com os dados do banco de dados
                            lblTitulo.Text = reader["Titulo"].ToString();
                            lblAutor.Text = reader["Autor"].ToString();
                            lblSinopse.Text = reader["Sinopse"].ToString();
                            
                        }
                        else
                        {
                            MessageBox.Show("Livro não encontrado."); // Mostra uma mensagem de erro
                            this.Close(); // Fecha o formulário atual
                        }
                    }
                }
            }
        }

        // Evento que é chamado quando o formulário é carregado (está vazio no momento)
        private void DetalhesLivros_Load(object sender, EventArgs e)
        {

        }

        // Evento que é chamado quando o botão "Voltar" é clicado
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
    }
}
