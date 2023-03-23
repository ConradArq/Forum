using Forum.Core.Models.Common;
using Forum.Core.Models.Messages;
using Forum.Core.Models.System;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Forum.Core.Models.Users
{

    public partial class User : IdentityUser<int, ApplicationUserLogin, ApplicationUserRole, ApplicationUserClaim>
    {

        public User()
        {
            SysAppEvent = new HashSet<SysAppEvent>();
            UserProfile = new HashSet<UserProfile>();
        }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User,int> manager)  
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }

        [StringLength(250)]
        public string ImageUrl { get; set; }

        public int StatusID { get; set; }

        public DateTime RegistrationDate { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public int? Reputation { get; set; }

        public virtual ICollection<SysAppEvent> SysAppEvent { get; set; }

        public virtual ICollection<SysLoginLog> SysLoginLog { get; set; }

        public virtual Status Status { get; set; }

        public virtual ICollection<UserProfile> UserProfile { get; set; }
    }

}
