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

namespace ACS.Inventory_Management
{
    public partial class Form_Main : Form
    {
        private int v_acces;
        private SQLiteConnection v_conn;
        private string v_username;

        private static List<string[]> v_category;

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

            // load tree view device
             try
            {
                load_treeview();
            }
            catch (Exception) {
                MessageBox.Show("Can not to show tree view!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

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
                                    _treeView_device.Nodes[0].Nodes[i].Nodes.Add(new TreeNode("SN: "+Convert.ToString(r["SN"])));
                                    continue;
                                }
                                _treeView_device.Nodes[0].Nodes[i].Nodes.Add(new TreeNode("NAME: "+Convert.ToString(r["Name"])));
                                continue;
                            }
                            _treeView_device.Nodes[0].Nodes[i].Nodes.Add(new TreeNode("SERI: " + Convert.ToString(r["Series"])));
                            continue;
                        }
                        _treeView_device.Nodes[0].Nodes[i].Nodes.Add(new TreeNode("ACODE: "+ Convert.ToString(r["AssetCode"])));
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
               return List<string[] = {CategoryID, CategoryName, Note, ImageID}>
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
             *                   Index:  0        1        2       3        4         5     6      7      8      9    10       11       12      13     14      15
               return List<string[] = {Model, AssetCode, Series, DateIn, DateOut, Status, Place, Note, UserBy, Ports, SN, PhoneNumber, IMET, Numbers, Name, CategoryID}>
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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
