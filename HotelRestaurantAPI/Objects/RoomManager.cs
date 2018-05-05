using DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HotelRestaurantAPI.Objects
{
    public static class RoomManager
    {
        //private Room room; // nem kell, kint lesz letrehozva a Room ektum, s azt atadva itt konfigolom, managelem

        private static List<List<Room>> initializeRoomsVector()
        {
            List<List<Room>> rooms = new List<List<Room>>();

            return rooms;
        }

        /*
         * 
         * Sides of the rooms(outer): 1.- R(x,y+25) ;2.R(x+25,y); 3.R(x,y-25); 4.R(x-25,y);
         * 
          */

        public static Room FirstConfigureRoom()
        {
            Room room;
            Tuple<int, int> position = null;

            List<List<Room>> rooms = initializeRoomsVector();

            if (rooms.Count == 0)
            {
                // set the room to the Origo(0,0)
                position = new Tuple<int, int>(0, 0);
            }
            else
            {
                //random nmb
                bool freeRoomFound = true;
                while (!freeRoomFound)
                {
                    // until we find a rooom with at least one free side
                    freeRoomFound = false;
                }
            }

            room = new Room(position);
            randomizeTerrainTypes(room);

            return room;
        }

        private static void randomizeTerrainTypes(Room room)
        {
            //
            int[] x = new int[10], y = new int[10];
            for (int i = 0; i < 9; ++i)
            {
                if ((i > 4) || ((new Random()).Next(0, 2) == 0))
                {
                    x[i] = new Random().Next(0, 25);
                    y[i] = new Random().Next(0, 25);
                }
            }
        }
    }
}