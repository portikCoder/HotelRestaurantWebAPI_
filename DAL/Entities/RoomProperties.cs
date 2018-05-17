using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class RoomProperties
    {
        [Key]
        public int RoomId { get; set; }
        public int PropertiId { get; set; }
        [ForeignKey("RoomId")]
        public virtual Room Room { get; set; }
        [ForeignKey("PropertiId")]
        public virtual Properties Properties { get; set; }
    }
}
