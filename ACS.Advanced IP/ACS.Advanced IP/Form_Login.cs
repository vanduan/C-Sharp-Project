using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SQLite;
using System.Security.Cryptography;

namespace ACS.Advanced_IP
{
    public partial class _Form_Login : Form
    {
        public static Boolean v_isClickConfig = false;
        public static SQLiteConnection v_conn;
        public object SQLiteConnection { get; private set; }

        public _Form_Login()
        {
            InitializeComponent();
        }


        private void label1_Click(object sender, EventArgs e)
        {

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
        private void set_conn()
        {
            String link = _textBox_linkFileDB.Text;
            String passwd = _textBox_passwdDB.Text;
            try
            {
                // create connection to database
                //v_conn = new System.Data.SQLite.SQLiteConnection("Data Source=" + link.Replace("\\", "\\\\") + ";Version=3;Password=" + passwd + ";");
                v_conn = new System.Data.SQLite.SQLiteConnection("Data Source=" + link.Replace("\\", "\\\\") + ";Version=3;");
                //v_conn.Open();
                MessageBox.Show("Success!", "Database connection", MessageBoxButtons.OK);

            }
            catch (Exception)
            {
                MessageBox.Show("Can't connect to database. Please check config!", "Database connection", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            // set size default of Window Login
            this.Size = new Size(442, 148);
            _textBox_linkFileDB.Text = "D:\\VANDUAN\\Project\\ACS.Advanced IP\\ACS.AdvancedIP.sqlite";
            _textBox_passwdDB.Text = "@eon1t123"; //default passwd for DB
            set_conn();
            
        }
        private bool check_user()
        {
            _textB_passwd.Text = "123123"; // to test
            _textB_username.Text = "duanpv"; // to test
            List<String> data_users = new List<string>();
            v_conn.Open();
            using (SQLiteCommand fmd = v_conn.CreateCommand())
            {
                fmd.CommandText = @"SELECT * FROM users";
                fmd.CommandType = CommandType.Text;
                SQLiteDataReader r = fmd.ExecuteReader();
                while (r.Read())
                {
                    data_users.Add(Convert.ToString(r["username"]) + ":" + Convert.ToString(r["passwd"]));
                }
            }
            // compare user & passwd
            bool isUserExist = false;
            bool isWrongPasswd = true;
            foreach (String data in data_users)
            {
                if (data.Contains(_textB_username.Text))
                {
                    String user = data.Split(':')[0];
                    String passwd = data.Split(':')[1];
                    if (user == _textB_username.Text)
                    {
                        isUserExist = true;
                        //MessageBox.Show(getHashSha256(_textB_passwd.Text).ToLower()+":"+ passwd.ToLower(),"aaaa", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        if (getHashSha256(_textB_passwd.Text).ToLower() == passwd.ToLower())
                        {
                            isWrongPasswd = false;
                            v_conn.Close();
                            return true;
                        }

                    }

                }
            }
            if (!isUserExist)
                MessageBox.Show("User is not exist!", "Login Notification", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else if (isWrongPasswd)
                MessageBox.Show("Wrong password!", "Login Notification", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            v_conn.Close();
            return false;
        }

        private void openMainForm()
        {
            _Form_Main fm = new _Form_Main(v_conn);

            this.Hide();
            fm.ShowDialog();
            this.Close();

        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (check_user())
                openMainForm();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (!v_isClickConfig)
            {
                // show menu config
                this.Size = new Size(442, 290);
                v_isClickConfig = true;
            }
            else
            {
                // hide menu config
                this.Size = new Size(442, 148);
                v_isClickConfig = false;
            }


        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click_2(object sender, EventArgs e)
        {
            // open file database sqlite (version 3)
            //int v_size = -1;
            OpenFileDialog v_openfdl = new OpenFileDialog();
            v_openfdl.Title = "Select database for ACS.Advanced IP";
            //v_openfdl.InitialDirectory = @"C:\";
            v_openfdl.Filter = "All files (*.*)|*.*| Sqlite (*.sqlite)|*.sqlite";
            v_openfdl.FilterIndex = 2;
            v_openfdl.RestoreDirectory = true;
            //v_openfdl.ShowDialog();

            if (v_openfdl.ShowDialog() == DialogResult.OK)
            {
                _textBox_linkFileDB.Text = v_openfdl.FileName;
            }
        }
        private void create_DB()
        {
          
                // To create database
                SQLiteConnection conn = new SQLiteConnection("Data Source=D:\\VANDUAN\\Project\\ACS.Advanced IP\\ACS.AdvancedIP.sqlite;Version=3;");
                conn.SetPassword("@eon1t123");
                conn.Open();

                // create table users
                using (SQLiteCommand fmd = conn.CreateCommand())
                {
                    fmd.CommandText = @"CREATE TABLE IF NOT EXISTS users (username varchar(20), passwd varchar(64))";
                    fmd.CommandType = CommandType.Text;
                    fmd.ExecuteNonQuery();
                    fmd.CommandText = @"INSERT INTO users (username, passwd) VALUES ("+"\"duanpv\","+ "\"96cae35ce8a9b0244178bf28e4966c2ce1b8385723a96a6b838858cdd6ca0a1e\"" + ")";
                    fmd.CommandType = CommandType.Text;
                    fmd.ExecuteNonQuery();
                }
                conn.Close();
        }

        private void _button_testConDB_Click(object sender, EventArgs e)
        {
            //create_DB();
            
            String link = _textBox_linkFileDB.Text;
            String passwd = _textBox_passwdDB.Text;
            try
            {
                // create connection to database
                v_conn = new System.Data.SQLite.SQLiteConnection("Data Source=" + link.Replace("\\", "\\\\") + ";Version=3;Password=" + passwd + ";");
                v_conn.Open();

                // create table users
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
    }
}
