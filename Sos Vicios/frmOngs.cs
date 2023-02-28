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
    public partial class frmOngs : Form
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

            txtNome.Clear();
            mktTelefone.Clear();
            mktCnpj.Clear();
            txtEndereco.Clear();
            txtWebsite.Clear();
            txtNome.Focus();
        }

        public void desabilitarCampos()
        {
            txtNome.Enabled = false;
            mktTelefone.Enabled = false;
            mktCnpj.Enabled = false;
            txtEndereco.Enabled = false;
            txtWebsite.Enabled = false;
            btncadastrar.Enabled = false;
            btnalterar.Enabled = false;
            btnexcluir.Enabled = false;
            btnlimpar.Enabled = false;
        }

        public void habilitarCampos()
        {
            txtNome.Enabled = true;
            mktTelefone.Enabled = true;
            mktCnpj.Enabled = true;
            txtEndereco.Enabled = true;
            txtWebsite.Enabled = true;
            btncadastrar.Enabled = true;
            txtNome.Focus();
        }


        public frmOngs()
        {
            
            InitializeComponent();
            buscarCodigo();
            limparCampos();
            desabilitarCampos();
        }

        public string nome = "";
        public frmOngs(string nome)
        {
            InitializeComponent();
            this.nome = nome;
            txtNome.Text = nome;
        }

        private void btnVoltar_Click(object sender, EventArgs e)
        {
            frmMenu abrir = new frmMenu();
            abrir.Show();
            this.Hide();
        }

        private void btncadastrar_Click(object sender, EventArgs e)
        {
            if (txtNome.Text.Equals(""))
            {
                MessageBox.Show("Campos obrigatórios!!!",
                   "Mensagem do sistema",
                   MessageBoxButtons.OK,
                   MessageBoxIcon.Error,
                   MessageBoxDefaultButton.Button1);
                limparCampos();
            }

            else if (mktTelefone.Text.Equals("(  )      -"))
            {
                MessageBox.Show("Campos obrigatórios!!!",
                "Mensagem do sistema",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error,
                MessageBoxDefaultButton.Button1);
                limparCampos();
            }

            else if (mktCnpj.Text.Equals("  ,   ,   /    -"))
            {
                MessageBox.Show("Campos obrigatórios!!!",
                "Mensagem do sistema",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error,
                MessageBoxDefaultButton.Button1);
                limparCampos();
            }

            else if (txtEndereco.Text.Equals(""))
            {
                MessageBox.Show("Campos obrigatórios!!!",
                "Mensagem do sistema",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error,
                MessageBoxDefaultButton.Button1);
                limparCampos();
            }

            else if (txtWebsite.Text.Equals(""))
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
                cadastrarONG();
            }
        }

        public void buscarCodigo()
        {


            MySqlCommand comm = new MySqlCommand();

            comm.CommandText = "select idONG + 1 from tbONGs order by idONG desc;";
            comm.CommandType = CommandType.Text;

            comm.Connection = Conexao.conectar();

            MySqlDataReader DR;
            DR = comm.ExecuteReader();

            DR.Read();

            txtCodigo.Text = Convert.ToString(DR.GetInt32(0));
            Conexao.desconectar();
        }

        public void cadastrarONG()
        {

            MySqlCommand comm = new MySqlCommand();

            comm.CommandText = "insert into tbONGs(nome,tel,cnpj,endereco,website)values(@nome, @tel, @cnpj, @endereco, @website);";
            comm.CommandType = CommandType.Text;
            //limpando os parâmetros de registro
            comm.Parameters.Clear();
            //ligando os campos do SQL ao c#
            comm.Parameters.Add("@nome", MySqlDbType.VarChar, 50).Value = txtNome.Text;
            comm.Parameters.Add("@tel", MySqlDbType.VarChar, 50).Value = mktTelefone.Text;
            comm.Parameters.Add("@cnpj", MySqlDbType.VarChar, 50).Value = mktCnpj.Text;
            comm.Parameters.Add("@endereco", MySqlDbType.VarChar, 50).Value = txtEndereco.Text;
            comm.Parameters.Add("@website", MySqlDbType.VarChar, 50).Value = txtWebsite.Text;

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

            frmOngs abrir = new frmOngs();
            abrir.Show();
            this.Hide();
        }




        private void btnpesquisar_Click(object sender, EventArgs e)
        {
            frmPesquisar abrir = new frmPesquisar();
            abrir.Show();
            this.Hide();
        }



        private void frmOngs_Load(object sender, EventArgs e)
        {
            IntPtr hMenu = GetSystemMenu(this.Handle, false);
            int MenuCount = GetMenuItemCount(hMenu) - 1;
            RemoveMenu(hMenu, MenuCount, MF_BYCOMMAND);
        }


        public void PesquisaONG(string nome)
        {
            MySqlCommand comm = new MySqlCommand();
            comm.CommandText = "select * from tbONGs where nome like '%" + nome + "%'";
            comm.CommandType = CommandType.Text;
            comm.Connection = Conexao.conectar();

            MySqlDataReader dr;
            dr = comm.ExecuteReader();
            dr.Read();


            txtNome.Text = dr.GetString(1);
            txtCodigo.Text = Convert.ToString(dr.GetInt32(0));
            mktTelefone.Text = dr.GetString(2);
            mktCnpj.Text = dr.GetString(3);
            txtEndereco.Text = dr.GetString(4);
            txtWebsite.Text = dr.GetString(5);


            Conexao.desconectar();
        }

        bool valor = false;

        private void txtNome_TextChanged(object sender, EventArgs e)
        {
            if (valor == false)
            {
                PesquisaONG(txtNome.Text);
                valor = true;
                btnNovo.Enabled = false;
                btnlimpar.Enabled = false;
            }

        }

        private void btnNovo_Click(object sender, EventArgs e)
        {
            habilitarCampos();
            valor = true;
            btncadastrar.Enabled = true;
        }

        private void txtCodigo_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnlimpar_Click(object sender, EventArgs e)
        {
            limparCampos();
        }


        DialogResult vresp;
        private void btnexcluir_Click(object sender, EventArgs e)
        {
            MySqlCommand comm = new MySqlCommand();

            comm.CommandText = "delete from tbONGs where idONG = @idONG";
            comm.Parameters.Clear();
            comm.Parameters.Add("@idONG", MySqlDbType.VarChar, 7).Value = txtCodigo.Text;

            comm.Connection = Conexao.conectar();

            vresp = MessageBox.Show("Deseja excluir esta ONG do registro?", "Mensagem do sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2);
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
                frmOngs abrir = new frmOngs();
                abrir.Show();
                this.Hide();
                limparCampos();
            }
        }

        public string Nome = null;

        public void alterarONG(string Nome)
        {
            MySqlCommand comm = new MySqlCommand();

            comm.CommandText = "update tbONGs set nome = @nome, tel = @tel, cnpj = @cnpj, endereco = @endereco, website = @website where nome =  @nome";
            comm.Parameters.Clear();
            comm.Parameters.Add("@nome", MySqlDbType.VarChar, 50).Value = txtNome.Text;
            comm.Parameters.Add("@tel", MySqlDbType.VarChar, 50).Value = mktTelefone.Text;
            comm.Parameters.Add("@cnpj", MySqlDbType.VarChar, 50).Value = mktCnpj.Text;
            comm.Parameters.Add("@endereco", MySqlDbType.VarChar, 50).Value = txtEndereco.Text;
            comm.Parameters.Add("@website", MySqlDbType.VarChar, 50).Value = txtWebsite.Text;

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

            frmOngs abrir = new frmOngs();
            abrir.Show();
            this.Hide();

        }

        private void btnalterar_Click(object sender, EventArgs e)
        {
            alterarONG(Nome);
        }
    }
}
