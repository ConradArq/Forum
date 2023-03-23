using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Forum.Core.Models.Messages
{

    [Table("Category")]
    public partial class Category
    {
        public Category()
        {
            Message = new HashSet<Message>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }

        [Required]
        [StringLength(250)]
        public string Name { get; set; }

        public string Description { get; set; }

        public virtual ICollection<Message> Message { get; set; }
    }
}
