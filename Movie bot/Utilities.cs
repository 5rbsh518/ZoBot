using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;// our tool
using System.IO;//System input and output

namespace ConsoleApp3
{
    class Utilities
    {
        private static Dictionary<string, string> alreats;
        static Utilities()  //ثابت 
        {
            string json = File.ReadAllText("systemlang/alerts.json");
            var data = JsonConvert.DeserializeObject<dynamic>(json);
            alreats = data.ToObject<Dictionary<string, string>>();
        }

        public static string GetAlert(string key)
        {
            if (alreats.ContainsKey(key)) return alreats[key];
            return "";
        }
        public static string GetFormattedAlert(string key, params object[] prarameter)
        {
            if (alreats.ContainsKey(key))
            {
                return string.Format(alreats[key], prarameter);
            }
            return "";
        }
        public static string GetFormattedAlert(string key, object prarameter)
        {
            return GetFormattedAlert(key, new object[] { prarameter });
        }
    }
}
