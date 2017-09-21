using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace ACS.Inventory_Management
{
    public partial class Form_Login : Form
    {
        private static Boolean v_isClickConfig = false;
        public static SQLiteConnection v_conn;


        /*
         *  v_access
         *  value: 0 -> Admin (full access)
         *         1 -> Manager (read/write)
         *         2 -> Staff (read only)
         * */
        public static int v_acces;

        public Form_Login()
        {
            InitializeComponent();
        }

        private void Form_Login_Load(object sender, EventArgs e)
        {
            Size = new Size(442, 136); // set default size form login

            // set to test
            _textBox_file_db.Text = "D:\\VANDUAN\\Project\\ACS.Inventory Management\\ACS.Inventory Management.sqlite";
            _textBox_passwd_file_db.Text = "@eon1t123";
            f_setConn();
        }

        private void f_setConn()
        {
            string fileName = _textBox_file_db.Text;
            string passwd = _textBox_passwd_file_db.Text;
            try
            {
                v_conn = new System.Data.SQLite.SQLiteConnection("Data Source=" + fileName.Replace("\\", "\\\\") + ";Version=3;Password=" + passwd + ";");
            }
            catch (Exception)
            {
                MessageBox.Show("Can't connect to database. Please check config!", "Database connection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }



        private void _button_config_Click(object sender, EventArgs e)
        {
            if (!v_isClickConfig)
            {
                // show menu config
                Size = new Size(442, 290);
                v_isClickConfig = true;
                _button_config.Text = "Config <<";
            }
            else
            {
                // hide menu config
                Size = new Size(442, 148);
                v_isClickConfig = false;
                _button_config.Text = "Config >>";
            }
        }

        private void _button_browser_file_db_Click(object sender, EventArgs e)
        {
            // open file database sqlite (version 3)

            OpenFileDialog openfdl = new OpenFileDialog();
            openfdl.Title = "IT Storage Management Database";
            //v_openfdl.InitialDirectory = @"C:\";
            openfdl.Filter = "All files (*.*)|*.*| Sqlite (*.sqlite)|*.sqlite";
            openfdl.FilterIndex = 2;
            openfdl.RestoreDirectory = true;

            if (openfdl.ShowDialog() == DialogResult.OK)
            {
                _textBox_file_db.Text = openfdl.FileName;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // to test connection database

            String link = _textBox_file_db.Text;
            String passwd = _textBox_passwd_file_db.Text;
            try
            {
                // create connection to database
                v_conn = new System.Data.SQLite.SQLiteConnection("Data Source=" + link.Replace("\\", "\\\\") + ";Version=3;Password=" + passwd + ";");
                v_conn.Open();

                // try query...
                using (SQLiteCommand fmd = v_conn.CreateCommand())
                {
                    fmd.CommandText = @"SELECT * FROM users ";
                    fmd.CommandType = CommandType.Text;
                    fmd.ExecuteNonQuery();
                }
                v_conn.Close();
                MessageBox.Show("Success!", "Database connection", MessageBoxButtons.OK);

            }
            catch (Exception)
            {
                MessageBox.Show("Can't open database.\n Please check your file and password!", "Database connection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void _button_login_Click(object sender, EventArgs e)
        {
            try
            {
                string fileName = _textBox_file_db.Text;
                string passwd = _textBox_passwd_file_db.Text;
                v_conn = new System.Data.SQLite.SQLiteConnection("Data Source=" + fileName.Replace("\\", "\\\\") + ";Version=3;Password=" + passwd + ";");

                if (check_user())
                    openMainForm();
            }
            catch (Exception)
            {
                MessageBox.Show("Can't login right now.\n Please check your config!", "Login error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void openMainForm()
        {
            Form_Main fm = new Form_Main(v_conn, v_acces, _textBox_username.Text);
            //Form_Main fm = new Form_Main();
            Hide();
            fm.ShowDialog();
            Close();
        }

        private bool check_user()
        {
            _textBox_passwd.Text = "@eon1t123"; // to test
            _textBox_username.Text = "admin"; // to test

            string username, passwd;

            if (_textBox_passwd.Text == "" || _textBox_username.Text == "")
            {
                MessageBox.Show("Username or password is empty!", "Login Notification", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }


            v_conn.Open();
            using (SQLiteCommand fmd = v_conn.CreateCommand())
            {
                fmd.CommandText = @"SELECT * FROM users WHERE username=" + "\'" + _textBox_username.Text + "\'";
                fmd.CommandType = CommandType.Text;
                SQLiteDataReader r = fmd.ExecuteReader();

                r.Read(); // read data
                username = Convert.ToString(r["username"]);
                passwd = Convert.ToString(r["password"]);

                // compare
                if (_textBox_username.Text == username)
                {
                    if (getHashSha256(_textBox_passwd.Text).ToLower() == passwd.ToLower())
                    {
                        v_acces = Convert.ToInt16(r["access"]);
                        v_conn.Close();
                        return true; // user is true
                    }
                    else
                        MessageBox.Show("Wrong password!", "Login Notification", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                else
                    MessageBox.Show("User is not exist!", "Login Notification", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            v_conn.Close();
            return false;
        }
        public static string getHashSha256(string text)
        {
            SHA256Managed crypt = new SHA256Managed();
            string hash = String.Empty;
            byte[] crypto = crypt.ComputeHash(Encoding.ASCII.GetBytes(text), 0, Encoding.ASCII.GetByteCount(text));
            foreach (byte theByte in crypto)
            {
                hash += theByte.ToString("x2");
            }
            return hash;
        }
    }
}
