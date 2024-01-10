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
    public partial class loginform : Form
    {
        public loginform()
        {
            InitializeComponent();
        }

        OleDbConnection con = new OleDbConnection("Provider=microsoft.jet.OLEDB.4.0;Data Source=db_user.mdb");
        OleDbCommand cmd = new OleDbCommand();
        OleDbDataAdapter da = new OleDbDataAdapter();

        private void label6_Click(object sender, EventArgs e)
        {
            this.Close();
            new registerForm().Show();
            
        }


        private void checkshowpassword_CheckedChanged(object sender, EventArgs e)
        {
            if (checkshowpassword.Checked)
            {
                txtPassword.PasswordChar = '\0';
            }
            else
            {
                txtPassword.PasswordChar = '*';
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            con.Open();
            String login = "SELECT * FROM tbl_users where username='"+ txtUserName.Text +"' and password= '"+ txtPassword.Text+"'";
            cmd= new OleDbCommand(login,con);
            OleDbDataReader reader = cmd.ExecuteReader();

            if (reader.Read() ==true)
            {
                new Menu().Show();
                MessageBox.Show("You have Login successfully ", "Login Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("Password or Email is wrong, Please try again",
                               "Login Failed",
                                MessageBoxButtons.OK, MessageBoxIcon.Error);

                txtPassword.Text = "";
                txtUserName.Focus();
            }
        }

        private void google_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Login with Google Account ", "To be Implemented Soon...", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void aaple_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Login with Apple Account ", "To be Implemented Soon...", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
