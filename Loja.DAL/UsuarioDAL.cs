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
                /*Conexão com BD
                Seleciona todos os dados da tb_usuarios*/
                SqlConnection CON = new SqlConnection();
                CON.ConnectionString = Properties.Settings.Default.CST;
                SqlCommand CM = new SqlCommand();
                CM.CommandType = System.Data.CommandType.Text;
                CM.CommandText = "SELECT*FROM tb_usuarios";
                CM.Connection = CON;
                SqlDataReader ER;
                IList<Usuario_DTO> listUsuarioDTO = new List<Usuario_DTO>();
                CON.Open();
                ER = CM.ExecuteReader();
                if (ER.HasRows)
                {
                    while (ER.Read())
                    {
                        Usuario_DTO usu = new Usuario_DTO();
                        /*nome dos objetos criados na DTO
                        Cada objetos criado é enviado para a lista, possbilitando que no final
                        vc tenha uma lista com
                        vários usuarios*/
                        usu.cod_usuario = Convert.ToInt32(ER["cod_usuario"]);
                        usu.perfil = Convert.ToInt32(ER["perfil"]);
                        usu.cadastro = Convert.ToDateTime(ER["cadastro"]);
                        usu.nome = Convert.ToString(ER["nome"]);
                        usu.email = Convert.ToString(ER["email"]);
                        usu.login = Convert.ToString(ER["cadastro"]);
                        usu.senha = Convert.ToString(ER["senha"]);
                        usu.situacao = Convert.ToString(ER["situacao"]);
                        listUsuarioDTO.Add(usu);
                    }
                }
                return listUsuarioDTO;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public int insereUsuario(Usuario_DTO USU)
        {
            try
            {
                /*Conexão com BD
                Inserindo dados na tb_usuarios*/
                SqlConnection CON = new SqlConnection();
                CON.ConnectionString = Properties.Settings.Default.CST;
                SqlCommand CM = new SqlCommand();
                CM.CommandType = System.Data.CommandType.Text;
                CM.CommandText = "INSERT INTO tb_usuarios (nome, login, email, senha, cadastro, situacao, perfil)" +
                " VALUES (@nome, @login,@email, @senha, @cadastro, @situacao, @perfil)";
                /*Para cada campo citado acima são colocados os valores*/
                /*Parameters irá substituir os valores dentro do campo*/
                CM.Parameters.Add("nome", System.Data.SqlDbType.VarChar).Value = USU.nome;
                CM.Parameters.Add("login", System.Data.SqlDbType.VarChar).Value = USU.login;
                CM.Parameters.Add("email", System.Data.SqlDbType.VarChar).Value = USU.email;
                CM.Parameters.Add("senha", System.Data.SqlDbType.VarChar).Value = USU.senha;
                CM.Parameters.Add("cadastro", System.Data.SqlDbType.DateTime).Value =
                USU.cadastro;
                CM.Parameters.Add("situacao", System.Data.SqlDbType.VarChar).Value =
                USU.situacao;
                CM.Parameters.Add("perfil", System.Data.SqlDbType.Int).Value = USU.perfil;
                CM.Connection = CON;
                CON.Open();
                int qtd = CM.ExecuteNonQuery();
                return qtd;
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
                SqlConnection CON = new SqlConnection();
                CON.ConnectionString = Properties.Settings.Default.CST;
                SqlCommand CM = new SqlCommand();
                CM.CommandType = System.Data.CommandType.Text;
                /*Atenção ao nome dos campos que deve ser igual ao Banco de Dados*/
                CM.CommandText = "UPDATE tb_usuarios SET perfil=@perfil, " +
                "nome= @nome, " +
                "login=@login, " +
                "email=@email, " +
                "senha=@senha, " +
                "cadastro=@cadastro, " +
                "situacao=@situacao " +
                "WHERE cod_usuario = @cod_usuario";
                /*Parameters irá substituir os valores dentro do campo*/
                CM.Parameters.Add("perfil", System.Data.SqlDbType.Int).Value = USU.perfil;
                CM.Parameters.Add("nome", System.Data.SqlDbType.VarChar).Value = USU.nome;
                CM.Parameters.Add("login", System.Data.SqlDbType.VarChar).Value = USU.login;
                CM.Parameters.Add("email", System.Data.SqlDbType.VarChar).Value = USU.email;
                CM.Parameters.Add("senha", System.Data.SqlDbType.VarChar).Value = USU.senha;
                CM.Parameters.Add("cadastro", System.Data.SqlDbType.DateTime).Value =
                USU.cadastro;
                CM.Parameters.Add("situacao", System.Data.SqlDbType.VarChar).Value =
                USU.situacao;
                CM.Parameters.Add("cod_usuario", System.Data.SqlDbType.VarChar).Value =
                USU.situacao;
                CM.Connection = CON;
                /*Abre conexão*/
                CON.Open();
                int qtd = CM.ExecuteNonQuery();
                return qtd;
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
                /*Excluindo dados na tb_usuarios*/
                SqlConnection CON = new SqlConnection();
                CON.ConnectionString = Properties.Settings.Default.CST;
                SqlCommand CM = new SqlCommand();
                CM.CommandType = System.Data.CommandType.Text;
                CM.CommandText = "DELETE tb_usuarios WHERE cod_usuario = @cod_usuario";
                /*tem um unico parametro que será o código do usuario, só existe um*/
                CM.Parameters.Add("cod_usuario", System.Data.SqlDbType.Int).Value =
                USU.cod_usuario;
                CM.Connection = CON;
                CON.Open();
                int qtd = CM.ExecuteNonQuery();
                /*retorna registros afetados*/
                return qtd;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
    }
