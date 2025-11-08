using Student_manager.DAL;
using Student_manager.Models;
using System;
using System.Collections.Generic;

namespace Student_manager.BLL
{
    public class ScoreService
    {
        private readonly ScoreDAO _dao = new ScoreDAO();

        public IEnumerable<Score> GetAllScores()
        {
            return _dao.GetAll();
        }

        public IEnumerable<Score> GetScoresByEnrollment(int enrollmentId)
        {
            if (enrollmentId <= 0) return new List<Score>();
            return _dao.GetByEnrollmentId(enrollmentId);
        }

        public Score GetScore(int id)
        {
            if (id <= 0) return null;
            return _dao.GetById(id);
        }

        public int CreateScore(Score s)
        {
            if (s == null) throw new ArgumentNullException(nameof(s));
            if (s.EnrollmentId <= 0) throw new ArgumentException("EnrollmentId không hợp lệ.");
            if (s.ScoreTypeId <= 0) throw new ArgumentException("ScoreTypeId không hợp lệ.");

            if (_dao.ExistsScoreTypeForEnrollment(s.EnrollmentId, s.ScoreTypeId))
                throw new ArgumentException("Loại điểm này đã tồn tại cho học viên trong lớp.");

            if (s.ScoreValue < 0 || s.ScoreValue > 10)
                throw new ArgumentException("Điểm phải nằm trong khoảng từ 0 đến 10.");

            var newId = _dao.Insert(s);
            return newId;
        }

        public bool UpdateScore(Score s)
        {
            if (s == null) throw new ArgumentNullException(nameof(s));
            if (s.ScoreId <= 0) throw new ArgumentException("ScoreId không hợp lệ.");

            if (s.ScoreValue < 0 || s.ScoreValue > 10)
                throw new ArgumentException("Điểm phải nằm trong khoảng từ 0 đến 10.");

            return _dao.Update(s);
        }

        public bool DeleteScore(int id)
        {
            if (id <= 0) return false;
            return _dao.Delete(id);
        }
        public bool UpdateScoreValue(int scoreId, decimal newValue)
        {
            if (scoreId <= 0) return false;
            return _dao.UpdateScoreValue(scoreId, newValue);
        }

        public decimal CalculateAverage(int enrollmentId)
        {
            var scores = GetScoresByEnrollment(enrollmentId);
            if (scores == null) return 0;

            decimal total = 0;
            decimal weightSum = 0;

            foreach (var s in scores)
            {
                var weight = _dao.GetScoreTypeWeight(s.ScoreTypeId);
                total += s.ScoreValue * weight;
                weightSum += weight;
            }

            return weightSum > 0 ? Math.Round(total / weightSum, 2) : 0;
        }
    }
}
