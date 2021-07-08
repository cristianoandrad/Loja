using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Loja.DTO;
using Loja.BLL;

namespace Loja
{
    /*
     * Responsável pela interação com os usuários. Nessa camada, temos a Interface – Forms.
     * 
     * UI
     * User Interface
     * 
     * É a camada responsável pela interação com os usuários, onde temos a Interface (Forms).
     * Faz referência às camadas BLL e DTO.         
     */
    public partial class Cadastro_usuario : Form
    {
        string modo = "";

        public Cadastro_usuario()
        {
            InitializeComponent();
        }



        private void Cadastro_usuario_Load(object sender, EventArgs e)
        /* Método carregaGrid.
        * Para atualizar os dados do Grid.
        * Basta chamar o método. */
        {
            carregaGrid();
        }
        private void carregaGrid()


        {


            try
            {
                IList<Usuario_DTO> listUsuario_DTO = new List<Usuario_DTO>();
                listUsuario_DTO = new UsuarioBLL().cargaUsuario();

                /*Preencher dados no DataGridView*/
                dataGridView1.DataSource = listUsuario_DTO;

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
<<<<<<< HEAD
            /*Linha atual que estiver selecionada aparecerá nos campos (textbox)
            * acima do dataGrid*/
            int sel = dataGridView1.CurrentRow.Index;
            /*Valor de cada datagrid será enviado ao seu respectivo texbox*/
            txtNome.Text = Convert.ToString(dataGridView1["nome", sel].Value);
            txtLogin.Text = Convert.ToString(dataGridView1["login", sel].Value);
            txtEmail.Text = Convert.ToString(dataGridView1["email", sel].Value);
            txtSenha.Text = Convert.ToString(dataGridView1["senha", sel].Value);
            txtCadastro.Text = Convert.ToString(dataGridView1["cadastro", sel].Value);
            /*Condição se a situação for igual a "A" então o combobox ficará
            * Ativo senao "Inativo" */
            if (Convert.ToString(dataGridView1["situacao", sel].Value) == "A")
            {
                cboSituacao.Text = "Ativo";
            }
            else
            {
                cboSituacao.Text = "Inativo";
                //cboPerfil.Text = Convert.ToString(dataGridView1["perfil", sel].Value);
            }

            switch(Convert.ToString(dataGridView1["perfil", sel].Value))
            {
                /*Caso seja 1, será escolhido Administrados, caso seja 2, operador
                * e caso 3, Gerencial*/
                case "1":
                    cboPerfil.Text = "Administrador";
                    break;
                case "2":
                    cboPerfil.Text = "Operador";
                    break;
                case "3":
                    cboPerfil.Text = "Gerencial";
                    break;
            }

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
=======
>>>>>>> parent of d3714c9 (continua)

        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            /*Chamando Método Limpar Campos que foi criado*/
            limpar_campos();

            /*inserindo data atual automaticamente no txtCadastro*/
            txtCadastro.Text = Convert.ToString(System.DateTime.Now);


            /*após clicar no botão NOVO, modo passa a ser novo (incluindo um registro)*/
            modo = "novo";

        }

        /*Criando Método Limpar Campos, para que todas as vezes em
         * que for necessário limpar nao será necessário repetir o
         * código, apenas chamar o método*/
        private void limpar_campos()
        {
            txtNome.Text = "";
            txtLogin.Text = "";
            txtEmail.Text = "";
            txtSenha.Text = "";
            txtCadastro.Text = "";
            cboPerfil.Text = "";
            cboSituacao.Text = "";
        }

        private void btnConfirmar_Click(object sender, EventArgs e)
        {
            if (modo == "novo")
            {
                /*Tratamento de Erros, exibe msg*/
                try
                {
                    /*Objeto USU*/
                    Usuario_DTO USU = new Usuario_DTO();
                    USU.nome = txtNome.Text;
                    USU.login = txtLogin.Text;
                    USU.email = txtEmail.Text;
                    USU.cadastro = System.DateTime.Now;
                    USU.senha = txtSenha.Text;
                    if (cboSituacao.Text == "Ativo")
                    {
                        USU.situacao = "A";
                    }
                    else
                    {
                        USU.situacao = "I";
                    }
                    switch (cboPerfil.Text)
                    {
                        case "Administrador":
                            USU.perfil = 1;
                            break;
                        case "Operador":
                            USU.perfil = 2;
                            break;
                        case "Gerencial":
                            USU.perfil = 3;
                            break;
                    }


                    /*Método insere usuário na classe UsuarioBLL*/
                    int x = new UsuarioBLL().insereUsuario(USU);
                    if (x > 0)
                    {
                        MessageBox.Show("Gravado com Sucesso!");
                    }

                    /*Recarrega o Grid */
                    carregaGrid();



                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro inesperado" + ex.Message);
                }
            }
            modo = "";
        }

        private void btnEditar_Click(object sender, EventArgs e)
        {
            modo = "alterar";
        }
    }
}
