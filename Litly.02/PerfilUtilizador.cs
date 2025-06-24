using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Data.SqlClient;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Litly._02
{
    public partial class PerfilUtilizador : Form
    {

        private int idUtilizadorLogadoParaPerfil;

        public PerfilUtilizador(string nome, string email, Image imagemPerfil, int idPerfil)
        {

            InitializeComponent();
            this.idUtilizadorLogadoParaPerfil = idPerfil;

            // Assume que você tem Labels (lblNomePerfil, lblEmailPerfil, lblBio) e PictureBox (picPerfil) no seu design
            lblNome.Text = nome;
            lblEmail.Text = email; // Exibe o email, ou outro dado relevante
            pictureBoxFotoPerfil.Image = imagemPerfil; // Exibe a imagem de perfil

            CarregarBioUtilizador();       // Carrega a biografia
            CarregarPublicacoesDoUtilizador();
        }

        public PerfilUtilizador()
        {
            InitializeComponent();
            this.idUtilizadorLogadoParaPerfil = Sessao.IdUtilizador; // Perfil do utilizador logado por padrão

            // Carrega os dados do utilizador logado da sessão para o perfil
            lblNome.Text = Sessao.NomeUtilizador;
            lblEmail.Text = Sessao.EmailUtilizador;
            pictureBoxFotoPerfil.Image = Sessao.ImagemPerfil;

            CarregarBioUtilizador();
            CarregarPublicacoesDoUtilizador();

        }

        private void CarregarBioUtilizador()
        {
            string bio = "Sem biografia."; // Valor padrão
            string connString = "Server=(localdb)\\MSSQLLocalDB;Database=Litly;Trusted_Connection=True;";

            using (Microsoft.Data.SqlClient.SqlConnection conn = new Microsoft.Data.SqlClient.SqlConnection(connString))
            {
                try
                {
                    conn.Open();
                    // Query usa o idUtilizadorPerfil para carregar a bio do utilizador correto
                    Microsoft.Data.SqlClient.SqlCommand cmd = new Microsoft.Data.SqlClient.SqlCommand("SELECT Bio FROM Utilizadores WHERE IdUtilizador = @IdUtilizador", conn);
                    cmd.Parameters.AddWithValue("@IdUtilizador", idUtilizadorLogadoParaPerfil);

                    Microsoft.Data.SqlClient.SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        if (reader["Bio"] != DBNull.Value)
                        {
                            bio = reader["Bio"].ToString();
                        }
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao carregar biografia: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            lblBio.Text = bio; // Assumindo que você tem um Label para a Bio (lblBio)
        }

        // MÉTODO PARA CARREGAR E EXIBIR AS PUBLICAÇÕES DO UTILIZADOR
        private void CarregarPublicacoesDoUtilizador()
        {
            flowLayoutPosts.Controls.Clear(); // Limpa publicações antigas antes de carregar novas

            string connString = "Server=(localdb)\\MSSQLLocalDB;Database=Litly;Trusted_Connection=True;";

            using (Microsoft.Data.SqlClient.SqlConnection conn = new Microsoft.Data.SqlClient.SqlConnection(connString))
            {
                try
                {
                    conn.Open();
                    // Seleciona as colunas da postagem, incluindo a Imagem
                    string query = "SELECT Titulo, Conteudo, DataCriacao, Imagem FROM Postagens WHERE IdUtilizador = @IdUtilizador ORDER BY DataCriacao DESC";
                    using (Microsoft.Data.SqlClient.SqlCommand cmd = new Microsoft.Data.SqlClient.SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@IdUtilizador", idUtilizadorLogadoParaPerfil);

                        using (Microsoft.Data.SqlClient.SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (!reader.HasRows)
                            {
                                Label noPostsLabel = new Label();
                                noPostsLabel.AutoSize = true;
                                noPostsLabel.Text = "Este utilizador ainda não fez publicações.";
                                noPostsLabel.Font = new Font(noPostsLabel.Font, FontStyle.Italic);
                                noPostsLabel.Padding = new Padding(10);
                                flowLayoutPosts.Controls.Add(noPostsLabel);
                            }
                            else
                            {
                                while (reader.Read())
                                {
                                    string titulo = reader["Titulo"].ToString();
                                    string conteudo = reader["Conteudo"].ToString();
                                    DateTime dataCriacao = (DateTime)reader["DataCriacao"];
                                    byte[] imagemBytes = reader["Imagem"] != DBNull.Value ? (byte[])reader["Imagem"] : null; // Obter a imagem

                                    // Cria um Panel para cada publicação para melhor organização
                                    Panel postPanel = new Panel();
                                    postPanel.Width = flowLayoutPosts.ClientSize.Width - 10; // Ajusta a largura para caber no FlowLayoutPanel
                                    postPanel.AutoSize = true; // Auto-ajusta a altura
                                    postPanel.Margin = new Padding(5);
                                    postPanel.BorderStyle = BorderStyle.FixedSingle;
                                    postPanel.Padding = new Padding(10);
                                    postPanel.BackColor = Color.WhiteSmoke;

                                    // Adiciona PictureBox para a imagem da postagem, se existir
                                    if (imagemBytes != null && imagemBytes.Length > 0)
                                    {
                                        PictureBox postagemPictureBox = new PictureBox();
                                        postagemPictureBox.Width = postPanel.Width - 20; // Ajusta largura
                                        postagemPictureBox.Height = 150; // Altura fixa para a imagem
                                        postagemPictureBox.SizeMode = PictureBoxSizeMode.Zoom; // Para a imagem caber
                                        using (MemoryStream ms = new MemoryStream(imagemBytes))
                                        {
                                            postagemPictureBox.Image = Image.FromStream(ms);
                                        }
                                        postagemPictureBox.Margin = new Padding(5); // Margem para separar dos outros elementos
                                        postPanel.Controls.Add(postagemPictureBox); // Adiciona a imagem ao painel
                                    }

                                    Label lblTitulo = new Label();
                                    lblTitulo.AutoSize = true;
                                    lblTitulo.Font = new Font(lblTitulo.Font.FontFamily, 12, FontStyle.Bold);
                                    lblTitulo.Text = titulo;
                                    lblTitulo.Dock = DockStyle.Top;
                                    lblTitulo.Margin = new Padding(0, 5, 0, 0); // Margem acima

                                    Label lblConteudo = new Label();
                                    lblConteudo.AutoSize = true;
                                    lblConteudo.MaximumSize = new Size(postPanel.Width - 20, 0); // Limita a largura do conteúdo
                                    lblConteudo.Text = conteudo;
                                    lblConteudo.Dock = DockStyle.Top;
                                    lblConteudo.Margin = new Padding(0, 5, 0, 0); // Margem acima

                                    Label lblData = new Label();
                                    lblData.AutoSize = true;
                                    lblData.Font = new Font(lblData.Font.FontFamily, 8, FontStyle.Italic);
                                    lblData.Text = $"Publicado em: {dataCriacao:dd/MM/yyyy HH:mm}";
                                    lblData.Dock = DockStyle.Top; // Usar Top para empilhar corretamente
                                    lblData.Margin = new Padding(0, 5, 0, 0); // Margem acima

                                    // Adiciona os Labels ao Panel na ordem desejada
                                    postPanel.Controls.Add(lblTitulo);
                                    postPanel.Controls.Add(lblConteudo);
                                    postPanel.Controls.Add(lblData);

                                    flowLayoutPosts.Controls.Add(postPanel);
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao carregar publicações: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void PerfilUtilizador_Load(object sender, EventArgs e)
        {
            /*lblNome.Text = nomeUtilizador;
            lblEmail.Text = emailUtilizador;
            txtBio.Text = bioUtilizador;*/
        }

        private void IblNome_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Imagens (*.jpg;*.png;*.jpeg)|*.jpg;*.png;*.jpeg";

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                string caminhoImagem = dialog.FileName;
                pictureBoxFotoPerfil.Image = Image.FromFile(caminhoImagem);
                pictureBoxFotoPerfil.Tag = caminhoImagem; // guarda caminho temporariamente
            }
        }

        private void btnSalvarImagem_Click(object sender, EventArgs e)
        {
            if (pictureBoxFotoPerfil.Image == null)
            {
                MessageBox.Show("Nenhuma imagem para salvar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Converte a imagem para byte[]
            byte[] imagemBytes;
            using (MemoryStream ms = new MemoryStream())
            {
                // Salva a imagem no MemoryStream no formato desejado (ex: PNG)
                pictureBoxFotoPerfil.Image.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                imagemBytes = ms.ToArray();
            }

            string connString = "Server=(localdb)\\MSSQLLocalDB;Database=Litly;Trusted_Connection=True;";
            using (SqlConnection conn = new SqlConnection(connString))
            {
                try
                {
                    conn.Open();
                    string query = "UPDATE Utilizadores SET ImagemPerfil = @ImagemPerfil WHERE IdUtilizador = @IdUtilizador";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.Add("@ImagemPerfil", SqlDbType.VarBinary, -1).Value = imagemBytes; // -1 para MAX
                        cmd.Parameters.AddWithValue("@IdUtilizador", idUtilizadorLogadoParaPerfil);

                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Imagem de perfil salva com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            // Atualizar a imagem na Sessao ou na PaginaPrincipal se necessário
                            // Sessao.ImagemPerfil = pictureBoxFotoPerfil.Image;
                            // Ou chamar um método na PaginaPrincipal para recarregar a imagem
                        }
                        else
                        {
                            MessageBox.Show("Erro ao salvar a imagem de perfil.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao salvar imagem: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
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

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
