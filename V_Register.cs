using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PBO_D08
{
    public partial class V_Register : Form
    {
        public V_Register()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Register UserRegister = new Register(textBox1.Text, textBox2.Text);
            bool cek_NIM = UserRegister.Cek_Akun();
            if (textBox1.Text != "" && textBox2.Text != "")
            {
                if (cek_NIM)
                {
                    bool Register_Akun = UserRegister.TambahAkun();
                    if (Register_Akun) 
                    {
                        MessageBox.Show("Register Akun Berhasil", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Password Harus 8 Huruf dan Mengandung Huruf Kapital, Huruf Kecil dan Angka", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                else
                {
                    MessageBox.Show("NIM Tidak Terdaftar Pada Fakultas", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            else { MessageBox.Show("Harap Isi TextBox", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error); }

        }
    }
}
