using DAL;
using DAL.Entities;
using HotelRestaurantAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotelRestaurantAPI.BL
{
    public static class AdminManager
    {
        private static HotelRestaurantDBContext DbContext = new HotelRestaurantDBContext();

        public static List<Room> GetRoom()
        {
            return DbContext.Rooms.ToList();
        }
        public static List<Equipment> GetRoomEquipment(int id)

        {
            var eqpId = DbContext.RoomEquipment.Where(x => x.RoomId == id).ToList();
            List<Equipment> equipmentList = new List<Equipment>();
            foreach (var c in eqpId)
            {

                equipmentList.Add(GetEquipment(c.EquipmentId));
            }

            return equipmentList;
        }
        public static Equipment GetEquipment(int id)
        {
            return DbContext.Equipment.FirstOrDefault(x => x.Id == id);
        }
        public static Equipment GetEquipment(string name)
        {
            return DbContext.Equipment.FirstOrDefault(x => x.name == name);
        }
        public static Room GetRoom(int id)
        {
            var S = DbContext.Rooms.FirstOrDefault(x => x.Id == id);
            return S;
        }
        public static void insertRoom(Room room)
        {

            DbContext.Rooms.Add(room);
            DbContext.SaveChanges();
        }
        public static void AddRoomEquipment(int id, string name)
        {
            RoomEquipment roomEquipment = new RoomEquipment();
            Room room = GetRoom(id);
            Equipment equipment = GetEquipment(name);
            roomEquipment.Equipment = equipment;
            roomEquipment.Room = room;
            DbContext.RoomEquipment.Add(roomEquipment);
            DbContext.SaveChanges();



        }
        public static void AddEquipment(string name)
        {
            Equipment equipment = new Equipment(name);

            DbContext.Equipment.Add(equipment);
            DbContext.SaveChanges();
        }
        public static void addType(string name)
        {
            DbContext.Types.Add(new DAL.Entities.Type(name));
            DbContext.SaveChanges();

        }
        public static void addRoomType(string typeName, int roomId)
        {
            DAL.Entities.Type type = DbContext.Types.FirstOrDefault(x => x.Name == typeName);
            DbContext.Rooms.FirstOrDefault(x => x.Id == roomId).Type = type;
            DbContext.SaveChanges();
        }
        public static void addSubType(string name)
        {
            DbContext.Subtypes.Add(new Subtype(name));
            DbContext.SaveChanges();

        }
        public static void addRoomSubType(string subTypeName, int roomId)
        {
            Subtype subType = DbContext.Subtypes.FirstOrDefault(x => x.name == subTypeName);
            DbContext.Rooms.FirstOrDefault(x => x.Id == roomId).Subtype = subType;
            DbContext.SaveChanges();
        }


        public static void AddReservation(List<int> roomId,Reservation reservation)
        {
            DbContext.Reservations.Add(reservation);
            RoomReservation roomReservation = new RoomReservation();
            roomReservation.Reservation = reservation;
            foreach (int c in roomId)
            {
                Room room = GetRoom(c);
                roomReservation.Room = room;
                DbContext.RoomReservations.Add(roomReservation);
            }

            DbContext.SaveChanges();


        }
        public static List<ReservationModel> GetAllReservation()
        {
            List<Reservation> reservationsList = DbContext.Reservations.ToList();
            List<ReservationModel> list = new List<ReservationModel>();
            ReservationModel model = new ReservationModel();
            foreach (var c in reservationsList)
            {
                var roomList = DbContext.RoomReservations.Where(x => x.ReservationId == c.Id).ToList();
                foreach (var t in roomList)
                {
                    model.RoomId.Add(t.RoomId);
                }
                model.reservation = c;
                list.Add(model);
            }

            return list;
        }
        public static List<ReservationModel> GetReservationToDate(DateTime StartTime , DateTime FinishTime)
        {
            var reservationsList = DbContext.Reservations.Where(x=>x.startDate>=StartTime && x.finishDate>=FinishTime);
            List<ReservationModel> list = new List<ReservationModel>();
            ReservationModel model = new ReservationModel();
            List<Reservation> ListAllReservation = new List<Reservation>();
            foreach (var c in reservationsList)
            {
                var roomList = DbContext.RoomReservations.Where(x => x.ReservationId == c.Id).ToList();
                foreach (var t in roomList)
                {
                    model.RoomId.Add(t.RoomId);
                }
                model.reservation = c;
                list.Add(model);
            }
            return list;
        }
        public static List<Reservation> GetRoomReservation(int id)
        {
            var listRoomReservation = DbContext.RoomReservations.Where(x => x.RoomId == id).ToList();
            List<Reservation> ListReserVation = new List<Reservation>();
            foreach (var res in listRoomReservation)
            {
                ListReserVation.Add(DbContext.Reservations.FirstOrDefault(x => x.Id == res.ReservationId));
            }
            return ListReserVation;
        }
        public static void AddProperties(string name)
        {
            Properties properties = new Properties();
            properties.name = name;

            DbContext.Properties.Add(properties);
            DbContext.SaveChanges();
        }
        public static Properties GetProperti(string name)
        {
            return DbContext.Properties.FirstOrDefault(x => x.name == name);
        }
        public static List<Properties> GetAllProperti(string name)
        {
            return DbContext.Properties.ToList();
        }
        public static List<Properties> GetRoomProperti(int roomId)
        {
            var listRoomProperty = DbContext.RoomProperties.Where(x => x.RoomId == roomId).ToList();
            List<Properties> listProperty = new List<Properties>();
            foreach (var res in listRoomProperty)
            {
                listProperty.Add(DbContext.Properties.FirstOrDefault(x => x.Id == res.PropertiId));
            }
            return listProperty;
        }
        public static void AddRoomProperties(int roomId, string name)
        {
            RoomProperties  roomProperties= new RoomProperties();
            Room room = GetRoom(roomId);
            Properties properties = GetProperti(name);
            roomProperties.Properties = properties;
            roomProperties.Room = room;
            DbContext.RoomProperties.Add(roomProperties);
            DbContext.SaveChanges();



        }
        public static List<RoomModel> GetAllRoom()
        {
            List<Room> RoomList = GetRoom();
            List<RoomModel> listRoomModel = new List<RoomModel>();
            RoomModel roomModel = new RoomModel();
            foreach(Room room in RoomList)
            {
                roomModel.PropertisList = GetRoomProperti(room.Id);
                roomModel.EquipmentList = GetRoomEquipment(room.Id);
                roomModel.room = room;
                listRoomModel.Add(roomModel);
            }
            return listRoomModel;
        }






    }
}