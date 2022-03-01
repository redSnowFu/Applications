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
    public partial class Order : Form
    {
        User currentUser = new User();
        //global variable for later usages
        string all = "All";
        //string not = "Not";
        
        //datatable for quering the transaction table
        DataTable transactionDt = new DataTable();
        //transactionType dataTable
        DataTable transacionTypeDt= new DataTable();
        //transactionStatus dataTable
        DataTable transactionStatusDt = new DataTable();

        DataTable transactionLineDt = new DataTable();
        DataTable inventoryDt = new DataTable();
        DataTable locationDt = new DataTable();
        //dataview
        DataView transactionDv = new DataView();
        DataTable transAndDeliDt = new DataTable();
        DataView transAndDeliDv = new DataView();
        DataTable deliveryDt = new DataTable();
        DataTable DeliveryTransDt = new DataTable();
        DataTable courierDt = new DataTable();

        static string connectionString = "datasource=localhost;port=3306;database=bullseye;" +
        "username=david;password=david";
        //create connection
        static MySqlConnection connDB = new MySqlConnection(connectionString);

        public Order(User u)
        {
            InitializeComponent();
            currentUser = u;
        }

        private void Order_Load(object sender, EventArgs e)
        {
            //check permission
            connDB.Open();
            resetForm();
        }

        private void resetForm()
        {
            //reset all tabs
            resetOrders();
            resetDeliveries();
            string userID = currentUser.getUserID();
            string roleID = currentUser.getRoleID();
            string locationName = currentUser.getLocationName();
            lblUserInfo.Text = userID + ", " + roleID + ", Location: " + locationName;
        }

        private void resetOrders()
        {
            HelpMethods.clearCbo(grpSearchOrders,grpUpdate,grpCreate);

            if (HelpMethods.catchError(() => HelpMethods.fillDtAndDgv(ref transactionDt, transactionTableAdapter.GetData, bdsOrders, dgvOrders)) == false)
                this.Close();
            else
            {
                HelpMethods.setupDgv(dgvOrders);
                dgvOrders.Sort(this.dgvOrders.Columns["creationDate"], ListSortDirection.Descending);
                fillCbos();
                //clear dgv selection
                dgvOrders.ClearSelection();
                chkOrderPermission();
            }
        }

        private void resetDeliveries()
        {
            HelpMethods.clearCbo(grpSearchDLF,grpProcessReturn);
            string setDeliveries = getDeliveriesCmd();
            fillDgvDeliveries(setDeliveries);
            HelpMethods.setupDgv(dgvDeliveries);
            HelpMethods.populateCbo(transAndDeliDt, "originalLocationID", cboLocDLF, all);
            HelpMethods.populateCbo(transAndDeliDt, "transactionStatus", cboStatusDLF, all);
            string[] processes = new string[] { "Keep", "Discard", "Retun to supplier" };
            cboProcessReturn.Items.AddRange(processes);
            cboProcessReturn.SelectedIndex = 0;
            dgvDeliveries.ClearSelection();
            chkDeliveriesPermission();

            if (HelpMethods.catchError(() => deliveryTableAdapter.GetData()) == false||
                HelpMethods.catchError(()=>deliverytransactionTableAdapter.GetData())==false||
                HelpMethods.catchError(() => courierTableAdapter.GetData()) == false)
                this.Close();
            else
            {
                deliveryDt = deliveryTableAdapter.GetData();
                DeliveryTransDt = deliverytransactionTableAdapter.GetData();
                courierDt = courierTableAdapter.GetData();
            }

        }

        //private void fillDeliCbos()
        //{
            
        //    HelpMethods.populateCbo(transAndDeliDt, "originalLocationID", cboLocDLF, all);
        //    HelpMethods.populateCbo(transAndDeliDt, "transactionStatus", cboStatusDLF, all);
        //}

        private void fillCbos()
        {
            //cboTypeOF.Items.Add("Outstanding");f
            cboTypeOF.Items.Add(all);
            cboLocationIDOF.Items.Add(all);
            cboStatusOF.Items.Add(all);
            cboStatusOF.Items.Add("Outstanding");
            foreach (DataGridViewRow row in dgvOrders.Rows)
            {
                if (cboTypeOF.Items.Contains(row.Cells["transactionType"].Value.ToString()) == false)
                    cboTypeOF.Items.Add(row.Cells["transactionType"].Value.ToString());
                if (cboLocationIDOF.Items.Contains(row.Cells["originalLocationID"].Value.ToString()) == false)
                    cboLocationIDOF.Items.Add(row.Cells["originalLocationID"].Value.ToString());
                if (cboStatusOF.Items.Contains(row.Cells["transactionStatus"].Value.ToString()) == false)
                    cboStatusOF.Items.Add(row.Cells["transactionStatus"].Value.ToString());
            }
            cboTypeOF.SelectedIndex = 0;
            cboLocationIDOF.SelectedIndex = 0;
            cboStatusOF.SelectedIndex = 0;

            //if (HelpMethods.catchError(() => transactionstatusTableAdapter.GetData()) == false)
            //    this.Close();
            //else
            //{
            //    transactionStatusDt = transactionstatusTableAdapter.GetData();
            //    HelpMethods.populateCbo(transactionStatusDt, "transactionStatus", cboUpdateStatus, not);
            //}
            cboUpdateStatus.Items.Add("NEW");
            cboUpdateStatus.SelectedIndex = 0;
            //string[] orders = new string[] { "ORDER", "EMERGENCY"};
            //cboAddType.Items.AddRange(orders);
            //cboAddType.SelectedIndex = 0;
        }

        private void chkDeliveriesPermission()
        {
            btnLoadOrder.Visible = false;
            btnConfirmDel.Visible = false;
            btnReceiveStore.Visible = false;
            btnReceiveReturn.Visible = false;
            btnProcessReturn.Visible = false;
            cboProcessReturn.Visible = false;
            List<string> actions = currentUser.getActions();
            if (actions.Contains("CRUD"))
            {
                btnLoadOrder.Visible = true;
                btnConfirmDel.Visible = true;
                btnReceiveStore.Visible = true;
            }
            if (actions.Contains("PROCESS ORDER"))
            {
                btnLoadOrder.Visible = true;
                btnReceiveReturn.Visible = true;
                btnProcessReturn.Visible = true;
                cboProcessReturn.Visible = true;
            }
            if (currentUser.getRoleID() == "Driver")
                btnConfirmDel.Visible = true;
            if (currentUser.getRoleID() == "Store Worker" || currentUser.getRoleID() == "Store Manager")
                btnReceiveStore.Visible = true;
        }

        private void chkOrderPermission()
        {
            btnScan.Enabled = false;
            btnConfrimReturn.Enabled = false;
            //btnLoadtoTruck.Enabled = false;
            //btnSigns.Enabled = false;
            //btnReceive.Enabled = false;
            btnConfrimReturn.Visible = false;
            grpCreate.Visible = false;
            btnAddOrder.Enabled = false;
            btnCreateE.Enabled = false;
            grpUpdate.Visible = false;
            btnScan.Visible = false;
            btnCancelBO.Visible = false;
            //btnLoadtoTruck.Visible = false;
            //btnSigns.Visible = false;
            //btnReceive.Visible = false;
            List<string> actions = currentUser.getActions();
            string filterCmd = "";
            if (actions.Contains("CREATE ORDER"))
            {
                grpCreate.Visible = true;
                btnCreateE.Enabled = true;
                btnCancelBO.Visible = true;
            }
                
            if (actions.Contains("UPDATE ALL ORDER"))
            {
                grpCreate.Visible = true;
                cboStatusOF.Text = "Outstanding";
                filterCmd = "transactionStatus NOT IN ('COMPLETE')";
                grpUpdate.Visible = true;
                
                btnAddOrder.Enabled = true;
                
            }
            if (actions.Contains("READ DELIVERY")&&currentUser.getRoleID()=="Driver")
            {
                btnConfrimReturn.Visible = true;
            }
            if(actions.Contains("UPDATE ORDER"))
            {
                cboLocationIDOF.Text = currentUser.getLocationID();
                filterCmd = "originalLocationID like '%" + cboLocationIDOF.Text + "%'";
            }
            if(currentUser.getRoleID()== "Warehouse Worker")
                filterCmd = "transactionStatus = 'PROCESSING'";

            HelpMethods.filterHelp(transactionDv, transactionDt, dgvOrders, filterCmd);
            transactionDv.Sort = " creationDate DESC ";
            if (actions.Contains("CRUD"))
            {
                grpCreate.Visible = true;
                btnAddOrder.Enabled = true;
                btnCreateE.Enabled = true;
                grpUpdate.Visible = true;
                btnConfrimReturn.Visible = true;
                btnCancelBO.Visible = true;
                //btnScan.Visible = true;
                //btnLoadtoTruck.Visible = true;
            }
            if (actions.Contains("PROCESS ORDER"))
            {
                
                btnScan.Visible = true;
            }
        }

        private string getDeliveriesCmd()
        {
            return "select d.deliveryID, t.transactionID, dt.routeID, d.vehicleID, c.courierName, d.dateTime, t.estimatedArrival, t.transactionStatus, " +
                "t.transactionType, t.originalLocationID from deliverytransaction dt, delivery d, courier c,transaction t " +
                "where dt.deliveryID = d.deliveryID and d.courierID = c.courierID and dt.transactionID = t.transactionID";
        }

        private void fillDgvDeliveries(string cmd)
        {
            MySqlDataAdapter tadAdapter = new MySqlDataAdapter(cmd, connDB);

            transAndDeliDt.Clear();
            transAndDeliDt.TableName = "transAndDeliDt";
            if (HelpMethods.catchError(() => tadAdapter.Fill(transAndDeliDt)) == false)
                this.Close();

            bdsDeliveries.DataSource = transAndDeliDt;
            dgvDeliveries.DataSource = bdsDeliveries;
        }

        private void btnSearchItem_Click(object sender, EventArgs e)
        {
            string transactionID = txtTransactionID.Text;
            string type = cboTypeOF.Text;
            string location = cboLocationIDOF.Text;
            string status = cboStatusOF.Text;
            string fromDate = mTxtFromDate.Text;
            string toDate = mTxtToDate.Text;
            HelpMethods.replaceStrChar(transactionID, type, location, status, fromDate, toDate);

            string filterCmd = string.Format("convert(transactionID, 'System.String') like '%{0}%'", transactionID);

            if (type == all)
                type = "";
            filterCmd += " AND transactionType like '%"+type+"%'";

            if (location == all)
                location = "";
            filterCmd += " AND originalLocationID like '%"+location+"%'";

            if (status == all)
                filterCmd += " AND transactionStatus like '%%'";
            else if (status == "Outstanding")
                filterCmd += " AND transactionStatus NOT IN ('COMPLETE')";
            else
                filterCmd += " AND transactionStatus like '%"+status+"%'";

            if (fromDate.Length == 10 && toDate.Length == 10)
                filterCmd += "Date IN (#" + fromDate + "#, #" + toDate + "#)";
            

            HelpMethods.filterHelp(transactionDv, transactionDt, dgvOrders, filterCmd);
            transactionDv.Sort = " creationDate DESC ";
        }

        private void btnView_Click(object sender, EventArgs e)
        {
            if (dgvOrders.SelectedRows.Count != 1)
                MessageBox.Show("Please select an item to proceed", "Warning");
            else
            {
                int transID = Convert.ToInt32(dgvOrders.SelectedRows[0].Cells["transactionID"].Value);
                CreateOrder frmCreateOrder = new CreateOrder(currentUser, transID);
                frmCreateOrder.ShowDialog();
            }
        }

        private void dgvOrders_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgvOrders.SelectedRows.Count != 1)
                MessageBox.Show("Please select an item to proceed", "Warning");
            else
            {
                int transID = Convert.ToInt32(dgvOrders.SelectedRows[0].Cells["transactionID"].Value);
                CreateOrder frmCreateOrder = new CreateOrder(currentUser, transID);
                frmCreateOrder.ShowDialog();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dgvOrders.SelectedRows.Count != 1)
                MessageBox.Show("Please select an item to proceed", "Warning");
            else
            {
                if (dgvOrders.SelectedRows[0].Cells["transactionStatus"].Value.ToString() != "SUBMITTED")
                    MessageBox.Show("This order's transaction status cannot be changed to 'NEW'", "Error");
                else
                {
                    int transID = Convert.ToInt32(dgvOrders.SelectedRows[0].Cells["transactionID"].Value);
                    string oldNote = transactionDt.Select("transactionID = " + transID)[0]["notes"].ToString();
                    string status = cboUpdateStatus.Text;
                    string originalStatus = dgvOrders.SelectedRows[0].Cells["transactionStatus"].Value.ToString();
                    string note = string.Concat(oldNote, "-->", "From '" + originalStatus + "' to '" + status + "'");
                    
                    HelpMethods.catchError(() => transactionTableAdapter.UpdateStatusAndNote(status, note, transID));
                    resetOrders();
                }
            }
        }

        private void btnAddOrder_Click(object sender, EventArgs e)
        {

            if (HelpMethods.catchError(() => locationTableAdapter.GetData()) == false)
                resetOrders();
            else
            {
                locationDt = locationTableAdapter.GetData();
                string findLocs = "locationTypeID='Store'";
                DataRow[] locsRows = locationDt.Select(findLocs);

                foreach (DataRow r in locsRows)
                {
                    string locID = r["locationID"].ToString();
                    string expression = "transactionType ='ORDER' AND originalLocationID = '" + locID + "' AND transactionStatus = 'NEW'";
                    DataRow[] foundRows = transactionDt.Select(expression);
                    if (foundRows.Count() < 1)
                    {
                        HelpMethods.catchError(() => transactionTableAdapter.InsertIntoTransaction("ORDER", locID, DateTime.Now, "NEW", "New Order Placed"));
                        resetOrders();
                    }
                }
            }

            //string type = cboAddType.Text;
            //string locID = currentUser.getLocationID();

            //string expression = "transactionType ='" + type + "' AND originalLocationID = '" + locID + "' AND transactionStatus = 'NEW'";
            //DataRow[] foundRows = transactionDt.Select(expression);
            //if (foundRows.Count() >= 1)
            //{
            //    MessageBox.Show("There's already an order exist in your account", "Warning");
            //}
            //else
            //{
            //    HelpMethods.catchError(() => transactionTableAdapter.InsertIntoTransaction(type, locID, DateTime.Now, "NEW", "New Order Placed"));
            //    resetForm();
            //}
        }



        private void Order_FormClosing(object sender, FormClosingEventArgs e)
        {
            connDB.Close();
        }

        private void btnCreateE_Click(object sender, EventArgs e)
        {
            string locID = currentUser.getLocationID();

            string expression = "transactionType ='EMERGENCY' AND originalLocationID = '" + locID 
                + "' AND transactionStatus = 'NEW'";
            DataRow[] foundRows = transactionDt.Select(expression);
            if (foundRows.Count() >= 1)
            {
                MessageBox.Show("There's already an EMERGENCY order exist in your account", "Warning");
            }
            else
            {
                HelpMethods.catchError(() => transactionTableAdapter.InsertIntoTransaction("EMERGENCY", locID, DateTime.Now, "NEW", "New Order Placed"));
                resetOrders();
            }
        }

        private void dgvOrders_SelectionChanged(object sender, EventArgs e)
        {
            btnScan.Enabled = false;
            btnConfrimReturn.Enabled = false;
            btnCancelBO.Enabled = false;
            if (dgvOrders.SelectedRows.Count >= 1)
            {
                if (dgvOrders.SelectedRows[0].Cells["transactionStatus"].Value.ToString() == "PROCESSING")
                    btnScan.Enabled = true;
                if (dgvOrders.SelectedRows[0].Cells["transactionStatus"].Value.ToString() == "SUBMITTED"&&
                dgvOrders.SelectedRows[0].Cells["transactionType"].Value.ToString() == "RETURN")
                    btnConfrimReturn.Enabled = true;
                if (dgvOrders.SelectedRows[0].Cells["transactionStatus"].Value.ToString() == "SUBMITTED" &&
                dgvOrders.SelectedRows[0].Cells["transactionType"].Value.ToString() == "BACKORDER" && 
                dgvOrders.SelectedRows[0].Cells["originalLocationID"].Value.ToString() == currentUser.getLocationID())
                    btnCancelBO.Enabled = true;
                if (dgvOrders.SelectedRows[0].Cells["transactionStatus"].Value.ToString() == "SUBMITTED" &&
                dgvOrders.SelectedRows[0].Cells["transactionType"].Value.ToString() == "BACKORDER" &&
                currentUser.getActions().Contains("CRUD"))
                    btnCancelBO.Enabled = true;
                //{
                //    btnLoadtoTruck.Enabled = true;
                //    btnSigns.Enabled = true;
                //}
                //if (dgvOrders.SelectedRows[0].Cells["transactionStatus"].Value.ToString() == "IN TRANSIT"&& dgvOrders.SelectedRows[0].Cells["originalLocationID"].Value.ToString() == currentUser.getLocationID())
                //    btnReceive.Enabled = true;
            }
        }

        private void btnScan_Click(object sender, EventArgs e)
        {
            if (dgvOrders.SelectedRows.Count != 1)
                MessageBox.Show("Please select an item to proceed", "Warning");
            else
            {
                int transactionID = Convert.ToInt32(dgvOrders.SelectedRows[0].Cells["transactionID"].Value);
                ScanItems frmScanItems = new ScanItems(currentUser, transactionID);
                frmScanItems.ShowDialog();
            }    
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            resetOrders();
        }

        private void btnLoadtoTruck_Click(object sender, EventArgs e)
        {
            
            
        }

        private void btnSigns_Click(object sender, EventArgs e)
        {
            
        }

        private void btnReceive_Click(object sender, EventArgs e)
        {
            
        }

        private void btnLoadOrder_Click(object sender, EventArgs e)
        {
            if (dgvDeliveries.SelectedRows.Count != 1)
                MessageBox.Show("Please select an delivery to proceed", "Warning");
            else
            {
                if (dgvDeliveries.SelectedRows[0].Cells["transactionStatus"].Value.ToString() != "READY")
                    MessageBox.Show("This order is not ready yet", "Error");
                else
                {
                    MessageBox.Show("All items has been loaded to the truck", "Information");
                }
            }
        }

        private void btnConfirmDel_Click(object sender, EventArgs e)
        {
            if (dgvDeliveries.SelectedRows.Count != 1)
                MessageBox.Show("Please select an delivery to proceed", "Warning");
            else
            {
                if (dgvDeliveries.SelectedRows[0].Cells["transactionStatus"].Value.ToString() != "READY")
                    MessageBox.Show("This order is not ready yet", "Error");
                else
                {
                    DialogResult ifSign = MessageBox.Show("Do you want to sign and accept those items?", "Confirm information", MessageBoxButtons.YesNo);
                    if (ifSign == DialogResult.Yes)
                    {
                        int transID = Convert.ToInt32(dgvDeliveries.SelectedRows[0].Cells["transactionID"].Value);
                        string oldNote = transactionDt.Select("transactionID = " + transID)[0]["notes"].ToString();
                        string status = "IN TRANSIT";
                        string originalStatus = dgvDeliveries.SelectedRows[0].Cells["transactionStatus"].Value.ToString();
                        string note = string.Concat(oldNote, "-->", "From '" + originalStatus + "' to '" + status + "'");

                        if (HelpMethods.catchError(() => transactionTableAdapter.UpdateStatusAndNote(status, note, transID)) == false)
                            resetDeliveries();

                        if (HelpMethods.catchError(() => transactionlineTableAdapter.GetData()) == false || HelpMethods.catchError(() => inventoryTableAdapter.GetData()) == false)
                            resetDeliveries();
                        else
                        {
                            transactionLineDt = transactionlineTableAdapter.GetData();
                            inventoryDt = inventoryTableAdapter.GetData();
                        }


                        DataRow[] trlRows = transactionLineDt.Select("transactionID =" + transID);
                        if (trlRows.Count() >= 1)
                        {
                            foreach (DataRow row in trlRows)
                            {
                                int itemID = Convert.ToInt32(row["itemID"]);
                                int quantity = Convert.ToInt32(row["quantity"]);
                                int whQuan = Convert.ToInt32(inventoryDt.Select("locationID='WARE' and itemID=" + itemID)[0]["quantity"]);
                                
                                string originalLoc = dgvDeliveries.SelectedRows[0].Cells["originalLocationID"].Value.ToString();
                                int storeQuan = Convert.ToInt32(inventoryDt.Select("locationID='" + originalLoc + "' and itemID=" + itemID)[0]["quantity"]);
                                int updateQuan = 0;
                                string thisLoc = "";

                                if(dgvDeliveries.SelectedRows[0].Cells["transactionType"].Value.ToString()== "RETURN")
                                {
                                    updateQuan = storeQuan - quantity;
                                    thisLoc = originalLoc;
                                }
                                else
                                {
                                    updateQuan = whQuan - quantity;
                                    thisLoc = "WARE";
                                }

                                if (HelpMethods.catchError(() => inventoryTableAdapter.DeductFormWare(updateQuan, itemID, thisLoc)) == false)
                                    resetDeliveries();
                                if (inventoryDt.Select("locationID='VHCL' and itemID=" + itemID).Count() < 1)
                                {
                                    if (HelpMethods.catchError(() => inventoryTableAdapter.InsertIntoInventory(itemID, "VHCL", quantity, null, 0)) == false)
                                        resetDeliveries();
                                }
                                else
                                {
                                    int updateVhTo = Convert.ToInt32(inventoryDt.Select("locationID='VHCL' and itemID=" + itemID)[0]["quantity"]) + quantity;
                                    if (HelpMethods.catchError(() => inventoryTableAdapter.DeductFormWare(updateVhTo, itemID, "VHCL")) == false)
                                        resetDeliveries();
                                }

                            }
                        }
                        MessageBox.Show("This order has been confirmed", "Information");
                        resetDeliveries();
                    }
                }
            }
        }

        private void btnReceiveStore_Click(object sender, EventArgs e)
        {
            if (dgvDeliveries.SelectedRows.Count != 1)
                MessageBox.Show("Please select an delivery to proceed", "Warning");
            else
            {
                int transactionID = Convert.ToInt32(dgvDeliveries.SelectedRows[0].Cells["transactionID"].Value);
                ReceiveItems frmReceiveItems = new ReceiveItems(currentUser, transactionID);
                frmReceiveItems.ShowDialog();
            }
        }

        private void btnRefreshDeliveries_Click(object sender, EventArgs e)
        {
            resetDeliveries();
        }

        private void dgvDeliveries_SelectionChanged(object sender, EventArgs e)
        {
            btnProcessReturn.Enabled = false;
            cboProcessReturn.Enabled = false;
            btnReceiveReturn.Enabled = false;
            btnLoadOrder.Enabled = false;
            btnConfirmDel.Enabled = false;
            btnReceiveStore.Enabled = false;
            if (dgvDeliveries.SelectedRows.Count >= 1)
            {
                
                if (dgvDeliveries.SelectedRows[0].Cells["transactionStatus"].Value.ToString() == "READY")
                {
                    btnLoadOrder.Enabled = true;
                    btnConfirmDel.Enabled = true;
                }
                if (dgvDeliveries.SelectedRows[0].Cells["transactionStatus"].Value.ToString() == "IN TRANSIT" && 
                    dgvDeliveries.SelectedRows[0].Cells["originalLocationID"].Value.ToString() == currentUser.getLocationID())
                    btnReceiveStore.Enabled = true;
                if(currentUser.getActions().Contains("CRUD"))
                    btnReceiveStore.Enabled = true;
                if (dgvDeliveries.SelectedRows[0].Cells["transactionStatus"].Value.ToString() == "IN TRANSIT" &&
                    dgvDeliveries.SelectedRows[0].Cells["transactionType"].Value.ToString() == "RETURN")
                    btnReceiveReturn.Enabled = true;
                if (dgvDeliveries.SelectedRows[0].Cells["transactionStatus"].Value.ToString() == "DELIVERED" &&
                    dgvDeliveries.SelectedRows[0].Cells["transactionType"].Value.ToString() == "RETURN")
                {
                    btnProcessReturn.Enabled = true;
                    cboProcessReturn.Enabled = true;
                }

            }
        }

        private void tabOrder_SelectedIndexChanged(object sender, EventArgs e)
        {
            resetForm();
        }

        private void btnSearchDLF_Click(object sender, EventArgs e)
        {
            
            string location = cboLocDLF.Text;
            string status = cboStatusDLF.Text;
            string fromDate = mtxtStartDLF.Text;
            string toDate = mtxtEndDLF.Text;
            
            HelpMethods.replaceStrChar(location, status);

            
            if (location == all)
                location = "";
            string filterCmd = "originalLocationID like '%" + location + "%'";

            if (status == all)
                status = "";
            filterCmd += " AND transactionStatus like '%" + status + "%'";

            if (fromDate.Length == 10 && toDate.Length == 10)
                filterCmd += "Date IN (#" + fromDate + "#, #" + toDate + "#)";


            HelpMethods.filterHelp(transAndDeliDv, transAndDeliDt, dgvDeliveries, filterCmd);
            
        }

        private void btnConfrimReturn_Click(object sender, EventArgs e)
        {
            if (dgvOrders.SelectedRows.Count != 1)
                MessageBox.Show("Please select an order to proceed", "Warning");
            else
            {
                string currentType = dgvOrders.SelectedRows[0].Cells["transactionType"].Value.ToString();
                if (dgvOrders.SelectedRows[0].Cells["transactionStatus"].Value.ToString() != "SUBMITTED"||
                    currentType != "RETURN")
                    MessageBox.Show("This order is not an order ready for return", "Error");
                else
                {
                    DialogResult ifSign = MessageBox.Show("Do you want to sign and accept those return items?", "Confirm information", MessageBoxButtons.YesNo);
                    if (ifSign == DialogResult.Yes)
                    {
                        int transID = Convert.ToInt32(dgvOrders.SelectedRows[0].Cells["transactionID"].Value);
                        string oldNote = transactionDt.Select("transactionID = " + transID)[0]["notes"].ToString();
                        string status = "IN TRANSIT";
                        string originalStatus = dgvOrders.SelectedRows[0].Cells["transactionStatus"].Value.ToString();
                        string note = string.Concat(oldNote, "-->", "From '" + originalStatus + "' to '" + status + "'");

                        if (HelpMethods.catchError(() => transactionTableAdapter.UpdateStatusAndNote(status, note, transID)) == false)
                            resetOrders();

                        
                        createDelivery(currentType, transID);
                        MessageBox.Show("This return has been confirmed", "Information");
                        resetOrders();
                    }
                }
            }



        }

        private void createDelivery(string currentType, int transactionID)
        {
            
            int deliveryID = 1;
            string vehicleID = "";
            int courierID = 1;
            string currentRouteID = "";

            if (deliveryDt.Rows.Count > 0)
            {
                int maxID = Convert.ToInt32(deliveryDt.Compute("Max([deliveryID])", string.Empty));
                deliveryID = maxID + 1;
            }

            
            currentRouteID = "WARE-DIEP";
            //int previousTransID = Convert.ToInt32(transactionDt.Select("transactionType='ORDER' and originalLocationID='" + currentLoc + "'", "estimatedArrival DESC")[0]["transactionID"]);
            //int previousDeID = Convert.ToInt32(DeliveryTransDt.Select("transactionID=" + previousTransID)[0]["deliveryID"]);
            //vehicleID = deliveryDt.Select("deliveryID=" + previousDeID)[0]["vehicleID"].ToString();
            //currentRouteID = DeliveryTransDt.Select("transactionID=" + previousTransID+" and deliveryID="+previousDeID)[0]["routeID"].ToString();
            vehicleID = "VAN";

            if (HelpMethods.catchError(() => deliveryTableAdapter.InsertIntoDelivery(deliveryID, DateTime.Now, vehicleID, courierID)) == false ||
                HelpMethods.catchError(() => deliverytransactionTableAdapter.InsertIntoDT(deliveryID, transactionID, currentRouteID)) == false)
                resetOrders();
        }

        private void btnReceiveReturn_Click(object sender, EventArgs e)
        {
            if (dgvOrders.SelectedRows.Count != 1)
                MessageBox.Show("Please select an delivery to proceed", "Warning");
            else
            {
                string currentType = dgvDeliveries.SelectedRows[0].Cells["transactionType"].Value.ToString();
                if (dgvDeliveries.SelectedRows[0].Cells["transactionStatus"].Value.ToString() != "IN TRANSIT" ||
                    currentType != "RETURN")
                    MessageBox.Show("This delivery is not ready for receive", "Error");
                else
                {
                    DialogResult ifSign = MessageBox.Show("Do you want to sign and accept those return items?", "Confirm information", MessageBoxButtons.YesNo);
                    if (ifSign == DialogResult.Yes)
                    {
                        int transID = Convert.ToInt32(dgvDeliveries.SelectedRows[0].Cells["transactionID"].Value);
                        string oldNote = transactionDt.Select("transactionID = " + transID)[0]["notes"].ToString();
                        string status = "DELIVERED";
                        string originalStatus = dgvDeliveries.SelectedRows[0].Cells["transactionStatus"].Value.ToString();
                        string note = string.Concat(oldNote, "-->", "From '" + originalStatus + "' to '" + status + "'");

                        if (HelpMethods.catchError(() => transactionTableAdapter.UpdateStatusAndNote(status, note, transID)) == false)
                            resetDeliveries();

                        if (HelpMethods.catchError(() => transactionlineTableAdapter.GetData()) == false || HelpMethods.catchError(() => inventoryTableAdapter.GetData()) == false)
                            resetDeliveries();
                        else
                        {
                            transactionLineDt = transactionlineTableAdapter.GetData();
                            inventoryDt = inventoryTableAdapter.GetData();
                        }


                        DataRow[] trlRows = transactionLineDt.Select("transactionID =" + transID);
                        if (trlRows.Count() >= 1)
                        {
                            foreach (DataRow row in trlRows)
                            {
                                int itemID = Convert.ToInt32(row["itemID"]);
                                int quantity = Convert.ToInt32(row["quantity"]);
                                int vhQuan = Convert.ToInt32(inventoryDt.Select("locationID='VHCL' and itemID=" + itemID)[0]["quantity"]);
                                int updateVhTo = vhQuan - quantity;
                                if (updateVhTo == 0)
                                {
                                    if (HelpMethods.catchError(() => inventoryTableAdapter.DeleteFromInventory(itemID, "VHCL")) == false)
                                        resetDeliveries();
                                }
                                else
                                {
                                    if (HelpMethods.catchError(() => inventoryTableAdapter.DeductFormWare(updateVhTo, itemID, "VHCL")) == false)
                                        resetDeliveries();
                                }
                                

                                if (inventoryDt.Select("locationID='WARE' and itemID=" + itemID).Count() < 1)
                                {
                                    if (HelpMethods.catchError(() => inventoryTableAdapter.InsertIntoInventory(itemID, "WARE", quantity, null, 0)) == false)
                                        resetDeliveries();
                                }
                                else
                                {
                                    int updateWhTo = Convert.ToInt32(inventoryDt.Select("locationID='WARE' and itemID=" + itemID)[0]["quantity"]) + quantity;
                                    if (HelpMethods.catchError(() => inventoryTableAdapter.DeductFormWare(updateWhTo, itemID, "WARE")) == false)
                                        resetDeliveries();
                                }

                            }
                        }

                        MessageBox.Show("This return has been delivered", "Information");
                        resetDeliveries();
                        
                        //btnProcessReturn.Visible = true;
                        //cboProcessReturn.Visible = true;
                    }
                }
            }
         }

        private void btnProcessReturn_Click(object sender, EventArgs e)
        {
            if (dgvDeliveries.SelectedRows.Count != 1)
                MessageBox.Show("Please select an delivery to proceed", "Warning");
            else
            {
                string currentType = dgvDeliveries.SelectedRows[0].Cells["transactionType"].Value.ToString();
                if (dgvDeliveries.SelectedRows[0].Cells["transactionStatus"].Value.ToString() != "DELIVERED" ||
                    currentType != "RETURN")
                    MessageBox.Show("This delivery is not ready for processing", "Error");
                else
                {
                    DialogResult ifSign = MessageBox.Show("Are you sure you want to "+cboProcessReturn.Text+"?", "Confirm information", MessageBoxButtons.YesNo);
                    if (ifSign == DialogResult.Yes)
                    {
                        int transID = Convert.ToInt32(dgvDeliveries.SelectedRows[0].Cells["transactionID"].Value);
                        string oldNote = transactionDt.Select("transactionID = " + transID)[0]["notes"].ToString();
                        string status = "COMPLETE";
                        string originalStatus = dgvDeliveries.SelectedRows[0].Cells["transactionStatus"].Value.ToString();
                        string note = string.Concat(oldNote, "-->", "From '" + originalStatus + "' to '" + status + "'");

                        if (HelpMethods.catchError(() => transactionTableAdapter.UpdateStatusAndNote(status, note, transID)) == false)
                            resetDeliveries();

                        

                        if (cboProcessReturn.Text == "Discard" || cboProcessReturn.Text == "Retun to supplier")
                        {
                            if (HelpMethods.catchError(() => transactionlineTableAdapter.GetData()) == false || HelpMethods.catchError(() => inventoryTableAdapter.GetData()) == false)
                                resetDeliveries();
                            else
                            {
                                transactionLineDt = transactionlineTableAdapter.GetData();
                                inventoryDt = inventoryTableAdapter.GetData();
                            }

                            DataRow[] trlRows = transactionLineDt.Select("transactionID =" + transID);
                            if (trlRows.Count() >= 1)
                            {
                                foreach (DataRow row in trlRows)
                                {
                                    int itemID = Convert.ToInt32(row["itemID"]);
                                    int quantity = Convert.ToInt32(row["quantity"]);
                                    int whQuan = Convert.ToInt32(inventoryDt.Select("locationID='WARE' and itemID=" + itemID)[0]["quantity"]);
                                    int updateWhTo = whQuan - quantity;
                                    if (HelpMethods.catchError(() => inventoryTableAdapter.DeductFormWare(updateWhTo, itemID, "WARE")) == false)
                                        resetDeliveries();

                                }
                            }
                        }
                        
                        MessageBox.Show("This return has been completed", "Information");
                        resetDeliveries();

                        //btnProcessReturn.Visible = false;
                        //cboProcessReturn.Visible = false;
                    }
                }
            }
        }

        private void btnCancelBO_Click(object sender, EventArgs e)
        {
            if (dgvOrders.SelectedRows.Count != 1)
                MessageBox.Show("Please select an delivery to proceed", "Warning");
            else
            {
                string currentType = dgvOrders.SelectedRows[0].Cells["transactionType"].Value.ToString();
                if (dgvOrders.SelectedRows[0].Cells["transactionStatus"].Value.ToString() != "SUBMITTED" ||
                    currentType != "BACKORDER")
                    MessageBox.Show("This Order cannot be cancelled", "Error");
                else
                {
                    DialogResult ifSign = MessageBox.Show("Are you sure you want to Cancel this order?", "Confirm information", MessageBoxButtons.YesNo);
                    if (ifSign == DialogResult.Yes)
                    {
                        int transID = Convert.ToInt32(dgvOrders.SelectedRows[0].Cells["transactionID"].Value);
                        string oldNote = dgvOrders.SelectedRows[0].Cells["notes"].ToString();
                        string status = "COMPLETE";
                        string originalStatus = dgvOrders.SelectedRows[0].Cells["transactionStatus"].Value.ToString();
                        string note = string.Concat(oldNote, "-->", "From '" + originalStatus + "' to '" + status + "'");

                        if (HelpMethods.catchError(() => transactionTableAdapter.UpdateStatusAndNote(status, note, transID)) == false)
                            resetOrders();

                        MessageBox.Show("This return has been completed", "Information");
                        resetOrders();
                    }
                }
            }
        }
    }
}
