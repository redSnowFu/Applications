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
    public partial class Inventory : Form
    {
        //global variable 'all'
        string all = "All";
        string not = "Not";
        //global variable locID
        string locID;
        string eO = "EMERGENCY";
        string rO = "ORDER";
        int transID;

        string[] orderType = { "BACKORDER", "EMERGENCY", "ORDER", "RETURN" };
        string[] deduction = { "DAMAGE", "LOSS", "SALE" };
        string[] adding = { "GAIN" };
        Dictionary<string, int> order = new Dictionary<string, int>();
        //create a user object to contain the user being sent in, class level
        User currentUser = new User();
        
        //a datatable for quering the inventory table
        DataTable inventoryDt = new DataTable();
        //a datatable for quering the item table
        DataTable itemDt = new DataTable();
        //a datatable for quering the inner join table
        DataTable mixDt = new DataTable();
        //a datatable reads ordering data
        DataTable orderingDt = new DataTable();
        //a datatable for quering the transaction table
        DataTable transactionDt = new DataTable();
        //a datatable for quering the transactionline table
        DataTable transactionLineDt = new DataTable();
        DataTable transactionTypeDt = new DataTable();

        DataTable locDt = new DataTable();
        
        //declare a dataview
        DataView inventoryDv = new DataView();


        public Inventory(User u)
        {
            InitializeComponent();
            //make the the class level variable equal to this user object
            currentUser = u;
        }
        //create a connection string
        static string connectionString = "datasource=localhost;port=3306;database=bullseye;" +
        "username=david;password=david";
        //create connection
        static MySqlConnection connDB = new MySqlConnection(connectionString);

        //form load, open the connection and reset the form
        private void Inventory_Load(object sender, EventArgs e)
        {
            connDB.Open();
            ResetForm();
            
        }
        //close the connection at form closing
        private void Inventory_FormClosing(object sender, FormClosingEventArgs e)
        {
            connDB.Close();
        }

        //funtion name: ResetForm
        //description: reset the form into the original display
        //sent: none
        //return: none
        private void ResetForm()
        {
            string userID = currentUser.getUserID();
            string roleID = currentUser.getRoleID();
            string locationName = currentUser.getLocationName();
            lblUserInfo.Text = userID + ", " + roleID + ", Location: " + locationName;
            HelpMethods.clearCbo(grpSearch, grpLocationSearch,grpAddTo);
            HelpMethods.clearCtrls(grpSearch);

            string fillOrdering = "select transactionline.itemID, sum(transactionline.quantity) as ordering, " +
                "transaction.originalLocationID from transactionline inner join transaction " +
                "on transactionline.transactionID=transaction.transactionID and transaction.transactionType in ('ORDER', 'EMERGENCY') " +
                "AND transaction.transactionStatus not in ('COMPLETE') group by transactionline.itemID, transaction.originalLocationID";
            fillOrderingDt(fillOrdering);
            

            string resetDataCmd = inventoryCmd();
            FillInventoryDgv(resetDataCmd);
            if (HelpMethods.catchError(() => transactionTableAdapter.GetData()) == false || HelpMethods.catchError(() => transactionlineTableAdapter.GetData()) == false)
                this.Close();
            else
            {
                transactionDt = transactionTableAdapter.GetData();
                transactionLineDt = transactionlineTableAdapter.GetData();
            }

            HelpMethods.setupDgv(dgvInventory);

            fillInventoryCbos();
            cboLocation.Text = currentUser.getLocationID();
            dgvInventory.ClearSelection();
            grpReorder.Enabled = false;
            
            locID = currentUser.getLocationID();
            checkPermission();
            HelpMethods.grpsToggle(false, grpAddPanel, btnRefresh, grpLocationSearch, grpSearch, grpReorder,grpConvenience);
            grpOrderAndReturn.Visible = false;
            grpAddTo.Enabled = false;
        }

        //funtion name: inventoryCmd
        //description: create an mysql command for inner joining two tables
        //sent: none
        //return: none
        private string inventoryCmd()
        {
            

            string cmd = "SELECT inventory.itemID, item.itemName, item.sku, item.description, item.caseSize,inventory.quantity, " +
                "inventory.reorderThreshold, inventory.reorderLevel, " +
                "item.categoryName, inventory.locationID FROM inventory INNER JOIN item ON inventory.itemID = item.itemID ";
            return cmd;
        }

        //funtion name: FillInventoryDgv
        //description: fill the datagridview of the form by using the sql cmd, datatable and connection
        //sent: none
        //return: none
        private void FillInventoryDgv(string cmd)
        {
            MySqlDataAdapter inventoryAdapter = new MySqlDataAdapter(cmd, connDB);

            mixDt.Clear();
            mixDt.TableName = "mixDt";
            if (HelpMethods.catchError(() => inventoryAdapter.Fill(mixDt)) == false)
                this.Close();

            bdsInventory.DataSource = mixDt;
            dgvInventory.DataSource = bdsInventory;

            //dgvInventory.AutoResizeColumns();

            
        }

        private void fillOrderingDt(string cmd)
        {
            MySqlDataAdapter orderingAdapter = new MySqlDataAdapter(cmd, connDB);

            orderingDt.Clear();
            orderingDt.TableName = "orderingDt";
            if (HelpMethods.catchError(() => orderingAdapter.Fill(orderingDt)) == false)
                this.Close();
            
        }
        //funtion name: fillInventoryCbos
        //description: fill the comboboxes of this form by using the helpmethod to query the database
        //sent: none
        //return: none
        private void fillInventoryCbos()
        {
            if (HelpMethods.catchError(() => inventoryTableAdapter.GetData()) == false || 
                HelpMethods.catchError(() => itemTableAdapter.GetData()) == false||
                HelpMethods.catchError(() => transactiontypeTableAdapter.GetData()) == false)
                this.Close();
            else
            {
                inventoryDt = inventoryTableAdapter.GetData();
                HelpMethods.populateCbo(inventoryDt, "locationID", cboLocation, all);
                itemDt = itemTableAdapter.GetData();
                HelpMethods.populateCbo(itemDt, "categoryName", cboCategory, all);
                transactionTypeDt = transactiontypeTableAdapter.GetData();
                HelpMethods.populateCbo(transactionTypeDt, "transactionType", cboAddtoTypes, not);
                cboAddtoTypes.Items.Remove("BACKORDER");
                cboAddtoTypes.SelectedIndex = 0;
            }
        }

        //this button can reset the form
        private void btnRefresh_Click(object sender, EventArgs e)
        {
            ResetForm();
        }

        //this button provide search function
        private void btnSearch_Click(object sender, EventArgs e)
        {
            //get what user input in the controls
            string category = cboCategory.Text;
            string itemID = txtItemID.Text;
            
            string itemName = txtItemName.Text;
            string sku = txtItemSku.Text;
            string description = txtDescription.Text;
            //call helpmethod, if the string contains ' then change it to ''
            HelpMethods.replaceStrChar(category, itemID, itemName, sku, description);

            //create filter command
            string filterCmd = string.Format("convert(itemID, 'System.String') like '%{0}%'", itemID) +
                " AND " + string.Format("convert(sku, 'System.String') like '%{0}%'", sku);
            
            List<string> itemNames = new List<string>();
            itemNames.Clear();
            if (itemName != "")
            {
                itemNames = itemName.Split(' ').ToList();
                itemName = "";
                for (int i = 0; i < itemNames.Count; i++)
                {
                    itemName += " AND itemName like '%" + itemNames[i] + "%'";
                }
                filterCmd += itemName;
            }

            List<string> descriptions = new List<string>();
            descriptions.Clear();
            if (description != "")
            {
                descriptions = description.Split(' ').ToList();
                description = "";
                for(int i =0;i< descriptions.Count; i++)
                {
                    description+= " AND description like '%" + descriptions[i] + "%'";
                }
                filterCmd += description;
            }

            if (category == all)
                category = "";
            filterCmd += " AND " + string.Format("convert(categoryName, 'System.String') like '%{0}%'", category);
            
            if (chkUnderThreshold.Checked)
            {
                filterCmd += " AND quantity <= reorderThreshold";

            }
            
            if (cboLocation.Text != all)
            {
                filterCmd += " AND " + string.Format("convert(locationID, 'System.String') like '%{0}%'", cboLocation.Text);
            }

            //call helpmethod, to filter the datagridview
            HelpMethods.filterHelp(inventoryDv, mixDt, dgvInventory, filterCmd);
            
        }

        //the changes of the cbo will filter the datagridview
        private void cboLocation_SelectedIndexChanged(object sender, EventArgs e)
        {
            string location = cboLocation.Text;
            if (location == all)
                location = "";
            HelpMethods.replaceStrChar(location);
            string filterCmd = string.Format("convert(locationID, 'System.String') like '%{0}%'", location);

            HelpMethods.filterHelp(inventoryDv, mixDt, dgvInventory, filterCmd);
            dgvInventory.ClearSelection();
        }

        private void txtItemID_KeyPress(object sender, KeyPressEventArgs e)
        {
            HelpMethods.RestrictCharacters("!@#$%^&*()_+=-`~';:\\|]}[{/?><.,",e);
        }

        private void txtItemName_KeyPress(object sender, KeyPressEventArgs e)
        {
            HelpMethods.RestrictCharacters("!@#$%^&*()_+=-`~';:\\|]}[{/?><.,", e);
        }

        private void txtItemSku_KeyPress(object sender, KeyPressEventArgs e)
        {
            HelpMethods.RestrictCharacters("!@#$%^&*()_+=-`~';:\\|]}[{/?><.,", e);
        }

        private void txtDescription_KeyPress(object sender, KeyPressEventArgs e)
        {
            HelpMethods.RestrictCharacters("!@#$%^&*()_+=-`~';:\\|]}[{/?><.,", e);
        }

        private void dgvInventory_SelectionChanged(object sender, EventArgs e)
        {
            
            if(dgvInventory.SelectedRows.Count == 1)
            {
                //nudCaseSize.Value = Convert.ToDecimal(dgvInventory.SelectedRows[0].Cells["caseSize"].Value);
                //nudCaseSize.Increment= Convert.ToDecimal(dgvInventory.SelectedRows[0].Cells["caseSize"].Value);
                //nudCaseSize.Minimum= Convert.ToDecimal(dgvInventory.SelectedRows[0].Cells["caseSize"].Value);
                
                if (cboLocation.Text != "VHCL")
                    nudReorderLevel.Value = Convert.ToDecimal(dgvInventory.SelectedRows[0].Cells["reorderLevel"].Value);
                else
                    nudReorderLevel.Value = nudReorderLevel.Minimum;
                if (cboLocation.Text!= "VHCL")
                    nudReorderThreshold.Value= Convert.ToDecimal(dgvInventory.SelectedRows[0].Cells["reorderThreshold"].Value);
                else
                    nudReorderThreshold.Value = nudReorderThreshold.Minimum;

                string rowLoc = dgvInventory.SelectedRows[0].Cells["locationID"].Value.ToString();
                if (currentUser.getLocationID() == rowLoc&&currentUser.getActions().Contains("UPDATE INVENTORY"))
                    grpReorder.Enabled = true;
                else if(currentUser.getActions().Contains("CRUD"))
                    grpReorder.Enabled = true;
                else
                    grpReorder.Enabled = false;


                if (currentUser.getActions().Contains("CREATE ORDER") && currentUser.getLocationID() == rowLoc)
                    grpAddTo.Enabled = true;
                else if (currentUser.getActions().Contains("CRUD"))
                    grpAddTo.Enabled = true;
                else
                    grpAddTo.Enabled = false;
            }
        }

        private void btnUpdateReorder_Click(object sender, EventArgs e)
        {
            //decimal caseSize= Convert.ToDecimal(dgvInventory.SelectedRows[0].Cells["caseSize"].Value);
            if (dgvInventory.SelectedRows.Count != 1)
                MessageBox.Show("Please select an item to proceed", "Warning");
            else
            {
                int itemID = Convert.ToInt32(dgvInventory.SelectedRows[0].Cells["itemID"].Value);
                int quan = Convert.ToInt32(dgvInventory.SelectedRows[0].Cells["quantity"].Value);
                int reorderLevel = Convert.ToInt32(nudReorderLevel.Value);
                
                if (nudReorderLevel.Value <= 0)
                    MessageBox.Show("The reorder level of this item must be more than 0", "Input Error");
                else if(nudReorderLevel.Value <= nudReorderThreshold.Value)
                    MessageBox.Show("The reorder level shouldn't be less or equal to the reorder threshold", "Input Error");
                else
                {
                    HelpMethods.catchError(() => inventoryTableAdapter.UpdateReorder((int)nudReorderThreshold.Value, reorderLevel, itemID, currentUser.getLocationID()));
                    ResetForm();
                    MessageBox.Show("Update completed", "Notice");
                }
            }
        }

        private void btnAddtoOrder_Click(object sender, EventArgs e)
        {
            
        }

        private int getTransID(string locID, DataTable dt, string str)
        {
            int id = 0;
            string expression = "transactionType='" + str + "' AND originalLocationID = '" + locID + "' AND transactionStatus = 'NEW'";
            DataRow[] foundRows = dt.Select(expression);
            if (foundRows.Count() >= 1)
                id = Convert.ToInt32(foundRows[0]["transactionID"]);
            return id;
        }

        //private void checkOrder(string locID, DataTable dt)
        //{
        //    string expression = "transactionType='ORDER' AND originalLocationID = '" + locID + "' AND transactionStatus = 'NEW'";
        //    DataRow[] foundRows = dt.Select(expression);
        //    if (foundRows.Count() >= 1&& currentUser.getActions().Contains("CREATE ORDER"))
        //    {
        //        btnAddtoOrder.Enabled = true;
        //        btnGotoOrder.Enabled = true;
        //    }

        //}

        private void checkPermission()
        {
            btnAddto.Enabled = false;
            btnAddall.Enabled = false;
            if (currentUser.getActions().Contains("CREATE ORDER") || currentUser.getActions().Contains("CRUD"))
            {
                btnAddto.Enabled = true;
                btnAddall.Enabled = true;
            }
                
        }

        private void btnGotoOrder_Click(object sender, EventArgs e)
        {
            //CreateOrder frmCreateOrder = new CreateOrder(currentUser, transID);
            //frmCreateOrder.ShowDialog();
            Order frmOrder = new Order(currentUser);
            frmOrder.ShowDialog();
        }

        private void btnAddtoE_Click(object sender, EventArgs e)
        {
            
        }

        private void btnAddall_Click(object sender, EventArgs e)
        {
            if (currentUser.getActions().Contains("UPDATE ALL ORDER") || currentUser.getActions().Contains("CRUD"))
            {
                if (HelpMethods.catchError(() => locationTableAdapter.GetData()) == false)
                    ResetForm();
                else
                {
                    locDt = locationTableAdapter.GetData();
                    string getStores = "locationTypeID='Store'";
                    DataRow[] rows = locDt.Select(getStores);
                    foreach (DataRow r in rows)
                    {
                        string locatID = r["LocationID"].ToString();
                        DataRow[] neworders = transactionDt.Select("transactionType='ORDER' and originalLocationID='" + locatID + "' and transactionStatus='NEW'");
                        if (neworders.Count() < 1)
                        {
                            MessageBox.Show("Location ID: " + locatID + " doesn't have a order, please create one first", "Error");
                            break;
                        }

                        int tID = Convert.ToInt32(neworders[0]["transactionID"]);
                        string getInven = "locationID='" + locatID + "'";
                        DataRow[] invenRows = mixDt.Select(getInven);
                        foreach (DataRow inR in invenRows)
                        {
                            int iID = Convert.ToInt32(inR["itemID"]);
                            int stock = Convert.ToInt32(inR["quantity"]);
                            int rethreshold = Convert.ToInt32(inR["reorderThreshold"]);
                            int relevel = Convert.ToInt32(inR["reorderLevel"]);
                            int ordering = 0;
                            DataRow[] getOrdering = orderingDt.Select("originalLocationID='" + locatID + "' and itemID=" + iID);
                            if (getOrdering.Count() == 1)
                                ordering = Convert.ToInt32(getOrdering[0]["ordering"]);
                            //if (inR["ordering"] != DBNull.Value)
                            //    ordering = Convert.ToInt32(inR["ordering"]);
                            int cSize = Convert.ToInt32(inR["caseSize"]);

                            if ((stock + ordering) <= rethreshold)
                            {
                                if (transactionLineDt.Select("transactionID="+tID+" and itemID=" + iID).Count() < 1)
                                {
                                    if ((relevel - stock - ordering) / cSize <= 0)
                                    {
                                        if (HelpMethods.catchError(() => transactionlineTableAdapter.InsertIntoTransactionLine(tID, iID, 1 * cSize)) == false)
                                            ResetForm();
                                    }
                                    else
                                    {
                                        if (HelpMethods.catchError(() => transactionlineTableAdapter.InsertIntoTransactionLine(tID, iID, ((relevel - stock - ordering) / cSize) * cSize)) == false)
                                            ResetForm();
                                    }
                                }
                                else
                                {
                                    if ((relevel - stock - ordering) / cSize <= 0)
                                    {
                                        if (HelpMethods.catchError(() => transactionlineTableAdapter.UpdateQuantity(1 * cSize, tID, iID)) == false)
                                            ResetForm();
                                    }
                                    else
                                    {
                                        if (HelpMethods.catchError(() => transactionlineTableAdapter.UpdateQuantity(((relevel - stock - ordering) / cSize) * cSize,tID, iID)) == false)
                                            ResetForm();
                                    }
                                }
                            }
                        }
                    }
                }
                MessageBox.Show("Item(s) have added to order(s)", "Successful");
                ResetForm();
            }

            else
            {
                string locatID = currentUser.getLocationID();
                DataRow[] neworders = transactionDt.Select("transactionType='ORDER' and originalLocationID='" + locatID + "' and transactionStatus='NEW'");
                if (neworders.Count() < 1)
                {
                    MessageBox.Show("Location ID: " + locatID + " doesn't have a order, please create one first", "Error");
                }
                else
                {
                    int tID = Convert.ToInt32(neworders[0]["transactionID"]);
                    string getInven = "locationID='" + locatID + "'";
                    DataRow[] invenRows = mixDt.Select(getInven);
                    foreach (DataRow inR in invenRows)
                    {
                        int iID = Convert.ToInt32(inR["itemID"]);
                        int stock = Convert.ToInt32(inR["quantity"]);
                        int rethreshold = Convert.ToInt32(inR["reorderThreshold"]);
                        int relevel = Convert.ToInt32(inR["reorderLevel"]);
                        int ordering = 0;
                        DataRow[] getOrdering = orderingDt.Select("originalLocationID='" + locatID + "' and itemID=" + iID);
                        if (getOrdering.Count() == 1)
                            ordering = Convert.ToInt32(getOrdering[0]["ordering"]);
                        //if (inR["ordering"] != DBNull.Value)
                        //    ordering = Convert.ToInt32(inR["ordering"]);
                        int cSize = Convert.ToInt32(inR["caseSize"]);

                        if ((stock + ordering)<=rethreshold)
                        {
                            
                            if (transactionLineDt.Select("transactionID=" + tID + " and itemID=" + iID).Count() < 1)
                            {
                                if ((relevel - stock - ordering) / cSize <= 0)
                                {
                                    if (HelpMethods.catchError(() => transactionlineTableAdapter.InsertIntoTransactionLine(tID, iID, 1 * cSize)) == false)
                                        ResetForm();
                                }
                                else
                                {
                                    if (HelpMethods.catchError(() => transactionlineTableAdapter.InsertIntoTransactionLine(tID, iID, ((relevel - stock - ordering) / cSize) * cSize)) == false)
                                        ResetForm();
                                }
                            }
                            else
                            {
                                if ((relevel - stock - ordering) / cSize <= 0)
                                {
                                    if (HelpMethods.catchError(() => transactionlineTableAdapter.UpdateQuantity(1 * cSize, tID, iID)) == false)
                                        ResetForm();
                                }
                                else
                                {
                                    if (HelpMethods.catchError(() => transactionlineTableAdapter.UpdateQuantity(((relevel - stock - ordering) / cSize) * cSize, tID, iID)) == false)
                                        ResetForm();
                                }
                            }
                        }
                        
                    }
                    MessageBox.Show("Item(s) have added to your order", "Successful");
                    ResetForm();
                }
                


            }
            
            
        }

        private void btnAddto_Click(object sender, EventArgs e)
        {
            cboAddtoTypes.Enabled = false;
            if (dgvInventory.SelectedRows.Count != 1)
            {
                MessageBox.Show("Please select an item to proceed", "Warning");
            }
            else
            {
                int itemID = Convert.ToInt32(dgvInventory.SelectedRows[0].Cells["itemID"].Value);
                string transactionType = cboAddtoTypes.Text;
                if (orderType.Contains(transactionType) == false)
                {
                    lblTitle.Text = "Add " + itemID + " to " + transactionType;
                    dgvInventory.Enabled = false;
                    if (transactionType == "DAMAGE" || transactionType == "LOSS" || transactionType == "GAIN")
                    {
                        txtReason.Text = "";
                        lblReason.Visible = true;
                        txtReason.Visible = true;
                    }
                    else
                    {
                        lblReason.Visible = false;
                        txtReason.Visible = false;
                    }
                    nudQuan.Value = nudQuan.Minimum;
                    HelpMethods.grpsToggle(true, grpAddPanel, btnRefresh, grpLocationSearch, grpSearch, grpReorder,grpConvenience);
                }
                else
                {
                    
                    if (transactionType == "RETURN" || transactionType == "BACKORDER")
                    {
                        txtNotes.Text = "";
                        lblNotes.Visible = true;
                        txtNotes.Visible = true;
                    }
                    else
                    {
                        lblNotes.Visible = false;
                        txtNotes.Visible = false;
                    }
                    //lstOrdering.Items.Clear();
                    //add item to the list
                    HelpMethods.grpsToggle(true, grpOrderAndReturn, btnRefresh, grpLocationSearch, grpSearch, grpReorder, grpConvenience);

                    //string itemID = dgvInventory.SelectedRows[0].Cells["itemID"].Value.ToString();
                    int quan = Convert.ToInt32(nudCsQuan.Value) * Convert.ToInt32(dgvInventory.SelectedRows[0].Cells["caseSize"].Value);
                    int originalQuan = Convert.ToInt32(dgvInventory.SelectedRows[0].Cells["quantity"].Value);
                    if (transactionType == "RETURN")
                    {
                        if (quan > originalQuan)
                            MessageBox.Show("Return quantity couldn't be bigger than the quantity in your inventory", "Warning");
                        else
                        {
                            
                            order.Add(itemID.ToString(), quan);
                            lstOrdering.DataSource = new BindingSource(order, null);
                            lstOrdering.DisplayMember = "Key";
                            lstOrdering.ValueMember = "Value";
                        }
                    }
                    else
                    {
                        order.Add(itemID.ToString(), quan);
                        lstOrdering.DataSource = new BindingSource(order, null);
                        lstOrdering.DisplayMember = "Key";
                        lstOrdering.ValueMember = "Value";
                    }
                    
                }
                
            }
            
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            HelpMethods.grpsToggle(false, grpAddPanel, btnRefresh, grpLocationSearch, grpSearch, grpReorder, grpConvenience);
            dgvInventory.Enabled = true;
            cboAddtoTypes.Enabled = true;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            int itemID = Convert.ToInt32(dgvInventory.SelectedRows[0].Cells["itemID"].Value);
            string transactionType = cboAddtoTypes.Text;
            string notes = txtReason.Text;
            int quan = Convert.ToInt32(nudQuan.Value);
            int originalQuan = Convert.ToInt32(dgvInventory.SelectedRows[0].Cells["quantity"].Value);
            int updateQuanTo = 0;
            string locatID = dgvInventory.SelectedRows[0].Cells["locationID"].Value.ToString();
            
            
            if (transactionType == "LOSS"|| transactionType == "DAMAGE")
            {
                if (quan > originalQuan)
                {
                    MessageBox.Show("Loss/Damaged quantity couldn't be bigger than the quantity in your inventory", "Warning");
                }
                else
                {
                    updateQuanTo = originalQuan - quan;
                    if (HelpMethods.catchError(() => transactionTableAdapter.InsertIntoTransaction(transactionType, locatID, DateTime.Now, "NEW", notes)) == false ||
                    HelpMethods.catchError(() => transactionTableAdapter.GetData()) == false)
                        ResetForm();
                    else
                    {
                        transactionDt = transactionTableAdapter.GetData();
                        int tID = Convert.ToInt32(transactionDt.Select("originalLocationID='" + locatID + "' and transactionType='" + transactionType + "' and transactionStatus='NEW'", "creationDate DESC")[0]["transactionID"]);
                        if (HelpMethods.catchError(() => transactionlineTableAdapter.InsertIntoTransactionLine(tID, itemID, quan)) == false||
                            HelpMethods.catchError(() => inventoryTableAdapter.DeductFormWare(updateQuanTo, itemID, locatID)) == false||
                            HelpMethods.catchError(() => transactionTableAdapter.UpdateStatus("COMPLETE",tID)) == false)
                            ResetForm();
                        else
                        {
                            MessageBox.Show("this item has been added into the loss/Damage order", "information");
                        }

                    }
                }
                
            }
            HelpMethods.grpsToggle(false, grpAddPanel, btnRefresh, grpLocationSearch, grpSearch, grpReorder, grpConvenience);
            dgvInventory.Enabled = true;
            cboAddtoTypes.Enabled = true;
        }

        private void cboAddtoTypes_SelectedIndexChanged(object sender, EventArgs e)
        {
            string transactionType = cboAddtoTypes.Text;
            lblQuan.Visible = orderType.Contains(transactionType);
            nudCsQuan.Visible = orderType.Contains(transactionType);
            lblcSize.Visible = orderType.Contains(transactionType);
            nudCsQuan.Value = nudCsQuan.Minimum;
        }

        private void btnCancelOrder_Click(object sender, EventArgs e)
        {
            cboAddtoTypes.Enabled = true;
            HelpMethods.grpsToggle(false, grpOrderAndReturn, btnRefresh, grpLocationSearch, grpSearch, grpReorder, grpConvenience);
            order.Clear();
        }

        private void btnSaveOrder_Click(object sender, EventArgs e)
        {
            string transactionType = cboAddtoTypes.Text;
            string locatID = dgvInventory.SelectedRows[0].Cells["locationID"].Value.ToString();
            string notes = "";
            if (transactionType == "RETURN" || transactionType == "BACKORDER")
                notes = txtNotes.Text;
            else if (transactionType == "ORDER" || transactionType == "EMERGENCY")
                notes = "New Order Placed";
            
            if (transactionDt.Select("originalLocationID='" + locatID + "' and transactionType='" + transactionType + "' and transactionStatus='NEW'").Count() < 1)
            {
                if (HelpMethods.catchError(() => transactionTableAdapter.InsertIntoTransaction(transactionType, locatID, DateTime.Now, "NEW", notes)) == false)
                    ResetForm();
            }

            int tID = Convert.ToInt32(transactionTableAdapter.getNewsetID(locatID, transactionType, "NEW").Rows[0]["transactionID"]);
            string[] ids = order.Keys.ToArray();
            int[] quans = order.Values.ToArray();
            if (transactionType == "RETURN")
            {
                for (int i = 0; i < ids.Length; i++)
                {
                    int itemID = Convert.ToInt32(ids[i]);
                    int quan = quans[i];
                    int originalQuan = Convert.ToInt32(inventoryDt.Select("LocationID='" + locatID + "' and itemID=" + itemID)[0]["quantity"]);
                    int updateQuanTo = originalQuan - quan;

                    try
                    {
                        transactionlineTableAdapter.InsertIntoTransactionLine(tID, itemID, quan);
                    }
                    catch (Exception)
                    {
                        int updateTlQuanTo = Convert.ToInt32(transactionLineDt.Select("transactionID='" + tID + "' and itemID=" + itemID)[0]["quantity"]) + quan;
                        HelpMethods.catchError(() => transactionlineTableAdapter.UpdateQuantity(updateTlQuanTo, tID, itemID));
                    }

                    if (HelpMethods.catchError(() => inventoryTableAdapter.DeductFormWare(updateQuanTo, itemID, locatID)) == false ||
                        HelpMethods.catchError(() => transactionTableAdapter.UpdateStatus("SUBMITTED", tID)) == false)
                        ResetForm();

                    try
                    {
                        inventoryTableAdapter.InsertIntoInventory(itemID, "VHCL", quan, null, 0);
                    }
                    catch (Exception)
                    {
                        int updateVhTo = Convert.ToInt32(inventoryDt.Select("locationID='VHCL' and itemID=" + itemID)[0]["quantity"]) + quan;
                        HelpMethods.catchError(() => inventoryTableAdapter.DeductFormWare(updateVhTo, itemID, "VHCL"));
                    }

                }
                MessageBox.Show("Return order has been submitted", "information");
            }
            else if (transactionType == "ORDER"|| transactionType == "EMERGENCY")
            {
                for (int i = 0; i < ids.Length; i++)
                {
                    int itemID = Convert.ToInt32(ids[i]);
                    int quan = quans[i];
                    try
                    {
                        transactionlineTableAdapter.InsertIntoTransactionLine(tID, itemID, quan);
                    }
                    catch (Exception)
                    {
                        int updateOrderTo = Convert.ToInt32(transactionLineDt.Select("transactionID=" + tID + " AND itemID = " + itemID)[0]["quantity"]) + quan;
                        HelpMethods.catchError(() => transactionlineTableAdapter.UpdateQuantity(updateOrderTo, tID, itemID));
                    }
                }
                MessageBox.Show("Item(s) have been added/updated to your order", "information");
            }
            
            cboAddtoTypes.Enabled = true;
            HelpMethods.grpsToggle(false, grpOrderAndReturn, btnRefresh, grpLocationSearch, grpSearch, grpReorder, grpConvenience);
            order.Clear();
        }

        private void btnGotoOrder_Click_1(object sender, EventArgs e)
        {
            Order frmOrder = new Order(currentUser);
            frmOrder.ShowDialog();
        }
    }
}
