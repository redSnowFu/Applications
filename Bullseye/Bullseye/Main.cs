using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bullseye
{
    public partial class Main : Form
    {
        //create a global user class to get the user
        User currentUser = new User();
        public Main(User u)
        {
            InitializeComponent();
            currentUser = u;
        }

        

        private void Main_Load(object sender, EventArgs e)
        {
            //call checkPermission function
            checkPermission();
            string userID = currentUser.getUserID();
            string roleID = currentUser.getRoleID();
            string locationName = currentUser.getLocationName();
            lblUserInfo.Text = userID + ", " + roleID + ", Location: " + locationName;
        }

        //funtion name: checkPermission
        //description: check permisson to see which button could be availiable for the current user
        //sent: none
        //return: none
        private void checkPermission()
        {
            List<string> actions = currentUser.getActions();

            btnInventory.Enabled = false;
            btnOrder.Enabled = false;
            btnWarehouse.Enabled = false;
            btnReport.Enabled = false;
            btnAdmin.Enabled = false;

            List<string> inventoryActs = new List<string> { "READ INVENTORY" };
            List<string> orderAct = new List<string> { "READ ORDER", "READ DELIVERY" };
            List<string> warehouseActs = new List<string> { "READ ITEM"};
            List<string> adminActs = new List<string> { "READ LOCATION", "READ USER",
                "READ COURIER"};


            if (actions.Contains("CRUD"))
            {
                btnInventory.Enabled = true;
                btnOrder.Enabled = true;
                btnWarehouse.Enabled = true;
                btnReport.Enabled = true;
                btnAdmin.Enabled = true;
            }
            else
            {
                if (actions.Any(x => inventoryActs.Any(y => y == x)))
                    btnInventory.Enabled = true;
                if (actions.Any(x => orderAct.Any(y => y == x)))
                    btnOrder.Enabled = true;
                if (actions.Any(x => warehouseActs.Any(y => y == x)))
                    btnWarehouse.Enabled = true;
                if (actions.Contains("READ DELIVERY")|| actions.Contains("CRUD"))
                    btnReport.Enabled = true;
                if (actions.Any(x => adminActs.Any(y => y == x)))
                    btnAdmin.Enabled = true;
                if(currentUser.getRoleID()== "Driver")
                    btnOrder.Enabled = true;
            }

            
        }

        //open new form and sent the user information to the next form
        private void btnInventory_Click(object sender, EventArgs e)
        {
            Inventory frmInventory = new Inventory(currentUser);
            frmInventory.ShowDialog();
        }

        //open new form and sent the user information to the next form
        private void btnAdmin_Click(object sender, EventArgs e)
        {
            Admin frmAdmin = new Admin(currentUser);
            frmAdmin.ShowDialog();
        }

        //open new form and sent the user information to the next form
        private void btnWarehouse_Click(object sender, EventArgs e)
        {
            Warehouse frmWarehouse = new Warehouse(currentUser);
            frmWarehouse.ShowDialog();
        }

        private void btnOrder_Click(object sender, EventArgs e)
        {
            Order frmOrder = new Order(currentUser);
            frmOrder.ShowDialog();
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            PointOfSale frmPOS = new PointOfSale(currentUser);
            frmPOS.ShowDialog();
        }
    }
}
