using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bullseye
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new logIn());
        }
    }

    public class User
    {
        //set properties of class Orders
        private string userID;
        //private String password;
        private string locationID;
        private string locationName;
        private string roleID;
        private List<string> actions;


        //set constructors of class Orders
        public User() { }
        public User(string userID, string locationID, string locationName, string roleID, List<string> actions) {
            this.userID = userID;
            this.locationID = locationID;
            this.locationName = locationName;
            this.roleID = roleID;
            this.actions = actions;
        }

        public string getUserID()
        {
            return userID;
        }

        //public string getPassword()
        //{
        //    return password;
        //}

        public string getLocationID()
        {
            return locationID;
        }

        public string getLocationName()
        {
            return locationName;
        }

        public string getRoleID()
        {
            return roleID;
        }

        public List<string> getActions()
        {
            return actions;
        }
    }
}
