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
    public partial class Warehouse : Form
    {
        //create a user object to contain the user being sent in, class level
        User currentUser = new User();
        //global variable for later usages
        string all = "All";
        string not = "Not";
        string addOrUpdateItem;
        private int newItemID = 0;
        //for check permission
        List<string> neededActs = new List<string> { "READ ITEM", "CRUD" };
        
        

        //datatable for quering the item table
        DataTable itemDt=new DataTable();
        //dataview
        DataView itemDv = new DataView();
        //datatable for quering the itemcategory table
        DataTable itemCategoryDt = new DataTable();
        //datatable for quering the supplier table
        DataTable supplierDt = new DataTable();

        public Warehouse(User u)
        {
            InitializeComponent();
            currentUser = u;
        }

        
        private void Warehouse_Load(object sender, EventArgs e)
        {
            //call checkFormPermission and reset form
            HelpMethods.checkFormPermission(tabWarehouse, currentUser.getActions(), neededActs);
            resetForm();
            
        }

        private void Warehouse_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }

        private void tabWarehouse_SelectedIndexChanged(object sender, EventArgs e)
        {
            resetForm();
        }

        private void resetForm()
        {
            //reset all tabs
            resetItem();
            string userID = currentUser.getUserID();
            string roleID = currentUser.getRoleID();
            string locationName = currentUser.getLocationName();
            lblUserInfo.Text = userID + ", " + roleID + ", Location: " + locationName;
        }


        //funtion name: resetItem
        //description: reset the item tab into the original display
        //sent: none
        //return: none
        private void resetItem()
        {
            //clear those cbos
            HelpMethods.clearCbo(grpSearchItems, grpChangeItem);
            
            //call method to fill the datatable and datagridview
            if (HelpMethods.catchError(() => HelpMethods.fillDtAndDgv(ref itemDt, itemTableAdapter.GetData, itemBindingSource, dgvItem)) == false)
                this.Close();
            else
            {
                //set up dgv
                HelpMethods.setupDgv(dgvItem);
                //decide if the user can see the active field based on their permission
                HelpMethods.toggleDgvField(dgvItem, currentUser.getActions(), itemDv, ref itemDt);
                //user with the certain permission could see more
                if(currentUser.getActions().Contains("DELETE ITEM"))
                {
                    if(dgvItem.Columns.Count > 0)
                    {
                        dgvItem.Columns["active"].Visible = true;
                        itemDv.Table = itemDt;
                        itemDv.RowFilter = "active=1 or active = 0";
                        dgvItem.DataSource = itemDv;
                    }    
                }

            }
            //hide and show certain controls
            HelpMethods.grpsToggle(false, grpChangeItem, btnRefreshItem, grpSearchItems, grpItem, grpManageItem, grpAdminItem);
            //call fillCbos
            fillCbos();
            //clear dgv selection
            dgvItem.ClearSelection();
            //check user permission to see what they can do in this tab
            HelpMethods.chkPermission(grpAdminItem, grpManageItem, btnAddItem, btnEditItem, currentUser.getActions(), "CRUD", "CREATE ITEM", "UPDATE ITEM");
            chkActiveItem.Visible = false;
            if (currentUser.getActions().Contains("DELETE ITEM") || currentUser.getActions().Contains("CRUD"))
                chkActiveItem.Visible = true;
            if (currentUser.getActions().Contains("DELETE ITEM"))
                grpAdminItem.Visible = true;
            //set up a variable to be for adding record
            if (newItemID == 0)
            {
                if (dgvItem.Columns.Count > 0)
                    newItemID = (int)itemDt.Compute("Max(itemID)", "")+1;
            }
                
        }

        //funtion name: fillCbos
        //description: fill the cbos by quering the database
        //sent: none
        //return: none
        private void fillCbos()
        {
            HelpMethods.populateCbo(itemDt, "categoryName", cboCategoryIF, all);

            if (HelpMethods.catchError(() => itemcategoryTableAdapter.GetData()) == false || HelpMethods.catchError(() => supplierTableAdapter.GetData()) == false)
                this.Close();
            else
            {

                itemCategoryDt = itemcategoryTableAdapter.GetData();
                HelpMethods.populateCbo(itemCategoryDt, "categoryName", cboCategoryI, not);
                supplierDt = supplierTableAdapter.GetData();
                fillSupplierCbo(itemDt, supplierDt, "supplierID", "companyName", cboSupplierNameIF, all);
                fillSupplierCbo(supplierDt, supplierDt, "supplierID", "companyName", cboSupplierNameI, not);
            }
            
        }

        private string fromNametoID(string name)
        {
            string supplierID = "";
            foreach (DataRow row in supplierDt.Rows)
            {
                if (name == row["companyName"].ToString())
                    supplierID = row["supplierID"].ToString();
            }
            return supplierID;
        }

        private void fillSupplierCbo(DataTable dt,DataTable dt2,string colName, string colName2, ComboBox cbo, string allOrNot)
        {
            if (allOrNot == "All")
                cbo.Items.Add("All");
            List<string> strs = new List<string>(dt.Rows.Count);
            foreach (DataRow row in dt.Rows)
            {
                foreach (DataRow r in dt2.Rows)
                {
                    if(row[colName].ToString()== r[colName].ToString())
                    {
                        if(strs.Contains(r[colName2].ToString())==false)
                            strs.Add(r[colName2].ToString());

                    }
                }
                    
            }
            for (int i = 0; i < strs.Count; i++)
            {
                if (cbo.Items.Contains(strs[i]) == false)
                    cbo.Items.Add(strs[i]);
            }

            cbo.SelectedIndex = 0;
        }

        private void btnEditItem_Click(object sender, EventArgs e)
        {
            //if dont select a record, this couldn't work
            if (dgvItem.SelectedRows.Count != 1)
            {
                MessageBox.Show("Please select an item to proceed", "Warning");
            }
            else
            {
                //the variable indicates thats a update operation
                addOrUpdateItem = "Update";

                //fill controls with certain data, shows the editing panel
                List<Control> itemCtrls = new List<Control> {lblItemIDI,txtItemNameI,txtSkuI,txtDescriptionI,
                    cboCategoryI,txtWeightI,txtCostPriceI,txtRetailPriceI,cboSupplierNameI,txtCaseSizeI,txtNotesI };

                HelpMethods.editPanelCreate(itemCtrls, dgvItem);
                foreach (DataRow row in supplierDt.Rows)
                {
                    if (dgvItem.SelectedRows[0].Cells["supplierID"].Value.ToString() == row["supplierID"].ToString())
                        cboSupplierNameI.Text = row["companyName"].ToString();
                }

                HelpMethods.grpsToggle(true, grpChangeItem, btnRefreshItem, grpSearchItems, grpItem, grpManageItem, grpAdminItem);
            }
        }

        private void btnAddItem_Click(object sender, EventArgs e)
        {
            //the variable indicates thats an adding operation
            addOrUpdateItem = "Add";
            //create the adding panel
            HelpMethods.addPanelCreate(grpChangeItem);
            //get a new id and shows the panel
            lblItemIDI.Text = newItemID.ToString();
            HelpMethods.grpsToggle(true, grpChangeItem, btnRefreshItem, grpSearchItems, grpItem, grpManageItem, grpAdminItem);
        }

        //this button can change the active status of the selected record
        private void btnSwitchItem_Click(object sender, EventArgs e)
        {
            if (dgvItem.SelectedRows.Count != 1)
                MessageBox.Show("Please select an item to proceed", "Warning");
            else
            {
                HelpMethods.grpsToggle(true, grpChangeItem, btnRefreshItem, grpSearchItems, grpItem, grpManageItem, grpAdminItem);
                grpChangeItem.Visible = false;

                Boolean currentStatus = Convert.ToBoolean(dgvItem.SelectedRows[0].Cells["active"].Value);
                DialogResult ifSwitch;
                if (currentStatus)
                    ifSwitch = MessageBox.Show("Are you sure you want to inactive this item?", "Confirm information", MessageBoxButtons.YesNo);
                else
                    ifSwitch = MessageBox.Show("Are you sure you want to active this item?", "Confirm information", MessageBoxButtons.YesNo);

                if (ifSwitch == DialogResult.Yes)
                {
                    string currentItemID = dgvItem.SelectedRows[0].Cells["itemID"].Value.ToString();

                    HelpMethods.catchError(() => itemTableAdapter.SwitchActiveStatus(!currentStatus, Convert.ToInt32(currentItemID)));
                    resetItem();
                }
                else
                {
                    HelpMethods.grpsToggle(false, grpChangeItem, btnRefreshItem, grpSearchItems, grpItem, grpManageItem, grpAdminItem);
                    grpChangeItem.Visible = false;
                }
            }
            
                
        }

        private void btnSaveItem_Click(object sender, EventArgs e)
        {
            //the id shouldn't be empty
            if(lblItemIDI.Text=="")
                MessageBox.Show("Item ID cannot be empty", "Input Error");
            else
            {
                //if any controls is a 'null' then set it to ""
                HelpMethods.makeCtrlNotNull(grpChangeItem);
                //add item
                if (addOrUpdateItem == "Add")
                {
                    if (HelpMethods.validateInt(lblItemIDI, cboSupplierNameI, txtCaseSizeI) || HelpMethods.validateDouble(txtWeightI, txtRetailPriceI, txtCostPriceI))
                    {
                        if (HelpMethods.catchError(() => itemTableAdapter.InsertIntoItem(Convert.ToInt32(lblItemIDI.Text),
                         txtItemNameI.Text, txtSkuI.Text, txtDescriptionI.Text, cboCategoryI.Text,
                         Convert.ToDecimal(txtWeightI.Text), Convert.ToDecimal(txtCostPriceI.Text),
                         Convert.ToDecimal(txtRetailPriceI.Text), Convert.ToInt32(fromNametoID(cboSupplierNameI.Text)),
                         Convert.ToInt32(txtCaseSizeI.Text), txtNotesI.Text, true)))
                            newItemID++;

                        resetItem();
                    }
                    else
                        MessageBox.Show("There're Invalid Input(s). Please check again", "Data type wrong");
                }
                //update item
                else
                {
                    if (HelpMethods.validateInt(lblItemIDI, cboSupplierNameI, txtCaseSizeI) || HelpMethods.validateDouble(txtWeightI, txtRetailPriceI, txtCostPriceI))
                    {
                        HelpMethods.catchError(() => itemTableAdapter.UpdateItem(txtItemNameI.Text, txtSkuI.Text,
                        txtDescriptionI.Text, cboCategoryI.Text,
                        Convert.ToDecimal(txtWeightI.Text), Convert.ToDecimal(txtCostPriceI.Text),
                        Convert.ToDecimal(txtRetailPriceI.Text), Convert.ToInt32(fromNametoID(cboSupplierNameI.Text)),
                        Convert.ToInt32(txtCaseSizeI.Text), txtNotesI.Text, true, Convert.ToInt32(lblItemIDI.Text)));

                        resetItem();
                    }  
                    else
                        MessageBox.Show("There're Invalid Input(s). Please check again", "Data type wrong");
                }
            }
                

        }

        //hide editing panel, restore other controls
        private void btnCancelItem_Click(object sender, EventArgs e)
        {
            HelpMethods.grpsToggle(false, grpChangeItem, btnRefreshItem, grpSearchItems, grpItem, grpManageItem, grpAdminItem);
        }
        //reset form
        private void btnRefreshItem_Click(object sender, EventArgs e)
        {
            resetItem();
        }
        //search by all kinds of filds, use the dataview filter
        private void btnSearchItem_Click(object sender, EventArgs e)
        {
            string itemID = txtItemIDIF.Text;
            string sku = txtSkuIF.Text;
            string itemName = txtItemNameIF.Text;
            string description = txtDescriptionIF.Text;
            string category = cboCategoryIF.Text;
            string supplierID = fromNametoID(cboSupplierNameIF.Text);
            HelpMethods.replaceStrChar(itemID, sku, itemName, description, category, supplierID);
            
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
            filterCmd += " AND " + string.Format("convert(categoryName, 'System.String') like '%{0}%'", category);
            
            if (supplierID == all)
                supplierID = "";
            filterCmd += " AND " + string.Format("convert(supplierID, 'System.String') like '%{0}%'", supplierID);

            if (currentUser.getActions().Contains("DELETE ITEM") || currentUser.getActions().Contains("CRUD"))
            {
                if (chkActiveItem.Checked)
                    filterCmd += "And active=1";
                else
                    filterCmd += "And active=0";
            }

            HelpMethods.filterHelp(itemDv, itemDt, dgvItem, filterCmd);

            
        }

        private void txtItemIDIF_KeyPress(object sender, KeyPressEventArgs e)
        {
            HelpMethods.RestrictCharacters("!@#$%^&*()_+=-`~';:\\|]}[{/?><.,", e);
        }

        private void txtSkuIF_KeyPress(object sender, KeyPressEventArgs e)
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
    }
}
