using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class RoomEquipment
    {
        [Key]
        public int RoomId { get; set; }
        public int EquipmentId { get; set; }

        public virtual Room Room { get; set; }
        public virtual  Equipment Equipment { get; set; }
    }
}
