using Forum.Core.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Repositories.Managers
{
    public class IdentityManager
    {
        public static User GetUserByUserName(UserManager userManager, string userName)
        {
            return userManager.Users.Where(u => u.UserName == userName).FirstOrDefault();
        }
    }
}
