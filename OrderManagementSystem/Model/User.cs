using OrderManagementSystem.Constants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderManagementSystem.Model
{
    internal class User
    {
        static int userId=20;
        string username;
        string password;
        RoleType roleType;

        public int UserId
        {
            get { return userId; }
            set { userId = value; }
        }
        public string UserName
        {
            get { return username; }
            set { username = value; }
        }
        public string Password
        {
            get { return password; }
            set { password = value; }
        }
        public RoleType RoleType
        {
            get { return RoleType; }
            set { RoleType = value; }
        }
        public User()
        { 
        }
        public User(int userId,string username, string password,RoleType roletype)
        {
            userId++;
            UserId=userId;
            UserName= username;
            Password= password;
            RoleType = roletype;
        }
    }
}
