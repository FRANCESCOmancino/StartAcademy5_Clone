using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryFile
{
    public static class UtilityLibrary
    {
        public static List<string> creaListString(string path)
        {
            List<string> listOfString = File.ReadAllLines(path).ToList();
            return listOfString;
        }
    }
}
