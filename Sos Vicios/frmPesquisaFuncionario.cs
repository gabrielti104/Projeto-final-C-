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
using MySqlConnector;

namespace Sos_Vicios
{
    public partial class frmPesquisaFuncionario : Form
    {
        const int MF_BYCOMMAND = 0X400;
        [DllImport("user32")]
        static extern int RemoveMenu(IntPtr hMenu, int nPosition, int wFlags);
        [DllImport("user32")]
        static extern IntPtr GetSystemMenu(IntPtr hWnd, bool bRevert);
        [DllImport("user32")]
        static extern int GetMenuItemCount(IntPtr hWnd);

        public frmPesquisaFuncionario()
        {
            InitializeComponent();
            Conexao.conectar();
        }

        private void frmPesquisaFuncionario_Load(object sender, EventArgs e)
        {
            IntPtr hMenu = GetSystemMenu(this.Handle, false);
            int MenuCount = GetMenuItemCount(hMenu) - 1;
            RemoveMenu(hMenu, MenuCount, MF_BYCOMMAND);
        }

        private void btnPesquisar_Click_1(object sender, EventArgs e)
        {
            if (rdbNome.Checked == false && rdbid.Checked == false)
            {
                MessageBox.Show("Favor selecionar um item!!!",
                    "Mensagem do sistema",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error,
                    MessageBoxDefaultButton.Button1);
            }

            else if (rdbNome.Checked && txtDescricao.Text != string.Empty)
            {
                pesquisaPorNome();
            }
            else if (rdbid.Checked)
            {
                pesquisaPorid();

            }
            else
            {
                MessageBox.Show("Digite um nome válido!!!",
                "Mensagem do sistema",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error,
                MessageBoxDefaultButton.Button1);
            }
        }

        public void pesquisaPorNome()
        {
            MySqlCommand comm = new MySqlCommand();
            comm.CommandText = "select * from tbFuncionarios where nome like '%" + txtDescricao.Text + "%'";
            comm.CommandType = CommandType.Text;
            comm.Connection = Conexao.conectar();

            MySqlDataReader dr;
            try
            {
                dr = comm.ExecuteReader();

                lstInformacoes.Items.Clear();

                while (dr.Read())
                {
                    lstInformacoes.Items.Add(dr.GetString(1));
                }

                Conexao.desconectar();
            }
            catch (Exception)
            {
                MessageBox.Show("Conectar banco de dados!!!",
                    "Mensagem do sistema",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error,
                    MessageBoxDefaultButton.Button1);
                limparCampos();
            }
        }

        public static string dados = "";

        public void pesquisaPorid()
        {
            MySqlCommand comm = new MySqlCommand();
            comm.CommandText = "select * from tbFuncionarios where idFunc = '" + txtDescricao.Text + "';";
            comm.CommandType = CommandType.Text;
            comm.Connection = Conexao.conectar();

            MySqlDataReader dr;
            try
            {
                dr = comm.ExecuteReader();
                dr.Read();

                lstInformacoes.Items.Clear();

                lstInformacoes.Items.Add(dr.GetString(1));

                Conexao.desconectar();
            }
            catch (Exception)
            {
                MessageBox.Show("Digite um código!",
                "Mensagem do sistema",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error,
                MessageBoxDefaultButton.Button1);
                limparCampos();
            }
        }

        public void limparCampos()
        {
            rdbNome.Checked = false;
            rdbid.Checked = false;
            lstInformacoes.Items.Clear();
            txtDescricao.Clear();
            btnPesquisar.Focus();
        }

        public static string valor = "";


        private void lstInformacoes_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            string valor = lstInformacoes.SelectedItem.ToString();
            frmfuncionario enviar = new frmfuncionario(valor);
            enviar.Show();
            this.Hide();
        }


    }
}
