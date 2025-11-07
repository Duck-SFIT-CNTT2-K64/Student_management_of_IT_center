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
            // 1. Kiểm tra Business Logic
            if (string.IsNullOrWhiteSpace(r.RoomName) || r.Capacity <= 0)
                return 0; // Trả về 0 nếu validation thất bại

            // 2. Gọi DAO và trả về RoomId mới
            // Giả định _roomsDAO.AddRoom() đã được sửa để trả về int ID
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

