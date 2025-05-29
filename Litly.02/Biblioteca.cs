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
    public partial class Biblioteca : Form
    {
        public ListBox ListBoxLivros => listBoxLivros;
        public Biblioteca()
        {
            InitializeComponent();
        }

        public void CarregarLivrosDoUtilizador()
        {
            string connString = "Server=(localdb)\\MSSQLLocalDB;Database=Litly;Trusted_Connection=True;";
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                string query = "SELECT Titulo, Autor FROM Livros WHERE IdUtilizador = @IdUtilizador";
                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@IdUtilizador", Sessao.IdUtilizador);

                SqlDataReader reader = cmd.ExecuteReader();
                listBoxLivros.Items.Clear();

                while (reader.Read())
                {
                    string titulo = reader["Titulo"].ToString();
                    string autor = reader["Autor"].ToString();
                    listBoxLivros.Items.Add($"{titulo} - {autor}");
                }

                reader.Close();
            }
        }


        public void listBoxLivros_SelectedIndexChanged(object sender, EventArgs e)
        {
            //

            string connString = "Server=(localdb)\\MSSQLLocalDB;Database=Litly;Trusted_Connection=True;";

            using (SqlConnection conn = new SqlConnection(connString))
            {
                try
                {
                    conn.Open();

                    string query = "SELECT Titulo, Autor FROM Livros WHERE IdUtilizador = @IdUtilizador";
                    SqlCommand cmd = new SqlCommand(query, conn);
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
            AdicionarLivros adicionarlivros = new AdicionarLivros();
            adicionarlivros.Show();
        }

        private void Biblioteca_Load(object sender, EventArgs e)
        {
            CarregarLivrosDoUtilizador();
        }
    }
}
