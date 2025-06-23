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
using System.Collections;

namespace Litly._02
{
    public partial class PaginaPostagem : Form
    {

        //private string tituloPostagem;
        public PaginaPostagem(string titulo, string autor, string conteudo, string data)
        {
            InitializeComponent();

            txtTitulo.Text = titulo;
            txtAutor.Text = autor;
            txtConteudo.Text = conteudo;
            txtData.Text = data;

            //CarregarDetalhesPostagem(tituloPostagem);
        }


        private void CarregarDetalhesPostagem(string tituloPostagem)
        {

            string connString = "Server=(localdb)\\MSSQLLocalDB;Database=Litly;Trusted_Connection=True;";
            using (Microsoft.Data.SqlClient.SqlConnection conn = new Microsoft.Data.SqlClient.SqlConnection(connString))
            {
                conn.Open();
                string query = "SELECT P.Conteudo, P.DataCriacao, U.Nome AS Autor " +
                               "FROM Postagens P INNER JOIN Utilizadores U ON P.IdUtilizador = U.IdUtilizador " +
                               "WHERE P.Titulo = @Titulo";
                using (Microsoft.Data.SqlClient.SqlCommand cmd = new Microsoft.Data.SqlClient.SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Titulo", tituloPostagem);
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        txtTitulo.Text = tituloPostagem;
                        txtConteudo.Text = reader["Conteudo"].ToString();
                        txtData.Text = Convert.ToDateTime(reader["DataCriacao"]).ToString("dd/MM/yyyy HH:mm");
                        txtAutor.Text = reader["Autor"].ToString();
                    }
                    else
                    {
                        MessageBox.Show("Postagem não encontrada.");
                        this.Close();
                    }
                }
            }
        }




        private void PaginaPostagem_Load(object sender, EventArgs e)
        {

        }

        private void btnPublicar_Click(object sender, EventArgs e)
        {


            try
            {
                // Obter o texto da postagem
                string conteudoPostagem = txtConteudo.Text;

                // Verificar se o conteúdo não está vazio
                if (string.IsNullOrWhiteSpace(conteudoPostagem))
                {
                    MessageBox.Show("O conteúdo da postagem não pode estar vazio.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // Lógica de publicação (exemplo: salvar no banco de dados ou enviar para uma API)
                bool sucesso = PublicarPostagem(conteudoPostagem);

                if (sucesso)
                {
                    MessageBox.Show("Postagem publicada com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtConteudo.Clear(); // Limpar o campo de texto após publicar
                }
                else
                {
                    MessageBox.Show("Falha ao publicar a postagem. Tente novamente.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ocorreu um erro: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Método para simular a publicação da postagem
        private bool PublicarPostagem(string conteudo)
        {
            // Aqui você pode implementar a lógica de salvar no banco de dados ou enviar para uma API
            // Retornando true como exemplo de sucesso
            return true;
        }






    }
}
