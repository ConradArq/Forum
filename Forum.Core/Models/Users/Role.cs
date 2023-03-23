using Microsoft.AspNet.Identity.EntityFramework;
using System.ComponentModel.DataAnnotations;

namespace Forum.Core.Models.Users
{

    public partial class Role : IdentityRole<int, ApplicationUserRole>
    {
        [StringLength(100)]
        public string Description { get; set; }
    }
}
