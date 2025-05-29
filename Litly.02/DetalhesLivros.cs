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
    public partial class DetalhesLivros : Form
    {

        private string titulolivro;
        public DetalhesLivros(string titulo)
        {
            InitializeComponent();
            titulolivro = titulo;

            CarregarDetalhesLivros(titulolivro);
        }


        private void CarregarDetalhesLivros(String titulo)
        {
            string connString = "Server=(localdb)\\MSSQLLocalDB;Database=Litly;Trusted_Connection=True;";
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                string query = "SELECT * FROM Livros WHERE Titulo = @Titulo";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Titulo", titulo);
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // Esses são exemplos de labels no formulário
                            lblTitulo.Text = reader["Titulo"].ToString();
                            lblAutor.Text = reader["Autor"].ToString();
                            lblSinopse.Text = reader["Sinopse"].ToString();
                            // Adicione os outros campos se quiser
                        }
                        else
                        {
                            MessageBox.Show("Livro não encontrado.");
                            this.Close();
                        }
                    }
                }
            }
        }
        private void DetalhesLivros_Load(object sender, EventArgs e)
        {

        }
    }
}
