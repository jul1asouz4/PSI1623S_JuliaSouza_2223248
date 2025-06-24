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
    public partial class frmAmigos : Form
    {
        private int idUtilizadorLogado;
        public frmAmigos(int idLogado)
        {
            InitializeComponent();
            this.idUtilizadorLogado = idLogado;
            CarregarAmigosAceitos(); // Carrega a lista de amigos aceitos
            CarregarPedidos(); // Carrega a lista de pedidos pendentes
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

        private void button3_Click(object sender, EventArgs e) // Abrir chat com respetivos amigos.
        {
            if (Amigos.SelectedItem != null)
            {
                if (Amigos.SelectedItem is ItemAmigo amigoSelecionado)
                {
                    this.Hide(); // Oculta o formulário atual de amigos

                    // Cria uma nova instância do FormChat com o ID do utilizador logado
                    // e o ID do amigo selecionado.
                    FormChat chat = new FormChat(idUtilizadorLogado, amigoSelecionado.Id);
                    chat.Show();

                    this.Close(); // Fecha o formulário frmAmigos
                }
                else
                {
                    MessageBox.Show("O item selecionado não é um amigo válido. Reinicie o formulário.", "Erro de Seleção", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Selecione um amigo na lista para abrir o chat.", "Nenhum Amigo Selecionado", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnProcurar_Click(object sender, EventArgs e)
        {
            string termo = textBox1.Text.Trim(); // Usa Trim para remover espaços em branco
            utilizadores.Items.Clear();

            if (string.IsNullOrWhiteSpace(termo))
            {
                MessageBox.Show("Digite um nome para procurar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string connString = "Server=(localdb)\\MSSQLLocalDB;Database=Litly;Trusted_Connection=True;";

            using (Microsoft.Data.SqlClient.SqlConnection con = new Microsoft.Data.SqlClient.SqlConnection(connString)) // Usar SqlConnection diretamente
            {
                try
                {
                    con.Open();
                    Microsoft.Data.SqlClient.SqlCommand cmd = new Microsoft.Data.SqlClient.SqlCommand("SELECT IdUtilizador, Nome FROM Utilizadores WHERE Nome LIKE @termo AND IdUtilizador <> @idLogado", con);
                    cmd.Parameters.AddWithValue("@termo", "%" + termo + "%");
                    cmd.Parameters.AddWithValue("@idLogado", idUtilizadorLogado);

                    Microsoft.Data.SqlClient.SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        // Adiciona ItemAmigo para facilitar o acesso ao ID depois
                        utilizadores.Items.Add(new ItemAmigo
                        {
                            Nome = reader["Nome"].ToString(),
                            Id = (int)reader["IdUtilizador"]
                        });
                    }
                    reader.Close();

                    if (utilizadores.Items.Count == 0)
                    {
                        MessageBox.Show("Nenhum utilizador encontrado com este nome.", "Pesquisa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao procurar utilizadores: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnSeguir_Click(object sender, EventArgs e)
        {
            if (utilizadores.SelectedItem != null)
            {
                // Certifica-se de que o item selecionado é do tipo ItemAmigo
                if (utilizadores.SelectedItem is ItemAmigo utilizadorParaSeguir)
                {
                    int idDestino = utilizadorParaSeguir.Id;

                    string conn = "Server=(localdb)\\MSSQLLocalDB;Database=Litly;Trusted_Connection=True;";
                    using (var con = new Microsoft.Data.SqlClient.SqlConnection(conn)) // Usar SqlConnection diretamente
                    {
                        try
                        {
                            con.Open();

                            // Verifica se já existe amizade ou pedido pendente entre os dois
                            var check = new Microsoft.Data.SqlClient.SqlCommand("SELECT Status FROM Amizades WHERE (IdSolicitante = @a AND IdAceito = @b) OR (IdSolicitante = @b AND IdAceito = @a)", con);
                            check.Parameters.AddWithValue("@a", idUtilizadorLogado);
                            check.Parameters.AddWithValue("@b", idDestino);
                            object result = check.ExecuteScalar();

                            if (result == null) // Não existe amizade ou pedido
                            {
                                var cmd = new Microsoft.Data.SqlClient.SqlCommand("INSERT INTO Amizades (IdSolicitante, IdAceito, Status) VALUES (@s, @d, 'Pendente')", con);
                                cmd.Parameters.AddWithValue("@s", idUtilizadorLogado);
                                cmd.Parameters.AddWithValue("@d", idDestino);
                                cmd.ExecuteNonQuery();

                                MessageBox.Show("Pedido de amizade enviado com sucesso!");
                                CarregarPedidos(); // Atualiza a lista de pedidos para ver se o seu próprio pedido aparece como pendente
                            }
                            else
                            {
                                string statusExistente = result.ToString();
                                if (statusExistente == "Pendente")
                                {
                                    MessageBox.Show("Já existe um pedido de amizade pendente com este utilizador.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                }
                                else if (statusExistente == "Aceite")
                                {
                                    MessageBox.Show("Você já é amigo deste utilizador.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Erro ao enviar pedido de amizade: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Item selecionado inválido. Tente novamente.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Selecione um utilizador primeiro para enviar o pedido.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void CarregarPedidos()
        {
            string conn = "Server=(localdb)\\MSSQLLocalDB;Database=Litly;Trusted_Connection=True;";
            using (var con = new Microsoft.Data.SqlClient.SqlConnection(conn)) // Usar SqlConnection diretamente
            {
                con.Open();
                var cmd = new Microsoft.Data.SqlClient.SqlCommand(@"SELECT u.IdUtilizador, u.Nome FROM Amizades a JOIN Utilizadores u ON u.IdUtilizador = a.IdSolicitante WHERE a.IdAceito = @idAceito AND a.Status = 'Pendente'", con);
                cmd.Parameters.AddWithValue("@idAceito", idUtilizadorLogado);

                using (var reader = cmd.ExecuteReader())
                {
                    Pedidos.Items.Clear();
                    while (reader.Read())
                    {
                        Pedidos.Items.Add(new ItemAmigo // Adiciona ItemAmigo para facilitar o aceite/recusa
                        {
                            Nome = reader["Nome"].ToString(),
                            Id = (int)reader["IdUtilizador"]
                        });
                    }
                }
            }
        }

        private void btnAceitar_Click(object sender, EventArgs e)
        {
            if (Pedidos.SelectedItem != null)
            {
                if (Pedidos.SelectedItem is ItemAmigo solicitante)
                {
                    int idSolicitante = solicitante.Id;

                    string conn = "Server=(localdb)\\MSSQLLocalDB;Database=Litly;Trusted_Connection=True;";
                    using (var con = new Microsoft.Data.SqlClient.SqlConnection(conn)) // Usar SqlConnection diretamente
                    {
                        try
                        {
                            con.Open();
                            var cmd = new Microsoft.Data.SqlClient.SqlCommand("UPDATE Amizades SET Status = 'Aceite' WHERE IdSolicitante = @s AND IdAceito = @a", con);
                            cmd.Parameters.AddWithValue("@s", idSolicitante);
                            cmd.Parameters.AddWithValue("@a", idUtilizadorLogado);
                            cmd.ExecuteNonQuery();

                            MessageBox.Show("Amizade aceite com sucesso!");
                            CarregarPedidos(); // Atualiza a lista de pedidos (para remover o aceite)
                            CarregarAmigosAceitos(); // Atualiza a lista de amigos aceitos
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Erro ao aceitar amizade: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Item selecionado inválido. Tente novamente.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Selecione um pedido para aceitar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnRecusar_Click(object sender, EventArgs e)
        {
            if (Pedidos.SelectedItem != null)
            {
                if (Pedidos.SelectedItem is ItemAmigo solicitante)
                {
                    int idSolicitante = solicitante.Id;

                    string conn = "Server=(localdb)\\MSSQLLocalDB;Database=Litly;Trusted_Connection=True;";
                    using (var con = new Microsoft.Data.SqlClient.SqlConnection(conn)) // Usar SqlConnection diretamente
                    {
                        try
                        {
                            con.Open();
                            var cmd = new Microsoft.Data.SqlClient.SqlCommand("DELETE FROM Amizades WHERE IdSolicitante = @s AND IdAceito = @a", con);
                            cmd.Parameters.AddWithValue("@s", idSolicitante);
                            cmd.Parameters.AddWithValue("@a", idUtilizadorLogado);
                            cmd.ExecuteNonQuery();

                            MessageBox.Show("Pedido recusado com sucesso.");
                            CarregarPedidos(); // Atualiza a lista de pedidos
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Erro ao recusar pedido: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Item selecionado inválido. Tente novamente.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Selecione um pedido para recusar.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void frmAmigos_Load(object sender, EventArgs e)
        {


            //CarregarPedidos();


        }

        private void btnVoltar_Click(object sender, EventArgs e) //  voltar a pagina principal da Litly
        {
            this.Hide();
            PaginaPrincipal principal = new PaginaPrincipal(Sessao.IdUtilizador);
            principal.Show();
            this.Close();
        }

        private void Amigos_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void CarregarAmigosAceitos()
        {
            Amigos.Items.Clear();

            string connString = "Server=(localdb)\\MSSQLLocalDB;Database=Litly;Trusted_Connection=True;";

            using (var con = new Microsoft.Data.SqlClient.SqlConnection(connString)) // Usar SqlConnection diretamente
            {
                try
                {
                    con.Open();

                    string sql = @"
                        SELECT u.IdUtilizador, u.Nome
                        FROM Amizades a
                        JOIN Utilizadores u ON
                            u.IdUtilizador =
                                CASE
                                    WHEN a.IdSolicitante = @IdUtilizadorLogado THEN a.IdAceito
                                    WHEN a.IdAceito = @IdUtilizadorLogado THEN a.IdSolicitante
                                    ELSE NULL
                                END
                        WHERE (a.IdSolicitante = @IdUtilizadorLogado OR a.IdAceito = @IdUtilizadorLogado)
                          AND a.Status = 'Aceite'";

                    using (var cmd = new Microsoft.Data.SqlClient.SqlCommand(sql, con)) // Usar SqlCommand diretamente
                    {
                        cmd.Parameters.AddWithValue("@IdUtilizadorLogado", idUtilizadorLogado);

                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Amigos.Items.Add(new ItemAmigo
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
                    MessageBox.Show("Erro ao carregar amigos aceites: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnRemover_Click(object sender, EventArgs e)
        {
            if (Amigos.SelectedItem is ItemAmigo amigoParaRemover)
            {
                DialogResult dialogResult = MessageBox.Show($"Tem certeza que deseja remover {amigoParaRemover.Nome} da sua lista de amigos?", "Confirmar Remoção", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes)
                {
                    string conn = "Server=(localdb)\\MSSQLLocalDB;Database=Litly;Trusted_Connection=True;";
                    using (var con = new Microsoft.Data.SqlClient.SqlConnection(conn))
                    {
                        try
                        {
                            con.Open();
                            // Remove a amizade independentemente de quem solicitou ou aceitou
                            string sql = "DELETE FROM Amizades WHERE (IdSolicitante = @idLogado AND IdAceito = @idAmigo) OR (IdSolicitante = @idAmigo AND IdAceito = @idLogado)";
                            using (var cmd = new Microsoft.Data.SqlClient.SqlCommand(sql, con))
                            {
                                cmd.Parameters.AddWithValue("@idLogado", idUtilizadorLogado);
                                cmd.Parameters.AddWithValue("@idAmigo", amigoParaRemover.Id);
                                int rowsAffected = cmd.ExecuteNonQuery();
                                if (rowsAffected > 0)
                                {
                                    MessageBox.Show($"{amigoParaRemover.Nome} foi removido da sua lista de amigos.", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    CarregarAmigosAceitos(); // Atualiza a lista após a remoção
                                }
                                else
                                {
                                    MessageBox.Show("Não foi possível remover o amigo.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Erro ao remover amigo: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Selecione um amigo para remover.", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }

}
