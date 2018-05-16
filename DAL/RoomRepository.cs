using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class RoomRepository
    {
        private HotelRestaurantDBContext DbContext = new HotelRestaurantDBContext();
        
        public List<Room> GetRoom()
        {
            return DbContext.Rooms.ToList();
        }
        public List<Equipment> GetRoomEquipment(int id)

        {
            var eqpId = DbContext.RoomEquipment.Where(x => x.RoomId == id).ToList();
            List<Equipment> equipmentList = new List<Equipment>();
            foreach(var c in eqpId)
            {
                
               equipmentList.Add(GetEquipment(c.EquipmentId));
            }

            return equipmentList;
        }
        public Equipment GetEquipment(int id)
        {
            return  DbContext.Equipment.FirstOrDefault(x=> x.Id==id);
        }
        public Equipment GetEquipment(string name)
        {
            return DbContext.Equipment.FirstOrDefault(x => x.name == name);
        }
        public Room GetRoom(int id)
        {
            var S= DbContext.Rooms.FirstOrDefault(x => x.Id == id);
            return S;
        }
        public void insertRoom(Room room)
        {
            
            DbContext.Rooms.Add(room);
            DbContext.SaveChanges();
        }
        public void AddRoomEquipment(int id, string name)
        {
            RoomEquipment roomEquipment = new RoomEquipment();
            Room room = GetRoom(id);
            Equipment equipment = GetEquipment(name);
            roomEquipment.Equipment = equipment;
            roomEquipment.Room = room;
            DbContext.RoomEquipment.Add(roomEquipment);
            DbContext.SaveChanges();



        }
        public void AddEquipment(string name)
        {
            Equipment equipment = new Equipment(name);
            
            DbContext.Equipment.Add(equipment);
            DbContext.SaveChanges();
        }
    }
}
