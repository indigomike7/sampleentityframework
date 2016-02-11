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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
/*           
            nsframeworkEntities1 mdl = new nsframeworkEntities1();
            mdl.Connection.Open();
            access_settings access = new access_settings();
 */
/*            access.access_name = "Test";
            access.created_by = "indigomike7";
            access.created_date = DateTime.Now;
            access.updated_by = "indigomike7";
            access.updated_date = DateTime.Now;
            mdl.AddToaccess_settings(access);
            mdl.SaveChanges();
            mdl.Connection.Close();
 */            
            /*
             * access = (from c in mdl.access_settings
                      where c.access_id == 4
                      select c).FirstOrDefault();
            mdl.DeleteObject(access);
            mdl.SaveChanges();
            mdl.Connection.Close();
             * */

/*            access = (from c in mdl.access_settings
                      where c.access_id == 5
                      select c).FirstOrDefault();
            access.access_name = "testing";
            mdl.SaveChanges();
            mdl.Connection.Close();
 * */
            
            //ObjectParameter name = new ObjectParameter("@menu_id", typeof(String));
            //Menu mnu = mdl.get_menu_by_id("1");

/*            menu mnu = mdl.get_menu_by_id("2").FirstOrDefault();
            //Console.WriteLine(mnu.menu_name);
            MessageBox.Show(mnu.menu_name);
*/



        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            if (tb_user_name.Text.Trim() == "" && tb_password.Text.Trim() == "")
            {
                MessageBox.Show("Please input username/email and password!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                EmptyTb();
                tb_user_name.Focus();
            }
            else
            {
                Entities1 mdl = new Entities1();
                mdl.Connection.Open();
                using (MD5 md5Hash = MD5.Create())
                {
                    string hash = this.GetMd5Hash(md5Hash, tb_password.Text);

                    user login = mdl.sp_login_user(tb_user_name.Text, hash).FirstOrDefault();
                    if (login != null)
                    {
                        Global.GlobalVar = tb_user_name.Text;
                        MDI frmMDI = new MDI();
                        //Application.Run(new MDI());
                        this.Close();
                        frmMDI.ShowDialog();

                    }
                    else
                    {
                        MessageBox.Show("Username/Email or password Error", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        EmptyTb();
                        tb_user_name.Focus();
                    }
                }
            }

            
        }
        public void EmptyTb()
        {
            tb_password.Text = "";
            tb_user_name.Text = "";
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

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
            Application.Exit();
        }
    }
}
