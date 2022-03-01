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
    public partial class AddTo : Form
    {
        User currentUser;
        int itemID;
        string transactionType;
        string[] orderType = { "BACKORDER", "EMERGENCY", "ORDER" };

        public AddTo(User u, int iID, string type)
        {
            InitializeComponent();
            currentUser = u;
            itemID = iID;
            transactionType = type;
        }

        private void AddTo_Load(object sender, EventArgs e)
        {
            lblTitle.Text = "Add " + itemID + " to " + transactionType;
            
            if (orderType.Contains(transactionType) == false)
                lblCaseSize.Visible = false;
            else
                lblCaseSize.Visible = true;
        }
    }
}
