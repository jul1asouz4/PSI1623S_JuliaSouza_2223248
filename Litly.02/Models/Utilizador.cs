using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Litly._02.Models
{
    internal class Utilizador : Form
    {




        public class Utilizadores
        {
            public string Nome { get; set; }
            public string Bio { get; set; }
            public string Email { get; set; }

            public override string ToString()
            {
                return $"Utilizador: {Nome}";
            }
        }



    }
}
