using Student_manager.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Student_manager.DAL
{
    public class RoomsDAO
    {
        private readonly DataProcesser _dataProcessor = new DataProcesser();

        public List<Room> GetAllRooms()
        {
            var list = new List<Room>();
            string query = "SELECT * FROM Rooms";
            DataTable dt = _dataProcessor.DocBang(query);

            foreach (DataRow row in dt.Rows)
            {
                list.Add(MapDataRowToRoom(row));
            }
            return list;
        }

        public int AddRoom(Room r)
        {
            // Dùng SCOPE_IDENTITY() để lấy ID vừa được chèn thành công
            string query = @"INSERT INTO Rooms (RoomName, Capacity)
                             VALUES (@RoomName, @Capacity);
                             SELECT SCOPE_IDENTITY();";

            using (var conn = SqlHelper.GetConnection())
            using (var cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@RoomName", r.RoomName);
                cmd.Parameters.AddWithValue("@Capacity", r.Capacity);

                conn.Open();

                // Dùng ExecuteScalar để lấy giá trị ID vừa chèn
                object result = cmd.ExecuteScalar();

                if (result != null && result != DBNull.Value)
                {
                    // Ép kiểu sang int và trả về ID
                    return Convert.ToInt32(result);
                }
                return 0; // Trả về 0 nếu thêm thất bại hoặc không lấy được ID
            }
        }

        public bool UpdateRoom(Room r)
        {
            string query = @"UPDATE Rooms SET RoomName=@RoomName, Capacity=@Capacity WHERE RoomId=@RoomId";
            using (var conn = SqlHelper.GetConnection())
            using (var cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@RoomName", r.RoomName);
                cmd.Parameters.AddWithValue("@Capacity", r.Capacity);
                cmd.Parameters.AddWithValue("@RoomId", r.RoomId);
                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool DeleteRoom(int roomId)
        {
            string query = "DELETE FROM Rooms WHERE RoomId=@RoomId";
            using (var conn = SqlHelper.GetConnection())
            using (var cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@RoomId", roomId);
                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        private Room MapDataRowToRoom(DataRow row)
        {
            return new Room
            {
                RoomId = (int)row["RoomId"],
                RoomName = row["RoomName"].ToString(),
                Capacity = (int)row["Capacity"]
            };
        }
    }
}

