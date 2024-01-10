using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace EmpSystem
{

    public partial class registerForm : Form
    {
        public registerForm()
        {
            InitializeComponent();
           
        }

        OleDbConnection con = new OleDbConnection("Provider=microsoft.jet.OLEDB.4.0;Data Source=db_user.mdb");
        OleDbCommand cmd = new OleDbCommand();
        OleDbDataAdapter da = new OleDbDataAdapter();

        private void btnRegister_Click(object sender, EventArgs e)
        {
            if(txtUserName.Text=="" && txtPassword.Text=="" && txtConfirmPassword.Text == "")
            {
                MessageBox.Show("Fields cannot be empty",
                                 "Registration Failed",
                                  MessageBoxButtons.OK,MessageBoxIcon.Error);

            }
            else if(txtPassword.Text == txtConfirmPassword.Text)
            {
                con.Open();
                string register = "INSERT INTO tbl_users VALUES ('" + txtUserName.Text + "','" + txtPassword.Text + "')";
                cmd = new OleDbCommand(register, con);
                cmd.ExecuteNonQuery();
                con.Close();

                txtUserName.Text = "";
                txtPassword.Text = "";
                txtConfirmPassword.Text = "";

                MessageBox.Show("Account has been successfully created", "Registration Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
             
            }
            else
            {
                MessageBox.Show("Password does not match, Please check password",
                                "Registration Failed",
                                 MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtPassword.Text = "";
                txtConfirmPassword.Text = "";
                txtPassword.Focus();
            }
        }

        private void checkshowpassword_CheckedChanged(object sender, EventArgs e)
        {
            if (checkshowpassword.Checked)
            {
                txtPassword.PasswordChar = '\0';
                txtConfirmPassword.PasswordChar = '\0';
            }
            else
            {
                txtPassword.PasswordChar = '*';
                txtConfirmPassword.PasswordChar = '*';
            }
        }

        private void label6_Click(object sender, EventArgs e)
        {
            new loginform().Show();
            this.Hide();
        }
    }
}
