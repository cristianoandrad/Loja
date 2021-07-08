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
        public class UsuarioBLL
        {
            /*Método cargaUsuario, retorna uma Lista de objetos usuario DTO
            (composto por vários atributos), vai até o BD e
            buscar todos os usuários.
            Usamos o try e Catch caso de algum erro, retorna para a camada view
            Executar o método cargaUsuario (será criado na DAL)
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
            public int insereUsuario(Usuario_DTO USU)
            {
                /*Insere usuario será criado na DAL*/
                try
                {
                    return new UsuarioDAL().insereUsuario(USU);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            public int alteraUsuario(Usuario_DTO USU)
            {
                try
                {
                    return new UsuarioDAL().alteraUsuario(USU);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
            public int excluiUsuario(Usuario_DTO USU)
            {
                try
                {
                    return new UsuarioDAL().excluiUsuario(USU);
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }
}
