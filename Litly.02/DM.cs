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

        // Variáveis de instância (membros da classe)
        int idUtilizadorLogado;
        int idAmigoSelecionado;

        // Apenas a título de organização, mova as conexões para uma variável de classe ou método auxiliar se for repetitiva
        private string ConnectionString = "Server=(localdb)\\MSSQLLocalDB;Database=Litly;Trusted_Connection=True;";


        // Construtor principal
        public FormChat(int idLogado)
        {
            InitializeComponent();
            idUtilizadorLogado = idLogado;
            CarregarListaAmigos();
            // CORRIGIDO: Usar o nome do evento correto ou remover se não for necessário
            // Se você tiver um evento listChats_SelectedIndexChanged_1 no designer, use ele.
            // Se você quer que listChats_SelectedIndexChanged(object sender, EventArgs e) seja o manipulador,
            // então você precisa ter um método com essa assinatura.
            // Pelo seu código, parece que listChats_SelectedIndexChanged_1 é o que foi gerado.
            this.listChats.SelectedIndexChanged += new System.EventHandler(this.listChats_SelectedIndexChanged_1);

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
            CarregarMensagens();    // Carrega as mensagens para este amigo específico (a versão sem parâmetros)
        }

        // Classe aninhada para os itens da lista de amigos
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
            using (var con = new Microsoft.Data.SqlClient.SqlConnection(ConnectionString)) // Usando ConnectionString
            {
                try
                {
                    string sql = @"SELECT u.IdUtilizador, u.Nome
                               FROM Amizades a
                               JOIN Utilizadores u ON u.IdUtilizador = CASE
                                                                        WHEN a.IdSolicitante = @IdUtilizadorLogado THEN a.IdAceito
                                                                        WHEN a.IdAceito = @IdUtilizadorLogado THEN a.IdSolicitante
                                                                        ELSE NULL
                                                                    END
                               WHERE (a.IdSolicitante = @IdUtilizadorLogado OR a.IdAceito = @IdUtilizadorLogado)
                                 AND a.Status = 'Aceite'";

                    using (var cmd = new Microsoft.Data.SqlClient.SqlCommand(sql, con))
                    {
                        cmd.Parameters.AddWithValue("@IdUtilizadorLogado", idUtilizadorLogado);
                        con.Open();
                        using (var reader = cmd.ExecuteReader())
                        {
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
            using (var con = new Microsoft.Data.SqlClient.SqlConnection(ConnectionString)) // Usando ConnectionString
            {
                try
                {
                    con.Open();
                    string sql = "INSERT INTO Mensagens (IdRemetente, IdDestinatario, Conteudo, DataEnvio) VALUES (@r, @d, @c, GETDATE())";
                    using (var cmd = new Microsoft.Data.SqlClient.SqlCommand(sql, con))
                    {
                        cmd.Parameters.AddWithValue("@r", idUtilizadorLogado);
                        cmd.Parameters.AddWithValue("@d", idDestinatario);
                        cmd.Parameters.AddWithValue("@c", conteudo);
                        cmd.ExecuteNonQuery();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao guardar mensagem: " + ex.Message, "Erro de Base de Dados", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    if (con.State == ConnectionState.Open)
                    {
                        con.Close();
                    }
                }
            }
        }
        private void DM_Load(object sender, EventArgs e)
        {

        }


        private void EnviarMensagem()
        {

            string mensagem = txtMensagem.Text.Trim();

            if (idAmigoSelecionado <= 0 || string.IsNullOrWhiteSpace(mensagem))
            {
                MessageBox.Show("Selecione um amigo e escreva uma mensagem.");
                return;
            }

            // 1. Guardar a mensagem no banco de dados
            GuardarMensagensNoBanco(idAmigoSelecionado, mensagem);

            // --- INÍCIO DA ATUALIZAÇÃO IMEDIATA DA UI ---

            // 2. Criar e adicionar o balão da mensagem à UI
            bool enviadoPorMim = true;
            DateTime dataEnvio = DateTime.Now; // Usamos a hora atual para exibição imediata

            AdicionarMensagemAoPainel(mensagem, dataEnvio, enviadoPorMim);

            // 3. Limpar a caixa de texto de entrada
            txtMensagem.Clear();

            // 4. (Opcional, mas recomendado) Foco na caixa de texto para digitar a próxima mensagem
            txtMensagem.Focus();

            // --- FIM DA ATUALIZAÇÃO IMEDIATA DA UI ---
        }


        // Este método agora será mais genérico para adicionar uma única mensagem ao FlowLayoutPanel
        // Tanto CarregarMensagens() quanto EnviarMensagem() poderão usá-lo.
        private void AdicionarMensagemAoPainel(string conteudo, DateTime data, bool enviadoPorMim)
        {
            Label msg = new Label();
            msg.AutoSize = true;
            msg.MaximumSize = new Size(flowMensagens.Width - 40, 0); // Ajustado para largura do flowMensagens
            msg.Text = $"{conteudo}\n{data:HH:mm}"; // Formata a data para exibir apenas hora e minuto
            msg.BackColor = enviadoPorMim ? Color.LightGreen : Color.LightGray;
            msg.ForeColor = Color.Black;
            msg.TextAlign = ContentAlignment.MiddleLeft;
            msg.Padding = new Padding(10);
            msg.Margin = new Padding(5);
            msg.BorderStyle = BorderStyle.FixedSingle;
            msg.Font = new Font("Segoe UI", 9);

            FlowLayoutPanel msgWrapper = new FlowLayoutPanel();
            msgWrapper.AutoSize = true;
            msgWrapper.Width = flowMensagens.Width; // Garante que o wrapper ocupa a largura total do pai
            msgWrapper.FlowDirection = enviadoPorMim ? FlowDirection.RightToLeft : FlowDirection.LeftToRight;
            msgWrapper.Controls.Add(msg);

            flowMensagens.Controls.Add(msgWrapper);

            flowMensagens.ScrollControlIntoView(msgWrapper);
        }


            private void CarregarMensagens() // Este método carrega as mensagens para o chat *selecionado*
            {
            if (idAmigoSelecionado <= 0)
                return;

            flowMensagens.Controls.Clear(); // Limpa mensagens antigas do painel

            using (var con = new Microsoft.Data.SqlClient.SqlConnection(ConnectionString)) // Usando ConnectionString
            {
                con.Open();
                string query = @"
            SELECT IdRemetente, Conteudo, DataEnvio
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
                            DateTime data = (DateTime)reader["DataEnvio"];

                            // Reutiliza o novo método auxiliar para adicionar a mensagem
                            AdicionarMensagemAoPainel(conteudo, data, enviadoPorMim);
                        }
                    }
                }
            }
            // Após carregar todas as mensagens, garante que a rolagem esteja no final
            if (flowMensagens.Controls.Count > 0)
            {
                flowMensagens.ScrollControlIntoView(flowMensagens.Controls[flowMensagens.Controls.Count - 1]);
            }
        }


        private void btnEnviar_Click(object sender, EventArgs e)
        {
            EnviarMensagem();
      

        }

        private void txtMensagem_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && !e.Shift)
            {
                e.SuppressKeyPress = true;
                EnviarMensagem();
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
            /*if (listChats.SelectedItem is ItemAmigo amigo)
            {
                AbrirChatCom(amigo.Id); // Chama AbrirChatCom para carregar as mensagens do amigo selecionado
            }*/
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

        private void flowMensagens_Paint(object sender, PaintEventArgs e)
        {

        }
    }

}
