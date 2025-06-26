using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Litly._02.Models; // Esta linha agora será correta
using Litly._02.DAL;


namespace Litly._02
{
    internal class Sessao
    {

        public static int IdUtilizador { get; set; } = 0; // Ou -1, dependendo do que indica "não logado"
        public static string NomeUtilizador { get; set; } = string.Empty; // <<<< Mude AQUI
        public static string EmailUtilizador { get; set; } = string.Empty; // <<<< E AQUI
        public static Image? ImagemPerfil { get; set; }
        static Sessao()
        {
            IdUtilizador = 0; // Valor padrão
            NomeUtilizador = string.Empty; // Valor padrão
            EmailUtilizador = string.Empty; // Valor padrão
            ImagemPerfil = null; // Valor padrão
        }

    }
}
