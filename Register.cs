using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Npgsql;

namespace PBO_D08
{
    public class Register
    {
        private string username;
        private string password;
        public Register(string username, string password)
        {
            this.username = username;
            this.password = password;
        }
        public bool Cek_Akun()
        {
            NpgsqlConnection connect = new NpgsqlConnection("Host=localhost;Username=postgres;password=syadid1306;Database=JAPRI;port=5432");
            connect.Open();
            NpgsqlCommand npgsqlCommand = new NpgsqlCommand();
            npgsqlCommand.Connection = connect;
            npgsqlCommand.CommandText = $"Select * from Mahasiswa Where nim = '{username}'";
            NpgsqlDataReader cek_nim = npgsqlCommand.ExecuteReader();
            bool result_cek = cek_nim.Read();
            connect.Close();
            return result_cek;
        }

        public bool TambahAkun()
        {
            bool validasi_password = password.Length == 8 &&
                                     Regex.IsMatch(password, "[A-Z]") &&
                                     Regex.IsMatch(password, "[a-z]") &&
                                     Regex.IsMatch(password, "[0-9]");
            //Regex.IsMatch(password, "[^a-zA-Z0-9]");

            if (validasi_password)
            {
                NpgsqlConnection connect = new NpgsqlConnection("Host=localhost;Username=postgres;password=syadid1306;Database=JAPRI;port=5432");
                connect.Open();

                string insertQuery = "INSERT INTO Asisten_praktikum (nim, password) VALUES (@nim, @password)";
                using (NpgsqlCommand cmd = new NpgsqlCommand(insertQuery, connect))
                {
                    cmd.Parameters.AddWithValue("nim", username);
                    cmd.Parameters.AddWithValue("password", password);

                    int rowsAffected = cmd.ExecuteNonQuery();
                    connect.Close();
                    if (rowsAffected > 0) { return true; }
                    else { return false; }


                    //NpgsqlCommand npgsqlCommand = new NpgsqlCommand();
                    //npgsqlCommand.Connection = connect;
                    //npgsqlCommand.CommandText = $"insert into Asisten_praktikum (nim,password) values ({username},{password})";
                    //NpgsqlDataReader data = npgsqlCommand.ExecuteReader();
                    //bool result = data.Read();
                    //return result;
                }

            }
            else { return false; }
        }
    }
}
