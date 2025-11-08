using Student_manager.DAL;
using Student_manager.Models;
using System;
using System.Collections.Generic;

namespace Student_manager.BLL
{
    public class ScoreTypeService
    {
        private readonly ScoreTypeDAO _dao = new ScoreTypeDAO();

        // 🔹 Lấy tất cả loại điểm
        public IEnumerable<ScoreType> GetAllScoreTypes()
        {
            return _dao.GetAll();
        }

        // 🔹 Lấy loại điểm theo ID
        public ScoreType GetScoreType(int id)
        {
            if (id <= 0) return null;
            return _dao.GetById(id);
        }

        // 🔹 Thêm loại điểm mới
        public int CreateScoreType(ScoreType s)
        {
            if (s == null) throw new ArgumentNullException(nameof(s));
            if (string.IsNullOrWhiteSpace(s.ScoreTypeName))
                throw new ArgumentException("Tên loại điểm không được để trống.");

            // kiểm tra trùng tên loại điểm
            if (_dao.ExistsScoreTypeName(s.ScoreTypeName))
                throw new ArgumentException("Tên loại điểm đã tồn tại.");

            // nếu không nhập trọng số, mặc định là 1
            if (s.Weight == null || s.Weight <= 0)
                s.Weight = 1;

            var newId = _dao.Insert(s);
            return newId;
        }

        // 🔹 Cập nhật loại điểm
        public bool UpdateScoreType(ScoreType s)
        {
            if (s == null) throw new ArgumentNullException(nameof(s));
            if (s.ScoreTypeId <= 0) throw new ArgumentException("ScoreTypeId không hợp lệ.");

            // kiểm tra trùng tên loại điểm, ngoại trừ chính nó
            if (_dao.ExistsScoreTypeName(s.ScoreTypeName, s.ScoreTypeId))
                throw new ArgumentException("Tên loại điểm đã tồn tại.");

            if (s.Weight == null || s.Weight <= 0)
                s.Weight = 1;

            return _dao.Update(s);
        }

        // 🔹 Xóa loại điểm
        public bool DeleteScoreType(int id)
        {
            if (id <= 0) return false;
            return _dao.Delete(id);
        }
    }
}
