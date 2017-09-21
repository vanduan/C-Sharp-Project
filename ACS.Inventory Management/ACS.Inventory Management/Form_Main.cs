using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace ACS.Inventory_Management
{
    public partial class Form_Main : Form
    {
        private int v_acces;
        private SQLiteConnection v_conn;
        private string v_username;

        private static List<string[]> v_category;

        private static string v_selectNodeText = null; // to reload datagirdview

        public Form_Main(SQLiteConnection v_conn, int v_acces, string text)
        {
            this.v_conn = v_conn;
            this.v_acces = v_acces;
            this.v_username = text;
            InitializeComponent();
        }

        private void Form_Main_Load(object sender, EventArgs e)
        {
            /*
         *  v_access
         *  value: 0 -> Admin (full access)
         *         1 -> Manager (read/write)
         *         2 -> Staff (read only)
         * */
            if (v_acces == 1)
                _button_Admin.Enabled = false;
            if (v_acces == 2)
            {
                _button_Admin.Enabled = false;
                _button_manager.Enabled = false;
            }

            // disable edit
            disable_edit();

            // display username
            // _label_userdisplay.Text = v_username;

            // hide lable+comBoBox select type
            _label_type.Hide();
            _comboBox_type.Hide();

            // load tree view device
            try
            {
                load_treeview();
            }
            catch (Exception)
            {
                MessageBox.Show("Can not to show tree view!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // load item for comboBox finder
            ComboBoxItem item = new ComboBoxItem();
            item = new ComboBoxItem();
            item.Text = "Anything";
            item.Value = "All";
            _comboBox_findIn.Items.Add(item);
            foreach (string[] strarr in v_category)
            {
                item = new ComboBoxItem();
                item.Text = strarr[1];
                item.Value = strarr[0];
                _comboBox_findIn.Items.Add(item);
            }

            // create data gird view 
            create_girdview();
        }

        private void create_girdview()
        {
            // create columns
            _dataGridView_devices.ColumnCount = 15;
            _dataGridView_devices.Columns[0].Name = "Model";
            _dataGridView_devices.Columns[1].Name = "Asset code";
            _dataGridView_devices.Columns[2].Name = "Series";
            _dataGridView_devices.Columns[3].Name = "Date in";
            _dataGridView_devices.Columns[4].Name = "Date out";
            _dataGridView_devices.Columns[5].Name = "Status";
            _dataGridView_devices.Columns[6].Name = "Place";
            _dataGridView_devices.Columns[7].Name = "Note";
            _dataGridView_devices.Columns[8].Name = "User by";
            _dataGridView_devices.Columns[9].Name = "Device name";
            _dataGridView_devices.Columns[10].Name = "SN";
            _dataGridView_devices.Columns[11].Name = "Phone number";
            _dataGridView_devices.Columns[12].Name = "IMEI";
            _dataGridView_devices.Columns[13].Name = "Numbers";
            _dataGridView_devices.Columns[14].Name = "Port";

            _dataGridView_devices.RowsDefaultCellStyle.BackColor = Color.White;
            _dataGridView_devices.AlternatingRowsDefaultCellStyle.BackColor = Color.LightGray;
        }

        private void disable_edit()
        {
            _textBox_code.ReadOnly = true;
            _textBox_datein.ReadOnly = true;
            _textBox_dateout.ReadOnly = true;
            _textBox_devicename.ReadOnly = true;
            _textBox_IMET.ReadOnly = true;
            _textBox_note.ReadOnly = true;
            _textBox_numbers.ReadOnly = true;
            _textBox_port.ReadOnly = true;
            _textBox_series.ReadOnly = true;
            _textBox_SN.ReadOnly = true;
            _textBox_usedby.ReadOnly = true;
            _textBox_model.ReadOnly = true;
            _textBox_phone.ReadOnly = true;
            _textBox_place.ReadOnly = true;
            _textBox_status.ReadOnly = true;

        }

        private void load_treeview()
        {
            // 1. load data category
            load_data();

            // 2. add node category to tree view
            TreeNode[] nodeCategorys = new TreeNode[v_category.Count]; // new tree node category

            for (int i = 0; i < v_category.Count; i++)
            {
                TreeNode node = new TreeNode(v_category[i][1]);
                node.ImageIndex = Convert.ToInt16(v_category[i][3]);
                nodeCategorys[i] = node;
            }
            TreeNode root = new TreeNode("ACS.IT Storage Management - HCM", nodeCategorys);
            _treeView_device.Nodes.Add(root);
            _treeView_device.Nodes[0].Expand();

            // 3. add node decive
            v_conn.Open();
            using (SQLiteCommand fmd = v_conn.CreateCommand())
            {
                for (int i = 0; i < v_category.Count; i++)
                {
                    fmd.CommandText = @"SELECT AssetCode, Series, Name, SN FROM Devices WHERE CategoryID like " + "\"" + v_category[i][0] + "\"";
                    fmd.CommandType = CommandType.Text;
                    SQLiteDataReader r = fmd.ExecuteReader();

                    while (r.Read())
                    {
                        if (Convert.ToString(r["AssetCode"]) == "")
                        {
                            if (Convert.ToString(r["Series"]) == "")
                            {
                                if (Convert.ToString(r["Name"]) == "")
                                {
                                    _treeView_device.Nodes[0].Nodes[i].Nodes.Add(new TreeNode("SN: " + Convert.ToString(r["SN"])));
                                    continue;
                                }
                                _treeView_device.Nodes[0].Nodes[i].Nodes.Add(new TreeNode("NAME: " + Convert.ToString(r["Name"])));
                                continue;
                            }
                            _treeView_device.Nodes[0].Nodes[i].Nodes.Add(new TreeNode("SERI: " + Convert.ToString(r["Series"])));
                            continue;
                        }
                        _treeView_device.Nodes[0].Nodes[i].Nodes.Add(new TreeNode("ACODE: " + Convert.ToString(r["AssetCode"])));
                    }
                    r.Close();
                }
                v_conn.Close();
            }
        }

        private void load_data()
        {
            // 1. load category device
            v_category = load_category();
        }

        private List<string[]> load_decives()
        {
            /* query decives from database
             *                    Index:  0        1        2       3        4         5     6      7      8      9    10       11       12      13    14      15
               return List<string[] = {Model, AssetCode, Series, DateIn, DateOut, Status, Place, Note, UserBy, Ports, SN, PhoneNumber, IMET, Numbers, Name, CategoryID}>
               
                */
            List<string[]> decives = new List<string[]>();
            v_conn.Open();
            using (SQLiteCommand fmd = v_conn.CreateCommand())
            {
                fmd.CommandText = @"SELECT * FROM Devices";
                fmd.CommandType = CommandType.Text;
                SQLiteDataReader r = fmd.ExecuteReader();

                while (r.Read())
                {
                    decives.Add(new string[] { Convert.ToString(r["Model"]), Convert.ToString(r["AssetCode"]),
                        Convert.ToString(r["Series"]), Convert.ToString(r["DateIn"]), Convert.ToString(r["DateOut"]),
                        Convert.ToString(r["Status"]), Convert.ToString(r["Place"]), Convert.ToString(r["Note"]),
                        Convert.ToString(r["UserBy"]), Convert.ToString(r["Ports"]), Convert.ToString(r["SN"]),
                        Convert.ToString(r["PhoneNumber"]), Convert.ToString(r["IMET"]), Convert.ToString(r["Numbers"]),
                        Convert.ToString(r["Name"]), Convert.ToString(r["CategoryID"]) });
                }
            }
            v_conn.Close();
            return decives;
        }

        private List<string[]> load_category()
        {
            /* query category from database
             * return List<string[] = {CategoryID, CategoryName, Note, ImageID}>
                */
            List<string[]> category = new List<string[]>();
            v_conn.Open();
            using (SQLiteCommand fmd = v_conn.CreateCommand())
            {
                fmd.CommandText = @"SELECT * FROM Category";
                fmd.CommandType = CommandType.Text;
                SQLiteDataReader r = fmd.ExecuteReader();

                while (r.Read())
                {
                    category.Add(new string[] { Convert.ToString(r["CategoryID"]), Convert.ToString(r["CategoryName"]), Convert.ToString(r["Note"]), Convert.ToString(r["ImageID"]) });
                }
            }
            v_conn.Close();
            return category;
        }

        private void _treeView_device_NodeMouseDoubleClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            //MessageBox.Show(e.Node.Text+":"+e.Node.Level);

            if (e.Node.Level == 1)
            {
                // clear old data
                _dataGridView_devices.Rows.Clear();
                _dataGridView_devices.Update();
                // double click on category ==> show detail of all detail in category
                v_conn.Open();
                using (SQLiteCommand fmd = v_conn.CreateCommand())
                {
                    foreach (string[] line in v_category)
                    {
                        if (line[1] == e.Node.Text)
                        {
                            fmd.CommandText = @"SELECT * FROM Devices WHERE CategoryID like " + "\"" + line[0] + "\"";
                            fmd.CommandType = CommandType.Text;
                            SQLiteDataReader r = fmd.ExecuteReader();

                            int count = 0;
                            while (r.Read())
                            {
                                string[] row = new string[] { Convert.ToString(r["Model"]), Convert.ToString(r["AssetCode"]), Convert.ToString(r["Series"]),
                                    Convert.ToString(r["DateIn"]),Convert.ToString(r["DateOut"]),Convert.ToString(r["Status"]),Convert.ToString(r["Place"]),
                                    Convert.ToString(r["Note"]),Convert.ToString(r["UserBy"]),Convert.ToString(r["Name"]),Convert.ToString(r["SN"]),
                                    Convert.ToString(r["PhoneNumber"]), Convert.ToString(r["IMEI"]),Convert.ToString(r["Numbers"]), Convert.ToString(r["Ports"])};
                                _dataGridView_devices.Rows.Add(row);
                                _dataGridView_devices.Rows[count].HeaderCell.Value = string.Format((count + 1).ToString(), "0");
                                count++;
                            }
                            break;
                            r.Close();
                        }
                    }
                }
                v_conn.Close();
                _dataGridView_devices.Update();
            }
        }

        private void _treeView_device_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                if (e.Node.Level == 2)
                {
                    // double click on device ==> show detail of device
                    string cmd = null;
                    if (e.Node.Text.Contains("ACODE"))
                        cmd = @"SELECT * FROM Devices WHERE AssetCode like " + "\"" + e.Node.Text.Split(':')[1].Substring(1) + "\"";
                    else if (e.Node.Text.Contains("SERI"))
                        cmd = @"SELECT * FROM Devices WHERE Series like " + "\"" + e.Node.Text.Split(':')[1].Substring(1) + "\"";
                    else if (e.Node.Text.Contains("NAME"))
                        cmd = @"SELECT * FROM Devices WHERE Name like " + "\"" + e.Node.Text.Split(':')[1].Substring(1) + "\"";
                    else if (e.Node.Text.Contains("SN"))
                        cmd = @"SELECT * FROM Devices WHERE SN like " + "\"" + e.Node.Text.Split(':')[1].Substring(1) + "\"";
                    v_conn.Open();
                    using (SQLiteCommand fmd = v_conn.CreateCommand())
                    {
                        fmd.CommandText = cmd;
                        fmd.CommandType = CommandType.Text;
                        SQLiteDataReader r = fmd.ExecuteReader();

                        if (r.Read())
                        {
                            _textBox_code.Text = Convert.ToString(r["AssetCode"]);
                            _textBox_datein.Text = Convert.ToString(r["DateIn"]);
                            _textBox_dateout.Text = Convert.ToString(r["DateOut"]);
                            _textBox_devicename.Text = Convert.ToString(r["Name"]);
                            _textBox_IMET.Text = Convert.ToString(r["IMEI"]);
                            _textBox_note.Text = Convert.ToString(r["Note"]);
                            _textBox_numbers.Text = Convert.ToString(r["Numbers"]);
                            _textBox_phone.Text = Convert.ToString(r["PhoneNumber"]);
                            _textBox_port.Text = Convert.ToString(r["Ports"]);
                            _textBox_series.Text = Convert.ToString(r["Series"]);
                            _textBox_SN.Text = Convert.ToString(r["SN"]);
                            _textBox_usedby.Text = Convert.ToString(r["UserBy"]);
                            _textBox_status.Text = Convert.ToString(r["Status"]);
                            _textBox_place.Text = Convert.ToString(r["Place"]);
                            _textBox_model.Text = Convert.ToString(r["Model"]);
                        }
                    }
                    v_conn.Close();
                }
            }
            else if (e.Button == MouseButtons.Right)
            {
                if (e.Node.Level == 1)
                {
                    _treeView_device.SelectedNode = e.Node; // select node on click
                    _contextMenuStrip_treeview.Items[2].Enabled = true; // reload
                    _contextMenuStrip_treeview.Items[0].Enabled = true; // view on table
                    _contextMenuStrip_treeview.Items[4].Enabled = false; // edit node device
                    _contextMenuStrip_treeview.Show(MousePosition);
                }
                else if (e.Node.Level == 0)
                {
                    _treeView_device.SelectedNode = e.Node; // select node on click
                    _contextMenuStrip_treeview.Items[0].Enabled = false; // view on table
                    _contextMenuStrip_treeview.Items[4].Enabled = false; // edit node device
                    _contextMenuStrip_treeview.Show(MousePosition);
                }
                else if (e.Node.Level == 2)
                {
                    _treeView_device.SelectedNode = e.Node; // select node on click
                    _contextMenuStrip_treeview.Items[3].Enabled = true; // reload
                    _contextMenuStrip_treeview.Items[0].Enabled = false; // view on table
                    if (v_acces == 0 || v_acces == 1)
                        _contextMenuStrip_treeview.Items[4].Enabled = true; // edit node device
                    _contextMenuStrip_treeview.Show(MousePosition);
                }
            }

        }



        private void reloadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // load tree view device

            try
            {
                _treeView_device.Nodes.Clear();
                v_category.Clear();
                load_treeview();
            }
            catch (Exception)
            {
                MessageBox.Show("Can not to show tree view!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void _dataGridView_devices_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            // view detail of device
            try
            {
                //_dataGridView_devices.Rows[v_rowIndex].Selected = false;
                //_dataGridView_devices.Rows[e.RowIndex].Selected = true;
                if (e.Button == MouseButtons.Left)
                {
                    //  _dataGridView_devices.Rows[v_rowIndex].Selected = false;

                    _textBox_code.Text = _dataGridView_devices.Rows[e.RowIndex].Cells[1].Value.ToString();
                    _textBox_datein.Text = _dataGridView_devices.Rows[e.RowIndex].Cells[3].Value.ToString();
                    _textBox_dateout.Text = _dataGridView_devices.Rows[e.RowIndex].Cells[4].Value.ToString();
                    _textBox_devicename.Text = _dataGridView_devices.Rows[e.RowIndex].Cells[9].Value.ToString();
                    _textBox_IMET.Text = _dataGridView_devices.Rows[e.RowIndex].Cells[12].Value.ToString();
                    _textBox_note.Text = _dataGridView_devices.Rows[e.RowIndex].Cells[7].Value.ToString();
                    _textBox_numbers.Text = _dataGridView_devices.Rows[e.RowIndex].Cells[13].Value.ToString();
                    _textBox_phone.Text = _dataGridView_devices.Rows[e.RowIndex].Cells[11].Value.ToString();
                    _textBox_port.Text = _dataGridView_devices.Rows[e.RowIndex].Cells[14].Value.ToString();
                    _textBox_series.Text = _dataGridView_devices.Rows[e.RowIndex].Cells[2].Value.ToString();
                    _textBox_SN.Text = _dataGridView_devices.Rows[e.RowIndex].Cells[10].Value.ToString();
                    _textBox_usedby.Text = _dataGridView_devices.Rows[e.RowIndex].Cells[8].Value.ToString();
                    _textBox_status.Text = _dataGridView_devices.Rows[e.RowIndex].Cells[5].Value.ToString();
                    _textBox_place.Text = _dataGridView_devices.Rows[e.RowIndex].Cells[6].Value.ToString();
                    _textBox_model.Text = _dataGridView_devices.Rows[e.RowIndex].Cells[0].Value.ToString();
                }
                else if (e.Button == MouseButtons.Right)
                {
                    _dataGridView_devices.CurrentCell = _dataGridView_devices.Rows[e.RowIndex].Cells[e.ColumnIndex];
                    _dataGridView_devices.Rows[e.RowIndex].Selected = true;

                    _contextMenuStrip_girdview.Show(MousePosition);
                }
            }
            catch (Exception) { };
        }

        private void viewOnTableToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // view devices on table

            // clear old data
            _dataGridView_devices.Rows.Clear();
            _dataGridView_devices.Update();
            // double click on category ==> show detail of all detail in category
            v_conn.Open();
            using (SQLiteCommand fmd = v_conn.CreateCommand())
            {
                foreach (string[] line in v_category)
                {
                    if (line[1] == _treeView_device.SelectedNode.Text)
                    {

                        fmd.CommandText = @"SELECT * FROM Devices WHERE CategoryID like " + "\"" + line[0] + "\"";
                        fmd.CommandType = CommandType.Text;
                        SQLiteDataReader r = fmd.ExecuteReader();

                        int count = 0;
                        while (r.Read())
                        {
                            string[] row = new string[] { Convert.ToString(r["Model"]), Convert.ToString(r["AssetCode"]), Convert.ToString(r["Series"]),
                                    Convert.ToString(r["DateIn"]),Convert.ToString(r["DateOut"]),Convert.ToString(r["Status"]),Convert.ToString(r["Place"]),
                                    Convert.ToString(r["Note"]),Convert.ToString(r["UserBy"]),Convert.ToString(r["Name"]),Convert.ToString(r["SN"]),
                                    Convert.ToString(r["PhoneNumber"]), Convert.ToString(r["IMEI"]),Convert.ToString(r["Numbers"]), Convert.ToString(r["Ports"])};
                            _dataGridView_devices.Rows.Add(row);
                            _dataGridView_devices.Rows[count].HeaderCell.Value = string.Format((count + 1).ToString(), "0");
                            count++;
                        }
                        break;
                        r.Close();
                    }
                }
            }
            v_conn.Close();
            _dataGridView_devices.Update();
            v_selectNodeText = _treeView_device.SelectedNode.Text;
        }

        private void editToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void reloadToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            // clear old data
            _dataGridView_devices.Rows.Clear();
            _dataGridView_devices.Update();
            // double click on category ==> show detail of all detail in category
            v_conn.Open();
            using (SQLiteCommand fmd = v_conn.CreateCommand())
            {
                foreach (string[] line in v_category)
                {
                    if (line[1] == v_selectNodeText)
                    {

                        fmd.CommandText = @"SELECT * FROM Devices WHERE CategoryID like " + "\"" + line[0] + "\"";
                        fmd.CommandType = CommandType.Text;
                        SQLiteDataReader r = fmd.ExecuteReader();

                        int count = 0;
                        while (r.Read())
                        {
                            string[] row = new string[] { Convert.ToString(r["Model"]), Convert.ToString(r["AssetCode"]), Convert.ToString(r["Series"]),
                                    Convert.ToString(r["DateIn"]),Convert.ToString(r["DateOut"]),Convert.ToString(r["Status"]),Convert.ToString(r["Place"]),
                                    Convert.ToString(r["Note"]),Convert.ToString(r["UserBy"]),Convert.ToString(r["Name"]),Convert.ToString(r["SN"]),
                                    Convert.ToString(r["PhoneNumber"]), Convert.ToString(r["IMEI"]),Convert.ToString(r["Numbers"]), Convert.ToString(r["Ports"])};
                            _dataGridView_devices.Rows.Add(row);
                            _dataGridView_devices.Rows[count].HeaderCell.Value = string.Format((count + 1).ToString(), "0");
                            count++;
                        }
                        break;
                        r.Close();
                    }
                }
            }
            v_conn.Close();
            _dataGridView_devices.Update();
        }

        private void _pictureBox_find_Click(object sender, EventArgs e)
        {

            try
            {
                if (_textBox_findwhat.Text != "")
                {
                    string findIn = null;
                    
                    if (_comboBox_findIn.Text == "")
                    {
                        findIn = "Anything";
                        find_fn(_textBox_findwhat.Text, findIn, "");
                    }
                    else
                    {
                        findIn = _comboBox_findIn.Text;
                        find_fn(_textBox_findwhat.Text, findIn, _comboBox_findIn.Text);
                    }

                }
                else
                {
                    MessageBox.Show("What do you want to search!?", "Find empty", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception x) {
                MessageBox.Show(e.ToString());
            }
        }

        private void find_fn(string findwhat, string findIn, string text)
        {
            // clear old data
            _dataGridView_devices.Rows.Clear();
            _dataGridView_devices.Update();
            // double click on category ==> show detail of all detail in category
            v_conn.Open();
            using (SQLiteCommand fmd = v_conn.CreateCommand())
            {
                if (findIn == "Anything")
                    fmd.CommandText = @"SELECT * FROM Devices WHERE Model GLOB " + "\'*" + findwhat + "*\' OR " + "AssetCode GLOB " + "\'*" + findwhat + "*\' OR "
                         + "Series GLOB " + "\'*" + findwhat + "*\' OR " + "DateIn GLOB " + "\'*" + findwhat + "*\' OR "
                          + "DateOut GLOB " + "\'*" + findwhat + "*\' OR " + "Status GLOB " + "\'*" + findwhat + "*\' OR "
                           + "Place GLOB " + "\'*" + findwhat + "*\' OR " + "Note GLOB " + "\'*" + findwhat + "*\' OR "
                            + "UserBy GLOB " + "\'*" + findwhat + "*\' OR " + "Name GLOB " + "\'*" + findwhat + "*\' OR "
                             + "SN GLOB " + "\'*" + findwhat + "*\' OR " + "PhoneNumber GLOB " + "\'*" + findwhat + "*\' OR "
                              + "IMEI GLOB " + "\'*" + findwhat + "*\' OR " + "Numbers GLOB " + "\'*" + findwhat + "*\' OR "
                               + "Ports GLOB " + "\'*" + findwhat + "*\'";
                else
                {
                    fmd.CommandText = @"SELECT * FROM Devices WHERE CategoryID LIKE "+ "(SELECT CategoryID FROM Category WHERE CategoryName LIKE \'" + text + "\' ) "
                        + "AND (Model GLOB " + "\'*" + findwhat + "*\' OR " + "AssetCode GLOB " + "\'*" + findwhat + "*\' OR "
                        + "Series GLOB " + "\'*" + findwhat + "*\' OR " + "DateIn GLOB " + "\'*" + findwhat + "*\' OR "
                          + "DateOut GLOB " + "\'*" + findwhat + "*\' OR " + "Status GLOB " + "\'*" + findwhat + "*\' OR "
                           + "Place GLOB " + "\'*" + findwhat + "*\' OR " + "Note GLOB " + "\'*" + findwhat + "*\' OR "
                            + "UserBy GLOB " + "\'*" + findwhat + "*\' OR " + "Name GLOB " + "\'*" + findwhat + "*\' OR "
                             + "SN GLOB " + "\'*" + findwhat + "*\' OR " + "PhoneNumber GLOB " + "\'*" + findwhat + "*\' OR "
                              + "IMEI GLOB " + "\'*" + findwhat + "*\' OR " + "Numbers GLOB " + "\'*" + findwhat + "*\' OR "
                               + "Ports GLOB " + "\'*" + findwhat + "*\')";
                }
                //MessageBox.Show(fmd.CommandText);
                fmd.CommandType = CommandType.Text;
                SQLiteDataReader r = fmd.ExecuteReader();

                int count = 0;
                while (r.Read())
                {
                    string[] row = new string[] { Convert.ToString(r["Model"]), Convert.ToString(r["AssetCode"]), Convert.ToString(r["Series"]),
                                    Convert.ToString(r["DateIn"]),Convert.ToString(r["DateOut"]),Convert.ToString(r["Status"]),Convert.ToString(r["Place"]),
                                    Convert.ToString(r["Note"]),Convert.ToString(r["UserBy"]),Convert.ToString(r["Name"]),Convert.ToString(r["SN"]),
                                    Convert.ToString(r["PhoneNumber"]), Convert.ToString(r["IMEI"]),Convert.ToString(r["Numbers"]), Convert.ToString(r["Ports"])};
                    _dataGridView_devices.Rows.Add(row);
                    _dataGridView_devices.Rows[count].HeaderCell.Value = string.Format((count + 1).ToString(), "0");
                    count++;
                }

                r.Close();
            }
            v_conn.Close();
            _dataGridView_devices.Update();
        }
    }
}
