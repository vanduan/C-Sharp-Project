using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SQLite;

namespace ACS.Advanced_IP
{
    public partial class _Form_TreeView : Form
    {
        public static SQLiteConnection v_conn;
        public static List<String> v_ipvlan;


        Class_Func v_class_func = new Class_Func();

        public _Form_TreeView(SQLiteConnection conn)
        {
            InitializeComponent();
            v_conn = conn;

        }
        private void _Form_TreeView_Load(object sender, EventArgs e)
        {
            _load_ipvlan();
            _button_pause.Enabled = false;
            _button_stop.Enabled = false;
            _button_scan.Enabled = false;
        }
        private void _load_ipvlan()
        {
            v_ipvlan = v_class_func._query_data_ipvlan(v_conn); // get list ip vlan
            v_ipvlan.Sort();

            // add item to combobox
            ComboBoxItem v_item = new ComboBoxItem();

            foreach (String line in v_ipvlan)
            {
                v_item = new ComboBoxItem();
                v_item.Text = line;
                v_item.Value = line.Split(':')[0].Split(' ')[1];
                _comboBox_ipvlan.Items.Add(v_item);
            }

        }
        private void _button_scan_MouseEnter(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void _button_scan_Click(object sender, EventArgs e)
        {
            _button_stop.Enabled = true;
            _button_pause.Enabled = true;
            String v_ipaddress = null;
            List<String> v_ip_listscan = null;
            try
            {

                // VLAN from database

                v_ipaddress = (_comboBox_ipvlan.SelectedItem as ComboBoxItem).Text.ToString().Split(':')[1];


            }
            catch (Exception)
            {
                // enter ipaddress 
                v_ipaddress = _comboBox_ipvlan.Text;
                v_ip_listscan = v_class_func._get_listip_ipvlan(v_ipaddress); // get list ip to scan

            }
            //v_ipaddress = _comboBox_ipvlan.Text;
            MessageBox.Show(v_ipaddress);

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void _comboBox_ipvlan_SelectedIndexChanged(object sender, EventArgs e)
        {
            // check ip address 
            try
            {
                if (v_class_func._checkIP(_comboBox_ipvlan.Text))
                {
                    _button_scan.Enabled = true;
                    //MessageBox.Show("true");
                }
                else
                {
                    _button_scan.Enabled = false;
                    //MessageBox.Show("false");
                }
            }
            catch (Exception)
            {
                _button_scan.Enabled = false;
                _comboBox_ipvlan.ForeColor = Color.Red;
            }
        }

        private void _comboBox_ipvlan_TextChanged(object sender, EventArgs e)
        {
            // check ip address
            try
            {
                if (v_class_func._checkIP(_comboBox_ipvlan.Text))
                {
                    _button_scan.Enabled = true;
                    _comboBox_ipvlan.ForeColor = Color.Black;
                    //MessageBox.Show("true");
                }
                else
                {
                    _button_scan.Enabled = false;
                    _comboBox_ipvlan.ForeColor = Color.Red;
                    //MessageBox.Show("false");
                }
            }
            catch (Exception)
            {
                _button_scan.Enabled = false;
                _comboBox_ipvlan.ForeColor = Color.Red;
            }
        }
    }
}
