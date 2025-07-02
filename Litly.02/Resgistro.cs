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
using Litly._02;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;


namespace Litly._02
{
    public partial class Resgistro : Form
    {
       
        
        public Resgistro()
        {
            InitializeComponent();
            
        }

        private void Resgistro_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

            string nome = textNome.Text.Trim();
            string email = textEmail.Text.Trim();
            string senha = textSenha.Text.Trim();

            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(senha))
            {
                MessageBox.Show("Preencha todos os campos!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string connectionString = "Server=(localdb)\\MSSQLLocalDB;Database=Litly;Trusted_Connection=True;";

            using (var conn = new Microsoft.Data.SqlClient.SqlConnection(connectionString))
            {
                conn.Open();
                var transaction = conn.BeginTransaction();

                try
                {
                    // Verifica se o email já está registado
                    string checkQuery = "SELECT COUNT(*) FROM Utilizadores WHERE Email = @Email";
                    using (var checkCmd = new Microsoft.Data.SqlClient.SqlCommand(checkQuery, conn, transaction))
                    {
                        checkCmd.Parameters.AddWithValue("@Email", email);
                        int count = (int)checkCmd.ExecuteScalar();
                        if (count > 0)
                        {
                            MessageBox.Show("Este email já está registado.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            transaction.Rollback();
                            return;
                        }
                    }

                    // Inserção com OUTPUT
                    string insertQuery = @"
                INSERT INTO Utilizadores (Nome, Email, PalavraPasse)
                OUTPUT INSERTED.IdUtilizador
                VALUES (@Nome, @Email, @PalavraPasse)";

                    using (var insertCmd = new Microsoft.Data.SqlClient.SqlCommand(insertQuery, conn, transaction))
                    {
                        insertCmd.Parameters.AddWithValue("@Nome", nome);
                        insertCmd.Parameters.AddWithValue("@Email", email);
                        insertCmd.Parameters.AddWithValue("@PalavraPasse", senha);

                        object resultId = insertCmd.ExecuteScalar();

                        if (resultId != null && resultId != DBNull.Value)
                        {
                            int novoIdUtilizador = Convert.ToInt32(resultId);
                            transaction.Commit();

                            // Sessão e redirecionamento
                            Sessao.IdUtilizador = novoIdUtilizador;
                            Sessao.NomeUtilizador = nome;
                            Sessao.EmailUtilizador = email;
                            Sessao.ImagemPerfil = null;

                            this.Hide();
                            PaginaPrincipal principal = new PaginaPrincipal(novoIdUtilizador);
                            principal.Show();
                            this.Close();
                        }
                        else
                        {
                            transaction.Rollback();
                            MessageBox.Show("Erro ao obter ID do utilizador.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
                catch (Exception ex)
                {
                    try { transaction.Rollback(); } catch { }
                    MessageBox.Show("Erro inesperado: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private int ObterIdNovoUtilizador(string email)
        {
            string connString = "Server=(localdb)\\MSSQLLocalDB;Database=Litly;Trusted_Connection=True;";
            using (SqlConnection conn = new SqlConnection(connString))
            {
                conn.Open();
                string query = "SELECT IdUtilizador FROM Utilizadores WHERE Email = @Email";
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Email", email);
                    object result = cmd.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                    {
                        return Convert.ToInt32(result);
                    }
                }
            }
            return -1;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Hide();
        }
    }
}
