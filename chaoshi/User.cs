using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace chaoshi
{
   public class User
    {
        private int userID;


        private string userName;

        private string password;

        public int UserID { get => userID; set => userID = value; }
        public string UserName { get => userName; set => userName = value; }
        public string Password { get => password; set => password = value; }
    }
}
