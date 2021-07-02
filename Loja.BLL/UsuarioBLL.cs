using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Loja.DAL;
using Loja.DTO;

namespace Loja.BLL
{
    /*
        * BLL
        * Business Logic Layer
        * É chamada de camada das regras de negócio (lógica da aplicação, cálculos etc).
        * Faz referência às camadas DAL e DTO.
        */
    public class UsuarioBLL
    {
        /*
         * Método cargaUsuario, retorna uma lista de objetos usuariosDTO
         * compostos por vários atributos, vai até o BD e busca todos os usuários
         * Usamos o try cacth caso dê algum erro, retorna a chamada para a view
         * executa o método cargaUsuario da DAL
         */

        public IList<Usuario_DTO> cargaUsuario()
        {
            try
            {
                return new UsuarioDAL().cargaUsuario();
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
