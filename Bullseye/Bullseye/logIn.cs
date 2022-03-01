using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace Bullseye
{
    public partial class logIn : Form
    {
        public logIn()
        {
            InitializeComponent();
        }
        
        //create a datatable to store data
        DataTable dt = new DataTable();
        DataTable userDt = new DataTable();

        private void btnLogin_Click(object sender, EventArgs e)
        {
            //check if userid and password exist and matched
            if(verifyUser(txtUserID.Text, txtPassword.Text))
            {
                //check if this user is active, if it's not, show message
                if (ifUserActive(txtUserID.Text))
                {
                    //create a object of user class and sent it to another form
                    User u = creatUser(txtUserID.Text);
                    MessageBox.Show("Log in successful");

                    Main frmMain = new Main(u);
                    frmMain.ShowDialog();
                }
                else
                    MessageBox.Show("This account is no longer in the system", "We are sorry");

            }
            else
            {
                //show this if the password or userid is wrong
                MessageBox.Show("Incorrect user ID or password, please try again", "Error");
            }
        }

        private void logIn_Load(object sender, EventArgs e)
        {
            //reset the login form
            resetLogin();
        }



        private void resetLogin()
        {
            //set the content of two txtbox into default(for test convenient) 
            //hide the password
            txtUserID.Text = "Admin";
            txtPassword.Text = "Passw0rd";
            
            txtPassword.PasswordChar = Convert.ToChar('*');

            fillCbos();
        }

        private void fillCbos()
        {
            

            if (HelpMethods.catchError(() => userTableAdapter.GetData()) == false )
                this.Close();
            else
            {

                userDt = userTableAdapter.GetData();
                HelpMethods.populateCbo(userDt, "userID", cboUser, "Not");
                
            }

        }

        //funtion name: verifyUser
        //description: this function checks if a user exist by using the userid to check it through the database
        //sent: string, string
        //return: bool
        private Boolean verifyUser(String userID, string password)
        {
            Boolean userExist = false;
            if (HelpMethods.catchError(() => userTableAdapter.GetData()))
                dt = userTableAdapter.GetData();
            else
                resetLogin();
            String cryPassword = HelpMethods.CalculateMD5Hash(password);
            
            foreach (DataRow row in dt.Rows)
            {
                if(userID== row["userID"].ToString())
                {
                    if (cryPassword == row["password"].ToString()) {
                        userExist = true;
                        break;
                    }
                }
            }
            
            return userExist;
        }

        //funtion name: ifUserActive
        //description: this function checks if a user exist by using the userid to check their active status through the database
        //sent: string
        //return: bool
        private bool ifUserActive(string userID)
        {
            Boolean ifActive= false;
            if (HelpMethods.catchError(() => userTableAdapter.GetData()))
                dt = userTableAdapter.GetData();
            else
                resetLogin();

            foreach (DataRow row in dt.Rows)
            {
                if (userID == row["userID"].ToString())
                {
                    //if (Convert.ToBoolean(row["active"]))
                    //    ifActive = true;
                    ifActive = Convert.ToBoolean(row["active"]);
                }
            }

            return ifActive;
        }

        //funtion name: creatUser
        //description: use the userid to create a user object
        //sent: string
        //return: User
        private User creatUser(string userID)
        {
            string roleID = "";
            string locationID = "";
            string locationName = "";
            List<string> actions= new List<string>();

            if (HelpMethods.catchError(() => userTableAdapter.GetData()))
                dt = userTableAdapter.GetData();
            else
                resetLogin();

            foreach (DataRow row in dt.Rows)
            {
                if (userID == row["userID"].ToString())
                {
                    locationID = row["locationID"].ToString();
                    roleID = row["roleID"].ToString();
                }
            }

            if (HelpMethods.catchError(() => permissionTableAdapter.GetData()))
                dt = permissionTableAdapter.GetData();
            else
                resetLogin();

            foreach (DataRow row in dt.Rows)
            {
                if (roleID == row["roleID"].ToString())
                    actions.Add(row["actionID"].ToString());
            }

            if (HelpMethods.catchError(() => locationTableAdapter.GetData()))
                dt = locationTableAdapter.GetData();
            else
                resetLogin();

            foreach (DataRow row in dt.Rows)
            {
                if (locationID == row["locationID"].ToString())
                    locationName = row["description"].ToString();
            }

            User u = new User(userID, locationID, locationName, roleID, actions);

            return u;
        }

        private void logIn_FormClosing(object sender, FormClosingEventArgs e)
        {
            //connDB.Close();
        }

        //hide or show the password in the textbox
        private void chkShowPsw_CheckedChanged(object sender, EventArgs e)
        {
            if (chkShowPsw.Checked == true)
            {
                txtPassword.PasswordChar = char.Parse("\0");
            }
            else if (chkShowPsw.Checked == false)
            {
                txtPassword.PasswordChar = Convert.ToChar('*');
            }
        }

        private void cboUser_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtUserID.Text = cboUser.Text;
        }
    }
}
