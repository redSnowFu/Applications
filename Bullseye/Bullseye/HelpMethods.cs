using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.Mail;
using System.Security.Cryptography;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bullseye
{
    public class HelpMethods
    {
        public HelpMethods()
        {

        }


        //funtion name: clearCbo
        //description: clear the cbos in those grps
        //sent: one or more groupboxes
        //return: none
        public static void clearCbo(params GroupBox[] grps)
        {
            foreach (GroupBox grp in grps)
            {
                for (int i = 0; i < grp.Controls.Count; i++)
                {
                    if (grp.Controls[i] is ComboBox CMB)
                        CMB.Items.Clear();
                }
            }
        }

        //funtion name: clearCtrls
        //description: clear the txt,maskedtxt,and uncheck the chk in those grps
        //sent: one or more groupboxes
        //return: none
        public static void clearCtrls(params GroupBox[] grps)
        {
            foreach(GroupBox grp in grps)
            {
                for(int i = 0; i < grp.Controls.Count; i++)
                {
                    if (grp.Controls[i] is TextBox || grp.Controls[i] is MaskedTextBox)
                        grp.Controls[i].Text = "";
                    else if (grp.Controls[i] is CheckBox chk)
                        chk.Checked = false;
                }
            }
        }

        //funtion name: grpsToggle
        //description: switch the visible controls, inable controls
        //sent: bool,gpr,btn,and one or more grps
        //return: none
        public static void grpsToggle(Boolean b, GroupBox grp1, Button btn, params GroupBox[] grps)
        {
            grp1.Visible = b;
            foreach (GroupBox grp in grps)
                grp.Enabled = !b;
            btn.Enabled = !b;
        }

        //funtion name: checkFormPermission
        //description: check which tab can be visible based on user's permission
        //sent: tabcontrol,list of string, list of string
        //return: none
        public static void checkFormPermission(TabControl tabAll, List<string> currentActs, List<string> neededActs)
        {
            List<TabPage> tps = new List<TabPage>();
            //foreach (TabPage tp in tabAll.TabPages)
            //    tps.Add(tp);
            for (int i = 0; i < tabAll.TabPages.Count; i++)
                tps.Add(tabAll.TabPages[i]);

            foreach (TabPage tp in tabAll.TabPages)
                tabAll.TabPages.Remove(tp);
            if (currentActs.Contains(neededActs[neededActs.Count-1]))
            {
                foreach (TabPage tp in tps)
                    tabAll.TabPages.Add(tp);
            }
            else
            {
                for(int i = 0; i < (neededActs.Count-1); i++)
                {
                    if (currentActs.Contains(neededActs[i]))
                        tabAll.TabPages.Add(tps[i]);
                }
            }
        }

        //funtion name: chkPermission
        //description: check which function can be used in a tab for a certain user
        //sent: grp,grp,btn,btn,list of string,string, string,string
        //return: none
        public static void chkPermission(GroupBox grpAdmin, GroupBox grpManage, Button btnAdd, Button btnEdit, List<string> actions, string d,string c, string u)
        {
            grpAdmin.Visible = false;
            grpManage.Visible = false;
            btnAdd.Enabled = false;
            btnEdit.Enabled = false;

            if (actions.Contains(d))
            {
                grpAdmin.Visible = true;
                grpManage.Visible = true;
                btnAdd.Enabled = true;
                btnEdit.Enabled = true;
            }
            else
            {
                if (actions.Contains(c))
                {
                    grpManage.Visible = true;
                    btnAdd.Enabled = true;
                }
                if (actions.Contains(u))
                {
                    grpManage.Visible = true;
                    btnEdit.Enabled = true;
                }

            }
        }

        //funtion name: catchError
        //description: a try catch for an action
        //sent: action
        //return: bool
        public static bool catchError(Action method)
        {
            try
            {
                method();
                return true;
            }
            catch (MySqlException ex)
            {
                MessageBox.Show(ex.Message, "DataError");
                return false;
            }  
        }

        //funtion name: addPanelCreate
        //description: open a panel for adding record
        //sent: groupbox
        //return: none
        public static void addPanelCreate(GroupBox grp)
        {
            foreach (Control ctrl in grp.Controls)
            {
                if (ctrl is TextBox || ctrl is MaskedTextBox)
                    ctrl.Text = "";
                if (ctrl is ComboBox cbo)
                    cbo.SelectedIndex = 0;
                
            }

        }

        //funtion name: editPanelCreate
        //description: a try catch for an action
        //sent: list of controls, datagridview
        //return: none
        public static void editPanelCreate(List<Control> ctrls, DataGridView dgv)
        {
            for(int i = 0; i < ctrls.Count; i++)
            {
                if (ctrls[i] is TextBox || ctrls[i] is MaskedTextBox || ctrls[i] is ComboBox || ctrls[i] is Label)
                    ctrls[i].Text = dgv.SelectedRows[0].Cells[i].Value.ToString();
            }
        }


        public static void setupDgv(DataGridView dgv)
        {
            dgv.AllowUserToAddRows = false;
            dgv.AllowUserToDeleteRows = false;
            dgv.MultiSelect = false;
            dgv.ReadOnly = true;
            //dgv.AllowUserToResizeColumns = false;
            dgv.AllowUserToResizeRows = false;
            
            dgv.RowHeadersVisible = false;
        }

        public static void fillDtAndDgv(ref DataTable dt, Func<DataTable> method, BindingSource bs, DataGridView dgv)
        {
            dt = method();
            bs.DataSource = dt;
            dgv.DataSource = bs;
            dgv.ClearSelection();
        }

        

        public static void toggleDgvField(DataGridView dgv, List<string> actions, DataView dv,ref DataTable dt)
        {
            if (dgv.Columns.Count > 0)
            {
                if (actions.Contains("CRUD"))
                {
                    dgv.Columns["active"].Visible = true;
                    dv.Table = dt;
                    dv.RowFilter = "active=1 or active = 0";
                    dgv.DataSource = dv;
                }
                    
                else
                {
                    dgv.Columns["active"].Visible = false;
                    dv.Table = dt;
                    dv.RowFilter="active=1";
                    dgv.DataSource = dv;
                }
                    
            }
        }

        public static void populateCbo(DataTable dt, string colName,ComboBox cbo,string allOrNot)
        {
            if (allOrNot == "All")
                cbo.Items.Add("All");
            List<string> strs = new List<string>(dt.Rows.Count);
            foreach (DataRow row in dt.Rows)
                strs.Add(row[colName].ToString());
            for(int i = 0; i < strs.Count; i++)
            {
                if(cbo.Items.Contains(strs[i])==false)
                    cbo.Items.Add(strs[i]);
            }
            
            cbo.SelectedIndex = 0;
        }

        public static void makeCtrlNotNull(GroupBox grp)
        {
            foreach (Control ctrl in grp.Controls)
            {
                if (ctrl is TextBox || ctrl is MaskedTextBox || ctrl is ComboBox)
                {
                    if (ctrl.Text == null)
                        ctrl.Text = "";
                }
            }
        }

        public static bool validateDouble(params Control[] ctrls)
        {
            Boolean valid = true;
            for(int i = 0; i < ctrls.Length; i++)
            {
                if(ctrls[i] is TextBox || ctrls[i] is MaskedTextBox || ctrls[i] is ComboBox||ctrls[i] is Label)
                {
                    if(Double.TryParse(ctrls[i].Text,out double d) == false)
                    {
                        valid = false;
                        break;
                    }
                }
            }
            return valid;
        }

        public static bool validateInt(params Control[] ctrls)
        {
            Boolean valid = true;
            for (int i = 0; i < ctrls.Length; i++)
            {
                if (ctrls[i] is TextBox || ctrls[i] is MaskedTextBox || ctrls[i] is ComboBox || ctrls[i] is Label)
                {
                    if (Int32.TryParse(ctrls[i].Text, out int d) == false)
                    {
                        valid = false;
                        break;
                    }
                }
            }
            return valid;
        }

        public static void replaceStrChar(params string[] strs)
        {
            foreach (string str in strs)
            {
                if (str.Contains("'"))
                    str.Replace("'", "''");
            }
                
        }

        public static void filterHelp(DataView dv, DataTable dt, DataGridView dgv, string cmd)
        {
            dv.Table = dt;
            
            dv.RowFilter = cmd;
            dgv.DataSource = dv;
        }

        public static string CalculateMD5Hash(string input)
        {
            // step 1, calculate MD5 hash from input
            MD5 md5 = System.Security.Cryptography.MD5.Create();
            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
            byte[] hash = md5.ComputeHash(inputBytes);

            // step 2, convert byte array to hex string
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("x2"));
            }
            return sb.ToString();
        }

        public static bool RestrictCharacters(string charactersToRestrict, KeyPressEventArgs e)
        {
            e.Handled = (charactersToRestrict + '"').Contains(e.KeyChar.ToString());
            return e.Handled == false ? true : false;
        }

        public static void sentEmail(string sender, string receiver, string subject,string body,string psw)
        {
            try
            {
                MailMessage mail = new MailMessage();
                SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
                
                mail.From = new MailAddress(sender);
                mail.To.Add(receiver);
                mail.Subject = subject;
                mail.Body = body;

                SmtpServer.Port = 587;
                SmtpServer.Credentials = new System.Net.NetworkCredential(sender, psw);
                SmtpServer.EnableSsl = true;

                SmtpServer.Send(mail);
                MessageBox.Show("mail Send");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }
    }
}
