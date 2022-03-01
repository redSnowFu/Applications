using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace Bullseye
{
    public partial class Admin : Form
    {
        //create a user object to contain the user being sent in, class level
        User currentUser = new User();
        //global variable for later usages
        string all = "All";
        string not = "Not";
        private int newCourierID = 0;
        string addOrUpdateCourier;
        //for check permission
        List<string> neededActs = new List<string> { "READ USER", "READ LOCATION", "READ COURIER", "CRUD" };

        

        //dataview for user tab
        DataView userDv = new DataView();
        //dataview for location tab
        DataView locDv = new DataView();
        //dataview for courier tab
        DataView courierDv = new DataView();
        //datatable for quering the user table
        DataTable userDt = new DataTable();
        //datatable for quering the location table
        DataTable locDt = new DataTable();
        //datatable for quering the courier table
        DataTable courierDt = new DataTable();
        //datatable for quering the role table
        DataTable roleDt = new DataTable();
        //datatable for quering the province table
        DataTable provinceDt = new DataTable();
        //datatable for quering the locationType table
        DataTable locTypeDt = new DataTable();

        public Admin(User u)
        {
            InitializeComponent();
            currentUser = u;
        }
        
        
        private void Admin_Load(object sender, EventArgs e)
        {
            //call checkFormPermission and reset form
            HelpMethods.checkFormPermission(tabAdmin, currentUser.getActions(), neededActs);
            resetForm();
        }

        private void Admin_FormClosing(object sender, FormClosingEventArgs e)
        {
            
        }
        //tab index changes, the form will be reset as well
        private void tabAdmin_SelectedIndexChanged(object sender, EventArgs e)
        {
            resetForm();
        }
        //funtion name: resetFrom
        //description: reset the all tabs into the original display
        //sent: none
        //return: none
        private void resetForm()
        {
            string userID = currentUser.getUserID();
            string roleID = currentUser.getRoleID();
            string locationName = currentUser.getLocationName();
            lblUserInfo.Text = userID + ", " + roleID + ", Location: " + locationName;
            resetUser();
            resetLocation();
            resetCourier();
        }

        //****************************************************************************
        //*****************************************************************************
        //******************************************************************************
        //For the User Tab
        //******************************************************************************
        //*****************************************************************************
        //****************************************************************************

        //funtion name: resetUser
        //description: reset the user tab into the original display
        //sent: none
        //return: none
        private void resetUser()
        {
            //clear those cbos
            HelpMethods.clearCbo(grpFilterU, grpChangeUser);
            //call method to fill the datatable and datagridview
            if (HelpMethods.catchError(() => HelpMethods.fillDtAndDgv(ref userDt, userTableAdapter.GetData, userBindingSource, dgvUser)) == false)
                this.Close();
            else
            {
                //set up dgv
                HelpMethods.setupDgv(dgvUser);
                //decide if the user can see the active field based on their permission
                HelpMethods.toggleDgvField(dgvUser, currentUser.getActions(), userDv, ref userDt);
            }
            //hide and show certain controls
            HelpMethods.grpsToggle(false, grpChangeUser, btnRefreshUser, grpFilterU, grpUser, grpManageUser, grpAdminUser);
            //call fillCbos
            fillUserCbos();
            //clear dgv selection
            dgvUser.ClearSelection();
            //check user permission to see what they can do in this tab
            HelpMethods.chkPermission(grpAdminUser, grpManageUser, btnAddUser, btnEditUser, currentUser.getActions(), "CRUD", "CREATE USER", "UPDATE USER");
        }

        //funtion name: fillCbos
        //description: fill the cbos by quering the database
        //sent: none
        //return: none
        private void fillUserCbos()
        {
            HelpMethods.populateCbo(userDt, "userID", cboUserIDUF, all);
            HelpMethods.populateCbo(userDt, "locationID", cboLocationIDUF, all);
            HelpMethods.populateCbo(userDt, "roleID", cboRoleIDUF, all);
            if (HelpMethods.catchError(() => locationTableAdapter.GetData()) == false || HelpMethods.catchError(() => roleTableAdapter.GetData()) == false)
                resetUser();
            else
            {
                locDt = locationTableAdapter.GetData();
                HelpMethods.populateCbo(locDt, "locationID", cboLocationIDU, not);
                roleDt = roleTableAdapter.GetData();
                HelpMethods.populateCbo(roleDt, "roleID", cboRoleIDU, not);
            }
            
        }

        
        //if the index of the cbo changes, the datagridview will change as well
        private void cboUserIDUF_SelectedIndexChanged(object sender, EventArgs e)
        {
            string userID = cboUserIDUF.Text;
            if (userID == all)
                userID = "";
            string filterCmd = string.Format("convert(userID, 'System.String') like '%{0}%'", userID);
            HelpMethods.filterHelp(userDv, userDt, dgvUser, filterCmd);
        }
        //if the index of the cbo changes, the datagridview will change as well
        private void cboLocationIDUF_SelectedIndexChanged(object sender, EventArgs e)
        {
            string locationID = cboLocationIDUF.Text;
            if (locationID == all)
                locationID = "";
            string filterCmd = string.Format("convert(locationID, 'System.String') like '%{0}%'", locationID);
            HelpMethods.filterHelp(userDv, userDt, dgvUser, filterCmd);
            
        }
        //if the index of the cbo changes, the datagridview will change as well
        private void cboRoleIDUF_SelectedIndexChanged(object sender, EventArgs e)
        {
            string roleID = cboRoleIDUF.Text;
            if (roleID == all)
                roleID = "";
            string filterCmd = string.Format("convert(roleID, 'System.String') like '%{0}%'", roleID);
            HelpMethods.filterHelp(userDv, userDt, dgvUser, filterCmd);
            
        }

        private void btnEditUser_Click(object sender, EventArgs e)
        {
            //if dont select a record, this couldn't work
            if (dgvUser.SelectedRows.Count != 1)
            {
                MessageBox.Show("Please select an item to proceed", "Warning");
            }
            else
            {
                //fill controls with certain data, shows the editing panel
                List<Control> userCtrls = new List<Control> { txtUserIDU, txtPswU, cboLocationIDU, cboRoleIDU };

                HelpMethods.editPanelCreate(userCtrls, dgvUser);
                txtUserIDU.Enabled = false;

                HelpMethods.grpsToggle(true, grpChangeUser, btnRefreshUser, grpFilterU, grpUser, grpManageUser, grpAdminUser);
            }
            
        }

        private void btnAddUser_Click(object sender, EventArgs e)
        {
            //create the adding panel
            HelpMethods.addPanelCreate(grpChangeUser);
            txtUserIDU.Enabled = true;

            HelpMethods.grpsToggle(true, grpChangeUser, btnRefreshUser, grpFilterU, grpUser, grpManageUser, grpAdminUser);
        }
        //this button can change the active status of the selected record
        private void btnSwitchUser_Click(object sender, EventArgs e)
        {
            //if dont select a record, this couldn't work
            if (dgvUser.SelectedRows.Count != 1)
            {
                MessageBox.Show("Please select an item to proceed", "Warning");
            }
            else
            {
                HelpMethods.grpsToggle(true, grpChangeUser, btnRefreshUser, grpFilterU, grpUser, grpManageUser, grpAdminUser);
                grpChangeUser.Visible = false;

                Boolean currentStatus = Convert.ToBoolean(dgvUser.SelectedRows[0].Cells["active"].Value);
                DialogResult ifSwitch;
                if (currentStatus)
                    ifSwitch = MessageBox.Show("Are you sure you want to inactive this user?", "Confirm information", MessageBoxButtons.YesNo);
                else
                    ifSwitch = MessageBox.Show("Are you sure you want to active this user?", "Confirm information", MessageBoxButtons.YesNo);

                if (ifSwitch == DialogResult.Yes)
                {
                    string currentUserID = dgvUser.SelectedRows[0].Cells["userID"].Value.ToString();
                    HelpMethods.catchError(() => userTableAdapter.SwitchActiveStatus(!currentStatus, currentUserID));
                    resetUser();
                }
                else
                {
                    HelpMethods.grpsToggle(false, grpChangeUser, btnRefreshUser, grpFilterU, grpUser, grpManageUser, grpAdminUser);
                    grpChangeUser.Visible = false;
                }
            }
            

        }

        private void btnSaveUser_Click(object sender, EventArgs e)
        {
            //the id and password shouldn't be empty
            if (txtUserIDU.Text == "")
                MessageBox.Show("User ID cannot be empty", "Input Error");
            else if(txtPswU.Text=="")
                MessageBox.Show("Password cannot be empty", "Input Error");
            else
            {
                //if any controls is a 'null' then set it to ""
                HelpMethods.makeCtrlNotNull(grpChangeUser);
                //encryped the password
                string encryPsw = HelpMethods.CalculateMD5Hash(txtPswU.Text);
                //add user
                if (txtUserIDU.Enabled)
                {
                    HelpMethods.catchError(() => userTableAdapter.InsertIntoUser(txtUserIDU.Text, encryPsw, cboLocationIDU.Text, cboRoleIDU.Text, true));
                    resetUser();
                }
                //edit user
                else
                {
                    HelpMethods.catchError(() => userTableAdapter.UpdateUser(encryPsw, cboLocationIDU.Text, cboRoleIDU.Text, txtUserIDU.Text));
                    resetUser();
                }
            }
        }
        //hide editing panel, restore other controls
        private void btnCancelUser_Click(object sender, EventArgs e)
        {
            HelpMethods.grpsToggle(false, grpChangeUser, btnRefreshUser, grpFilterU, grpUser, grpManageUser, grpAdminUser);
        }
        //set user tab
        private void btnRefreshUser_Click(object sender, EventArgs e)
        {
            resetUser();
        }


        //****************************************************************************
        //*****************************************************************************
        //******************************************************************************
        //For the location Tab
        //******************************************************************************
        //*****************************************************************************
        //****************************************************************************

        //funtion name: resetLocation
        //description: reset the location tab into the original display
        //sent: none
        //return: none
        private void resetLocation()
        {
            //clear those cbos
            HelpMethods.clearCbo(grpChangeLoc, grpSearchLocation);
            //call method to fill the datatable and datagridview
            if (HelpMethods.catchError(() => HelpMethods.fillDtAndDgv(ref locDt, locationTableAdapter.GetData, locationBindingSource, dgvLocation)) == false)
                this.Close();
            else
            {
                //set up dgv
                HelpMethods.setupDgv(dgvLocation);
                //decide if the user can see the active field based on their permission
                HelpMethods.toggleDgvField(dgvLocation, currentUser.getActions(), locDv, ref locDt);
            }
            //hide and show certain controls
            HelpMethods.grpsToggle(false, grpChangeLoc, btnRefreshLoc, grpSearchLocation, grpLocation, grpManageLoc, grpAdminLoc);
            //call fillLocCbos
            fillLocCbos();
            //manually fill a cbo
            cboDeliveryDayL.Items.AddRange(new string[] { "MONDAY", "TUESDAY", "WEDNESDAY", "THURSDAY", "FRIDAY", "SATURDAY", "SUNDAY", "ANY"});
            //clear dgv selection
            dgvLocation.ClearSelection();
            //check user permission to see what they can do in this tab
            HelpMethods.chkPermission(grpAdminLoc, grpManageLoc, btnAddLoc, btnEditLoc, currentUser.getActions(), "CRUD", "CREATE LOCATION", "UPDATE LOCATION");
        }
        //funtion name: fillLocCbos
        //description: fill the cbos by quering the database
        //sent: none
        //return: none
        private void fillLocCbos()
        {
            HelpMethods.populateCbo(locDt, "province", cboProvinceLF, all);
            HelpMethods.populateCbo(locDt, "locationTypeID", cboLocationTypeLF, all);
            if (HelpMethods.catchError(() => provinceTableAdapter.GetData()) == false || HelpMethods.catchError(() => locationtypeTableAdapter.GetData()) == false)
                resetLocation();
            else
            {
                provinceDt = provinceTableAdapter.GetData();
                HelpMethods.populateCbo(provinceDt, "provinceID", cboProvinceL, not);
                locTypeDt = locationtypeTableAdapter.GetData();
                HelpMethods.populateCbo(locTypeDt, "locationTypeID", cboLocationTypeIDL, not);
            }
            
        }
        //if the index of the cbo changes, the datagridview will change as well
        private void cboProvinceLF_SelectedIndexChanged(object sender, EventArgs e)
        {
            string province = cboProvinceLF.Text;
            if (province == all)
                province = "";
            string filterCmd = string.Format("convert(province, 'System.String') like '%{0}%'", province);

            HelpMethods.filterHelp(locDv, locDt, dgvLocation, filterCmd);
        }
        //if the index of the cbo changes, the datagridview will change as well
        private void cboLocationTypeLF_SelectedIndexChanged(object sender, EventArgs e)
        {
            string type = cboLocationTypeLF.Text;
            if (type == all)
                type = "";
            string filterCmd = string.Format("convert(locationTypeID, 'System.String') like '%{0}%'", type);

            HelpMethods.filterHelp(locDv, locDt, dgvLocation, filterCmd);
            
        }

        private void btnEditLoc_Click(object sender, EventArgs e)
        {
            //if dont select a record, this couldn't work
            if (dgvLocation.SelectedRows.Count != 1)
            {
                MessageBox.Show("Please select an item to proceed", "Warning");
            }
            else
            {
                //fill controls with certain data, shows the editing panel
                List<Control> locCtrls = new List<Control> { txtLocationIDL, txtDescriptionL, txtAddressL, txtCityL, cboProvinceL,
                txtPostalCodeL,txtCountryL,cboLocationTypeIDL,cboDeliveryDayL};

                HelpMethods.editPanelCreate(locCtrls, dgvLocation);
                txtLocationIDL.Enabled = false;

                HelpMethods.grpsToggle(true, grpChangeLoc, btnRefreshLoc, grpSearchLocation, grpLocation, grpManageLoc, grpAdminLoc);
            }
        }

        private void btnAddLoc_Click(object sender, EventArgs e)
        {
            //create the adding panel
            HelpMethods.addPanelCreate(grpChangeLoc);
            txtLocationIDL.Enabled = true;

            HelpMethods.grpsToggle(true, grpChangeLoc, btnRefreshLoc, grpSearchLocation, grpLocation, grpManageLoc, grpAdminLoc);
        }
        //this button can change the active status of the selected record
        private void btnSwitchLoc_Click(object sender, EventArgs e)
        {
            //if dont select a record, this couldn't work
            if (dgvLocation.SelectedRows.Count != 1)
            {
                MessageBox.Show("Please select an item to proceed", "Warning");
            }
            else
            {
                HelpMethods.grpsToggle(true, grpChangeLoc, btnRefreshLoc, grpSearchLocation, grpLocation, grpManageLoc, grpAdminLoc);
                grpChangeLoc.Visible = false;

                Boolean locStatus = Convert.ToBoolean(dgvLocation.SelectedRows[0].Cells["active"].Value);
                DialogResult ifSwitch;
                if (locStatus)
                    ifSwitch = MessageBox.Show("Are you sure you want to inactive this location?", "Confirm information", MessageBoxButtons.YesNo);
                else
                    ifSwitch = MessageBox.Show("Are you sure you want to active this location?", "Confirm information", MessageBoxButtons.YesNo);
                if (ifSwitch == DialogResult.Yes)
                {

                    string currentLocID = dgvLocation.SelectedRows[0].Cells["locationID"].Value.ToString();
                    HelpMethods.catchError(() => locationTableAdapter.SwitchActiveStatus(!locStatus, currentLocID));
                    resetLocation();
                }
                else
                {
                    HelpMethods.grpsToggle(true, grpChangeLoc, btnRefreshLoc, grpSearchLocation, grpLocation, grpManageLoc, grpAdminLoc);
                    grpChangeLoc.Visible = false;
                }
            }
            

        }

        private void btnSaveLoc_Click(object sender, EventArgs e)
        {
            //the id should be four character
            if (txtLocationIDL.Text.Length != 4)
                MessageBox.Show("Location ID should be four upper-case letter", "Input Error");
            else
            {
                //if any controls is a 'null' then set it to ""
                HelpMethods.makeCtrlNotNull(grpChangeLoc);
                //add location
                if (txtLocationIDL.Enabled)
                {
                    HelpMethods.catchError(() => locationTableAdapter.InsertIntoLocation(txtLocationIDL.Text.ToUpper(), txtDescriptionL.Text, txtAddressL.Text, txtCityL.Text, cboProvinceL.Text, txtPostalCodeL.Text, txtCountryL.Text, cboLocationTypeIDL.Text, cboDeliveryDayL.Text, true));
                    resetLocation();
                    
                }
                //update location
                else
                {
                    HelpMethods.catchError(() => locationTableAdapter.UpdateLocation(txtDescriptionL.Text, txtAddressL.Text, txtCityL.Text, cboProvinceL.Text, txtPostalCodeL.Text, txtCountryL.Text, cboLocationTypeIDL.Text, cboDeliveryDayL.Text, txtLocationIDL.Text));
                    resetLocation();
                }
            }
        }
        //hide editing panel, restore other controls
        private void btnCancelLoc_Click(object sender, EventArgs e)
        {
            HelpMethods.grpsToggle(false, grpChangeLoc, btnRefreshLoc, grpSearchLocation, grpLocation, grpManageLoc, grpAdminLoc);
        }
        //reset location tab
        private void btnRefreshLoc_Click(object sender, EventArgs e)
        {
            resetLocation();
        }

        //****************************************************************************
        //*****************************************************************************
        //******************************************************************************
        //For the Courier Tab
        //******************************************************************************
        //*****************************************************************************
        //****************************************************************************

        //funtion name: resetCourier
        //description: reset the courier tab into the original display
        //sent: none
        //return: none
        private void resetCourier()
        {
            //clear those cbos
            HelpMethods.clearCbo(grpSearchCourier, grpChangeCourier);
            //call method to fill the datatable and datagridview
            if (HelpMethods.catchError(() => HelpMethods.fillDtAndDgv(ref courierDt, courierTableAdapter.GetData, courierBindingSource, dgvCourier)) == false)
                this.Close();
            else
            {
                //set up dgv
                HelpMethods.setupDgv(dgvCourier);
                //decide if the user can see the active field based on their permission
                HelpMethods.toggleDgvField(dgvCourier, currentUser.getActions(), courierDv, ref courierDt);
            }
            //hide and show certain controls
            HelpMethods.grpsToggle(false, grpChangeCourier, btnRefreshCourier, grpSearchCourier, grpCourier, grpManageCourier, grpAdminCourier);
            //call fillCourierCbos
            fillCourierCbos();
            //clear dgv selection
            dgvCourier.ClearSelection();
            //check user permission to see what they can do in this tab
            HelpMethods.chkPermission(grpAdminCourier, grpManageCourier, btnAddCourier, btnEditCourier, currentUser.getActions(), "CRUD", "CREATE COURIER", "UPDATE COURIER");
            //set up a variable to be for adding record
            if (newCourierID==0)
            {
                if (dgvCourier.Columns.Count > 0)
                    newCourierID = (int)courierDt.Compute("Max(courierID)", "") + 1;
            }
        }
        //funtion name: fillCourierCbos
        //description: fill the cbos by quering the database
        //sent: none
        //return: none
        private void fillCourierCbos()
        {
            HelpMethods.populateCbo(courierDt, "provinceID", cboProvinceCF, all);
            if (HelpMethods.catchError(() => provinceTableAdapter.GetData()) == false)
                resetLocation();
            else
            {
                provinceDt = provinceTableAdapter.GetData();
                HelpMethods.populateCbo(provinceDt, "provinceID", cboProvinceCourier, not);
            }
        }
        //if the index of the cbo changes, the datagridview will change as well
        private void cboProvinceCF_SelectedIndexChanged(object sender, EventArgs e)
        {
            string province = cboProvinceCF.Text;
            if (province == all)
                province = "";
            string filterCmd = string.Format("convert(provinceID, 'System.String') like '%{0}%'", province);
            HelpMethods.filterHelp(courierDv, courierDt, dgvCourier, filterCmd);
            
        }

        private void btnEditCourier_Click(object sender, EventArgs e)
        {
            //if dont select a record, this couldn't work
            if (dgvCourier.SelectedRows.Count != 1)
            {
                MessageBox.Show("Please select an item to proceed", "Warning");
            }
            else
            {
                //fill controls with certain data, shows the editing panel
                List<Control> CourierCtrl = new List<Control> { lblCourierIDC, txtCourierNameC, txtAddressCourier, txtCityCourier, cboProvinceCourier,
                txtPostalCodeCourier, txtCountryCourier,txtCourierEmailC,mtxtCourierPhoneC,txtNoteCourier};

                HelpMethods.editPanelCreate(CourierCtrl, dgvCourier);
                //the variable indicates thats a update operation
                addOrUpdateCourier = "Update";

                HelpMethods.grpsToggle(true, grpChangeCourier, btnRefreshCourier, grpSearchCourier, grpCourier, grpManageCourier, grpAdminCourier);
            }
        }

        private void btnAddCourier_Click(object sender, EventArgs e)
        {
            //create the adding panel
            HelpMethods.addPanelCreate(grpChangeCourier);
            //the variable indicates thats an adding operation
            addOrUpdateCourier = "Add";
            //get a new id and shows the panel
            lblCourierIDC.Text = newCourierID.ToString();

            HelpMethods.grpsToggle(true, grpChangeCourier, btnRefreshCourier, grpSearchCourier, grpCourier, grpManageCourier, grpAdminCourier);
        }
        //this button can change the active status of the selected record
        private void btnSwitchCourier_Click(object sender, EventArgs e)
        {
            //if dont select a record, this couldn't work
            if (dgvCourier.SelectedRows.Count != 1)
            {
                MessageBox.Show("Please select an item to proceed", "Warning");
            }
            else
            {
                HelpMethods.grpsToggle(true, grpChangeCourier, btnRefreshCourier, grpSearchCourier, grpCourier, grpManageCourier, grpAdminCourier);
                grpChangeCourier.Visible = false;

                Boolean courierStatus = Convert.ToBoolean(dgvCourier.SelectedRows[0].Cells[10].Value);
                DialogResult ifSwitch;
                if (courierStatus)
                    ifSwitch = MessageBox.Show("Are you sure you want to inactive this courier?", "Confirm information", MessageBoxButtons.YesNo);
                else
                    ifSwitch = MessageBox.Show("Are you sure you want to active this courier?", "Confirm information", MessageBoxButtons.YesNo);

                if (ifSwitch == DialogResult.Yes)
                {

                    string currentCourierID = dgvCourier.SelectedRows[0].Cells["courierID"].Value.ToString();
                    HelpMethods.catchError(() => courierTableAdapter.SwitchActiveStatus(!courierStatus, Convert.ToInt32(currentCourierID)));
                    resetCourier();
                }
                else
                {
                    HelpMethods.grpsToggle(true, grpChangeCourier, btnRefreshCourier, grpSearchCourier, grpCourier, grpManageCourier, grpAdminCourier);
                    grpChangeCourier.Visible = false;
                }
            }
            

        }

        private void btnSaveCourier_Click(object sender, EventArgs e)
        {
            //if any controls is a 'null' then set it to ""
            HelpMethods.makeCtrlNotNull(grpChangeCourier);
            //add courier
            if (addOrUpdateCourier == "Add")
            {
                if (HelpMethods.catchError(() => courierTableAdapter.InsertIntoCourier(txtCourierNameC.Text, txtAddressCourier.Text, txtCityCourier.Text, cboProvinceCourier.Text, txtPostalCodeCourier.Text, txtCountryCourier.Text, txtCourierEmailC.Text, mtxtCourierPhoneC.Text, txtNoteCourier.Text, true)) == false)
                    newCourierID++;
                resetCourier();
            }
            //update courier
            else
            {
                HelpMethods.catchError(() => courierTableAdapter.UpdateCourier(txtCourierNameC.Text, txtAddressCourier.Text, txtCityCourier.Text, cboProvinceCourier.Text, txtPostalCodeCourier.Text, txtCountryCourier.Text, txtCourierEmailC.Text, mtxtCourierPhoneC.Text, txtNoteCourier.Text, true, Convert.ToInt32(lblCourierIDC.Text)));
                resetCourier();
            }
            
        }
        //hide editing panel, restore other controls
        private void btnCancelCourier_Click(object sender, EventArgs e)
        {
            HelpMethods.grpsToggle(false, grpChangeCourier, btnRefreshCourier, grpSearchCourier, grpCourier, grpManageCourier, grpAdminCourier);
        }
        //reset courier tab
        private void btnRefreshCourier_Click(object sender, EventArgs e)
        {
            resetCourier();
        }

        private void txtUserIDU_KeyPress(object sender, KeyPressEventArgs e)
        {
            HelpMethods.RestrictCharacters("!@#$%^&*()+=-`~';:\\|]}[{/?><.,", e);
        }

        private void txtPswU_KeyPress(object sender, KeyPressEventArgs e)
        {
            //HelpMethods.RestrictCharacters("!@#$%^&*()_+=-`~';:\\|]}[{/?><.,", e);
        }
    }
}
