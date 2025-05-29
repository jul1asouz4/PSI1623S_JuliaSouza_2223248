using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
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


            using (SqlConnection conn = new SqlConnection(connString))
            {

                try
                {

                    conn.Open();

                   // Sessao.IdUtilizador = reader.GetInt32(0);
                    string query = "SELECT COUNT(*) FROM Utilizadores WHERE Email = @Email AND PalavraPasse = @PalavraPasse";
                    SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@PalavraPasse", senha);

                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        Sessao.IdUtilizador = reader.GetInt32(0); // <-- muito importante!
                        reader.Close();


                        MessageBox.Show("Login realizado com sucesso!", "Bem-vindo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Hide();
                        PaginaPrincipal principal = new PaginaPrincipal();
                        principal.Show();                            // ...
                    }else
                    {
                        reader.Close(); // <-- também fecha aqui
                        MessageBox.Show("Email ou senha incorretos!", "Erro de login", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }


                   /* int count = (int)cmd.ExecuteScalar();

                    if (count > 0)
                    {
                        MessageBox.Show("Login realizado com sucesso!", "Bem-vindo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Hide();
                        PaginaPrincipal principal = new PaginaPrincipal();
                        principal.Show();

                    }
                    else
                    {
                        MessageBox.Show("Email ou senha incorretos!", "Erro de login", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }*/
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao conectar com o banco: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);

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
    }
}
