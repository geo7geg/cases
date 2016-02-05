using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;
using System.Text;

namespace WebApplication1
{
    public class Class1
    {
        public static string sqlstringtext()
        {
            string appPath = HttpRuntime.AppDomainAppPath + @"\sql.txt";
            //string appPath = @"c:\Users\" + Environment.UserName + @"\Desktop\sql.txt";
            List<string> lines = new List<string>();

            using (StreamReader r = new StreamReader(appPath, Encoding.Default))
            {
                string line;
                while ((line = r.ReadLine()) != null)
                {
                    lines.Add(line);
                }
            }
            string sqltext = "";
            foreach (string s in lines)
            {
                //string[] words = s;

                sqltext = s.Trim();

                //words[0] = "";
                //words[1] = "";
            }

            return sqltext;
        }

        public static string sqlstring = sqlstringtext();
    }
}