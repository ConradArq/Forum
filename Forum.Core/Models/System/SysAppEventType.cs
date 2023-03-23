using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Forum.Core.Models.System
{

    [Table("SysAppEventType")]
    public partial class SysAppEventType
    {
        public SysAppEventType()
        {
            SysAppEvent = new HashSet<SysAppEvent>();
        }

        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }

        [Required]
        [StringLength(250)]
        public string Name { get; set; }

        public virtual ICollection<SysAppEvent> SysAppEvent { get; set; }
    }
}
