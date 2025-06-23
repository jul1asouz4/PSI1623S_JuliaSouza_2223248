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


namespace Litly._02
{
    public partial class Form1 : Form
    {
        // Variável para armazenar o ID do utilizador logado
        int idUtilizadorLogado;

        public Form1()
        {
            InitializeComponent();
        }

        // Construtor sobrecarregado que recebe o ID do utilizador logado
        public Form1(int idLogado)
        {
            InitializeComponent(); // Inicializa os componentes do formulário
            idUtilizadorLogado = idLogado; // Armazena o ID do utilizador logado
        }

        // Evento do botão1 
        private void button1_Click(object sender, EventArgs e)
        {
            Login login = new Login(); 
            login.Show();
            this.Hide();
        }

        // Evento que ocorre quando o formulário é carregado (está vazio por enquanto)
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        // Evento do botão2 (por exemplo, botão "Sair")
        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }
    }
}
