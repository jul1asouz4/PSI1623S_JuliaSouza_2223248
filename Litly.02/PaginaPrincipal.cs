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

        // Inicialize as propriedades aqui para evitar CS8618
        public int IdUtilizadorLogadoProp { get; set; } = 0; // Renomeado para evitar conflito com campo privado idUtilizadorLogado
        public string NomeUtilizadorLogado { get; set; } = string.Empty;
        public string EmailUtilizadorLogado { get; set; } = string.Empty;
        public Image? ImagemPerfilLogado { get; set; } = null; // Imagem pode ser null

        private SqlConnection conexao; // Já tem, mas garanta que é inicializada no construtor
        private string connectionString = "Server=(localdb)\\MSSQLLocalDB;Database=Litly;Trusted_Connection=True;"; // Já está inicializada

        public PaginaPrincipal(int idLogado)
        {
            InitializeComponent();
            idUtilizadorLogado = idLogado;
            conexao = new SqlConnection(connectionString); // Inicialize conexao aqui

            CarregarDadosUtilizadorLogado();
            CarregarPostsPrincipais(); // Chame aqui para carregar posts no início
        }

        // PaginaPrincipal.cs

        private void btnLike_Click(object sender, EventArgs e)
        {
            Button clickedButton = sender as Button;
            if (clickedButton == null) return;

            int idPostagem = (int)clickedButton.Tag; // Obtém o IdPostagem do Tag do botão
            int idUtilizador = Sessao.IdUtilizador; // Assume que Sessao.IdUtilizador armazena o ID do usuário logado

            try
            {
                conexao.Open();

                // 1. Verificar se o utilizador já gostou desta postagem
                string checkLikeQuery = "SELECT COUNT(*) FROM Gostos WHERE IdUtilizador = @IdUtilizador AND IdPostagem = @IdPostagem";
                SqlCommand checkCmd = new SqlCommand(checkLikeQuery, conexao);
                checkCmd.Parameters.AddWithValue("@IdUtilizador", idUtilizador);
                checkCmd.Parameters.AddWithValue("@IdPostagem", idPostagem);

                int existingLikes = (int)checkCmd.ExecuteScalar();

                if (existingLikes > 0)
                {
                    // Se já gostou, então "desgostar" (remover o gosto)
                    string deleteLikeQuery = "DELETE FROM Gostos WHERE IdUtilizador = @IdUtilizador AND IdPostagem = @IdPostagem";
                    SqlCommand deleteCmd = new SqlCommand(deleteLikeQuery, conexao);
                    deleteCmd.Parameters.AddWithValue("@IdUtilizador", idUtilizador);
                    deleteCmd.Parameters.AddWithValue("@IdPostagem", idPostagem);
                    deleteCmd.ExecuteNonQuery();
                    MessageBox.Show("Gosto removido!");
                }
                else
                {
                    // Se não gostou, então "gostar" (adicionar o gosto)
                    string insertLikeQuery = "INSERT INTO Gostos (IdUtilizador, IdPostagem, DataGosto) VALUES (@IdUtilizador, @IdPostagem, GETDATE())";
                    SqlCommand insertCmd = new SqlCommand(insertLikeQuery, conexao);
                    insertCmd.Parameters.AddWithValue("@IdUtilizador", idUtilizador);
                    insertCmd.Parameters.AddWithValue("@IdPostagem", idPostagem);
                    insertCmd.ExecuteNonQuery();
                    MessageBox.Show("Gosto adicionado!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao processar o gosto: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (conexao.State == ConnectionState.Open)
                {
                    conexao.Close();
                }
                // Após o gosto/desgosto, recarregue as publicações para atualizar os contadores
                CarregarPostsPrincipais();
            }
        }
        private void CarregarPostsPrincipais()
        {
            if (this.flowLayoutPanelPosts == null)
            {
                MessageBox.Show("O FlowLayoutPanel para posts (flowLayoutPanelPosts) não foi encontrado no design do formulário.", "Erro de Layout", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            flowLayoutPanelPosts.Controls.Clear(); // Limpa as postagens existentes antes de carregar novas


            try
            {
                conexao.Open();
                string query = "SELECT p.IdPostagem, p.Titulo, p.Conteudo, p.Autor, p.DataCriacao, p.Imagem, " +
                               "u.Nome AS NomeUtilizador, u.ImagemPerfil AS ImagemPerfilUtilizador, " +
                               "(SELECT COUNT(*) FROM Gostos WHERE IdPostagem = p.IdPostagem) AS TotalGostos, " +
                               "(SELECT COUNT(*) FROM Gostos WHERE IdPostagem = p.IdPostagem AND IdUtilizador = @IdUtilizadorLogado) AS JaGostou " +
                               "FROM Postagens p JOIN Utilizadores u ON p.IdUtilizador = u.IdUtilizador ORDER BY p.DataCriacao DESC";

                SqlCommand cmd = new SqlCommand(query, conexao);
                // Garanta que Sessao.IdUtilizador está populado (normalmente após login bem-sucedido)
                cmd.Parameters.AddWithValue("@IdUtilizadorLogado", Sessao.IdUtilizador);

                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    int idPostagem = reader.GetInt32(reader.GetOrdinal("IdPostagem"));
                    // Tratar DBNull.Value para strings, usando string.Empty como padrão
                    string titulo = reader["Titulo"] != DBNull.Value ? reader["Titulo"].ToString() : string.Empty;
                    string conteudo = reader["Conteudo"] != DBNull.Value ? reader["Conteudo"].ToString() : string.Empty;
                    string autorPostagem = reader["Autor"] != DBNull.Value ? reader["Autor"].ToString() : string.Empty;
                    DateTime dataCriacao = (DateTime)reader["DataCriacao"];
                    string nomeUtilizadorPost = reader["NomeUtilizador"] != DBNull.Value ? reader["NomeUtilizador"].ToString() : string.Empty;
                    int totalGostos = reader.GetInt32(reader.GetOrdinal("TotalGostos"));
                    bool jaGostou = reader.GetInt32(reader.GetOrdinal("JaGostou")) > 0;

                    Image? imagemPost = null; // Use Image? para aceitar nulo
                    if (reader["Imagem"] != DBNull.Value)
                    {
                        byte[] imagemPostBytes = (byte[])reader["Imagem"];
                        using (var ms = new MemoryStream(imagemPostBytes))
                        {
                            imagemPost = Image.FromStream(ms);
                        }
                    }

                    // --- INÍCIO: Código para criar o Panel e seus controles para CADA POSTAGEM ---
                    Panel postPanel = new Panel();
                    postPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                    postPanel.Size = new System.Drawing.Size(450, 250); // Ajuste o tamanho do painel de cada postagem
                    postPanel.Margin = new System.Windows.Forms.Padding(10); // Margem entre as postagens
                    postPanel.BackColor = System.Drawing.Color.White;

                    // Título da postagem
                    Label lblTituloPost = new Label();
                    lblTituloPost.Text = titulo;
                    lblTituloPost.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, System.Drawing.FontStyle.Bold);
                    lblTituloPost.Location = new System.Drawing.Point(10, 10);
                    lblTituloPost.MaximumSize = new System.Drawing.Size(postPanel.Width - 20, 0); // Ajusta a largura máxima
                    lblTituloPost.AutoSize = true;
                    postPanel.Controls.Add(lblTituloPost);

                    // Autor da Postagem e quem Publicou
                    Label lblAutorPost = new Label();
                    lblAutorPost.Text = $"Autor: {autorPostagem} - Publicado por: {nomeUtilizadorPost}";
                    lblAutorPost.Font = new System.Drawing.Font("Segoe UI", 9F);
                    lblAutorPost.Location = new System.Drawing.Point(10, lblTituloPost.Bottom + 5);
                    lblAutorPost.MaximumSize = new System.Drawing.Size(postPanel.Width - 20, 0);
                    lblAutorPost.AutoSize = true;
                    postPanel.Controls.Add(lblAutorPost);

                    // Conteúdo da postagem
                    Label lblConteudoPost = new Label();
                    lblConteudoPost.Text = conteudo;
                    lblConteudoPost.Font = new System.Drawing.Font("Segoe UI", 10F);
                    lblConteudoPost.Location = new System.Drawing.Point(10, lblAutorPost.Bottom + 10);
                    lblConteudoPost.MaximumSize = new System.Drawing.Size(postPanel.Width - 20, 80); // Limita a altura do conteúdo
                    lblConteudoPost.AutoSize = true;
                    postPanel.Controls.Add(lblConteudoPost);

                    // Imagem da Postagem (se houver)
                    if (imagemPost != null)
                    {
                        PictureBox pbPostagem = new PictureBox();
                        pbPostagem.Image = imagemPost;
                        pbPostagem.SizeMode = PictureBoxSizeMode.Zoom;
                        pbPostagem.Size = new System.Drawing.Size(80, 80); // Tamanho da imagem da postagem
                        pbPostagem.Location = new System.Drawing.Point(postPanel.Width - 90, 10); // Canto superior direito do postPanel
                        postPanel.Controls.Add(pbPostagem);
                    }

                    // Data de Criação
                    Label lblDataCriacao = new Label();
                    lblDataCriacao.Text = $"Data: {dataCriacao.ToString("dd/MM/yyyy HH:mm")}";
                    lblDataCriacao.Font = new System.Drawing.Font("Segoe UI", 8F);
                    lblDataCriacao.Location = new System.Drawing.Point(10, lblConteudoPost.Bottom + 10);
                    lblDataCriacao.AutoSize = true;
                    postPanel.Controls.Add(lblDataCriacao);

                    // Botão de Gostar
                    Button btnLike = new Button();
                    btnLike.Text = jaGostou ? "Desgostar" : "Gostar";
                    btnLike.Tag = idPostagem; // Armazena o IdPostagem no Tag do botão
                    btnLike.Click += new EventHandler(btnLike_Click); // Anexa o manipulador de eventos
                    btnLike.Location = new System.Drawing.Point(10, postPanel.Height - 40); // Posicionamento no rodapé do postPanel
                    btnLike.Size = new System.Drawing.Size(80, 30);
                    postPanel.Controls.Add(btnLike);

                    // Contador de Gostos
                    Label lblTotalGostos = new Label();
                    lblTotalGostos.Text = $"Likes: {totalGostos}";
                    lblTotalGostos.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
                    lblTotalGostos.Location = new System.Drawing.Point(btnLike.Right + 10, postPanel.Height - 35); // Posicionamento ao lado do botão
                    lblTotalGostos.AutoSize = true;
                    postPanel.Controls.Add(lblTotalGostos);

                    // --- FIM: Código para criar o Panel e seus controles ---

                    // ESTA É A LINHA QUE ESTAVA A FALTAR! ADICIONA O PAINEL DE POSTAGEM AO FLOWLAYOUPANEL GERAL.
                    flowLayoutPanelPosts.Controls.Add(postPanel); // <<<<< ADICIONE ESTA LINHA AQUI!
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao carregar publicações: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (conexao.State == ConnectionState.Open)
                {
                    conexao.Close();
                }
            }
        }



        private void CarregarDadosUtilizadorLogado()
        {
            using (SqlConnection conn = new Microsoft.Data.SqlClient.SqlConnection(connectionString))
            {
                conn.Open();
                Microsoft.Data.SqlClient.SqlCommand cmd = new Microsoft.Data.SqlClient.SqlCommand("SELECT Nome, Email, ImagemPerfil FROM Utilizadores WHERE IdUtilizador = @IdUtilizador", conn);
                cmd.Parameters.AddWithValue("@IdUtilizador", idUtilizadorLogado);

                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    // Use o operador de coalescência nula (??) para string.Empty se DBNull
                    NomeUtilizadorLogado = reader["Nome"] != DBNull.Value ? reader["Nome"].ToString() : string.Empty;
                    EmailUtilizadorLogado = reader["Email"] != DBNull.Value ? reader["Email"].ToString() : string.Empty;

                    if (reader["ImagemPerfil"] != DBNull.Value)
                    {
                        byte[] imgBytes = (byte[])reader["ImagemPerfil"];
                        using (var ms = new MemoryStream(imgBytes))
                        {
                            ImagemPerfilLogado = Image.FromStream(ms);
                        }
                    }
                    else
                    {
                        ImagemPerfilLogado = null; // Garante que é nulo se não houver imagem
                    }

                    Sessao.IdUtilizador = idUtilizadorLogado;
                    Sessao.NomeUtilizador = NomeUtilizadorLogado;
                    Sessao.EmailUtilizador = EmailUtilizadorLogado;
                    Sessao.ImagemPerfil = ImagemPerfilLogado;
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
            FormChat dm = new FormChat(Sessao.IdUtilizador);
            dm.Show();
            this.Hide();

        }

        private void button6_Click(object sender, EventArgs e)
        {
            PaginaPostagem criarPostagemForm = new PaginaPostagem(Sessao.IdUtilizador);
            criarPostagemForm.ShowDialog(); 
        }

        private void AbrirPostagem(string titulo) // Método que abre PaginaPostagem no modo de VISUALIZAÇÃO
        {
            using (Microsoft.Data.SqlClient.SqlConnection conn = new Microsoft.Data.SqlClient.SqlConnection("Server=(localdb)\\MSSQLLocalDB;Database=Litly;Trusted_Connection=True;"))
            {
                conn.Open();
                Microsoft.Data.SqlClient.SqlCommand cmd = new Microsoft.Data.SqlClient.SqlCommand("SELECT Titulo, Autor, Conteudo, DataCriacao, Imagem FROM Postagens WHERE Titulo = @Titulo", conn);
                cmd.Parameters.AddWithValue("@Titulo", titulo);

                Microsoft.Data.SqlClient.SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    // Tratar DBNull.Value aqui antes de passar para o construtor
                    string tituloBD = reader["Titulo"] != DBNull.Value ? reader["Titulo"].ToString() : string.Empty;
                    string autorBD = reader["Autor"] != DBNull.Value ? reader["Autor"].ToString() : string.Empty;
                    string conteudoBD = reader["Conteudo"] != DBNull.Value ? reader["Conteudo"].ToString() : string.Empty;
                    string dataBD = Convert.ToDateTime(reader["DataCriacao"]).ToString("dd/MM/yyyy HH:mm");
                    byte[]? imagemBD = reader["Imagem"] != DBNull.Value ? (byte[])reader["Imagem"] : null; // Use byte[]? para aceitar nulo

                    var paginaPostagem = new PaginaPostagem(tituloBD, autorBD, conteudoBD, dataBD, imagemBD, Sessao.IdUtilizador);
                    paginaPostagem.Show();
                    this.Hide(); // Esconde a PaginaPrincipal ao abrir a postagem
                }
                else
                {
                    MessageBox.Show("Postagem não encontrada no banco de dados.");
                }
                reader.Close();
            }
        }

        private void button1_Click(object? sender, EventArgs e)
        {
            MessageBox.Show("Você já está na Página Principal.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void buttonBiblioteca_Click(object sender, EventArgs e)
        {

            Biblioteca biblioteca = new Biblioteca(Sessao.IdUtilizador);
            biblioteca.Show();
            this.Hide();

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
            string tipoBusca = cmbTipoBusca.SelectedItem?.ToString() ?? string.Empty;
            listResultados.Items.Clear();

            if (string.IsNullOrEmpty(termo) || string.IsNullOrEmpty(tipoBusca)) // Esta validação já existe
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
                        cmd.CommandText = "SELECT IdUtilizador, Nome, Email FROM Utilizadores WHERE Nome LIKE @termo OR Email LIKE @termo";
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
                Microsoft.Data.SqlClient.SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    if (tipoBusca == "Utilizadores")
                    {
                        string nome = reader["Nome"].ToString();
                        string email = reader["Email"].ToString();
                        int id = reader.GetInt32(reader.GetOrdinal("IdUtilizador")); // Certifique-se de que esta linha esteja ativa e correta
                        listResultados.Items.Add($"👤 {nome} - {email} (ID:{id})");
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
            string tipoBusca = cmbTipoBusca.SelectedItem?.ToString();


            if (itemSelecionado.Contains("Nenhum resultado encontrado")) return; // Impede ação em "nenhum resultado"
            if (tipoBusca == "Utilizadores" && itemSelecionado.StartsWith("👤 "))
            {
                string[] partes = itemSelecionado.Substring(2).Split(" - ");
                if (partes.Length >= 2)
                {
                    // Extrair ID do utilizador (o ID foi adicionado ao texto do ListBox para facilitar)
                    string idString = partes[1].Split("ID:")[1].Replace(")", "").Trim();
                    int idPerfil = int.Parse(idString);

                    AbrirPerfilUtilizador(idPerfil);
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
                    // Esta chamada é agora correta, pois o método AbrirPostagem irá buscar todos os dados.
                    AbrirPostagem(tituloPostagem);
                }
            }


        }

        // Modificado para aceitar o ID do utilizador a ser exibido
        private void AbrirPerfilUtilizador(int idUtilizadorParaPerfil)
        {
            using (SqlConnection conn = new SqlConnection("Server=(localdb)\\MSSQLLocalDB;Database=Litly;Trusted_Connection=True;"))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT Nome, Email, ImagemPerfil FROM Utilizadores WHERE IdUtilizador = @IdUtilizador", conn);
                cmd.Parameters.AddWithValue("@IdUtilizador", idUtilizadorParaPerfil);

                Microsoft.Data.SqlClient.SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    // Tratar DBNull.Value
                    string nome = reader["Nome"] != DBNull.Value ? reader["Nome"].ToString() : string.Empty;
                    string email = reader["Email"] != DBNull.Value ? reader["Email"].ToString() : string.Empty;
                    Image? imagem = null; // Use Image?

                    if (reader["ImagemPerfil"] != DBNull.Value)
                    {
                        byte[] imgBytes = (byte[])reader["ImagemPerfil"];
                        using (var ms = new MemoryStream(imgBytes))
                        {
                            imagem = Image.FromStream(ms);
                        }
                    }
                    // Construtor de PerfilUtilizador já deve aceitar string, string, Image?, int
                    var perfil = new PerfilUtilizador(nome, email, imagem, idUtilizadorParaPerfil);
                    perfil.Show();
                    this.Hide(); // Esconde a página principal
                }
                reader.Close();
            }
        }


    

        
        private void AbrirDetalhesLivro(string titulo)
        {
            using (SqlConnection conn = new SqlConnection("Server=(localdb)\\MSSQLLocalDB;Database=Litly;Trusted_Connection=True;"))
            {
                conn.Open();
                Microsoft.Data.SqlClient.SqlCommand cmd = new Microsoft.Data.SqlClient.SqlCommand("SELECT Titulo, Autor, Sinopse FROM Livros WHERE Titulo = @Titulo", conn);
                cmd.Parameters.AddWithValue("@Titulo", titulo);

                Microsoft.Data.SqlClient.SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    // Tratar DBNull.Value
                    string tituloBD = reader["Titulo"] != DBNull.Value ? reader["Titulo"].ToString() : string.Empty;
                    string autor = reader["Autor"] != DBNull.Value ? reader["Autor"].ToString() : string.Empty;
                    string sinopse = reader["Sinopse"] != DBNull.Value ? reader["Sinopse"].ToString() : string.Empty;

                    var detalhesLivro = new DetalhesLivros(tituloBD, autor, sinopse);
                    detalhesLivro.Show();
                    this.Hide(); // Esconde a página principal
                }
                else
                {
                    MessageBox.Show("Livro não encontrado no banco de dados.");
                }
                reader.Close();
            }
        }
        

        private void buttonPerfil_Click(object sender, EventArgs e)
        {

            var perfil = new PerfilUtilizador(NomeUtilizadorLogado, EmailUtilizadorLogado, ImagemPerfilLogado, idUtilizadorLogado);
            perfil.Show();
            this.Hide();



        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmAmigos amigos = new frmAmigos(idUtilizadorLogado);
            amigos.Show();
            this.Hide();
        }
    }
}
