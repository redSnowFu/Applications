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
    public partial class ScanItems : Form
    {
        User currentUser = new User();
        int transactionID;
        string currentType = "";
        DataTable waitingDt = new DataTable();
        DataTable processingDt = new DataTable();
        DataTable transactionDt = new DataTable();
        DataTable inventoryDt = new DataTable();
        DataTable deliveryDt = new DataTable();
        DataTable locDt = new DataTable();
        DataTable DeliveryTransDt = new DataTable();
        DataTable routeDt = new DataTable();
        DataTable itemsDt = new DataTable();
        DataTable transactionLineDt = new DataTable();
        DataTable courierDt = new DataTable();
        static string connectionString = "datasource=localhost;port=3306;database=bullseye;" +
        "username=david;password=david";
        //create connection
        static MySqlConnection connDB = new MySqlConnection(connectionString);

        public ScanItems(User u, int id)
        {
            InitializeComponent();
            currentUser = u;
            transactionID = id;
        }

        private void ScanItems_Load(object sender, EventArgs e)
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

            string setWaiting = getCmd("W");
            string setProcessing = getCmd("P");

            if (HelpMethods.catchError(() => fillDgv(setWaiting, waitingDt, "waitingDt", bdsWaiting, dgvWaiting)) == false)
                this.Close();
            if (HelpMethods.catchError(() => fillDgv(setProcessing, processingDt, "processingDt", bdsProcessing, dgvProcessing)) == false)
                this.Close();
            if (HelpMethods.catchError(() => transactionTableAdapter.GetData()) == false || 
                HelpMethods.catchError(() => deliveryTableAdapter.GetData()) == false|| 
                HelpMethods.catchError(() => locationTableAdapter.GetData()) == false||
                HelpMethods.catchError(() => deliverytransactionTableAdapter.GetData()) == false||
                HelpMethods.catchError(() => routeTableAdapter.GetData()) == false||
                HelpMethods.catchError(() => itemTableAdapter.GetData()) == false||
                HelpMethods.catchError(() => transactionlineTableAdapter.GetData()) == false||
                HelpMethods.catchError(() => courierTableAdapter.GetData()) == false)
                this.Close();
            else
            {
                transactionDt = transactionTableAdapter.GetData();
                currentType = transactionDt.Select("transactionID=" + transactionID)[0]["transactionType"].ToString();
                deliveryDt = deliveryTableAdapter.GetData();
                locDt = locationTableAdapter.GetData();
                DeliveryTransDt = deliverytransactionTableAdapter.GetData();
                routeDt = routeTableAdapter.GetData();
                itemsDt = itemTableAdapter.GetData();
                transactionLineDt = transactionlineTableAdapter.GetData();
                courierDt = courierTableAdapter.GetData();
            }

            


            btnScanAll.Enabled = true;
            btnScanOne.Enabled = true;
            btnConfirmReady.Enabled = false;
            lblPickCourier.Visible = false;
            cboECourier.Visible = false;
            if (transactionDt.Select("transactionID=" + transactionID)[0]["transactionStatus"].ToString() == "PROCESSING")
            {
                if (waitingDt != null && waitingDt.Rows.Count == 0)
                {
                    btnConfirmReady.Enabled = true;
                    btnScanAll.Enabled = false;
                    btnScanOne.Enabled = false;
                }
                    
            }
            if (currentType == "EMERGENCY")
            {
                HelpMethods.populateCbo(courierDt, "courierName", cboECourier, "not");
                cboECourier.Items.Remove("Acadia");
                cboECourier.SelectedIndex = 0;
                lblPickCourier.Visible = true;
                cboECourier.Visible = true;
            }

            HelpMethods.setupDgv(dgvWaiting);
            dgvWaiting.ClearSelection();
            HelpMethods.setupDgv(dgvProcessing);
            dgvProcessing.ClearSelection();
        }

        private string getCmd(string str)
        {
            string cmd = "";
            if (str == "W")
                cmd = "select transactionline.transactionID, transactionline.itemID, item.itemName, transactionline.quantity " +
                    "from transactionline inner join item on transactionline.itemID = item.itemID and transactionline.transactionID = " + 
                    transactionID + " and transactionline.itemID not in " +
                    "(select processingtline.itemID from processingtline where processingtline.transactionID = " + transactionID + ")";
            if(str=="P")
                cmd = "select processingtline.transactionID, processingtline.itemID, item.itemName, processingtline.quantity " +
                    "from processingtline inner join item on processingtline.itemID = item.itemID and processingtline.transactionID = " +
                    transactionID;
            return cmd;
        }

        private void fillDgv(string cmd, DataTable dt, string dtName, BindingSource bds,DataGridView dgv)
        {
            MySqlDataAdapter newAdapter = new MySqlDataAdapter(cmd, connDB);
            
            dt.Clear();
            dt.TableName = dtName;

            if (HelpMethods.catchError(() => newAdapter.Fill(dt)) == false)
                this.Close();

            bds.DataSource = dt;
            dgv.DataSource = bds;

            dgv.AutoResizeColumns();
        }

        //private void fillProcessing(string cmd)
        //{
        //    MySqlDataAdapter processingAdapter = new MySqlDataAdapter(cmd, connDB);
        //    processingDt.Clear();
        //    processingDt.TableName = "processingDt";

        //    if (HelpMethods.catchError(() => processingAdapter.Fill(processingDt)) == false)
        //        this.Close();

        //    bdsProcessing.DataSource = processingDt;
        //    dgvProcessing.DataSource = bdsProcessing;

        //    dgvProcessing.AutoResizeColumns();
        //}

        private void ScanItems_FormClosing(object sender, FormClosingEventArgs e)
        {
            connDB.Close();
        }

        private void btnScanAll_Click(object sender, EventArgs e)
        {
            //string expression = "transactionid =" + transactionID;
            //DataRow[] foundRows = waitingDt.Select(expression);
            foreach(DataRow r in waitingDt.Rows)
            {
                int iID = Convert.ToInt32(r["itemID"]);
                int quan = Convert.ToInt32(r["quantity"]);
                if (HelpMethods.catchError(() => processingtlineTableAdapter.AddItem(transactionID, iID, quan)) == false)
                    resetForm();
            }
            resetForm();
        }

        private void btnScanOne_Click(object sender, EventArgs e)
        {
            if (dgvWaiting.SelectedRows.Count != 1)
                MessageBox.Show("Please select an item to proceed", "Warning");
            else
            {
                int iID = Convert.ToInt32(dgvWaiting.SelectedRows[0].Cells["itemID"].Value);
                int quan = Convert.ToInt32(dgvWaiting.SelectedRows[0].Cells["quantity"].Value);
                HelpMethods.catchError(() => processingtlineTableAdapter.AddItem(transactionID, iID, quan));
                resetForm();
            }
        }

        private void btnConfirmReady_Click(object sender, EventArgs e)
        {
            //foreach(DataRow r in processingDt.Rows)
            //{
            //    int iID = Convert.ToInt32(r["itemID"]);
            //    int quan = Convert.ToInt32(r["quantity"]);
            //    int updateQuanTo=
            //}
            DialogResult ifConfirm = MessageBox.Show("Are you sure you want to confirm this order to 'READY'?", "Confirm information", MessageBoxButtons.YesNo);
            if (ifConfirm == DialogResult.Yes)
            {
                string oldNote = transactionDt.Select("transactionID = " + transactionID)[0]["notes"].ToString();
                string status = "READY";
                string originalStatus = transactionDt.Select("transactionID = " + transactionID)[0]["transactionStatus"].ToString();
                string note = string.Concat(oldNote, "-->", "From '" + originalStatus + "' to '" + status + "'");

                HelpMethods.catchError(() => transactionTableAdapter.UpdateStatusAndNote(status, note, transactionID));

                createDelivery();

                resetForm();
                btnScanAll.Enabled = false;
                btnScanOne.Enabled = false;
            }       
        }

        private void createDelivery()
        {
            //int maxID = 0;
            int deliveryID = 1;
            string vehicleID = "";
            int courierID = 1;
            double totalWeight = 0;
            string currentRouteID = "";

            if (deliveryDt.Rows.Count > 0)
            {
                int maxID = Convert.ToInt32(deliveryDt.Compute("Max([deliveryID])", string.Empty));
                deliveryID = maxID + 1;
            }

            if (currentType == "ORDER" || currentType == "RETURN")
                courierID = 1;
            else if (currentType == "EMERGENCY")
                courierID = Convert.ToInt32(courierDt.Select("courierName='" + cboECourier.Text + "'")[0]["courierID"]);

            string currentLoc = transactionDt.Select("transactionID=" + transactionID)[0]["originalLocationID"].ToString();
            string deDay = locDt.Select("locationID='" + currentLoc + "'")[0]["deliveryDay"].ToString();
            DataRow[] sameDayRows = locDt.Select("deliveryDay='" + deDay + "'");

            if (sameDayRows.Count() > 1)
            {
                DataRow[] desRouteRows = routeDt.Select("destinationLocationID = '" + currentLoc + "'");
                if (desRouteRows.Count() > 1)
                {
                    foreach (DataRow desR in desRouteRows)
                    {
                        if (desR["startLocationID"].ToString() != "WARE")
                            currentRouteID = desR["routeID"].ToString();
                    }
                }
                else
                    currentRouteID = desRouteRows[0]["routeID"].ToString();


                List<String> locArr = new List<String>();
                string locs = "";
                foreach (DataRow sdR in sameDayRows)
                {
                    string loc = sdR["locationID"].ToString();
                    DataRow[] routeRows = routeDt.Select("startLocationID='" + loc + "' or destinationLocationID = '" + loc + "'");
                    if (routeRows.Count() > 0)
                    {
                        foreach (DataRow rtR in routeRows)
                        {
                            locArr.Add(rtR["routeID"].ToString());
                        }
                    }

                }

                if (locArr.Count() > 0)
                {
                    for (int i = 0; i < locArr.Count(); i++)
                    {
                        if (i < locArr.Count() - 1)
                            locs += "'"+locArr[i] + "', ";
                        else
                            locs += "'" + locArr[i] + "'";
                    }
                }

                

                DataRow[] delivRows = DeliveryTransDt.Select("routeID in (" + locs + ")");
                if (delivRows.Count() >= 1)
                {
                    foreach (DataRow dlr in delivRows)
                    {
                        int temptransid = Convert.ToInt32(dlr["transactionID"]);
                        if (transactionDt.Select("transactionID=" + temptransid)[0]["transactionType"].ToString() == "ORDER")
                        {
                            deliveryID = Convert.ToInt32(DeliveryTransDt.Select("transactionID=" + temptransid)[0]["deliveryID"]);
                            DataRow[] tslRs = transactionLineDt.Select("transactionID=" + temptransid);
                            if (tslRs.Count() > 0)
                            {
                                
                                foreach (DataRow tslr in tslRs)
                                {
                                    int iID = Convert.ToInt32(tslr["itemID"]);
                                    double iWeight = Convert.ToDouble(itemsDt.Select("itemID=" + iID)[0]["weight"]);
                                    totalWeight += iWeight;
                                }
                            }
                        }
                    }
                }

            }
            else
                currentRouteID = "WARE-" + currentLoc;
                

            double currentWeight = 0;

            DataRow[] wholeOrder = transactionLineDt.Select("transactionID=" + transactionID);
            if (wholeOrder.Count() > 0)
            {
                foreach (DataRow tRow in wholeOrder)
                {
                    int iID = Convert.ToInt32(tRow["itemID"]);
                    double iWeight = Convert.ToDouble(itemsDt.Select("itemID=" + iID)[0]["weight"]);
                    currentWeight += iWeight;
                }
            }
            totalWeight += currentWeight;

            if (totalWeight <= 852.75)
                vehicleID = "VAN";
            else if (totalWeight > 852.75 && totalWeight <= 1292.74)
                vehicleID = "LIGHT";
            else if (totalWeight > 1292.74 && totalWeight <= 4086.87)
                vehicleID = "MEDIUM";
            else
                vehicleID = "HEAVY";

            string sender = "bullseyesj@gmail.com";
            string receiver = courierDt.Select("courierID=" + courierID)[0]["courierEmail"].ToString();
            string subject = "";
            string body = "";
            string psw = "bePassw0rd";
            if (totalWeight > 0)
            {
                if (totalWeight == currentWeight)
                {
                    HelpMethods.catchError(() => deliveryTableAdapter.InsertIntoDelivery(deliveryID, DateTime.Now, vehicleID, courierID));
                    if (currentType == "ORDER")
                    {
                        subject = "NEW - DeliveryID: "+deliveryID + " - Deliver to "+currentLoc;
                        body = "Truck size: " + vehicleID + "; Delivery date: " + deDay + ".";
                    }
                }
                else
                {
                    HelpMethods.catchError(() => deliveryTableAdapter.UpdateVehicleID(vehicleID, deliveryID));
                    if (currentType == "ORDER")
                    {
                        subject = "UPDATE - DeliveryID: " + deliveryID + " - Deliver to " + currentLoc;
                        body = "Truck size: " + vehicleID + "; Delivery date: " + deDay + ".";
                    }
                }
                HelpMethods.catchError(() => deliverytransactionTableAdapter.InsertIntoDT(deliveryID, transactionID, currentRouteID));

                //if (currentType == "ORDER")
                //    HelpMethods.sentEmail(sender, receiver, subject, body, psw);
            }
            
        }
    }
}
