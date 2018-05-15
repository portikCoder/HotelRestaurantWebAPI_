using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class Equipment
    {
        [Key]
        public int Id { get; set; }
        public String name { get; set; }

        public virtual ICollection<RoomEquipment> RoomEquipment { get; set; }
    }
}
