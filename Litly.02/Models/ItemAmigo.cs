using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Litly._02.Models
{
    internal class ItemAmigo
    {

        // Propriedade pública do tipo int chamada Id
        public int Id { get; set; }

        // Propriedade pública do tipo string chamada Nome
        public string Nome { get; set; }


        // Sobrescreve o método ToString() herdado da classe Object
        public override string ToString()
        {

            // Retorna o valor da propriedade Nome
            return Nome;
        }

    }
}
