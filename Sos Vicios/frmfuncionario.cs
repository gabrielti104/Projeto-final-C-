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
    public partial class frmfuncionario : Form
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
            mktcpf.Clear();
            mktTelefone.Clear();
            txtendereco.Clear();
            txtnome.Focus();
        }

        public void desabilitarCampos()
        {
            txtnome.Enabled = false;
            mktTelefone.Enabled = false;
            mktcpf.Enabled = false;
            txtendereco.Enabled = false;
            btncadastrar.Enabled = false;
            btnalterar.Enabled = false;
            btnexcluir.Enabled = false;
            btnlimpar.Enabled = false;
        }

        public void habilitarCampos()
        {
            txtnome.Enabled = true;
            mktTelefone.Enabled = true;
            mktcpf.Enabled = true;
            txtendereco.Enabled = true;
            btncadastrar.Enabled = true;
            txtnome.Focus();
        }


        public frmfuncionario()
        {

            InitializeComponent();
            buscarCodigo();
            limparCampos();
            desabilitarCampos();
        }

        public string nome = "";
        public frmfuncionario(string nome)
        {
            InitializeComponent();
            this.nome = nome;
            txtnome.Text = nome;
        }

        private void btnVoltar_Click_1(object sender, EventArgs e)
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

            else if (mktTelefone.Text.Equals("(  )      -"))
            {
                MessageBox.Show("Campos obrigatórios!!!",
                "Mensagem do sistema",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error,
                MessageBoxDefaultButton.Button1);
                limparCampos();
            }

            else if (mktcpf.Text.Equals("  ,   ,   /    -"))
            {
                MessageBox.Show("Campos obrigatórios!!!",
                "Mensagem do sistema",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error,
                MessageBoxDefaultButton.Button1);
                limparCampos();
            }

            else if (txtendereco.Text.Equals(""))
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
                CadastrarFunc();
            }
        }

        public void buscarCodigo()
        {


            MySqlCommand comm = new MySqlCommand();

            comm.CommandText = "select idFunc + 1 from tbFuncionarios order by idFunc desc;";
            comm.CommandType = CommandType.Text;

            comm.Connection = Conexao.conectar();

            MySqlDataReader DR;
            DR = comm.ExecuteReader();

            DR.Read();

            txtid.Text = Convert.ToString(DR.GetInt32(0));
            Conexao.desconectar();
        }

        public void CadastrarFunc()
        {

            MySqlCommand comm = new MySqlCommand();

            comm.CommandText = "insert into tbFuncionarios(nome,cpf,tel,endereco)values(@nome, @cpf, @tel, @endereco);";
            comm.CommandType = CommandType.Text;
            //limpando os parâmetros de registro
            comm.Parameters.Clear();
            //ligando os campos do SQL ao c#
            comm.Parameters.Add("@nome", MySqlDbType.VarChar, 50).Value = txtnome.Text;
            comm.Parameters.Add("@cpf", MySqlDbType.VarChar, 50).Value = mktcpf.Text;
            comm.Parameters.Add("@tel", MySqlDbType.VarChar, 50).Value = mktTelefone.Text;
            comm.Parameters.Add("@endereco", MySqlDbType.VarChar, 50).Value = txtendereco.Text;

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

                MessageBox.Show("Funcionario já existe no banco de dados!",
                   "Mensagem do sistema",
                   MessageBoxButtons.OK,
                   MessageBoxIcon.Error,
                   MessageBoxDefaultButton.Button1);
            }


            Conexao.desconectar();

            frmfuncionario abrir = new frmfuncionario();
            abrir.Show();
            this.Hide();
        }




        private void btnpesquisar_Click_1(object sender, EventArgs e)
        {
            frmPesquisaFuncionario abrir = new frmPesquisaFuncionario();
            abrir.Show();
            this.Hide();
        }



        private void frmfuncionario_Load(object sender, EventArgs e)
        {
            IntPtr hMenu = GetSystemMenu(this.Handle, false);
            int MenuCount = GetMenuItemCount(hMenu) - 1;
            RemoveMenu(hMenu, MenuCount, MF_BYCOMMAND);
        }


        public void PesquisaFunc(string nome)
        {
            MySqlCommand comm = new MySqlCommand();
            comm.CommandText = "select * from tbFuncionarios where nome like '%" + nome + "%'";
            comm.CommandType = CommandType.Text;
            comm.Connection = Conexao.conectar();

            MySqlDataReader dr;
            dr = comm.ExecuteReader();
            dr.Read();


            txtnome.Text = dr.GetString(1);
            txtid.Text = Convert.ToString(dr.GetInt32(0));
            mktcpf.Text = dr.GetString(2);
            mktTelefone.Text = dr.GetString(3);
            txtendereco.Text = dr.GetString(4);


            Conexao.desconectar();
        }

        bool valor = false;

        private void txtnome_TextChanged_1(object sender, EventArgs e)
        {
            if (valor == false)
            {
                PesquisaFunc(txtnome.Text);
                valor = true;
                btnnovo.Enabled = false;
                btnlimpar.Enabled = false;
            }

        }

        private void btnnovo_Click(object sender, EventArgs e)
        {
            habilitarCampos();
            valor = true;
            btncadastrar.Enabled = true;
        }

        private void txtid_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnlimpar_Click_1(object sender, EventArgs e)
        {
            limparCampos();
        }


        DialogResult vresp;
        private void btnexcluir_Click_1(object sender, EventArgs e)
        {
            MySqlCommand comm = new MySqlCommand();

            comm.CommandText = "delete from tbFuncionarios where idFunc = @idFunc";
            comm.Parameters.Clear();
            comm.Parameters.Add("@idFunc", MySqlDbType.VarChar, 7).Value = txtid.Text;

            comm.Connection = Conexao.conectar();

            vresp = MessageBox.Show("Deseja excluir este funcionário do registro?", "Mensagem do sistema", MessageBoxButtons.YesNo, MessageBoxIcon.Information, MessageBoxDefaultButton.Button2);
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
                frmfuncionario abrir = new frmfuncionario();
                abrir.Show();
                this.Hide();
                limparCampos();
            }
        }

        public string Nome = null;

        public void alterarFunc(string Nome)
        {
            MySqlCommand comm = new MySqlCommand();

            comm.CommandText = "update tbFuncionarios set nome = @nome, cpf = @cpf, tel = @tel, endereco = @endereco where nome =  @nome";
            comm.Parameters.Clear();
            comm.Parameters.Add("@nome", MySqlDbType.VarChar, 50).Value = txtnome.Text;
            comm.Parameters.Add("@cpf", MySqlDbType.VarChar, 50).Value = mktcpf.Text;
            comm.Parameters.Add("@tel", MySqlDbType.VarChar, 50).Value = mktTelefone.Text;
            comm.Parameters.Add("@endereco", MySqlDbType.VarChar, 50).Value = txtendereco.Text;

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

            frmfuncionario abrir = new frmfuncionario();
            abrir.Show();
            this.Hide();

        }

        private void btnalterar_Click_1(object sender, EventArgs e)
        {
            alterarFunc(Nome);
        }


    }
}
