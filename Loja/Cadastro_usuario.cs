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
        public Cadastro_usuario()
        {
            InitializeComponent();
        }

        private void Cadastro_usuario_Load(object sender, EventArgs e)
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
                cboPerfil.Text = Convert.ToString(dataGridView1["perfil", sel].Value);
            }

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
