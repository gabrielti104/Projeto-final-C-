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
    public partial class frmUsuario : Form
    {
        const int MF_BYCOMMAND = 0X400;
        [DllImport("user32")]
        static extern int RemoveMenu(IntPtr hMenu, int nPosition, int wFlags);
        [DllImport("user32")]
        static extern IntPtr GetSystemMenu(IntPtr hWnd, bool bRevert);
        [DllImport("user32")]
        static extern int GetMenuItemCount(IntPtr hWnd);
        public void limparCampos()
        {

            txtnome.Clear();
            txtsenha.Clear();
            txtconfirmar.Clear();
            txtnome.Focus();
        }

        public void desabilitarCampos()
        {
            txtnome.Enabled = false;
            txtsenha.Enabled = false;
            txtconfirmar.Enabled = false;
            btncadastrar.Enabled = false;
            btnalterar.Enabled = false;
            btnexcluir.Enabled = false;
            btnlimpar.Enabled = false;
        }

        public void habilitarCampos()
        {
            txtnome.Enabled = true;
            txtsenha.Enabled = true;
            txtconfirmar.Enabled = true;
            btncadastrar.Enabled = true;
            txtnome.Focus();
        }


        public frmUsuario()
        {

            InitializeComponent();
            buscarCodigo();
            limparCampos();
            desabilitarCampos();
        }

        public string nome = "";

        public frmUsuario(string nome)
        {
            InitializeComponent();
            this.nome = nome;
            txtnome.Text = nome;
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            frmMenuADM abrir = new frmMenuADM();
            abrir.Show();
            this.Hide();
        }

        private void btncadastrar_Click_1(object sender, EventArgs e)
        {
            if (txtnome.Text.Equals(""))
            {
                MessageBox.Show("Campos obrigatórios!!!",
                   "Mensagem do sistema",
                   MessageBoxButtons.OK,
                   MessageBoxIcon.Error,
                   MessageBoxDefaultButton.Button1);
                limparCampos();
            }

            else if (txtsenha.Text.Equals(""))
            {
                MessageBox.Show("Campos obrigatórios!!!",
                "Mensagem do sistema",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error,
                MessageBoxDefaultButton.Button1);
                limparCampos();
            }

            else if (txtconfirmar.Text.Equals(""))
            {
                MessageBox.Show("Campos obrigatórios!!!",
                "Mensagem do sistema",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error,
                MessageBoxDefaultButton.Button1);
                limparCampos();
            }

            else
            {
                cadastrarUsuario();
            }
        }

        public void buscarCodigo()
        {


            MySqlCommand comm = new MySqlCommand();

            comm.CommandText = "select idUsu + 1 from tbUsuarios order by idUsu desc;";
            comm.CommandType = CommandType.Text;

            comm.Connection = Conexao.conectar();

            MySqlDataReader DR;
            DR = comm.ExecuteReader();

            DR.Read();

            txtid.Text = Convert.ToString(DR.GetInt32(0));
            Conexao.desconectar();
        }

        public int idFunc;
        public void cadastrarUsuario()
        {
            MySqlCommand comm = new MySqlCommand();

            comm.CommandText = "insert into tbUsuarios(nome,senha)values(@nome, @senha);";
            comm.CommandType = CommandType.Text;
            //limpando os parâmetros de registro
            comm.Parameters.Clear();
            //ligando os campos do SQL ao c#
            comm.Parameters.Add("@nome", MySqlDbType.VarChar, 50).Value = txtnome.Text;
            comm.Parameters.Add("@senha", MySqlDbType.VarChar, 50).Value = txtsenha.Text;

            comm.Connection = Conexao.conectar();


            try
            {
                comm.ExecuteNonQuery();

                MessageBox.Show("Cadastrado com sucesso!",
                        "Mensagem do sistema",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information,
                        MessageBoxDefaultButton.Button1);
                limparCampos();
            }
            catch (Exception)
            {

                MessageBox.Show("Usuário já existe no banco de dados!",
                   "Mensagem do sistema",
                   MessageBoxButtons.OK,
                   MessageBoxIcon.Error,
                   MessageBoxDefaultButton.Button1);
            }


            Conexao.desconectar();

            frmUsuario abrir = new frmUsuario();
            abrir.Show();
            this.Hide();
        }




        private void btnpesquisar_Click_1(object sender, EventArgs e)
        {
            frmPesquisaUsuario abrir = new frmPesquisaUsuario();
            abrir.Show();
            this.Hide();
        }



        private void frmUsuario_Load(object sender, EventArgs e)
        {
            IntPtr hMenu = GetSystemMenu(this.Handle, false);
            int MenuCount = GetMenuItemCount(hMenu) - 1;
            RemoveMenu(hMenu, MenuCount, MF_BYCOMMAND);
        }


        public void PesquisaUsuario(string nome)
        {
            MySqlCommand comm = new MySqlCommand();
            comm.CommandText = "select * from tbUsuarios where nome like '%" + nome + "%'";
            comm.CommandType = CommandType.Text;
            comm.Connection = Conexao.conectar();

            MySqlDataReader dr;
            dr = comm.ExecuteReader();
            dr.Read();


            txtnome.Text = dr.GetString(1);
            txtid.Text = Convert.ToString(dr.GetInt32(0));
            txtsenha.Text = dr.GetString(2);


            Conexao.desconectar();
        }

        bool valor = false;

        private void txtnome_TextChanged_1(object sender, EventArgs e)
        {
            if (valor == false)
            {
                PesquisaUsuario(txtnome.Text);
                valor = true;
                btnnovo.Enabled = false;
                btnlimpar.Enabled = false;
            }

        }

        private void btnnovo_Click_1(object sender, EventArgs e)
        {
            habilitarCampos();
            valor = true;
            btncadastrar.Enabled = true;
        }


        private void btnlimpar_Click_1(object sender, EventArgs e)
        {
            limparCampos();
        }


        DialogResult vresp;
        private void btnexcluir_Click_1(object sender, EventArgs e)
        {
            MySqlCommand comm = new MySqlCommand();

            comm.CommandText = "delete from tbUsuarios where idUsu = @idUsu";
            comm.Parameters.Clear();
            comm.Parameters.Add("@idUsu", MySqlDbType.VarChar, 7).Value = txtid.Text;

            comm.Connection = Conexao.conectar();

            vresp = MessageBox.Show("Deseja excluir este Usuário do registro?", "Mensagem do sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2);
            if (vresp == DialogResult.Yes)
            {
                try
                {
                    comm.ExecuteNonQuery();
                    MessageBox.Show("Registro excluído com sucesso!", "Mensagem do sistema", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1);
                }
                catch (Exception)
                {

                }
                Conexao.desconectar();
                frmUsuario abrir = new frmUsuario();
                abrir.Show();
                this.Hide();
                limparCampos();
            }
        }

        public string eome = null;

        public void alterarusuario(string eome)
        {
            MySqlCommand comm = new MySqlCommand();

            comm.CommandText = "update tbUsuarios set nome = @nome, senha = @senha where nome =  @nome";
            comm.Parameters.Clear();
            comm.Parameters.Add("@nome", MySqlDbType.VarChar, 50).Value = txtnome.Text;
            comm.Parameters.Add("@senha", MySqlDbType.VarChar, 50).Value = txtsenha.Text;

            comm.Connection = Conexao.conectar();


            try
            {
                comm.ExecuteNonQuery();

                MessageBox.Show("Alterado com sucesso!",
                        "Mensagem do sistema",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information,
                        MessageBoxDefaultButton.Button1);
                limparCampos();
            }
            catch (Exception)
            {

            }
            Conexao.desconectar();

            frmUsuario abrir = new frmUsuario();
            abrir.Show();
            this.Hide();

        }

        private void btnalterar_Click_1(object sender, EventArgs e)
        {
            alterarusuario(eome);
        }

        private void txtid_TextChanged(object sender, EventArgs e)
        {

        }


    }
}
