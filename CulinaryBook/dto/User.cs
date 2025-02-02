using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CulinaryBook.dto
{
    public class User
    {
 
        public User(int userId)
        {
            UserId = userId;
        }

        public User(int userId, string userName)
        {
            UserId = userId;
            UserName = userName;
        }

        public int UserId
        {
            get; set;
        }

        public string UserName { get; set; }
    }
}
