using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.IO;
using System.Text.RegularExpressions;

namespace LibEsi
{
    public class Market
    {
        /// <summary>
        /// returns all market data for item in region 
        /// </summary>
        /// <param name="regid">region ID</param>
        /// <param name="iteid">Item id</param>
        /// <returns>IN the return string each record is separateed by ";" each item be ","</returns>
        public string getall(string regid, string iteid)
        {
            WebClient wc = new WebClient();
            MemoryStream stream = new MemoryStream(wc.DownloadData("https://esi.tech.ccp.is/dev/markets/" + regid.ToString() + "/orders/?type_id=" + iteid.ToString() + "&order_type=all&page=1&datasource=tranquility"));
            var reader = new StreamReader(stream);
            string input = reader.ReadToEnd();
            string replacedString1 = Regex.Replace(input, "\"", "");
            string replacedString2 = Regex.Replace(replacedString1, "order_id:", "");
            string replacedString3 = Regex.Replace(replacedString2, "type_id:", "");
            string replacedString4 = Regex.Replace(replacedString3, "location_id:", "");
            string replacedString5 = Regex.Replace(replacedString4, "volume_remain:", "");
            string replacedString6 = Regex.Replace(replacedString5, "min_volume:", "");
            string replacedString7 = Regex.Replace(replacedString6, "price:", "");
            string replacedString8 = Regex.Replace(replacedString7, "is_buy_order:", "");
            string replacedString9 = Regex.Replace(replacedString8, "issued:", "");
            string replacedString10 = Regex.Replace(replacedString9, "range:", "");
            string replacedString11 = Regex.Replace(replacedString10, @"\[", "");
            string replacedString12 = Regex.Replace(replacedString11, @"\]", "");
            string replacedString13 = Regex.Replace(replacedString12, "duration:", "");
            string replacedString14 = Regex.Replace(replacedString13, "volume_total:", "");
            string replacedString15 = Regex.Replace(replacedString14, " ", "");
            replacedString15 = replacedString15.Replace(System.Environment.NewLine, "");
            string replacedString16 = Regex.Replace(replacedString15, @"},{", ";");
            string replacedString17 = Regex.Replace(replacedString16, "{", "");
            string replacedString18 = Regex.Replace(replacedString17, "}", "");
            string output = replacedString18;
            return output;


            }

    }


    public class Market1
    {
    }

    public class Market2
    {
    }

    public class Market3
    {
    }

    public class Market4
    {
    }

    public class Market5
    {
    }
}
