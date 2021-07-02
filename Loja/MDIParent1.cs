using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Loja
{
    public partial class MDIParent1 : Form
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

        private int childFormNumber = 0;

        public MDIParent1()
        {
            InitializeComponent();
        }

        private void usuáriosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            /*
             * Chamada da form Cadastro usuario dentro da MDI
             * ou seja, abrir dentro do form principal
             * chama-se a janela filha(childForm) dentro do form principal
             */

            Form childForm = new Cadastro_usuario();
            childForm.MdiParent = this;
            childForm.Show();
        }

        private void menuStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void produtosToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }
    }
}
