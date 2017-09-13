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
    public partial class _Form_Main : Form
    {
        public static SQLiteConnection v_conn;
        public _Form_Main(SQLiteConnection conn)
        {
            v_conn = conn;
            InitializeComponent();
            _button_treeview.MouseEnter += new EventHandler(_button_treeview_MouseEnter);
            _button_treeview.MouseLeave += new EventHandler(_button_treeview_MouseLeave);
        }

        private void _button_treeview_MouseLeave(object sender, EventArgs e)
        {
            _button_treeview.BackColor = Color.Chocolate;
        }

        private void _button_treeview_MouseEnter(object sender, EventArgs e)
        {
            _button_treeview.BackColor = Color.Snow;
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void _button_treeview_Click(object sender, EventArgs e)
        {
            _Form_TreeView ftw = new _Form_TreeView(v_conn);
            ftw.Show();
        }
    }
}
