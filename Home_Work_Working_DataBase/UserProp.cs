using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Home_Work_Working_DataBase
{
    internal class UserProp
    {
        public UserProp(int userId, string username, string password)
        {
            this.userId = userId;
            this.username = username;
            this.password = password;
        }

        public int userId { get; set; }
        public string username { get; set; }
        public string password { get; set; }
    }
}
