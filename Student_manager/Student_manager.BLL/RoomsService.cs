using Student_manager.DAL;
using Student_manager.Models;
using System.Collections.Generic;

namespace Student_manager.Services
{
    public class RoomsService
    {
        private readonly RoomsDAO _roomsDAO = new RoomsDAO();

        public List<Room> GetAllRooms()
        {
            return _roomsDAO.GetAllRooms();
        }

        public int AddRoom(Room r)
        {
            if (string.IsNullOrWhiteSpace(r.RoomName) || r.Capacity <= 0)
                return 0; 

            return _roomsDAO.AddRoom(r);
        }

        public bool UpdateRoom(Room r)
        {
            if (r.RoomId <= 0) return false;
            return _roomsDAO.UpdateRoom(r);
        }

        public bool DeleteRoom(int roomId)
        {
            return _roomsDAO.DeleteRoom(roomId);
        }
    }
}

