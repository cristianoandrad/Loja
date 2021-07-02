using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Loja.DTO;

namespace Loja.DAL
{

    /*
    * DAL
    * Data Access Layer
    * É a camada responsável pelo acesso a dados.
    * Faz referência somente à DTO.
    */

    public class UsuarioDAL
    {
        /*
         * Método cargaUsuario, retorna uma lista de objetos usuarios DTO
         * composto com vários atributos, vai até o BD e busca toso os usuarios
         * Usamos o try catch caso de algum erro, retorna para a camada view
         * executa o método cargaUsuario 
         */

        public IList<Usuario_DTO> cargaUsuario()
        {
            try
            {
                /*Conexão com o banco de dados
                 * Seleciona todos os dados da tabela tb_usuarios
                 */
                SqlConnection con = new SqlConnection();
                con.ConnectionString = Properties.Settings.Default.CST;
                SqlCommand cm = new SqlCommand();
                cm.CommandType = System.Data.CommandType.Text;
                cm.CommandText = "selec * from tb_usuarios";
                cm.Connection = con;

                SqlDataReader er;
                IList<Usuario_DTO> listUsuariosDTO = new List<Usuario_DTO>();

                con.Open();
                er = cm.ExecuteReader();
                if (er.HasRows)
                {
                    while (er.Read())
                    {
                        Usuario_DTO usu = new Usuario_DTO();

                        /* Nome do objeto criado na DTO
                         * Cada objeto criado é enviado para uma lista, possibilitando
                         * que no final voce tenha uma lista com vários usuários
                         */
                        usu.cod_usuario = Convert.ToInt32(er["cod_usuario"]);
                        usu.nome = Convert.ToString(er["nome"]);
                        usu.login = Convert.ToString(er["login"]);
                        usu.email = Convert.ToString(er["email"]);
                        usu.senha = Convert.ToString(er["senha"]);
                        usu.cadastro = Convert.ToDateTime(er["cadastro"]);
                        usu.situacao = Convert.ToString(er["situacao"]);
                        usu.perfil = Convert.ToInt32(er["perfil"]);
                        listUsuariosDTO.Add(usu);
                    }

                }
                return listUsuariosDTO;



            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
