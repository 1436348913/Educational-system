using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chaoshi
{
    public class SUser
    {

        private int suserID;


        private string suserName;

        private string spassword;

        public int SuserID { get => suserID; set => suserID = value; }
        public string SuserName { get => suserName; set => suserName = value; }
        public string Spassword { get => spassword; set => spassword = value; }
    }
}
