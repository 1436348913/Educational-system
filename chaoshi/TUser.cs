using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chaoshi
{
    public class TUser
    {
        private int tuserID;


        private string tuserName;

        private string tpassword;

        public int TuserID { get => tuserID; set => tuserID = value; }
        public string Tpassword { get => tpassword; set => tpassword = value; }
        public string TuserName { get => tuserName; set => tuserName = value; }
    }
}
