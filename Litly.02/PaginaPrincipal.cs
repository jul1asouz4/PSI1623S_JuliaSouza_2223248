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
using static System.Collections.Specialized.BitVector32;

namespace Litly._02
{
    public partial class PaginaPrincipal : Form
    {
        public PaginaPrincipal()
        {
            InitializeComponent();
        }



        private void PaginaPrincipal_Load(object sender, EventArgs e)
        {
            cmbTipoBusca.Items.Add("Utilizadores");
            cmbTipoBusca.Items.Add("Livros");
            cmbTipoBusca.Items.Add("Postagens");
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            PaginaPrincipal principal = new PaginaPrincipal();
            principal.Show();
        }

        private void buttonBiblioteca_Click(object sender, EventArgs e)
        {

            Biblioteca biblioteca = new Biblioteca();
            biblioteca.Show();

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.Show();
            this.Hide();
        }

        private void buttonBrowse_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void txtBrowse_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            string termo = txtBrowse.Text.Trim();
            string tipoBusca = cmbTipoBusca.SelectedItem?.ToString();
            listResultados.Items.Clear();

            if (string.IsNullOrEmpty(termo) || string.IsNullOrEmpty(tipoBusca))
            {
                MessageBox.Show("Digite algo para buscar e selecione o tipo.");
                return;
            }



            //

            string connString = "Server=(localdb)\\MSSQLLocalDB;Database=Litly;Trusted_Connection=True;";
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = conn;
                switch (tipoBusca)
                {
                    case "Utilizadores":
                        cmd.CommandText = "SELECT Nome, Email FROM Utilizadores WHERE Nome LIKE @termo OR Email LIKE @termo";
                        break;
                    case "Livros":
                        cmd.CommandText = "SELECT Titulo, Autor FROM Livros WHERE Titulo LIKE @termo OR Autor LIKE @termo";
                        break;
                    case "Postagens":
                        cmd.CommandText = "SELECT Titulo FROM Postagens WHERE Titulo LIKE @termo";
                        break;
                    default:
                        MessageBox.Show("Seleção inválida.");
                        return;
                }
                cmd.Parameters.AddWithValue("@termo", "%" + termo + "%");
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    if (tipoBusca == "Utilizadores")
                    {
                        string nome = reader["Nome"].ToString();
                        string email = reader["Email"].ToString();
                        listResultados.Items.Add($"👤 {nome} - {email}");
                    }
                    else if (tipoBusca == "Livros")
                    {
                        string titulo = reader["Titulo"].ToString();
                        string autor = reader["Autor"].ToString();
                        listResultados.Items.Add($"📚 {titulo} - {autor}");
                    }
                    else if (tipoBusca == "Postagens")
                    {
                        string titulo = reader["Titulo"].ToString();
                        listResultados.Items.Add($"📝 {titulo}");
                    }
                }
                reader.Close();
            }
            if (listResultados.Items.Count == 0)
            {
                listResultados.Items.Add("🔍 Nenhum resultado encontrado.");
            }
        }



        private void listResultados_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listResultados.SelectedItem == null)
                return;
            string itemSelecionado = listResultados.SelectedItem.ToString();
            if (itemSelecionado.StartsWith("Utilizador: "))
            {
                // Lógica para abrir página de utilizador
                string nomeUtilizador = itemSelecionado.Substring("Utilizador: ".Length).Split('(')[0].Trim();
                // Chama uma função que abre o perfil do utilizador (crie ou redirecione para um formulário)
                //AbrirPerfilUtilizador(nomeUtilizador);
            }
            else if (itemSelecionado.StartsWith("Livro: "))
            {
                string tituloLivro = itemSelecionado.Substring("Livro: ".Length).Split('-')[0].Trim();
                AbrirDetalhesLivro(tituloLivro);
            }
            else if (itemSelecionado.StartsWith("Postagem: "))
            {
                string tituloPostagem = itemSelecionado.Substring("Postagem: ".Length).Trim();
                AbrirPostagem(tituloPostagem);
            }
        }

        private void AbrirPerfilUtilizador(string nome, string email, string bio)
        {
            // Abre um novo formulário passando o nome (ou faz uma pesquisa detalhada no banco)
            var perfil = new PerfilUtilizador(nome, email, bio);
            perfil.Show();
        }
        private void AbrirDetalhesLivro(string titulo)
        {
            var detalhesLivro = new DetalhesLivros(titulo);
            detalhesLivro.Show();
        }
        private void AbrirPostagem(string titulo)
        {
            var postagem = new PaginaPostagem(titulo);
            postagem.Show();
        }
    }
}
