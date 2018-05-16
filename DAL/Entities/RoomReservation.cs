using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entities
{
    public class RoomReservation
    {
        [Key]
        public int RoomId;
        public int ReservationId;
        [ForeignKey("RoomId")]
        public virtual Room Room { get; set; }
        [ForeignKey("EquipmentId")]
        public virtual Reservation Reservation { get; set; }
    }
}
