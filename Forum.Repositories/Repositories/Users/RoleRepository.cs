using Forum.Core.Enums.Users;
using Forum.Core.Models.Users;
using Forum.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Repositories.Repositories.Users
{
    public class RoleRepository : GenericRepository<Role>, IRoleRepository
    {
        public static ApplicationRoles GetUserRoleByUserID(int userID)
        {
            ApplicationRoles role = default(ApplicationRoles);

            using (FContext context = new FContext())
            {
                User user;
                user = (from u in context.Users
                        where u.Id == userID
                        select u).FirstOrDefault();

                if (user != null)
                    role = (ApplicationRoles)user.Roles.FirstOrDefault().RoleId;

            }

            return role;
        }
    }
}
