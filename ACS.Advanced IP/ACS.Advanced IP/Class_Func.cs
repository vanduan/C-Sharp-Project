using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Data;

namespace ACS.Advanced_IP
{
    class Class_Func
    {
        internal List<String> _query_data_ipvlan(SQLiteConnection conn)
        {
            // query info vlan and ip address from database
            List<String> datas = new List<string>();
            conn.Open();
            using (SQLiteCommand fmd = conn.CreateCommand())
            {
                fmd.CommandText = @"SELECT * FROM ipvlan";
                fmd.CommandType = CommandType.Text;
                SQLiteDataReader r = fmd.ExecuteReader();
                while (r.Read())
                {
                    datas.Add(Convert.ToString(r["name"]) + ":        " + Convert.ToString(r["ipaddress"])+":       " + Convert.ToString(r["detail"]));
                }

            }
            conn.Close();
            return datas;
        }

        internal List<string> _get_listip_ipvlan(string v_ipaddress)
        {
            // return list all ip to scan
            List<String> v_list_ip = new List<string>();


            return null; // *********************note
        }

        

        internal bool _checkIP(String v_ipvlan)
        {
            // check ip input from comboBox
            try
            {
                // get ip from template
                v_ipvlan = v_ipvlan.Split(':')[1].Replace(" ","");
            }
            catch (Exception) { };

            if (v_ipvlan.Contains("-"))
            {
                // many ip address
                String ip_one = v_ipvlan.Split('-')[0];
                String ip_two = v_ipvlan.Split('-')[1];
                if (_checkIP_one(ip_one))
                {
                    if (_checkIP_one(ip_two))
                        return true;
                    else
                    {
                        if(ip_two.Length <= 3)
                        {
                            Int16 temp = Convert.ToInt16(ip_two);
                            if (temp <= 255 && temp >= 0)
                                return true;
                        }
                    }
                }
            }
            else
            {
                // just one
                if (_checkIP_one(v_ipvlan))
                    return true;
            }
            return false; // note
        }

        private bool _checkIP_one(string v_ipvlan)
        {
            string[] ip = v_ipvlan.Split('.');
            if (ip.Length != 4)
                return false;
            int temp;
            foreach (string num in ip)
            {
                if (num.Length > 3) return false;
                temp = Convert.ToInt16(num);
                if (temp > 255 || temp < 0)
                    return false;
            }
            return true;
        }
    }
}
