using Forum.Core.Models.Users;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Forum.Core.Models.System
{

    [Table("SysLoginLog")]
    public partial class SysLoginLog
    {
        public int ID { get; set; }

        public int UserID { get; set; }

        public string UserIP { get; set; }

        public string MachineName { get; set; }

        public DateTime CreationDate { get; set; }

        public virtual User User { get; set; }
    }
}
