using MySqlConnector;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace Sos_Vicios
{
    public partial class frmLogin : Form
    {
        const int MF_BYCOMMAND = 0X400;
        [DllImport("user32")]
        static extern int RemoveMenu(IntPtr hMenu, int nPosition, int wFlags);
        [DllImport("user32")]
        static extern IntPtr GetSystemMenu(IntPtr hWnd, bool bRevert);
        [DllImport("user32")]
        static extern int GetMenuItemCount(IntPtr hWnd);

        public frmLogin()
        {
            InitializeComponent();
        }
        private void frmLogin_Load_1(object sender, EventArgs e)
        {
            IntPtr hMenu = GetSystemMenu(this.Handle, false);
            int MenuCount = GetMenuItemCount(hMenu) - 1;
            RemoveMenu(hMenu, MenuCount, MF_BYCOMMAND);
        }


        private bool entrar = false;

        private void btnEntrar_Click(object sender, EventArgs e)
        {
            entrar = AcessoSistema();

            if (entrar)
            {
                frmMenu abrir = new frmMenu();
                abrir.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Usuário ou senha incorretos", "Mensagem do sistema", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);

            }
        }
            bool AcessoSistema()
            {
                bool resultado = false;
                Conexao.conectar();
                MySqlCommand comm = new MySqlCommand();
                comm.CommandText = "SELECT * FROM tbusuarios WHERE nome='" + txtUsuario.Text + "'AND senha = '" + txtSenha.Text + "'";
                comm.CommandType = CommandType.Text;
                comm.Connection = Conexao.conectar();
                MySqlDataReader DR;
                DR = comm.ExecuteReader();
                resultado = DR.HasRows;
                Conexao.desconectar();
                return resultado;
            }

        

        private void btnSair_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
