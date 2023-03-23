using Forum.Core.Models.Common;
using Forum.Core.Models.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Forum.Core.Models.Messages
{

    [Table("Thread")]
    public partial class Thread: MaintainableEntity
    {
        public Thread()
        {
            Message = new HashSet<Message>();
        }

        public int ID { get; set; }

        [Required]
        public string Name { get; set; }

        public int CategoryID { get; set; }

        public int ViewsCount { get; set; }

        public int? Stars { get; set; }

        public virtual ICollection<Message> Message { get; set; }
    }
}
