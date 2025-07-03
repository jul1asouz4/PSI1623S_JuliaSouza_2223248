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
using static System.Net.Mime.MediaTypeNames;

namespace Litly._02
{
    public partial class Login : Form
    {

        private int idUtilizadorLogadoParaLogin;

        public Login(int idLogado)
        {
            InitializeComponent();
            idUtilizadorLogadoParaLogin = idLogado;


        }

        public Login()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connString = "Server=(localdb)\\MSSQLLocalDB;Database=Litly;Trusted_Connection=True;";

            string email = textEmail.Text.Trim();
            string senha = textSenha.Text.Trim();

            if (email == "" || senha == "")
            {
                MessageBox.Show("Preencha todos os campos!", "Aviso", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (Microsoft.Data.SqlClient.SqlConnection conn = new Microsoft.Data.SqlClient.SqlConnection(connString))
            {
                try
                {
                    conn.Open();

                    string query = "SELECT IdUtilizador, Nome FROM Utilizadores WHERE Email = @Email AND PalavraPasse = @PalavraPasse";

                    Microsoft.Data.SqlClient.SqlCommand cmd = new Microsoft.Data.SqlClient.SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@PalavraPasse", senha);

                    Microsoft.Data.SqlClient.SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        Sessao.IdUtilizador = reader.GetInt32(reader.GetOrdinal("IdUtilizador"));
                        Sessao.NomeUtilizador = reader["Nome"].ToString();

                        reader.Close();

                        MessageBox.Show("Login realizado com sucesso!", "Bem-vindo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        
                        PaginaPrincipal principal = new PaginaPrincipal(Sessao.IdUtilizador);
                        principal.Show();
                        this.Hide();
                    }
                    else
                    {
                        reader.Close();
                        MessageBox.Show("Email ou senha incorretos!", "Erro de login", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao tentar conectar ao banco de dados:\\n" + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }


        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Resgistro resgisto = new Resgistro();
            resgisto.Show();
            this.Hide();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Resgistro resgisto = new Resgistro();
            resgisto.Show();
            this.Hide();

        }

        private void linkLabel1_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void Login_Load(object sender, EventArgs e)
        {

        }
    }
}
