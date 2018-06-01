using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp3
{
    public static class Globals
    {
        static Globals()
        {
            DictionaryPath = "";
        }

        private static string _dictionaryPath;
        public static string DictionaryPath
        {
            get { return _dictionaryPath; }
            set { _dictionaryPath = value; }
        }


    }
}
