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
            CarregarAmigosAceitos();
        }

        private void button3_Click(object sender, EventArgs e) // Abrir chat com respetivos amigos.
        {

        }

        private void btnProcurar_Click(object sender, EventArgs e)
        {
            string termo = textBox1.Text;
            utilizadores.Items.Clear();

            string connString = "Server=(localdb)\\MSSQLLocalDB;Database=Litly;Trusted_Connection=True;";

            using (Microsoft.Data.SqlClient.SqlConnection con = new Microsoft.Data.SqlClient.SqlConnection(connString))
            {
                con.Open();
                Microsoft.Data.SqlClient.SqlCommand cmd = new Microsoft.Data.SqlClient.SqlCommand("SELECT IdUtilizador, Nome FROM Utilizadores WHERE Nome LIKE @termo AND IdUtilizador <> @idLogado", con);
                cmd.Parameters.AddWithValue("@termo", "%" + termo + "%");
                cmd.Parameters.AddWithValue("@idLogado", idUtilizadorLogado); // você já tem esse valor

                Microsoft.Data.SqlClient.SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    utilizadores.Items.Add($"{reader["IdUtilizador"]} - {reader["Nome"]}");
                }
            }
        }

        private void btnSeguir_Click(object sender, EventArgs e)
        {
            if (utilizadores.SelectedItem != null)
            {
                string item = utilizadores.SelectedItem.ToString();
                int idDestino = int.Parse(item.Split('-')[0].Trim());

                string conn = "Server=(localdb)\\MSSQLLocalDB;Database=Litly;Trusted_Connection=True;";
                using (var con = new Microsoft.Data.SqlClient.SqlConnection(conn))
                {
                    con.Open();

                    // Verifica se já existe amizade entre os dois
                    var check = new Microsoft.Data.SqlClient.SqlCommand("SELECT COUNT(*) FROM Amizades WHERE (IdSolicitante = @a AND IdAceito = @b) OR (IdSolicitante = @b AND IdAceito = @a)", con);
                    check.Parameters.AddWithValue("@a", idUtilizadorLogado);
                    check.Parameters.AddWithValue("@b", idDestino);
                    int existe = (int)check.ExecuteScalar();

                    if (existe == 0)
                    {
                        var cmd = new Microsoft.Data.SqlClient.SqlCommand("INSERT INTO Amizades (IdSolicitante, IdAceito, Status) VALUES (@s, @d, 'Pendente')", con);
                        cmd.Parameters.AddWithValue("@s", idUtilizadorLogado);
                        cmd.Parameters.AddWithValue("@d", idDestino);
                        cmd.ExecuteNonQuery();

                        MessageBox.Show("Pedido de amizade enviado!");
                    }
                    else
                    {
                        MessageBox.Show("Já existe um pedido ou amizade com este utilizador.");
                    }
                }
            }
            else
            {
                MessageBox.Show("Selecione um utilizador primeiro.");
            }
        }

        private void CarregarPedidos()
        {
            string conn = "Server=(localdb)\\MSSQLLocalDB;Database=Litly;Trusted_Connection=True;";
            using (var con = new Microsoft.Data.SqlClient.SqlConnection(conn))
            {
                con.Open();
                var cmd = new Microsoft.Data.SqlClient.SqlCommand(@"SELECT u.IdUtilizador, u.Nome FROM Amizades a JOIN Utilizadores u ON u.IdUtilizador = a.IdSolicitante WHERE a.IdAceito = @idAceito AND a.Status = 'Pendente'", con);
                cmd.Parameters.AddWithValue("@idAceito", idUtilizadorLogado);

                using (var reader = cmd.ExecuteReader())
                {
                    Pedidos.Items.Clear();
                    while (reader.Read())
                    {
                        // E aqui, ao ler o dado, também referencie o nome correto da coluna
                        Pedidos.Items.Add($"{reader["IdUtilizador"]} - {reader["Nome"]}");
                    }
                }
            }
        }

        private void btnAceitar_Click(object sender, EventArgs e)
        {
            if (Pedidos.SelectedItem != null)
            {
                string item = Pedidos.SelectedItem.ToString();
                int idSolicitante = int.Parse(item.Split('-')[0].Trim());

                string conn = "Server=(localdb)\\MSSQLLocalDB;Database=Litly;Trusted_Connection=True;";
                using (var con = new Microsoft.Data.SqlClient.SqlConnection(conn))
                {
                    con.Open();
                    var cmd = new Microsoft.Data.SqlClient.SqlCommand("UPDATE Amizades SET Status = 'Aceito' WHERE IdSolicitante = @s AND IdAceito = @a", con);
                    cmd.Parameters.AddWithValue("@s", idSolicitante);
                    cmd.Parameters.AddWithValue("@a", idUtilizadorLogado);
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Amizade aceite!");
                    CarregarPedidos(); // Atualiza lista
                }
            }
        }

        private void btnRecusar_Click(object sender, EventArgs e)
        {
            if (Pedidos.SelectedItem != null)
            {
                string item = Pedidos.SelectedItem.ToString();
                int idSolicitante = int.Parse(item.Split('-')[0].Trim());

                string conn = "Server=(localdb)\\MSSQLLocalDB;Database=Litly;Trusted_Connection=True;";
                using (var con = new Microsoft.Data.SqlClient.SqlConnection(conn))
                {
                    con.Open();
                    var cmd = new Microsoft.Data.SqlClient.SqlCommand("DELETE FROM Amizades WHERE IdSolicitante = @s AND IdAceito = @a", con);
                    cmd.Parameters.AddWithValue("@s", idSolicitante);
                    cmd.Parameters.AddWithValue("@a", idUtilizadorLogado);
                    cmd.ExecuteNonQuery();

                    MessageBox.Show("Pedido recusado.");
                    CarregarPedidos(); // Atualiza lista
                }
            }
        }

        private void frmAmigos_Load(object sender, EventArgs e)
        {


            CarregarPedidos();


        }

        private void btnVoltar_Click(object sender, EventArgs e) //  voltar a pagina principal da Litly
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

        private void Amigos_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void CarregarAmigosAceitos()
        {
            Amigos.Items.Clear();

            string connString = "Server=(localdb)\\MSSQLLocalDB;Database=Litly;Trusted_Connection=True;";

            using (var con = new Microsoft.Data.SqlClient.SqlConnection(connString))
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
                    END
            WHERE (a.IdSolicitante = @IdUtilizadorLogado OR a.IdAceito = @IdUtilizadorLogado)
              AND a.Status = 'Aceite'";

                using (var cmd = new Microsoft.Data.SqlClient.SqlCommand(sql, con))
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
        }

    }

}
