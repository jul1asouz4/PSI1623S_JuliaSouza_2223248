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
using System.IO;

namespace Litly._02
{
    public partial class PaginaPostagem : Form
    {

        private int idUtilizadorLogado; // ID do utilizador logado, necessário para publicar
        private bool _isCreationMode; // Flag para saber se o formulário está no modo de criação
        private byte[] _imagemBytes; // Para armazenar os bytes da imagem selecionada
        public PaginaPostagem(string titulo, string autor, string conteudo, string data, byte[] imagem, int idLogado)
        {
            InitializeComponent();
            _isCreationMode = false; // Modo de visualização
            idUtilizadorLogado = idLogado;

            // Preencher os campos com os dados da postagem
            txtTitulo.Text = titulo;
            txtAutor.Text = autor;
            txtConteudo.Text = conteudo;
            txtData.Text = data;

            // Tornar campos somente leitura
            txtTitulo.ReadOnly = true;
            txtConteudo.ReadOnly = true;
            txtAutor.ReadOnly = true;
            txtData.ReadOnly = true;
            btnPublicar.Visible = false; // Ocultar o botão "Publicar" no modo de visualização

            // Ocultar botões de seleção de imagem no modo de visualização
            btnSelecionarImagem.Visible = false;
            btnRemoverImagem.Visible = false;

            // Carregar imagem, se houver
            if (imagem != null && imagem.Length > 0)
            {
                using (MemoryStream ms = new MemoryStream(imagem))
                {
                    pictureBoxPostagem.Image = Image.FromStream(ms);
                }
            }
            else
            {
                pictureBoxPostagem.Image = null; // Limpa a PictureBox se não houver imagem
            }
        }

        // Construtor 2: Para CRIAR uma nova postagem
        public PaginaPostagem(int idLogado)
        {
            InitializeComponent();
            _isCreationMode = true; // Modo de criação
            idUtilizadorLogado = idLogado;

            // Deixar campos editáveis para entrada do utilizador
            txtTitulo.ReadOnly = false;
            txtConteudo.ReadOnly = false;
            txtTitulo.Clear(); // Limpar campos para nova entrada
            txtConteudo.Clear();

            // Campos preenchidos automaticamente e somente leitura
            txtAutor.ReadOnly = true;
            txtAutor.Text = Sessao.NomeUtilizador; // O autor é o utilizador logado

            txtData.ReadOnly = true;
            txtData.Text = DateTime.Now.ToString("dd/MM/yyyy HH:mm"); // Data e hora atual da criação

            btnPublicar.Text = "Publicar"; // Texto para o botão de ação
            btnPublicar.Visible = true; // Exibir o botão "Publicar"

            // Exibir botões de seleção de imagem e limpar PictureBox
            btnSelecionarImagem.Visible = true;
            btnRemoverImagem.Visible = true;
            pictureBoxPostagem.Image = null; // Inicia sem imagem na PictureBox
            _imagemBytes = null; // Zera os bytes da imagem
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


            // Esta lógica só deve ser executada no modo de criação
            if (_isCreationMode)
            {
                string titulo = txtTitulo.Text.Trim();
                string conteudo = txtConteudo.Text.Trim();
                string autor = txtAutor.Text.Trim(); // Pega o nome do autor do campo preenchido automaticamente

                if (string.IsNullOrEmpty(titulo) || string.IsNullOrEmpty(conteudo))
                {
                    MessageBox.Show("Título e Conteúdo são obrigatórios para a publicação.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                string connString = "Server=(localdb)\\MSSQLLocalDB;Database=Litly;Trusted_Connection=True;";
                try
                {
                    using (Microsoft.Data.SqlClient.SqlConnection conn = new Microsoft.Data.SqlClient.SqlConnection(connString))
                    {
                        conn.Open();
                        string insertQuery = "INSERT INTO Postagens (Titulo, Autor, Conteudo, DataCriacao, IdUtilizador, Imagem) " +
                                             "VALUES (@Titulo, @Autor, @Conteudo, GETDATE(), @IdUtilizador, @Imagem)";
                        using (Microsoft.Data.SqlClient.SqlCommand cmd = new Microsoft.Data.SqlClient.SqlCommand(insertQuery, conn))
                        {
                            cmd.Parameters.AddWithValue("@Titulo", titulo);
                            cmd.Parameters.AddWithValue("@Autor", autor);
                            cmd.Parameters.AddWithValue("@Conteudo", conteudo);
                            cmd.Parameters.AddWithValue("@IdUtilizador", idUtilizadorLogado);

                            // Adicionar o parâmetro da imagem. Se _imagemBytes for nulo, insere DBNull.Value.
                            if (_imagemBytes != null && _imagemBytes.Length > 0)
                            {
                                cmd.Parameters.AddWithValue("@Imagem", _imagemBytes);
                            }
                            else
                            {
                                cmd.Parameters.AddWithValue("@Imagem", DBNull.Value);
                            }

                            int rowsAffected = cmd.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Publicação criada com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                this.Close(); // Fecha o formulário após a publicação bem-sucedida
                            }
                            else
                            {
                                MessageBox.Show("Erro ao criar a publicação.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao tentar publicar: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                // Mensagem para o caso do botão ser clicado no modo de visualização (onde deveria estar oculto)
                MessageBox.Show("Este botão não está ativo no modo de visualização de postagem.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // Método para simular a publicação da postagem
        private bool PublicarPostagem(string conteudo)
        {
            // Aqui você pode implementar a lógica de salvar no banco de dados ou enviar para uma API
            // Retornando true como exemplo de sucesso
            return true;
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnSelecionarImagem_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "Imagens|*.jpg;*.jpeg;*.png;*.gif;*.bmp|Todos os Ficheiros|*.*"; // Filtro de ficheiros
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    // Carrega a imagem para a PictureBox
                    pictureBoxPostagem.Image = Image.FromFile(openFile.FileName);
                    // Converte a imagem para um array de bytes para guardar na base de dados
                    using (MemoryStream ms = new MemoryStream())
                    {
                        // Salva no formato original da imagem selecionada
                        pictureBoxPostagem.Image.Save(ms, pictureBoxPostagem.Image.RawFormat);
                        _imagemBytes = ms.ToArray();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao carregar a imagem: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    pictureBoxPostagem.Image = null; // Limpa a PictureBox em caso de erro
                    _imagemBytes = null; // Zera os bytes
                }
            }
        }

        private void btnRemoverImagem_Click(object sender, EventArgs e)
        {
            pictureBoxPostagem.Image = null; // Remove a imagem da PictureBox
            _imagemBytes = null;             // Define os bytes da imagem como nulos para não serem guardados
            MessageBox.Show("Imagem removida.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

       
    }

}
    

