using DAL;
using DAL.Entities;
using HotelRestaurantAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotelRestaurantAPI.BL
{
    public static class UsersManager
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
                model.Reservation = c;
                list.Add(model);
            }
            foreach (var c in list)
            {
                c.Reservation.price = 0;
                c.Reservation.status = 0;
                c.Reservation.createReservation = DateTime.MaxValue;
                c.Reservation.RoomReservations = null;
            }

            return list;
        }
        public static List<ReservationModel> GetReservationToDate(DateTime StartTime, DateTime FinishTime)
        {
            var reservationsList = DbContext.Reservations.Where(x => x.startDate >= StartTime && x.finishDate >= FinishTime);
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
                model.Reservation = c;
                list.Add(model);
            }
            foreach (var c in list)
            {
                c.Reservation.price = 0;
                c.Reservation.status = 0;
                c.Reservation.createReservation = DateTime.MaxValue;
                c.Reservation.RoomReservations = null;
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
            foreach (var c in ListReserVation)
            {
                c.price = 0;
                c.status = 0;
                c.createReservation = DateTime.MaxValue;
                c.RoomReservations = null;
            }
            return ListReserVation;
        }
    }
}