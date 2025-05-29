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
    public partial class PaginaPostagem : Form
    {

        private string tituloPostagem;
        public PaginaPostagem(string titulo)
        {
            InitializeComponent();
            tituloPostagem = titulo;    

            CarregarDetalhesPostagem(tituloPostagem);
        }


        private void CarregarDetalhesPostagem(string tituloPostagem) 
        {

            string connString = "Server=(localdb)\\MSSQLLocalDB;Database=Litly;Trusted_Connection=True;";
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                string query = "SELECT P.Conteudo, P.DataCriacao, U.Nome AS Autor " +
                               "FROM Postagens P INNER JOIN Utilizadores U ON P.IdUtilizador = U.IdUtilizador " +
                               "WHERE P.Titulo = @Titulo";
                using (SqlCommand cmd = new SqlCommand(query, conn))
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
    }
}
