using Forum.Core.Enums.Common;
using Forum.Core.Models.Common;
using Forum.Core.Models.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Forum.Core.Models
{
    public class MaintainableEntity : IMaintainableEntity
    {
        public int StatusID { get; set; }

        public DateTime CreationDate { get; set; }

        [ForeignKey("CreationUser")]
        public int CreationUserID { get; set; }

        public DateTime? ModifiedDate { get; set; }

        public int? ModifiedUserID { get; set; }

        public DateTime? DeletedDate { get; set; }

        public int? DeletedUserID { get; set; }

        public void SetCreationData(DateTime date, int userID)
        {
            CreationDate = date;
            CreationUserID = userID;
        }

        public void SetModifiedData(DateTime date, int userID)
        {
            ModifiedDate = date;
            ModifiedUserID = userID;
        }

        public void SetDeletedData(DateTime date, int userID)
        {
            DeletedDate = date;
            DeletedUserID = userID;
        }

        public void SetStatus(States states)
        {
            StatusID = (int)states;
        }

        public virtual Status Status { get; set; }
        public virtual User CreationUser { get; set; }
    }
}
