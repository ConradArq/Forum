using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Forum.Core.Models.Users
{

    [Table("Seniority")]
    public partial class Seniority
    {
        public Seniority()
        {
            UserProfile = new HashSet<UserProfile>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }

        [Required]
        [StringLength(50)]
        public string Name { get; set; }

        public string Description { get; set; }

        public virtual ICollection<UserProfile> UserProfile { get; set; }
    }
}
