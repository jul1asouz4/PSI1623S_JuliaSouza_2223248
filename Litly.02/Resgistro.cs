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


            if (email == "" || senha == "")
            {
                MessageBox.Show("Preencha todos os campos!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            string connectionString = "Server=(localdb)\\MSSQLLocalDB;Database=Litly;Trusted_Connection=True;";

            using (Microsoft.Data.SqlClient.SqlConnection conn = new Microsoft.Data.SqlClient.SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();


                    string checkQuery = "SELECT COUNT(*) FROM Utilizadores WHERE email = @Email";
                    using (Microsoft.Data.SqlClient.SqlCommand checkCmd = new Microsoft.Data.SqlClient.SqlCommand(checkQuery, conn))
                    {
                        checkCmd.Parameters.AddWithValue("@Email", email);
                        int count = (int)checkCmd.ExecuteScalar();

                        if (count > 0)
                        {
                            MessageBox.Show("Este email já está registado.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }

                    // Insere novo utilizador
                    string insertQuery = "INSERT INTO Utilizadores (Nome, Email, PalavraPasse) VALUES (@Nome, @Email, @PalavraPasse)";
                    Microsoft.Data.SqlClient.SqlCommand insertCmd = new Microsoft.Data.SqlClient.SqlCommand(insertQuery, conn);
                    insertCmd.Parameters.AddWithValue("@Nome", nome);
                    insertCmd.Parameters.AddWithValue("@Email", email);
                    insertCmd.Parameters.AddWithValue("@PalavraPasse", senha);

                    int result = insertCmd.ExecuteNonQuery();

                    if (result > 0)
                    {
                        // Agora, obtenha o ID do utilizador recém-criado
                        // Método SCOPE_IDENTITY() é recomendado para obter o último ID gerado na sessão atual
                        string selectIdQuery = "SELECT SCOPE_IDENTITY()";
                        Microsoft.Data.SqlClient.SqlCommand selectIdCmd = new Microsoft.Data.SqlClient.SqlCommand(selectIdQuery, conn);
                        int novoIdUtilizador = Convert.ToInt32(selectIdCmd.ExecuteScalar());

                        MessageBox.Show("Registo concluído com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Hide();

                        // Define os dados na classe Sessao para o utilizador recém-registrado
                        Sessao.IdUtilizador = novoIdUtilizador;
                        Sessao.NomeUtilizador = nome;
                        Sessao.EmailUtilizador = email;
                        Sessao.ImagemPerfil = null; // Ou defina uma imagem padrão

                        // Abre a PaginaPrincipal com o ID do NOVO utilizador
                        PaginaPrincipal principalRe = new PaginaPrincipal(novoIdUtilizador);
                        principalRe.Show();
                        // this.Close(); // Pode ser this.Close() em vez de this.Hide() se quiser fechar completamente
                    }
                    else
                    {
                        MessageBox.Show("Erro ao efetuar o registo.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private int ObterIdNovoUtilizador(string email)
        {
            string connString = "Server=(localdb)\\MSSQLLocalDB;Database=Litly;Trusted_Connection=True;";
            using (Microsoft.Data.SqlClient.SqlConnection conn = new Microsoft.Data.SqlClient.SqlConnection(connString))
            {
                conn.Open();
                string query = "SELECT IdUtilizador FROM Utilizadores WHERE Email = @Email";
                using (Microsoft.Data.SqlClient.SqlCommand cmd = new Microsoft.Data.SqlClient.SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@Email", email);
                    object result = cmd.ExecuteScalar();
                    if (result != null)
                    {
                        return Convert.ToInt32(result);
                    }
                }
            }
            return -1; // Ou lance uma exceção, ou retorne 0
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Hide();
        }
    }
}
