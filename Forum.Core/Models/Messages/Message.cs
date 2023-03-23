using Forum.Core.Models.Common;
using Forum.Core.Models.Users;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Forum.Core.Models.Messages
{

    [Table("Message")]
    public partial class Message : MaintainableEntity
    {
        public int ID { get; set; }

        [Required]
        public string Description { get; set; }

        public int ThreadID { get; set; }

        public int? CategoryID { get; set; }

        public int? Stars { get; set; }

        public int MessageTypeID { get; set; }

        public virtual Category Category { get; set; }

        public virtual MessageType MessageType { get; set; }

        public virtual Thread Thread { get; set; }

    }
}
