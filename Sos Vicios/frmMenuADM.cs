using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sos_Vicios
{

    public partial class frmMenuADM : Form
    {

        const int MF_BYCOMMAND = 0X400;
        [DllImport("user32")]
        static extern int RemoveMenu(IntPtr hMenu, int nPosition, int wFlags);
        [DllImport("user32")]
        static extern IntPtr GetSystemMenu(IntPtr hWnd, bool bRevert);
        [DllImport("user32")]
        static extern int GetMenuItemCount(IntPtr hWnd);

        public frmMenuADM()
        {
            InitializeComponent();
        }
        private void frmMenuADM_Load(object sender, EventArgs e)
        {
            IntPtr hMenu = GetSystemMenu(this.Handle, false);
            int MenuCount = GetMenuItemCount(hMenu) - 1;
            RemoveMenu(hMenu, MenuCount, MF_BYCOMMAND);
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            frmMenu abrir = new frmMenu();
            abrir.Show();
            this.Hide();
        }

        private void btncadastrafuncionario_Click(object sender, EventArgs e)
        {
            frmfuncionario abrir = new frmfuncionario();
            abrir.Show();
            this.Hide();
        }

        private void btncadastrausuario_Click(object sender, EventArgs e)
        {
            frmUsuario abrir = new frmUsuario();
            abrir.Show();
            this.Hide();
        }


    }
}
