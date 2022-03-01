using MySql.Data.MySqlClient;
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
    public partial class ReceiveItems : Form
    {
        User currentUser = new User();
        int transactionID;

        DataTable waitingDt = new DataTable();
        DataTable transactionDt = new DataTable();
        DataTable inventoryDt = new DataTable();
        DataTable transactionLineDt = new DataTable();
        static string connectionString = "datasource=localhost;port=3306;database=bullseye;" +
        "username=david;password=david";
        //create connection
        static MySqlConnection connDB = new MySqlConnection(connectionString);

        public ReceiveItems(User u, int id)
        {
            InitializeComponent();

            currentUser = u;
            transactionID = id;
        }

        private void ReceiveItems_Load(object sender, EventArgs e)
        {
            connDB.Open();
            resetForm();
        }

        private void ReceiveItems_FormClosing(object sender, FormClosingEventArgs e)
        {
            connDB.Close();
        }

        private void resetForm()
        {
            string userID = currentUser.getUserID();
            string roleID = currentUser.getRoleID();
            string locationName = currentUser.getLocationName();
            lblUserInfo.Text = userID + ", " + roleID + ", Location: " + locationName;

            string setWaiting = getCmd();
            fillDgv(setWaiting);

            if (HelpMethods.catchError(() => transactionTableAdapter.GetData()) == false)
                this.Close();
            else
                transactionDt = transactionTableAdapter.GetData();

            HelpMethods.setupDgv(dgvWaiting);
            dgvWaiting.ClearSelection();

            
            btnSigns.Enabled = false;
            if (ifAllScanned())
                btnSigns.Enabled = true;
            

        }

        private string getCmd()
        {
            string cmd = "select transactionline.transactionID, transactionline.itemID, item.itemName, transactionline.quantity " +
                     "from transactionline inner join item on transactionline.itemID = item.itemID and transactionline.transactionID = " +
                     transactionID;
            return cmd;
        }

        private void fillDgv(string cmd)
        {
            MySqlDataAdapter trlAdapter = new MySqlDataAdapter(cmd, connDB);

            waitingDt.Clear();
            waitingDt.TableName = "waitingDt";
            if (HelpMethods.catchError(() => trlAdapter.Fill(waitingDt)) == false)
                this.Close();

            bdsWaiting.DataSource = waitingDt;
            dgvWaiting.DataSource = bdsWaiting;

            //dgvInventory.AutoResizeColumns();


        }

        private bool ifAllScanned()
        {
            bool b = true;
            foreach (DataGridViewRow r in dgvWaiting.Rows)
            {
                if (r.DefaultCellStyle.BackColor != Color.Blue)
                {
                    b = false;
                    break;
                }
                    
            }
            
            return b;
        }

        private void btnScanAll_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow r in dgvWaiting.Rows)
            {
                if (r.DefaultCellStyle.BackColor != Color.Blue)
                {
                    r.DefaultCellStyle.BackColor = Color.Blue;
                }

            }

            if (ifAllScanned())
            {
                btnScanAll.Enabled = false;
                btnScanOne.Enabled = false;
                btnSigns.Enabled = true;
            }
                
        }

        private void btnScanOne_Click(object sender, EventArgs e)
        {
            if (dgvWaiting.SelectedRows.Count != 1)
                MessageBox.Show("Please select an item to proceed", "Warning");
            else if(dgvWaiting.SelectedRows[0].DefaultCellStyle.BackColor != Color.Blue)
            {
                dgvWaiting.SelectedRows[0].DefaultCellStyle.BackColor = Color.Blue;
            }

            btnSigns.Enabled = false;
            if (ifAllScanned())
            {
                btnSigns.Enabled = true;
                btnScanOne.Enabled = false;
                btnScanAll.Enabled = false;
            }
        }

        private void btnSigns_Click(object sender, EventArgs e)
        {
            if (transactionDt.Select("transactionID=" + transactionID)[0]["transactionStatus"].ToString() != "IN TRANSIT")
                MessageBox.Show("This order is not IN TRANSIT", "Error");
            else
            {
                DialogResult ifSign = MessageBox.Show("Do you want to sign and accept those items?", "Confirm information", MessageBoxButtons.YesNo);
                if (ifSign == DialogResult.Yes)
                {
                    if (HelpMethods.catchError(() => inventoryTableAdapter.GetData()) == false)
                        resetForm();
                    else
                    {
                        inventoryDt = inventoryTableAdapter.GetData();
                    }

                    foreach (DataGridViewRow row in dgvWaiting.Rows)
                    {
                        int itemID = Convert.ToInt32(row.Cells["itemID"].Value);
                        int quantity = Convert.ToInt32(row.Cells["quantity"].Value);
                        int vhQuan = Convert.ToInt32(inventoryDt.Select("locationID='VHCL' and itemID=" + itemID)[0]["quantity"]);
                        int updateVhTo = vhQuan - quantity;
                        if (updateVhTo ==0)
                        {
                            if (HelpMethods.catchError(() => inventoryTableAdapter.DeleteFromInventory(itemID, "VHCL")) == false)
                                resetForm();
                        }
                        else
                        {
                            if (HelpMethods.catchError(() => inventoryTableAdapter.DeductFormWare(updateVhTo, itemID, "VHCL")) == false)
                                resetForm();
                        }
                        

                        string locID = currentUser.getLocationID();
                        if (inventoryDt.Select("locationID='"+locID+"' and itemID=" + itemID).Count() < 1)
                        {
                            if (HelpMethods.catchError(() => inventoryTableAdapter.InsertIntoInventory(itemID, locID, quantity, null, 0)) == false)
                                resetForm();
                        }
                        else
                        {
                            int updateStTo = Convert.ToInt32(inventoryDt.Select("locationID='"+ locID+"' and itemID=" + itemID)[0]["quantity"]) + quantity;
                            if (HelpMethods.catchError(() => inventoryTableAdapter.DeductFormWare(updateStTo, itemID, locID)) == false)
                                resetForm();
                        }
                    }

                    string oldNote = transactionDt.Select("transactionID = " + transactionID)[0]["notes"].ToString();
                    string status = "DELIVERED";
                    string originalStatus = transactionDt.Select("transactionID = " + transactionID)[0]["transactionStatus"].ToString();
                    string note = string.Concat(oldNote, "-->", "From '" + originalStatus + "' to '" + status + "'");

                    if (HelpMethods.catchError(() => transactionTableAdapter.UpdateStatusAndNote(status, note, transactionID)) == false)
                        resetForm();

                    MessageBox.Show("This order has been received", "Information");
                    resetForm();
                }
            }
        }

        private void dgvWaiting_SelectionChanged(object sender, EventArgs e)
        {
            btnScanAll.Enabled = false;
            btnScanOne.Enabled = false;
            
            if (dgvWaiting.SelectedRows.Count >= 1)
            {
                if (dgvWaiting.SelectedRows[0].DefaultCellStyle.BackColor != Color.Blue)
                    btnScanOne.Enabled = true;
                if (!ifAllScanned())
                    btnScanAll.Enabled = true;
            }
        }
    }
}
