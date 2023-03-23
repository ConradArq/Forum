using Forum.Core.Models.Users;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Forum.Core.Models.System
{

    [Table("SysAppEvent")]
    public partial class SysAppEvent
    {
        public int ID { get; set; }

        public int SysAppEventTypeID { get; set; }

        public int? UserID { get; set; }

        public string UserIP { get; set; }

        public string Description { get; set; }

        public string Trace { get; set; }

        public DateTime CreationDate { get; set; }

        public virtual SysAppEventType SysAppEventType { get; set; }

        public virtual User User { get; set; }
    }
}
