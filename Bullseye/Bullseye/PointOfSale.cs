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
    public partial class PointOfSale : Form
    {
        User currentUser = new User();
        int transacitonID;

        string sale = "Accept Payment";
        string re = "Return Complete";

        DataTable transactionDt = new DataTable();
        DataTable transactionLineDt = new DataTable();
        DataTable itemDt = new DataTable();
        DataTable inventoryDt = new DataTable();

        public PointOfSale(User u)
        {
            InitializeComponent();
            currentUser = u;
        }

        //create a connection string
        static string connectionString = "datasource=localhost;port=3306;database=bullseye;" +
        "username=david;password=david";
        //create connection
        static MySqlConnection connDB = new MySqlConnection(connectionString);

        private void PointOfSale_Load(object sender, EventArgs e)
        {
            connDB.Open();
            resetForm();
        }

        private void resetForm()
        {
            string userID = currentUser.getUserID();
            string roleID = currentUser.getRoleID();
            string locationName = currentUser.getLocationName();
            lblUserInfo.Text = userID + ", " + roleID + ", Location: " + locationName;

            swithCtrls(false);

            HelpMethods.setupDgv(dgvItems);
            dgvItems.ClearSelection();

            if (HelpMethods.catchError(() => transactionTableAdapter.GetData()) == false || 
                HelpMethods.catchError(() => transactionlineTableAdapter.GetData()) == false||
                HelpMethods.catchError(() => itemTableAdapter.GetData()) == false||
                HelpMethods.catchError(() => inventoryTableAdapter.GetData()) == false)
                this.Close();
            else
            {
                transactionDt = transactionTableAdapter.GetData();
                transactionLineDt = transactionlineTableAdapter.GetData();
                itemDt = itemTableAdapter.GetData();
                inventoryDt = inventoryTableAdapter.GetData();
            }
        }

        private void swithCtrls(bool b)
        {
            btnReturn.Enabled = !b;
            btnSale.Enabled = !b;
            picCancel.Visible = b;

            lblTitle.Visible = b;

            lblInumInput.Visible = b;
            mtxtItemNumber.Visible = b;
            lblQuanInput.Visible = b;
            mtxtQuantities.Visible = b;
            btnAdd.Visible = b;
            btnRemove.Visible = b;

            lblItemNumTitle.Visible = b;
            lblItemNum.Visible = b;
            lblSubtotalTitle.Visible = b;
            lblSubtotal.Visible = b;
            lblTaxTitle.Visible = b;
            lblTax.Visible = b;
            lblGrandTotalTitle.Visible = b;
            lblGrandTotal.Visible = b;
            btnConfirm.Visible = b;
        }

        private void resetCtrlData(string SorR)
        {
            int newTid = Convert.ToInt32(transactionDt.Compute("max([transactionID])", string.Empty)) + 1;
            mtxtItemNumber.Text = "";
            mtxtQuantities.Text = "";
            lblItemNum.Text = "0";
            btnRemove.Enabled = false;
            btnAdd.Enabled = true;
            if (SorR == sale)
            {
                lblTitle.Text = "Sale #: " + newTid.ToString();
                lblSubtotal.Text = "$0.00";
                lblTax.Text= "$0.00";
                lblGrandTotal.Text= "$0.00";
                btnConfirm.Text = sale;
            }
            else
            {
                lblTitle.Text = "Return #: " + newTid.ToString();
                lblSubtotal.Text = "-$0.00";
                lblTax.Text = "-$0.00";
                lblGrandTotal.Text = "-$0.00";
                btnConfirm.Text = re;
                btnRemove.Visible = false;
            }
            btnConfirm.Enabled = false;
        }

        private void btnSale_Click(object sender, EventArgs e)
        {
            resetCtrlData(sale);
            swithCtrls(true);
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            resetCtrlData(re);
            swithCtrls(true);
            
        }

        private void picCancel_Click(object sender, EventArgs e)
        {
            swithCtrls(false);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            int itemNum = Convert.ToInt32(mtxtItemNumber.Text);
            int quan= Convert.ToInt32(mtxtQuantities.Text);
            string currentLoc = currentUser.getLocationID();
            if (mtxtItemNumber.Text.Length != 5)
                MessageBox.Show("Please enter a valid item number!", "Warning");
            else if(itemDt.Select("itemID="+ itemNum).Count()==0)
                MessageBox.Show("Please enter a valid item number!", "Warning");
            else if(mtxtQuantities.Text=="")
                MessageBox.Show("Please enter a valid quantity!", "Warning");
            else if(quan<=0)
                MessageBox.Show("Please enter a valid quantity!", "Warning");
            //else if (Convert.ToInt32(inventoryDt.Select("itemID=" + itemNum + " and locationID='" + currentLoc + "'")[0]["quantity"]) < quan)
            //    MessageBox.Show("Please enter a valid quantity!", "Warning");
            else
            {
                int invQuan = Convert.ToInt32(inventoryDt.Select("itemID=" + itemNum + " and locationID='" + currentLoc + "'")[0]["quantity"]);
                if (btnConfirm.Text == sale && invQuan < quan)
                    MessageBox.Show("Stock is not enough!", "Warning");
                else
                {
                    string iName = itemDt.Select("itemID=" + itemNum)[0]["itemName"].ToString();
                    string category= itemDt.Select("itemID=" + itemNum)[0]["categoryName"].ToString();
                    string price = "";
                    decimal dprice = 0;
                    if (searchDgv(itemNum, dgvItems))
                    {
                        foreach (DataGridViewRow row in dgvItems.Rows)
                        {
                            if (Convert.ToInt32(row.Cells["ItemID"].Value)==itemNum)
                            {
                                int newQuan = Convert.ToInt32(row.Cells["quantity"].Value) + quan;
                                if (btnConfirm.Text == sale && invQuan < newQuan)
                                    MessageBox.Show("Stock is not enough!", "Warning");
                                else
                                {
                                    dprice = Convert.ToDecimal(itemDt.Select("itemID=" + itemNum)[0]["retailPrice"]);
                                    price = (dprice * newQuan).ToString("f2");
                                    row.Cells["Price"].Value = price;
                                    row.Cells["quantity"].Value = newQuan;
                                    calTotal();
                                }
                                break;
                            }
                        }
                    }
                    else
                    {
                        dprice = Convert.ToDecimal(itemDt.Select("itemID=" + itemNum)[0]["retailPrice"]);
                        price = (dprice * quan).ToString("f2");
                        dgvItems.Rows.Add(itemNum, iName, quan.ToString(), price, category);
                    }
                }
            }
        }

        private bool searchDgv(int id, DataGridView dgv)
        {
            bool b = false;
            if (dgv.RowCount > 0)
            {
                foreach (DataGridViewRow row in dgv.Rows)
                {
                    if (Convert.ToInt32(row.Cells["ItemID"].Value)==id)
                    {
                        b = true;
                        break;
                    }
                }
            }

            return b;
        }

        private void calTotal()
        {
            if (dgvItems.RowCount > 0)
            {
                int itemNum = 0;
                decimal subtotal = 0;
                decimal tax = 0;
                decimal grandTotal = 0;

                foreach (DataGridViewRow row in dgvItems.Rows)
                {
                    itemNum += Convert.ToInt32(row.Cells["quantity"].Value);
                    subtotal += Convert.ToDecimal(row.Cells["price"].Value);
                }
                tax = subtotal * (decimal)0.15;
                grandTotal = subtotal + tax;

                lblItemNum.Text = itemNum.ToString();
                
                if(btnConfirm.Text == sale)
                {
                    lblSubtotal.Text = "$" + subtotal.ToString("f2");
                    lblTax.Text = "$" + tax.ToString("f2");
                    lblGrandTotal.Text = "$" + grandTotal.ToString("f2");
                }
                else
                {
                    lblSubtotal.Text = "-$" + subtotal.ToString("f2");
                    lblTax.Text = "-$" + tax.ToString("f2");
                    lblGrandTotal.Text = "-$" + grandTotal.ToString("f2");
                }
            }
            else
            {
                lblItemNum.Text = "0";
                if (btnConfirm.Text == sale)
                {
                    lblSubtotal.Text = "$0.00";
                    lblTax.Text = "$0.00"; ;
                    lblGrandTotal.Text = "$0.00"; ;
                }
                else
                {
                    lblSubtotal.Text = "-$0.00";
                    lblTax.Text = "-$0.00";
                    lblGrandTotal.Text = "-$0.00";
                }
            }
        }

        private void dgvItems_SelectionChanged(object sender, EventArgs e)
        {
            
        }

        private void dgvItems_RowsRemoved(object sender, DataGridViewRowsRemovedEventArgs e)
        {
            if (dgvItems.RowCount > 0)
            {
                
                btnConfirm.Enabled = true;
                if(btnConfirm.Text==sale)
                    btnRemove.Enabled = true;
            }
            else
            {
                btnRemove.Enabled = false;
                btnConfirm.Enabled = false;
            }
            calTotal();
        }

        private void dgvItems_RowsAdded(object sender, DataGridViewRowsAddedEventArgs e)
        {
            if (dgvItems.RowCount > 0)
            {
                
                btnConfirm.Enabled = true;
                if (btnConfirm.Text == sale)
                    btnRemove.Enabled = true;
            }
            else
            {
                btnRemove.Enabled = false;
                btnConfirm.Enabled = false;
            }
            calTotal();
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            if (dgvItems.SelectedRows.Count <= 0)
            {
                MessageBox.Show("Please select an item to Process", "Warning");
            }
            else
            {
                dgvItems.Rows.RemoveAt(dgvItems.SelectedCells[0].RowIndex);
            }
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            string mes = "";
            string transType = "";
            string locID = currentUser.getLocationID();
            string transStatus = "COMPLETE";
            string note = "";
            if (btnConfirm.Text == sale)
            {
                mes = "Accept payment of " + lblGrandTotal.Text + "?\nNo more changes could be made after 'yes' is clicked";
                transType = "SALE";
            }
            else
            {
                mes = "Accept this return?\nNo more changes could be made after 'yes' is clicked";
                transType = "GAIN";
            }  

            DialogResult ifConfirm = MessageBox.Show(mes, "Confirm information", MessageBoxButtons.YesNo);
            if (ifConfirm == DialogResult.Yes)
            {
                int itemID;
                int quan;
                int storeQuan;
                int updateTo;
                note = transType + ": " + lblGrandTotal.Text;
                if (HelpMethods.catchError(() => transactionTableAdapter.InsertIntoTransaction(transType, locID, DateTime.Now, "NEW", note)) == false)
                    resetForm();
                transacitonID = Convert.ToInt32(transactionTableAdapter.getNewsetID(locID, transType, "NEW").Rows[0]["transactionID"]);

                if (btnConfirm.Text == sale)
                {
                    foreach (DataGridViewRow row in dgvItems.Rows)
                    {
                        itemID = Convert.ToInt32(row.Cells["ItemID"].Value);
                        quan = Convert.ToInt32(row.Cells["quantity"].Value);
                        storeQuan = Convert.ToInt32(inventoryDt.Select("itemID=" + itemID + " and locationID='" + locID + "'")[0]["quantity"]);
                        updateTo = storeQuan - quan;
                        if (HelpMethods.catchError(() => inventoryTableAdapter.DeductFormWare(updateTo, itemID, locID)) == false||
                            HelpMethods.catchError(() => transactionlineTableAdapter.InsertIntoTransactionLine(transacitonID, itemID, quan)) == false)
                            resetForm();

                    }
                }
                else
                {
                    foreach (DataGridViewRow row in dgvItems.Rows)
                    {
                        itemID = Convert.ToInt32(row.Cells["ItemID"].Value);
                        quan = Convert.ToInt32(row.Cells["quantity"].Value);
                        storeQuan = Convert.ToInt32(inventoryDt.Select("itemID=" + itemID + " and locationID='" + locID + "'")[0]["quantity"]);
                        updateTo = storeQuan + quan;
                        if (HelpMethods.catchError(() => inventoryTableAdapter.DeductFormWare(updateTo, itemID, locID)) == false ||
                            HelpMethods.catchError(() => transactionlineTableAdapter.InsertIntoTransactionLine(transacitonID, itemID, quan)) == false)
                            resetForm();

                    }
                }
                if (HelpMethods.catchError(() => transactionTableAdapter.UpdateStatus(transStatus, transacitonID)) == false)
                    resetForm();

                MessageBox.Show("Completed!", "Information");
                resetForm();
                dgvItems.Rows.Clear();
            }
        }

        private void PointOfSale_FormClosing(object sender, FormClosingEventArgs e)
        {
            connDB.Close();
        }
    }
}
