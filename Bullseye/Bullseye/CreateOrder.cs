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
using Microsoft.VisualBasic;

namespace Bullseye
{
    public partial class CreateOrder : Form
    {
        User currentUser = new User();
        int transacitonID;
        string all = "All";
        //datatable for quering the transaction table
        DataTable transactionDt = new DataTable();
        //a datatable for quering the inner join table
        DataTable mixDt = new DataTable();
        //a datatable for suming quantity for ordering items
        DataTable quantitySumDt= new DataTable();
        //dataview
        DataView orderItemDv = new DataView();
        //datatable for quering the transactionLine table
        DataTable transactionLineDt = new DataTable();
        //datatable for quering the supplier table
        DataTable supplierDt = new DataTable();

        public CreateOrder(User u, int id)
        {
            InitializeComponent();
            currentUser = u;
            transacitonID = id;
        }

        //create a connection string
        static string connectionString = "datasource=localhost;port=3306;database=bullseye;" +
        "username=david;password=david";
        //create connection
        static MySqlConnection connDB = new MySqlConnection(connectionString);

        private void CreateOrder_Load(object sender, EventArgs e)
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

            HelpMethods.clearCbo(grpSearchItems);
            string resetDataCmd = orderCmd();

            if (HelpMethods.catchError(() => FillOrderDgv(resetDataCmd)) == false)
                this.Close();
            if (HelpMethods.catchError(() => transactionTableAdapter.GetData()) == false || HelpMethods.catchError(() => transactionlineTableAdapter.GetData()) == false)
                this.Close();
            else
            {
                transactionDt = transactionTableAdapter.GetData();
                transactionLineDt = transactionlineTableAdapter.GetData();

                bool editable = checkEditable();
                if (editable)
                    grpManage.Visible = true;
                else
                    grpManage.Visible = false;

                addButtons(editable);
                addChks(editable);

                HelpMethods.setupDgv(dgvOrderItem);
                dgvOrderItem.MultiSelect = true;
                dgvOrderItem.ClearSelection();

                fillCbos();

                colorShortage();
            }

            
        }

        private string orderCmd()
        {
            string cmd = "select item.itemID, item.itemName, item.description, transactionline.quantity as orderQuantity, " +
                "item.caseSize, item.categoryName as category, item.notes, supplier.companyName as supplier, inventory.quantity as warehouseQuantity from transactionline inner join item " +
                "on transactionline.transactionID = " + transacitonID +
                " and item.itemID = transactionline.itemID inner join supplier on item.supplierID = supplier.supplierID" +
                " inner join inventory on inventory.itemID=item.itemID and inventory.locationID = 'WARE'";
            return cmd;
        }

        private void FillOrderDgv(string cmd)
        {
            MySqlDataAdapter orderItemAdapter = new MySqlDataAdapter(cmd, connDB);

            mixDt.Clear();
            mixDt.TableName = "mixDt";
            if (HelpMethods.catchError(() => orderItemAdapter.Fill(mixDt)) == false)
                this.Close();

            bdsOrderItem.DataSource = mixDt;
            dgvOrderItem.DataSource = bdsOrderItem;

            dgvOrderItem.AutoResizeColumns();


        }

        private void colorShortage()
        {
            string cmd = "select itemID, sum(quantity) as sumQuantity  from transactionline where transactionID in (select transactionID from transaction where transactionStatus = 'SUBMITTED' ) group by itemID ";
            quantitySumDt.Clear();
            quantitySumDt.TableName = "quantitySumDt";
            MySqlDataAdapter quantitySumAdapter = new MySqlDataAdapter(cmd, connDB);
            string status = transactionDt.Select("transactionID = " + transacitonID)[0]["transactionStatus"].ToString();
            if (HelpMethods.catchError(() => quantitySumAdapter.Fill(quantitySumDt)) == false)
                this.Close();
            else if(status=="NEW"|| status == "SUBMITTED")
            {
                foreach (DataGridViewRow row in dgvOrderItem.Rows)
                {
                    foreach (DataRow r in quantitySumDt.Rows)
                    {
                        if (Convert.ToInt32(r["itemID"]) == Convert.ToInt32(row.Cells["itemID"].Value))
                        {
                            //MessageBox.Show(row.Cells["warehouseQuantity"].Value.ToString(), r["sumQuantity"].ToString());
                            if(Convert.ToInt32(row.Cells["warehouseQuantity"].Value)< Convert.ToInt32(r["sumQuantity"]))
                                row.DefaultCellStyle.BackColor = Color.Red;
                        }
                    }
                }
            }
        }

        private Boolean checkEditable()
        {
            btnSubmit.Enabled = false;
            btnProcessing.Enabled = false;
            btnModifyQuanties.Enabled = false;
            
            bool b = false;
            string expression = "transactionid =" + transacitonID;
            DataRow[] foundRows = transactionDt.Select(expression);
            if (foundRows.Count() >= 1 && currentUser.getLocationID() == foundRows[0]["originalLocationID"].ToString()&& currentUser.getActions().Contains("UPDATE ORDER") && foundRows[0]["transactionStatus"].ToString() == "NEW")
            {
                b = true;
                lblUserInfo.Text += "\n Order Status: " + foundRows[0]["transactionStatus"].ToString() + ", Order Type: " + foundRows[0]["transactionType"].ToString();
                if (foundRows[0]["transactionType"].ToString() == "EMERGENCY")
                    btnSubmit.Enabled = true;
            }
                
            else if(foundRows.Count() >= 1 && currentUser.getActions().Contains("CRUD")&&foundRows[0]["transactionStatus"].ToString() == "NEW")
            {
                b = true;
                lblUserInfo.Text += "\n Order Status: " + foundRows[0]["transactionStatus"].ToString() + ", Order Type: " + foundRows[0]["transactionType"].ToString();
                btnSubmit.Enabled = true;
            }
            if(currentUser.getActions().Contains("CRUD")|| currentUser.getActions().Contains("PROCESS ORDER"))
            {
                if (foundRows.Count() >= 1&& foundRows[0]["transactionStatus"].ToString()== "SUBMITTED")
                {
                    if(foundRows[0]["transactionType"].ToString() == "EMERGENCY"||
                        foundRows[0]["transactionType"].ToString() == "ORDER")
                        btnModifyQuanties.Enabled = true;
                    
                    if (ifEnough())
                        btnProcessing.Enabled = true;
                }
                    
            }

            return b;
        }

        private void addButtons(bool b)
        {
            if (dgvOrderItem.Columns.Contains("btnEdit") == false)
            {
                DataGridViewButtonColumn btnEdit = new DataGridViewButtonColumn();
                btnEdit.Name = "btnEdit";
                //btnEdit.HeaderText = "Edit";
                btnEdit.Text = "Edit";
                btnEdit.UseColumnTextForButtonValue = true; //dont forget this line
                dgvOrderItem.Columns.Add(btnEdit);
                
            }
            dgvOrderItem.Columns["btnEdit"].Visible = b;
            if (dgvOrderItem.Columns.Contains("btnDeleteOne") == false)
            {
                DataGridViewButtonColumn btnDelete = new DataGridViewButtonColumn();
                btnDelete.Name = "btnDeleteOne";
                //btnDelete.HeaderText = "Delete";
                btnDelete.Text = "Remove";
                btnDelete.UseColumnTextForButtonValue = true; //dont forget this line
                dgvOrderItem.Columns.Add(btnDelete);
                
            }
            dgvOrderItem.Columns["btnDeleteOne"].Visible = b;

        }

        private void addChks(bool b)
        {
            if (dgvOrderItem.Columns.Contains("checkBoxes") == false)
            {
                DataGridViewCheckBoxColumn CheckboxColumn = new DataGridViewCheckBoxColumn();

                int chkColIndex = 0;
                CheckboxColumn.Name = "checkBoxes";
                dgvOrderItem.Columns.Insert(chkColIndex, CheckboxColumn);
                
            }
            dgvOrderItem.Columns["checkBoxes"].Visible = b;
        }

        private void fillCbos()
        {
            HelpMethods.populateCbo(mixDt, "category", cboCategoryIF, all);
            if (HelpMethods.catchError(() => supplierTableAdapter.GetData()) == false)
                resetForm();
            else
            {
                supplierDt = supplierTableAdapter.GetData();
                HelpMethods.populateCbo(mixDt, "supplier", cboSupplierNameIF, all);
            }
        }

        private void CreateOrder_FormClosing(object sender, FormClosingEventArgs e)
        {
            connDB.Close();
        }
        
        private void chkAll_CheckedChanged(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dgvOrderItem.Rows)
            {
                if (row.Cells["itemID"] != row.Cells[0])
                {
                    DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)row.Cells[0];
                    if (chkAll.Checked)
                    {
                        chk.Value = true;
                        row.Selected = true;
                    }

                    else
                    {
                        chk.Value = false;
                        row.Selected = false;
                    }
                }
            }
        }

        private void dgvOrderItem_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 0)
            {
                DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)dgvOrderItem.Rows[e.RowIndex].Cells[0];

                if (Convert.ToBoolean(chk.Value) == true)
                {
                    chk.Value = false;
                    dgvOrderItem.Rows[e.RowIndex].Selected = false;
                }
                else
                {
                    chk.Value = true;
                    dgvOrderItem.Rows[e.RowIndex].Selected = true;
                }
            }
            else if (dgvOrderItem.Columns[e.ColumnIndex].Name == "btnDeleteOne")
            {
                int itemID = Convert.ToInt32(dgvOrderItem.Rows[e.RowIndex].Cells["itemID"].Value);
                DialogResult ifDelete = MessageBox.Show("Are you sure you want to remove this item?", "Confirm information", MessageBoxButtons.YesNo);
                if (ifDelete == DialogResult.Yes)
                {
                    HelpMethods.catchError(() => transactionlineTableAdapter.DeleteItem(transacitonID, itemID));
                    resetForm();
                }
            }
            else if (dgvOrderItem.Columns[e.ColumnIndex].Name == "btnEdit")
            {
                int itemID = Convert.ToInt32(dgvOrderItem.Rows[e.RowIndex].Cells["itemID"].Value);
                string quantityStr = dgvOrderItem.Rows[e.RowIndex].Cells["orderQuantity"].Value.ToString();
                int caseSize = Convert.ToInt32(dgvOrderItem.Rows[e.RowIndex].Cells["caseSize"].Value);
                string input = Interaction.InputBox("How many do you want to order?\nCase size: " + caseSize.ToString(), "Modify quantity", quantityStr);
                int newQuantity;
                if (int.TryParse(input, out newQuantity))
                {
                    if (newQuantity % caseSize == 0)
                    {
                        HelpMethods.catchError(() => transactionlineTableAdapter.UpdateQuantity(newQuantity, transacitonID, itemID));
                        resetForm();
                    }
                    else
                        MessageBox.Show("Order Quantity should base on the case size of this item", "Warning");
                }
                else if(input=="")
                    MessageBox.Show("Order Quantity didn't get modified", "Exit");
                else
                {
                    MessageBox.Show("Order Quantity should be a whole number", "Warning");
                }
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            DialogResult ifDelete = MessageBox.Show("Are you sure you want to remove those items?", "Confirm information", MessageBoxButtons.YesNo);
            if (ifDelete == DialogResult.Yes)
            {
                int count = 0;
                foreach (DataGridViewRow row in dgvOrderItem.Rows)
                {

                    DataGridViewCheckBoxCell chk = (DataGridViewCheckBoxCell)row.Cells[0];
                    int itemID = Convert.ToInt32(row.Cells["itemID"].Value);
                    if (Convert.ToBoolean(chk.Value))
                    {

                        if(HelpMethods.catchError(() => transactionlineTableAdapter.DeleteItem(transacitonID, itemID))==false)
                            resetForm();
                        else
                            count++;
                    }

                }
                if (count == 0)
                    MessageBox.Show("You need to select at least one item", "Warning");
                else
                {
                    MessageBox.Show("Those items have been Removed", "Removed");
                    resetForm();
                }
                    

                
            }   
        }

        private void btnSearchItem_Click(object sender, EventArgs e)
        {
            string itemID = txtItemIDIF.Text;
            //string sku = txtSkuIF.Text;
            string itemName = txtItemNameIF.Text;
            string description = txtDescriptionIF.Text;
            string category = cboCategoryIF.Text;
            string supplierName = cboSupplierNameIF.Text;
            HelpMethods.replaceStrChar(itemID, itemName, description, category, supplierName);

            string filterCmd = string.Format("convert(itemID, 'System.String') like '%{0}%'", itemID);

            List<string> itemNames = new List<string>();
            itemNames.Clear();
            if (itemName != "")
            {
                itemNames = itemName.Split(' ').ToList();
                itemName = "";
                for (int i = 0; i < itemNames.Count; i++)
                {
                    //" AND itemName like '%" + itemNames[i] + "%'";
                    itemName += " AND " + string.Format("convert(itemName, 'System.String') like '%{0}%'", itemNames[i]);
                }
                filterCmd += itemName;
            }

            List<string> descriptions = new List<string>();
            descriptions.Clear();
            if (description != "")
            {
                descriptions = description.Split(' ').ToList();
                description = "";
                for (int i = 0; i < descriptions.Count; i++)
                {
                    description += " AND " + string.Format("convert(description, 'System.String') like '%{0}%'", descriptions[i]);
                }
                filterCmd += description;
            }

            if (category == all)
                category = "";
            filterCmd += " AND " + string.Format("convert(category, 'System.String') like '%{0}%'", category);

            if (supplierName == all)
                supplierName = "";
            filterCmd += " AND " + string.Format("convert(supplier, 'System.String') like '%{0}%'", supplierName);

            HelpMethods.filterHelp(orderItemDv, mixDt, dgvOrderItem, filterCmd);
        }

        private void txtItemIDIF_KeyPress(object sender, KeyPressEventArgs e)
        {
            HelpMethods.RestrictCharacters("!@#$%^&*()_+=-`~';:\\|]}[{/?><.,", e);
        }

        private void txtItemNameIF_KeyPress(object sender, KeyPressEventArgs e)
        {
            HelpMethods.RestrictCharacters("!@#$%^&*()_+=-`~';:\\|]}[{/?><.,", e);
        }

        private void txtDescriptionIF_KeyPress(object sender, KeyPressEventArgs e)
        {
            HelpMethods.RestrictCharacters("!@#$%^&*()_+=-`~';:\\|]}[{/?><.,", e);
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            string locID = transactionDt.Select("transactionID = " + transacitonID)[0]["originalLocationID"].ToString();

            string expression = "transactionType ='ORDER' AND originalLocationID = '" + locID
                + "' AND transactionStatus = 'SUBMITTED'";
            DataRow[] foundRows = transactionDt.Select(expression);
            if (foundRows.Count() >= 1)
            {
                MessageBox.Show("There's already an SUBMITTED order from this location", "Warning");
            }
            else
            {
                string oldNote = transactionDt.Select("transactionID = " + transacitonID)[0]["notes"].ToString();
                string status = "SUBMITTED";
                string originalStatus = "NEW";
                string note = string.Concat(oldNote, "-->", "From '" + originalStatus + "' to '" + status + "'");
                if (HelpMethods.catchError(() => transactionTableAdapter.UpdateStatusAndNote(status, note, transacitonID)))
                {
                    resetForm();
                    
                }
                    
                else
                    this.Close();
            }
        }

        private void btnModifyQuanties_Click(object sender, EventArgs e)
        {
            if (ifEnough())
                MessageBox.Show("The warehouse has enough supplies to fulfill items in this order", "Information");
            else if(mtxtDeliveryDate.Text.Length != 10&&Convert.ToDateTime(mtxtDeliveryDate.Text)<=DateTime.Now)
            {
                MessageBox.Show("The Estimated Arrival date should be input and it should be later than today", "Information");
            }
            else
            {
                modifyQuan();
                MessageBox.Show("The quantities of some items has been modified and put into backorder(s)!", "Information");
            }
                
        }

        private bool ifEnough()
        {
            int count = 0;
            bool b = false;
            foreach (DataGridViewRow dgvRow in dgvOrderItem.Rows)
            {
                if (dgvRow.DefaultCellStyle.BackColor == Color.Red)
                    count++;
            }

            if (count == 0)
                b = true;

            return b;
        }

        private void modifyQuan()
        {
            
            int trid = 0;
            String str = "";
            foreach (DataGridViewRow dgvRow in dgvOrderItem.Rows)
            {
                
                if (dgvRow.DefaultCellStyle.BackColor == Color.Red)
                {
                    DataRow[] trids = transactionDt.Select("transactionStatus = 'SUBMITTED' or transactionStatus = 'PROCESSING' or transactionStatus = 'READY'");
                    foreach(DataRow idr in trids)
                    {
                        
                        trid = Convert.ToInt32(idr["transactionID"]);
                        DataRow[] getTrls = transactionLineDt.Select("transactionID = " + trid);
                        foreach (DataRow trlr in getTrls)
                        {
                            int iID = Convert.ToInt32(trlr["itemID"]);
                            if (iID == Convert.ToInt32(dgvRow.Cells["itemID"].Value))
                            {
                                foreach (DataRow r in quantitySumDt.Rows)
                                {
                                    if (Convert.ToInt32(r["itemID"]) == iID)
                                    {
                                        double percent = Convert.ToInt32(trlr["quantity"]) / Convert.ToDouble(r["sumQuantity"]);
                                        int wareQuan = Convert.ToInt32(dgvRow.Cells["warehouseQuantity"].Value);
                                        int caseSize = Convert.ToInt32(dgvRow.Cells["caseSize"].Value);
                                        int newQuan = (int)Math.Floor((wareQuan * percent)/caseSize)*caseSize;

                                        int backorderQuan = Convert.ToInt32(trlr["quantity"]) - newQuan;
                                        string locID = transactionDt.Select("transactionID = " + trid)[0]["originalLocationID"].ToString();
                                        putIntoBackOrder(backorderQuan, iID, locID);

                                        if (HelpMethods.catchError(() => transactionlineTableAdapter.UpdateQuantity(newQuan, trid, iID)) == false)
                                            resetForm();
                                        str = "Item " + iID + " quantity changed. ";
                                        string oldNote = transactionDt.Select("transactionID = " + trid)[0]["notes"].ToString();
                                        string note = string.Concat(oldNote, "-->", str);
                                        if (HelpMethods.catchError(() => transactionTableAdapter.UpdateNotes(note, trid)) == false)
                                            resetForm();
                                    }
                                }
                                
                            }
                            
                        }
                        //if (str != "")
                        //{
                        //    string oldNote = transactionDt.Select("transactionID = " + transacitonID)[0]["notes"].ToString();
                        //    string note = string.Concat(oldNote, "-->", str);
                        //    if (HelpMethods.catchError(() => transactionTableAdapter.UpdateNotes(note, trid)) == false)
                        //        resetForm();
                        //}
                    }
                }
            }

            resetForm();
        }

        private void putIntoBackOrder(int backorderQuan, int iID, string locID)
        {
            
            DataRow[] backOrders = transactionDt.Select("transactionStatus = 'SUBMITTED' and originalLocationID='"+locID+ "' and transactionType='BACKORDER'");
            if (backOrders.Count() < 1)
            {
                //transactionType, originalLocationID, creationDate, estimatedArrival, transactionStatus, notes)
                DateTime estimatedArrival = Convert.ToDateTime(mtxtDeliveryDate.Text);
                if (HelpMethods.catchError(() => transactionTableAdapter.InsertWithArrival("BACKORDER", locID, DateTime.Now, estimatedArrival, "SUBMITTED", "BACKORDER for: '"+locID+ "'. Estimated Arrival: "+ mtxtDeliveryDate.Text)) == false)
                    resetForm();
                
            }
            int backTransID= Convert.ToInt32(transactionTableAdapter.getNewsetID(locID, "BACKORDER", "SUBMITTED").Rows[0]["transactionID"]);
            try
            {
                //HelpMethods.catchError(() => transactionlineTableAdapter.InsertIntoTransactionLine(backTransID, iID, backorderQuan));
                transactionlineTableAdapter.InsertIntoTransactionLine(backTransID, iID, backorderQuan);
            }
            catch (Exception)
            {
                HelpMethods.catchError(() => transactionlineTableAdapter.UpdateQuantity(backorderQuan, backTransID, iID));
            }
            
            string oldNotes= transactionTableAdapter.GetNewestNotes(backTransID).Rows[0]["notes"].ToString();
            string notes = oldNotes + " Item ID: " + iID + ". Quantity: " + backorderQuan + ".";
            if (HelpMethods.catchError(() => transactionTableAdapter.UpdateNotes(notes, backTransID)) == false)
                resetForm();
        }

        private void btnProcessing_Click(object sender, EventArgs e)
        {
            if (!ifEnough())
                MessageBox.Show("The warehouse doesn't have enough supplies to fulfill some items in this order", "check it first");
            else
            {
                string oldNote = transactionDt.Select("transactionID = " + transacitonID)[0]["notes"].ToString();
                string status = "PROCESSING";
                string originalStatus = "SUBMITTED";
                string note = string.Concat(oldNote, "-->", "From '" + originalStatus + "' to '" + status + "'");

                if (HelpMethods.catchError(() => transactionTableAdapter.UpdateStatus(status, transacitonID)))
                    MessageBox.Show("Order is in processing!");
                resetForm();
            }
                
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            resetForm();
        }
    }
}
