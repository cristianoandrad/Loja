using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Loja.DTO
{
    /*
    * DTO
    * É a camada em que estão localizados os objetos e as tabelas.
    * Esta camada não faz referência a ninguém
    */

    public class Usuario_DTO
    {
        public int cod_usuario { get; set; }
        public string nome { get; set; }
        public string login { get; set; }
        public string email { get; set; }
        public string senha { get; set; }
        public DateTime cadastro { get; set; }
        public string situacao { get; set; }
        public int perfil { get; set; }


    }
}