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
    public partial class PerfilUtilizador : Form
    {

        private string nomeUtilizador;
        public PerfilUtilizador(string nome, string email, string bio)
        {
            InitializeComponent();
            // Exibe os dados nos controles (por exemplo, labels)
            lblNome.Text = nome;
            lblEmail.Text = email;
            txtBio.Text = bio;
        }



        private void PerfilUtilizador_Load(object sender, EventArgs e)
        {
            lblNome.Text = nomeUtilizador;
        }

        private void IblNome_Click(object sender, EventArgs e)
        {

        }
    }
}
