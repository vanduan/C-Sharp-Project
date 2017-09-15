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
                    datas.Add(Convert.ToString(r["name"]) + ":        " + Convert.ToString(r["ipaddress"]) + ":       " + Convert.ToString(r["detail"]));
                }

            }
            conn.Close();
            return datas;
        }

        internal List<string> _get_listip_ipvlan(string v_ipaddress)
        {
            v_ipaddress = v_ipaddress.Replace(" ", "");
            // return list all ip to scan
            List<String> v_list_ip = new List<string>();
            if (!v_ipaddress.Contains("-"))
                // just one ip address
                v_list_ip.Add(v_ipaddress);
            else
            {
                // and many ip address
                String ip_one = v_ipaddress.Split('-')[0];
                String ip_two = v_ipaddress.Split('-')[1];
                if (ip_two.Length <= 3) // same ip network
                    ip_two = ip_one.Split('.')[0] + "." + ip_one.Split('.')[1] + "." + ip_one.Split('.')[2] + "." + ip_two;

                String[] ip_ones = ip_one.Split('.');
                String[] ip_twos = ip_two.Split('.');
                //System.Windows.Forms.MessageBox.Show(ip_ones[0]+ ip_ones[1] + ip_ones[2] + ip_ones[3]);
                //System.Windows.Forms.MessageBox.Show(ip_twos[0]+ ip_twos[1]+ ip_twos[2]+ ip_twos[3]);

                int flagIpBegin = 0;
                /*
                 * 0:  equal
                 * 1:  ip_one is begin
                 * -1: else
                */
                for (int i = 0; i < 4; i++)
                {
                    if (Convert.ToInt16(ip_ones[i]) < Convert.ToInt16(ip_twos[i]))
                    {
                        flagIpBegin = 1;
                        break;
                    }
                    else if (Convert.ToInt16(ip_ones[i]) > Convert.ToInt16(ip_twos[i]))
                    {
                        flagIpBegin = -1;
                        break;
                    }
                }
                String[] ip_begin = null;
                String[] ip_end =null;
                if (flagIpBegin == 0)
                {
                    v_list_ip.Add(ip_one);
                }
                else
                {
                    if (flagIpBegin == 1)
                    {
                        ip_begin = ip_ones;
                        ip_end = ip_twos;
                    }


                    else if (flagIpBegin == -1)
                    {
                        ip_begin = ip_twos;
                        ip_end = ip_ones;
                    }
                    for (int oct1 = Convert.ToInt16(ip_begin[0]); oct1 <= Convert.ToInt16(ip_end[0]); oct1++)
                        for (int oct2 = Convert.ToInt16(ip_begin[1]); oct2 <= Convert.ToInt16(ip_end[1]); oct2++)
                            for (int oct3 = Convert.ToInt16(ip_begin[2]); oct3 <= Convert.ToInt16(ip_end[2]); oct3++)
                                for (int oct4 = Convert.ToInt16(ip_begin[3]); oct4 <= Convert.ToInt16(ip_end[3]); oct4++)
                                {
                                    if (oct4 == 255 || oct4 == 255) continue;
                                    v_list_ip.Add(oct1 + "." + oct2 + "." + oct3 + "." + oct4);
                                }
                                    
                }
            }

            return v_list_ip;
        }



        internal bool _checkIP(String v_ipvlan)
        {
            // check ip input from comboBox
            try
            {
                // get ip from template
                v_ipvlan = v_ipvlan.Split(':')[1].Replace(" ", "");
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
                        if (ip_two.Length <= 3)
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
