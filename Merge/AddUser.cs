using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Merge
{
    public partial class AddUser : Form
    {
        public AddUser()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(textBox1.Text == "" || tbNewPassword.Text =="" || tbConfirmPassword.Text =="" || tbNewPassword.Text != tbConfirmPassword.Text)
            {
                MessageBox.Show("Please input field! Verify New Password and Confirm Password is the same!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                try
                {
                    Entities1 mdl = new Entities1();
                    mdl.Connection.Open();
                    user user = new user();
                    user.user_name = textBox1.Text;
                    user.user_password = tbNewPassword.Text;
                    user.created_by = Global.GlobalVar;
                    user.created_date = DateTime.Now;
                    user.updated_by = Global.GlobalVar;
                    user.updated_date = DateTime.Now;
                    user.user_address = "";
                    user.user_birth_date = DateTime.Now;
                    user.user_birth_place = "";
                    user.user_email = "";
                    user.user_first_name = "";
                    user.user_last_name = "";
                    user.user_last_login = DateTime.Parse("01/01/1970");
                    user.user_phone_number = "";
                    user.user_photo_file = "";
                    user.user_social_number = "";
                    user.user_marital_status = "";
                    user.user_gender = "";
                    user.user_group_id = 1;
                    mdl.AddTousers(user);
                    mdl.SaveChanges();
                    mdl.Connection.Close();

                    MessageBox.Show("Success Add New User", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Loading();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message + " " + ex.InnerException + " " + ex.StackTrace, "Error", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            }
        }

        private void AddUser_Load(object sender, EventArgs e)
        {
            Loading();
        }
        private void Loading()
        {
            Entities1 mdl = new Entities1();
            List<user> userList = new List<user>();
            userList = (from c in mdl.users
                        orderby c.user_id descending
                        select c).ToList();
            foreach (user user in userList)
            {
                user.user_password = "******";
            }
            dataGridView1.DataSource = userList;

        }
    }
}
