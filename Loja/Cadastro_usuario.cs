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

        }
    }
}
