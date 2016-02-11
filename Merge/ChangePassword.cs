using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Configuration;
using System.Data.Objects;
using System.Security.Cryptography;
using System.Text;


namespace Merge
{
    public partial class ChangePassword : Form
    {
        public ChangePassword()
        {
            InitializeComponent();
        }

        private void ChangePassword_Load(object sender, EventArgs e)
        {

            textBox1.Text = Global.GlobalVar;
        }

        private void button1_Click(object sender, EventArgs e)
        {

            if (tbOldPassword.Text.Trim() == "" ||  tbNewPassword.Text.Trim() == "" || tbConfirmPassword.Text.Trim()=="" || tbConfirmPassword.Text != tbNewPassword.Text)
            {
                MessageBox.Show("Please input field! Verify New Password and Confirm Password is the same!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                tbOldPassword.Text = "";
                tbNewPassword.Text = "";
                tbConfirmPassword.Text = "";
                tbOldPassword.Focus();
            }
            else
            {
                Entities1 mdl = new Entities1();
                mdl.Connection.Open();
                using (MD5 md5Hash = MD5.Create())
                {
                    string hash = this.GetMd5Hash(md5Hash, tbOldPassword.Text);
                    string hash2 = this.GetMd5Hash(md5Hash, tbNewPassword.Text);
                    user login = mdl.sp_login_user(textBox1.Text, hash).FirstOrDefault();
                    if (login != null)
                    {
                        user access = (from c in mdl.users
                                       where c.user_name == textBox1.Text
                                       select c).FirstOrDefault();
                        access.user_password = hash2;
                        mdl.SaveChanges();
                        MessageBox.Show("Success Change Password", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Username or Old Password Error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        tbOldPassword.Text = "";
                        tbNewPassword.Text = "";
                        tbConfirmPassword.Text = "";
                        tbOldPassword.Focus();
                    }
                }
                mdl.Connection.Close();
            }

        }
        public string GetMd5Hash(MD5 md5Hash, string input)
        {

            // Convert the input string to a byte array and compute the hash.
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            // Create a new Stringbuilder to collect the bytes
            // and create a string.
            StringBuilder sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data 
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string.
            return sBuilder.ToString();
        }

        // Verify a hash against a string.
        public bool VerifyMd5Hash(MD5 md5Hash, string input, string hash)
        {
            // Hash the input.
            string hashOfInput = GetMd5Hash(md5Hash, input);

            // Create a StringComparer an compare the hashes.
            StringComparer comparer = StringComparer.OrdinalIgnoreCase;

            if (0 == comparer.Compare(hashOfInput, hash))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

    }
}
