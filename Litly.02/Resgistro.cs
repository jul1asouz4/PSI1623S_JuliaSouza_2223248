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


            if (string.IsNullOrEmpty(email) || string.IsNullOrEmpty(senha)) // Usar String.IsNullOrEmpty para melhor prática
            {
                MessageBox.Show("Preencha todos os campos!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            string connectionString = "Server=(localdb)\\MSSQLLocalDB;Database=Litly;Trusted_Connection=True;";

            using (Microsoft.Data.SqlClient.SqlConnection conn = new Microsoft.Data.SqlClient.SqlConnection(connectionString)) // Usar SqlConnection diretamente
            {
                try
                {
                    conn.Open();


                    string checkQuery = "SELECT COUNT(*) FROM Utilizadores WHERE email = @Email";
                    using (Microsoft.Data.SqlClient.SqlCommand checkCmd = new Microsoft.Data.SqlClient.SqlCommand(checkQuery, conn)) // Usar SqlCommand diretamente
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
                    Microsoft.Data.SqlClient.SqlCommand insertCmd = new Microsoft.Data.SqlClient.SqlCommand(insertQuery, conn); // Usar SqlCommand diretamente
                    insertCmd.Parameters.AddWithValue("@Nome", nome);
                    insertCmd.Parameters.AddWithValue("@Email", email);
                    insertCmd.Parameters.AddWithValue("@PalavraPasse", senha);

                    int result = insertCmd.ExecuteNonQuery();

                    if (result > 0)
                    {
                        // Agora, obtenha o ID do utilizador recém-criado
                        string selectIdQuery = "SELECT SCOPE_IDENTITY()"; 
                        Microsoft.Data.SqlClient.SqlCommand selectIdCmd = new Microsoft.Data.SqlClient.SqlCommand(selectIdQuery, conn); // Usar SqlCommand diretamente

                        object resultId = selectIdCmd.ExecuteScalar(); // Obter o resultado como 'object'

                        int novoIdUtilizador;

                        // VERIFICAÇÃO DE DBNULL AQUI:
                        if (resultId != null && resultId != DBNull.Value)
                        {
                            novoIdUtilizador = Convert.ToInt32(resultId);

                            // Opcional: MessageBox.Show("Registo concluído com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information); // Removido para evitar MessageBox extra no fluxo de login/registo
                            this.Hide();

                            // Define os dados na classe Sessao para o utilizador recém-registrado
                            Sessao.IdUtilizador = novoIdUtilizador;
                            Sessao.NomeUtilizador = nome;
                            Sessao.EmailUtilizador = email;
                            Sessao.ImagemPerfil = null; // Ou defina uma imagem padrão

                            // Abre a PaginaPrincipal com o ID do NOVO utilizador
                            PaginaPrincipal principalRe = new PaginaPrincipal(novoIdUtilizador);
                            principalRe.Show();
                            this.Close(); // Fecha o formulário de registo após o sucesso
                        }
                        else
                        {
                            // Lida com o cenário em que SCOPE_IDENTITY() não retornou um valor válido
                            MessageBox.Show("Erro: Não foi possível obter o ID do utilizador recém-registado. Verifique a configuração da tabela de utilizadores (coluna IdUtilizador deve ser IDENTITY).", "Erro de Registo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            // Pode optar por não esconder o formulário e permitir que o utilizador tente novamente
                        }
                    }
                    else
                    {
                        MessageBox.Show("Erro ao efetuar o registo. Nenhuma linha foi afetada.", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
