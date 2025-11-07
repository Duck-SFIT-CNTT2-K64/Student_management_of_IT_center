using Student_manager.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Student_manager.DAL
{
    public class ClassSchedulesDAO
    {
        private readonly DataProcesser _dataProcessor = new DataProcesser();

        public List<ClassSchedule> GetSchedulesByClassId(int? classId = null)
        {
            var result = new List<ClassSchedule>();
            string query = "SELECT * FROM ClassSchedules";
            if (classId.HasValue)
            {
                query += " WHERE ClassId = @ClassId";
            }

            using (var conn = SqlHelper.GetConnection())
            using (var cmd = new SqlCommand(query, conn))
            {
                if (classId.HasValue)
                    cmd.Parameters.AddWithValue("@ClassId", classId.Value);

                conn.Open();
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        result.Add(MapReaderToSchedule(reader));
                    }
                }
            }
            return result;
        }

        public bool AddSchedule(ClassSchedule s)
        {
            string query = @"INSERT INTO ClassSchedules (ClassId, RoomId, Weekday, StartTime, EndTime)
                             VALUES (@ClassId, @RoomId, @Weekday, @StartTime, @EndTime)";
            using (var conn = SqlHelper.GetConnection())
            using (var cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@ClassId", s.ClassId);
                cmd.Parameters.AddWithValue("@RoomId", (object)s.RoomId ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Weekday", s.Weekday);
                cmd.Parameters.AddWithValue("@StartTime", s.StartTime);
                cmd.Parameters.AddWithValue("@EndTime", s.EndTime);
                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool UpdateSchedule(ClassSchedule s)
        {
            string query = @"UPDATE ClassSchedules 
                             SET RoomId=@RoomId, Weekday=@Weekday, StartTime=@StartTime, EndTime=@EndTime
                             WHERE ScheduleId=@ScheduleId";
            using (var conn = SqlHelper.GetConnection())
            using (var cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@RoomId", (object)s.RoomId ?? DBNull.Value);
                cmd.Parameters.AddWithValue("@Weekday", s.Weekday);
                cmd.Parameters.AddWithValue("@StartTime", s.StartTime);
                cmd.Parameters.AddWithValue("@EndTime", s.EndTime);
                cmd.Parameters.AddWithValue("@ScheduleId", s.ScheduleId);
                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool DeleteSchedule(int scheduleId)
        {
            string query = "DELETE FROM ClassSchedules WHERE ScheduleId=@ScheduleId";
            using (var conn = SqlHelper.GetConnection())
            using (var cmd = new SqlCommand(query, conn))
            {
                cmd.Parameters.AddWithValue("@ScheduleId", scheduleId);
                conn.Open();
                return cmd.ExecuteNonQuery() > 0;
            }
        }

        private ClassSchedule MapReaderToSchedule(SqlDataReader reader)
        {
            return new ClassSchedule
            {
                ScheduleId = (int)reader["ScheduleId"],
                ClassId = (int)reader["ClassId"],
                RoomId = reader["RoomId"] == DBNull.Value ? null : (int?)reader["RoomId"],
                Weekday = reader["Weekday"].ToString(),
                StartTime = (TimeSpan)reader["StartTime"],
                EndTime = (TimeSpan)reader["EndTime"]
            };
        }
    }
}

