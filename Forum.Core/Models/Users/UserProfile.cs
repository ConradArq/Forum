using System.ComponentModel.DataAnnotations.Schema;

namespace Forum.Core.Models.Users
{

    [Table("UserProfile")]
    public partial class UserProfile
    {
        public int ID { get; set; }

        public string Signature { get; set; }

        public int UserID { get; set; }

        public int UserReputationID { get; set; }

        public virtual Seniority Seniority { get; set; }

        public virtual User User { get; set; }
    }
}
