using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Npgsql;

namespace PBO_D08
{
    public class Login
    {
        private string username;
        private string password;
        public Login(string username, string password) { 
            this.username = username;
            this.password = password;
        }
        public bool LoginAkun()
        {
            NpgsqlConnection connect = new NpgsqlConnection("Host=localhost;Username=postgres;password=syadid1306;Database=JAPRI;port=5432");
            connect.Open();
            NpgsqlCommand npgsqlCommand = new NpgsqlCommand();
            npgsqlCommand.Connection = connect;
            npgsqlCommand.CommandText = $"Select * from Asisten_Praktikum Where nim = '{username}' and password = '{password}'";
            NpgsqlDataReader data = npgsqlCommand.ExecuteReader();
            bool result = data.Read();
            connect.Close();
            return result;
        }

    }
}
