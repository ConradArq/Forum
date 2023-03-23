using Forum.Core.Models.Messages;
using Forum.Core.Models.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Core.Models.Common
{
    public partial class Status
    {
        public Status()
        {
            User = new HashSet<User>();
        }

        public int ID { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        public virtual ICollection<User> User { get; set; }
    }
}
