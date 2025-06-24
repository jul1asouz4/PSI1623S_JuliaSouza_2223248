using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Litly._02
{
    public partial class FormChat : Form
    {

        int idUtilizadorLogado;
        int idAmigoSelecionado;


        public FormChat(int idLogado)
        {
            InitializeComponent();
            idUtilizadorLogado = idLogado;
            CarregarListaAmigos();
            this.listChats.SelectedIndexChanged += new System.EventHandler(this.listChats_SelectedIndexChanged);

        }

        // NOVO CONSTRUTOR para iniciar o chat com um amigo específico
        public FormChat(int idLogado, int idAmigoParaChat)
        {
            InitializeComponent();
            idUtilizadorLogado = idLogado;
            idAmigoSelecionado = idAmigoParaChat; // Define o amigo selecionado

            CarregarListaAmigos(); // Carrega a lista de amigos na barra lateral (listChats)

            // Tenta selecionar o amigo na listChats se ele existir, para que o chat correto esteja visível
            foreach (ItemAmigo item in listChats.Items)
            {
                if (item.Id == idAmigoParaChat)
                {
                    listChats.SelectedItem = item;
                    break;
                }
            }
            CarregarMensagens();   // Carrega as mensagens para este amigo específico
        }
        private class ItemAmigo
        {
            public string Nome { get; set; }
            public int Id { get; set; }

            public override string ToString()
            {
                return Nome;
            }
        }

        private void CarregarListaAmigos()
        {
            listChats.Items.Clear();
            string connString = "Server=(localdb)\\MSSQLLocalDB;Database=Litly;Trusted_Connection=True;"; // Certifique-se das barras duplas aqui, como no código.

            using (var con = new Microsoft.Data.SqlClient.SqlConnection(connString))
            {
                try
                {


                    // A QUERY CORRIGIDA PARA PEGAR TODOS OS AMIGOS ACEITOS
                    string sql = @"SELECT u.IdUtilizador, u.Nome
                           FROM Amizades a  -- << CORRIGIDO: Nome da tabela para 'Amizade'
                           JOIN Utilizadores u ON u.IdUtilizador = CASE
                                                                      WHEN a.IdSolicitante = @IdUtilizadorLogado THEN a.IdAceito
                                                                      WHEN a.IdAceito = @IdUtilizadorLogado THEN a.IdSolicitante
                                                                      ELSE NULL
                                                                  END
                           WHERE (a.IdSolicitante = @IdUtilizadorLogado OR a.IdAceito = @IdUtilizadorLogado)
                             AND a.Status = 'Aceite'"; // << Adicionado filtro por Status 'Aceite'

                    using (var cmd = new Microsoft.Data.SqlClient.SqlCommand(sql, con))
                    {
                        // Passa o ID do utilizador logado para o parâmetro
                        cmd.Parameters.AddWithValue("@IdUtilizadorLogado", idUtilizadorLogado);
                        con.Open();

                        using (var reader = cmd.ExecuteReader())
                        {
                            //listChats.Items.Clear(); // Limpa a lista antes de adicionar novos itens

                            if (!reader.HasRows)
                            {
                                // Opcional: Mensagem se não houver amigos
                                //MessageBox.Show("Você não tem amigos aceitos para conversar.", "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }

                            while (reader.Read())
                            {
                                listChats.Items.Add(new ItemAmigo
                                {
                                    Nome = reader["Nome"].ToString(),
                                    Id = (int)reader["IdUtilizador"]
                                });
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao carregar lista de amigos: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }



        private void GuardarMensagensNoBanco(int idDestinatario, string conteudo)
        {
            string conn = "Server=(localdb)\\MSSQLLocalDB;Database=Litly;Trusted_Connection=True;";
            using (var con = new Microsoft.Data.SqlClient.SqlConnection(conn))
            {
                con.Open();
                string sql = "INSERT INTO Mensagens (IdRemetente, IdDestinatario, Conteudo) VALUES (@r, @d, @c)";
                using (var cmd = new Microsoft.Data.SqlClient.SqlCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@r", idUtilizadorLogado);
                    cmd.Parameters.AddWithValue("@d", idDestinatario);
                    cmd.Parameters.AddWithValue("@c", conteudo);
                    cmd.ExecuteNonQuery();
                }
            }
        }
        private void DM_Load(object sender, EventArgs e)
        {

        }


        private void EnviarMensagem(string mensagem, bool doUsuario)
        {
            /*if (idAmigoSelecionado <= 0 || string.IsNullOrWhiteSpace(txtMensagem.Text))
            {
                MessageBox.Show("Selecione um amigo e escreva uma mensagem.");
                return;
            }

            string connString = "Server=(localdb)\\MSSQLLocalDB;Database=Litly;Trusted_Connection=True;";
            using (var con = new Microsoft.Data.SqlClient.SqlConnection(connString))
            {
                con.Open();

                string query = @"INSERT INTO Mensagens (IdRemetente, IdDestinatario, Conteudo)
                         VALUES (@rem, @dest, @conteudo)";

                using (var cmd = new Microsoft.Data.SqlClient.SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@rem", idUtilizadorLogado);
                    cmd.Parameters.AddWithValue("@dest", idAmigoSelecionado);
                    cmd.Parameters.AddWithValue("@conteudo", txtMensagem.Text);

                    cmd.ExecuteNonQuery();
                }
            }

            txtMensagem.Clear();
            CarregarMensagens();*/

            if (idAmigoSelecionado <= 0 || string.IsNullOrWhiteSpace(txtMensagem.Text))
            {
                MessageBox.Show("Selecione um amigo e escreva uma mensagem.");
                return;
            }

            // A lógica de guardar mensagem já está em GuardarMensagensNoBanco,
            // então não precisamos duplicar a query aqui.
            GuardarMensagensNoBanco(idAmigoSelecionado, txtMensagem.Text);

            txtMensagem.Clear();
            CarregarMensagens(); // Recarrega as mensagens para mostrar a nova
        }


        private void CarregarMensagens() // Este método carrega as mensagens para o chat *selecionado*
        {
            if (idAmigoSelecionado <= 0)
                return;

            flowMensagens.Controls.Clear(); // Limpa mensagens antigas do painel

            string connString = "Server=(localdb)\\MSSQLLocalDB;Database=Litly;Trusted_Connection=True;";

            using (var con = new Microsoft.Data.SqlClient.SqlConnection(connString))
            {
                con.Open();
                string query = @"
            SELECT IdRemetente, Conteudo, DataEnvio -- Alterado de DataHora para DataEnvio
            FROM Mensagens
            WHERE (IdRemetente = @id1 AND IdDestinatario = @id2)
               OR (IdRemetente = @id2 AND IdDestinatario = @id1)
            ORDER BY DataEnvio ASC";

                using (var cmd = new Microsoft.Data.SqlClient.SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@id1", idUtilizadorLogado);
                    cmd.Parameters.AddWithValue("@id2", idAmigoSelecionado);

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            bool enviadoPorMim = (int)reader["IdRemetente"] == idUtilizadorLogado;
                            string conteudo = reader["Conteudo"].ToString();
                            DateTime data = (DateTime)reader["DataEnvio"]; //estava DataHora, mas o correto é DataEnvio

                            Label msg = new Label();
                            msg.AutoSize = true;
                            msg.MaximumSize = new Size(300, 0); // largura máxima
                            msg.Text = $"{conteudo}\n{data:HH:mm}";
                            msg.BackColor = enviadoPorMim ? Color.LightGreen : Color.LightGray;
                            msg.TextAlign = ContentAlignment.MiddleLeft;
                            msg.Padding = new Padding(10);
                            msg.Margin = new Padding(5);

                            FlowLayoutPanel msgWrapper = new FlowLayoutPanel();
                            msgWrapper.AutoSize = true;
                            msgWrapper.Dock = DockStyle.Top;
                            msgWrapper.FlowDirection = enviadoPorMim ? FlowDirection.RightToLeft : FlowDirection.LeftToRight;
                            msgWrapper.Controls.Add(msg);

                            flowMensagens.Controls.Add(msgWrapper);
                        }
                    }
                }
            }
        }


        private void btnEnviar_Click(object sender, EventArgs e)
        {


            EnviarMensagem(txtMensagem.Text, true);
            //GuardarMensagensNoBanco(idAmigoSelecionado, txtMensagem.Text);

        }

        private void txtMensagem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && !e.Shift)
            {
                e.SuppressKeyPress = true; // Impede quebra de linha
                EnviarMensagem(txtMensagem.Text, true);
            }
        }



        private void CarregarMensagens(int idAmigo)
        {
            //listChats.Items.Clear();

            string connString = "Server=(localdb)\\MSSQLLocalDB;Database=Litly;Trusted_Connection=True;";

            using (var con = new Microsoft.Data.SqlClient.SqlConnection(connString))
            {
                con.Open();

                //MessageBox.Show("ID do utilizador logado: " + idUtilizadorLogado);


                string sql = @"
            SELECT DISTINCT u.IdUtilizador, u.Nome
            FROM Utilizadores u
            WHERE u.IdUtilizador IN (
                SELECT IdRemetente FROM Mensagens WHERE IdDestinatario = @IdUtilizadorLogado
                UNION
                SELECT IdDestinatario FROM Mensagens WHERE IdRemetente = @IdUtilizadorLogado
            )";

                using (var cmd = new Microsoft.Data.SqlClient.SqlCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@IdUtilizadorLogado", idUtilizadorLogado);

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            // Adiciona apenas se ainda não estiver na lista para evitar duplicados
                            // O ItemAmigo já está definido na classe.
                            bool found = false;
                            foreach (ItemAmigo existingItem in listChats.Items)
                            {
                                if (existingItem.Id == (int)reader["IdUtilizador"])
                                {
                                    found = true;
                                    break;
                                }
                            }
                            if (!found)
                            {
                                listChats.Items.Add(new ItemAmigo
                                {
                                    Nome = reader["Nome"].ToString(),
                                    Id = (int)reader["IdUtilizador"]
                                });
                            }
                        }
                    }
                }

            }
        }


        private void listChats_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listChats.SelectedItem is ItemAmigo amigo)
            {
                AbrirChatCom(amigo.Id); // Chama AbrirChatCom para carregar as mensagens do amigo selecionado
            }
        }

        private void btnAbrirChat_Click(object sender, EventArgs e)
        {
            if (listChats.SelectedItem is ItemAmigo amigo)
            {
                AbrirChatCom(amigo.Id);
            }
            else
            {
                MessageBox.Show("Selecione um utilizador para iniciar o chat.");
            }
        }

        private void btnProcurarAmigos_Click(object sender, EventArgs e)
        {
            string filtro = txtPesquisarChat.Text.Trim();
            CarregarListaAmigos(filtro);
        }

        private void CarregarListaAmigos(string filtro = "")
        {
            listChats.Items.Clear();

            string connectionString = "Server=(localdb)\\MSSQLLocalDB;Database=Litly;Trusted_Connection=True;";
            string query = @"
            SELECT DISTINCT u.IdUtilizador, u.Nome
            FROM Amizades a
            JOIN Utilizadores u ON
                u.IdUtilizador = CASE
                                   WHEN a.IdSolicitante = @IdUtilizadorLogado THEN a.IdAceito
                                   WHEN a.IdAceito = @IdUtilizadorLogado THEN a.IdSolicitante
                                   ELSE NULL
                               END
            WHERE (a.IdSolicitante = @IdUtilizadorLogado OR a.IdAceito = @IdUtilizadorLogado)
              AND a.Status = 'Aceite'";


            if (!string.IsNullOrWhiteSpace(filtro))
            {
                query += " AND U.Nome LIKE @Filtro";
            }

            using (Microsoft.Data.SqlClient.SqlConnection conn = new Microsoft.Data.SqlClient.SqlConnection(connectionString))
            using (Microsoft.Data.SqlClient.SqlCommand cmd = new Microsoft.Data.SqlClient.SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@IdUtilizadorLogado", idUtilizadorLogado); // CORRIGIDO: Nome do parâmetro
                if (!string.IsNullOrWhiteSpace(filtro))
                {
                    cmd.Parameters.AddWithValue("@Filtro", "%" + filtro + "%");
                }

                conn.Open();
                var reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    listChats.Items.Add(new ItemAmigo
                    {
                        Nome = reader["Nome"].ToString(),
                        Id = (int)reader["IdUtilizador"]
                    });
                }
            }
        }

        private void txtPesquisarChat_TextChanged(object sender, EventArgs e)
        {
            listSugestoesAmigos.Items.Clear();

            if (string.IsNullOrWhiteSpace(txtPesquisarChat.Text))
            {
                listSugestoesAmigos.Visible = false;
                // Quando o texto de pesquisa é limpo, recarrega a lista de amigos aceites normal
                CarregarListaAmigos();
                return;
            }

            string connString = "Server=(localdb)\\MSSQLLocalDB;Database=Litly;Trusted_Connection=True;";
            using (var con = new Microsoft.Data.SqlClient.SqlConnection(connString))
            {
                con.Open();

                string sql = @"
            SELECT IdUtilizador, Nome FROM Utilizadores
            WHERE Nome LIKE @nome AND IdUtilizador <> @idAtual";

                using (var cmd = new Microsoft.Data.SqlClient.SqlCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@nome", "%" + txtPesquisarChat.Text + "%");
                    cmd.Parameters.AddWithValue("@idAtual", idUtilizadorLogado);

                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            listSugestoesAmigos.Items.Add(new ItemAmigo
                            {
                                Nome = reader["Nome"].ToString(),
                                Id = (int)reader["IdUtilizador"]
                            });
                        }

                        listSugestoesAmigos.Visible = listSugestoesAmigos.Items.Count > 0;
                    }
                }
            }
        }

        private void listSugestoesAmigos_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listSugestoesAmigos.SelectedItem is ItemAmigo amigo)
            {
                txtPesquisarChat.Text = amigo.Nome;
                listSugestoesAmigos.Visible = false;

                AbrirChatCom(amigo.Id); // Abre o chat com o amigo selecionado da sugestão
            }
        }

        private void AbrirChatCom(int idAmigo)
        {
            string connString = "Server=(localdb)\\MSSQLLocalDB;Database=Litly;Trusted_Connection=True;";

            using (var con = new Microsoft.Data.SqlClient.SqlConnection(connString))
            {
                con.Open();

                string sql = "SELECT IdUtilizador, Nome, Email, ImagemPerfil FROM Utilizadores WHERE IdUtilizador = @id";

                using (var cmd = new Microsoft.Data.SqlClient.SqlCommand(sql, con))
                {
                    cmd.Parameters.AddWithValue("@id", idAmigo);

                    using (var reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            idAmigoSelecionado = idAmigo;

                            string nome = reader["Nome"].ToString();
                            string email = reader["Email"].ToString();

                            lblNomeContato.Text = nome;
                            lblNomePerfil.Text = nome;
                            lblStatusPerfil.Text = email;

                            if (!(reader["ImagemPerfil"] is DBNull))
                            {
                                byte[] imagemBytes = (byte[])reader["ImagemPerfil"];
                                using (var ms = new MemoryStream(imagemBytes))
                                {
                                    picPerfil.Image = Image.FromStream(ms);
                                }
                            }
                            else
                            {
                                picPerfil.Image = null; // Garante que a imagem é limpa se não houver no DB
                            }

                            CarregarMensagens(); // Recarrega as mensagens para o novo amigo selecionado
                        }
                    }
                }
            }
        }


        private void btnSair_Click(object sender, EventArgs e)
        {

            this.Hide();

            // Cria uma nova instância da PaginaPrincipal, passando o ID do utilizador logado
            // que está armazenado na classe estática Sessao.
            PaginaPrincipal principal = new PaginaPrincipal(Sessao.IdUtilizador);
            principal.Show(); // Exibe a PaginaPrincipal


            this.Close();
        }

        private void btnPedidos_Click(object sender, EventArgs e)
        {
            frmAmigos amigos = new frmAmigos(idUtilizadorLogado); // Cria uma nova instância de frmAmigos
            amigos.Show(); // Exibe o formulário de amigos
            this.Hide();
        }

        private void listChats_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }

        private void btnVerPerfil_Click(object sender, EventArgs e)
        {

            if (idAmigoSelecionado > 0)
            {
                PerfilUtilizador perfilUtilizador = new PerfilUtilizador();
                perfilUtilizador.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Selecione um amigo para ver o perfil.");
            }

        }

        private void btnVerPerfil_Click_1(object sender, EventArgs e)
        {
            // Verifica se um amigo está selecionado no chat
            if (idAmigoSelecionado > 0)
            {
                string connString = "Server=(localdb)\\MSSQLLocalDB;Database=Litly;Trusted_Connection=True;";
                using (Microsoft.Data.SqlClient.SqlConnection conn = new Microsoft.Data.SqlClient.SqlConnection(connString))
                {
                    try
                    {
                        conn.Open();
                        // Seleciona os dados do perfil do amigo
                        string sql = "SELECT Nome, Email, ImagemPerfil FROM Utilizadores WHERE IdUtilizador = @IdUtilizador";
                        using (Microsoft.Data.SqlClient.SqlCommand cmd = new Microsoft.Data.SqlClient.SqlCommand(sql, conn))
                        {
                            cmd.Parameters.AddWithValue("@IdUtilizador", idAmigoSelecionado);

                            using (Microsoft.Data.SqlClient.SqlDataReader reader = cmd.ExecuteReader())
                            {
                                if (reader.Read())
                                {
                                    string nomeAmigo = reader["Nome"].ToString();
                                    string emailAmigo = reader["Email"].ToString();
                                    Image imagemAmigo = null;

                                    if (reader["ImagemPerfil"] != DBNull.Value)
                                    {
                                        byte[] imagemBytes = (byte[])reader["ImagemPerfil"];
                                        using (var ms = new MemoryStream(imagemBytes))
                                        {
                                            imagemAmigo = Image.FromStream(ms);
                                        }
                                    }

                                    // Cria e mostra o formulário PerfilUtilizador com os dados do amigo
                                    PerfilUtilizador perfilAmigo = new PerfilUtilizador(nomeAmigo, emailAmigo, imagemAmigo, idAmigoSelecionado);
                                    perfilAmigo.Show();
                                    this.Hide(); // Esconde o formulário DM
                                }
                                else
                                {
                                    MessageBox.Show("Dados do amigo não encontrados.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Erro ao carregar perfil do amigo: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Selecione um amigo na lista para ver o perfil.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }

}
