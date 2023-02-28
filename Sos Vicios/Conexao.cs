using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySqlConnector;

namespace Sos_Vicios
{
    class Conexao
    {
        private static string conString = "server=localhost;Port=3306;Database=dbSosvicios;Uid=root;Pwd=''";
        private static MySqlConnector.MySqlConnection conn = null;

        public static MySqlConnection conectar()
        {
            conn = new MySqlConnection(conString);
            try
            {
                conn.Open();
            }
            catch (MySqlException)
            {
                conn = null;
            }
            return conn;
        }
        public static void desconectar()
        {
            if (conn != null)
            {
                conn.Close();
            }
        }

    }
}