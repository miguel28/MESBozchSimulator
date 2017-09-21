using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace MES_Bosch_Simulator
{
    public class XMLParser
    {
        public string Code = "";
        public XMLParser()
        {
            Code = "";
        }

        public void Load(string file)
        {
            Code = File.ReadAllText(file);

        }
        
        public void SetAttribute(string attrName, string value)
        {
            Code = Code.Replace("%" + attrName + "%", value);
        }

        public string GetAttribute(string attrName)
        {
            string SearchTerm;
            int Index1;
            int Index2;
            string subString;
            string result;

            SearchTerm = attrName + "=\"";
            Index1 = Code.IndexOf(SearchTerm) + SearchTerm.Length;

            subString = Code.Substring(Index1);
            Index2 = subString.IndexOf("\"");

            result = Code.Substring(Index1, Index2);
            return result;
        }

        public string GetValue(string valName)
        {
            string SearchTerm;
            string SearchTerm2;
            int Index1;
            int Index2;
            string result;

            SearchTerm =  "<" + valName + ">";
            SearchTerm2 =  "</" + valName + ">";
            Index1 = Code.IndexOf(SearchTerm);
            Index2 = Code.IndexOf(SearchTerm2);

            result = Code.Substring(Index1, Index2 - Index1);
            return result;
        }
    }
}
