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

namespace Litly._02
{
    public partial class PerfilUtilizador : Form
    {

        private int idUtilizadorLogadoParaPerfil;

        public PerfilUtilizador(string nome, string email, Image imagem, int idLogado)
        {
            InitializeComponent();
            lblNome.Text = nome;
            lblEmail.Text = email;
            pictureBoxFotoPerfil.Image = imagem;
            idUtilizadorLogadoParaPerfil = idLogado; // Armazena o ID
        }

        public PerfilUtilizador()
        {
            //Apaguei os outros campos pq não os utilizava corretamente.
            /*InitializeComponent();
            lblNome.Text = Nome;
            lblEmail.Text = Email;*/

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
    }
}
