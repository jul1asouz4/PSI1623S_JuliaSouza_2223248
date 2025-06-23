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
using static System.Collections.Specialized.BitVector32;
using static System.Runtime.InteropServices.JavaScript.JSType;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Litly._02
{
    public partial class PaginaPrincipal : Form
    {
        private int idUtilizadorLogado;

        public int IdUtilizadorLogado { get; set; }
        public string NomeUtilizadorLogado { get; set; }
        public string EmailUtilizadorLogado { get; set; }
        public Image ImagemPerfilLogado { get; set; }

        public PaginaPrincipal(int idLogado)
        {
            InitializeComponent();
            idUtilizadorLogado = idLogado;

            CarregarDadosUtilizadorLogado();


        }

        private void CarregarDadosUtilizadorLogado()
        {
            string connString = "Server=(localdb)\\MSSQLLocalDB;Database=Litly;Trusted_Connection=True;";
            using (SqlConnection conn = new Microsoft.Data.SqlClient.SqlConnection(connString))
            {
                conn.Open();
                Microsoft.Data.SqlClient.SqlCommand cmd = new Microsoft.Data.SqlClient.SqlCommand("SELECT Nome, Email, ImagemPerfil FROM Utilizadores WHERE IdUtilizador = @IdUtilizador", conn);
                cmd.Parameters.AddWithValue("@IdUtilizador", idUtilizadorLogado);

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    NomeUtilizadorLogado = reader["Nome"].ToString();
                    EmailUtilizadorLogado = reader["Email"].ToString();

                    // Supondo que ImagemPerfil está armazenada como varbinary no banco:
                    if (reader["ImagemPerfil"] != DBNull.Value)
                    {
                        byte[] imgBytes = (byte[])reader["ImagemPerfil"];
                        using (var ms = new MemoryStream(imgBytes))
                        {
                            Image imagem = Image.FromStream(ms); // Lê a imagem dos bytes
                            ImagemPerfilLogado = imagem; // Salva na propriedade, se quiser usar depois
                            //pictureBoxFotoPerfil.Image = imagem; // Mostra na UI

                            /*Image imagem = ImagemPerfilLogado;
                            pictureBoxFotoPerfil.Image = Image imagem; // Mostra na UI*/


                        }
                    }
                }
                reader.Close();
            }
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

        private void button4_Click(object sender, EventArgs e) //DM
        {
            FormChat dm = new FormChat(idUtilizadorLogado);
            dm.Show();

        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            PaginaPrincipal principal = new PaginaPrincipal(idUtilizadorLogado);
            principal.Show();
        }

        private void buttonBiblioteca_Click(object sender, EventArgs e)
        {

            Biblioteca biblioteca = new Biblioteca(idUtilizadorLogado);
            biblioteca.Show();

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
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

            string connString = "Server=(localdb)\\MSSQLLocalDB;Database=Litly;Trusted_Connection=True;";
            using (Microsoft.Data.SqlClient.SqlConnection conn = new Microsoft.Data.SqlClient.SqlConnection(connString))
            {
                conn.Open();
                Microsoft.Data.SqlClient.SqlCommand cmd = new Microsoft.Data.SqlClient.SqlCommand();
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
            this.listResultados.SelectedIndexChanged += new System.EventHandler(this.listResultados_SelectedIndexChanged);


            if (listResultados.SelectedItem == null)
                return;

            string itemSelecionado = listResultados.SelectedItem.ToString();
            string tipoBusca = cmbTipoBusca.SelectedItem?.ToString();

            if (tipoBusca == "Utilizadores" && itemSelecionado.StartsWith("👤 "))
            {
                // Extrai nome e email
                string[] partes = itemSelecionado.Substring(2).Split(" - ");
                if (partes.Length >= 2)
                {
                    

                    var perfil = new PerfilUtilizador(NomeUtilizadorLogado, EmailUtilizadorLogado, ImagemPerfilLogado, idUtilizadorLogado);
                    perfil.Show();
                }
            }
            else if (tipoBusca == "Livros" && itemSelecionado.StartsWith("📚 "))
            {
                string[] partes = itemSelecionado.Substring(2).Split(" - ");
                if (partes.Length >= 1)
                {
                    string tituloLivro = partes[0].Trim();
                    AbrirDetalhesLivro(tituloLivro);
                }
            }
            else if (tipoBusca == "Postagens" && itemSelecionado.StartsWith("📝 "))
            {
                string[] partes = itemSelecionado.Substring(2).Split(" - ");
                if (partes.Length >= 1)
                {
                    string tituloPostagem = partes[0].Trim();
                    AbrirPostagem(tituloPostagem);
                }

            }


        }



        private string ObterBioDoUtilizador(string email)
        {
            string bio = "";
            string connString = "Server=(localdb)\\MSSQLLocalDB;Database=Litly;Trusted_Connection=True;";

            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT Bio FROM Utilizadores WHERE Email = @Email", conn);
                cmd.Parameters.AddWithValue("@Email", email);

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    bio = reader["Bio"].ToString();
                }
                reader.Close();
            }

            return bio;
        }

        private void AbrirPerfilUtilizador()
        {
            // Abre um novo formulário passando o nome (ou faz uma pesquisa detalhada no banco)
            var perfil = new PerfilUtilizador(NomeUtilizadorLogado, EmailUtilizadorLogado, ImagemPerfilLogado, idUtilizadorLogado);
            perfil.Show();
        }
        private void AbrirDetalhesLivro(string titulo)
        {
            using (SqlConnection conn = new SqlConnection("Server=(localdb)\\MSSQLLocalDB;Database=Litly;Trusted_Connection=True;"))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT * FROM Livros WHERE Titulo = @Titulo", conn);
                cmd.Parameters.AddWithValue("@Titulo", titulo);

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    string tituloBD = reader["Titulo"].ToString();
                    string autor = reader["Autor"].ToString();
                    //string genero = reader["Genero"].ToString();
                    string sinopse = reader["Sinopse"].ToString();

                    var detalhesLivro = new DetalhesLivros(titulo, autor, sinopse);
                    detalhesLivro.Show();
                }
                else
                {
                    MessageBox.Show("Livro não encontrado no banco de dados.");
                }
                reader.Close();
            }
        }
        private void AbrirPostagem(string titulo)
        {
            using (SqlConnection conn = new SqlConnection("Server=(localdb)\\MSSQLLocalDB;Database=Litly;Trusted_Connection=True;"))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT Titulo, Autor, Conteudo, DataCriacao FROM Postagens WHERE Titulo = @Titulo", conn);
                cmd.Parameters.AddWithValue("@Titulo", titulo);

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    string tituloBD = reader["Titulo"].ToString();
                    string autorBD = reader["Autor"].ToString();
                    string conteudoBD = reader["Conteudo"].ToString();
                    string dataBD = Convert.ToDateTime(reader["DataCriacao"]).ToString("dd/MM/yyyy");

                    var paginaPostagem = new PaginaPostagem(tituloBD, autorBD, conteudoBD, dataBD);
                    paginaPostagem.Show();
                }
                else
                {
                    MessageBox.Show("Postagem não encontrada no banco de dados.");
                }
                reader.Close();
            }
        }

        private void buttonPerfil_Click(object sender, EventArgs e)
        {

            var perfil = new PerfilUtilizador(NomeUtilizadorLogado, EmailUtilizadorLogado, ImagemPerfilLogado, idUtilizadorLogado);
            perfil.Show();
            


        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmAmigos amigos = new frmAmigos(idUtilizadorLogado);
            amigos.Show();
        }
    }
}
