using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;

namespace Student_manager.DAL
{
    public class DataProcesser
    {
        // prefer connection string from config; fall back to hard-coded value for backward compatibility
        private static readonly string _connString = ConfigurationManager.ConnectionStrings["StudentDB"]?.ConnectionString
            ?? "Data Source=DUCKCYZZZ\\SQLEXPRESS;Initial Catalog=QLSV_TrungTamTinHoc;Integrated Security=True;";

        // expose for other DAL code that previously referenced DataProcesser.ConnectionString
        public static string ConnectionString => _connString;

        private SqlConnection sqlConnect = null;

        //Ham mo ket noi
        private void KetNoiCSDL()
        {
            sqlConnect = new SqlConnection(_connString);
            if (sqlConnect.State != ConnectionState.Open)
                sqlConnect.Open();
        }
        //Ham dong ket noi
        private void DongKetNoiSQL()
        {
            if (sqlConnect != null)
            {
                if (sqlConnect.State != ConnectionState.Closed)
                {
                    sqlConnect.Close();
                }
                sqlConnect.Dispose();
                sqlConnect = null;
            }
        }
        //Ham thuc thi cau lenh dang select tra ve mot Datatable
        public DataTable DocBang(string sql)
        {
            DataTable dtBang = new DataTable();
            KetNoiCSDL();
            using (SqlDataAdapter sqldataAdapte = new SqlDataAdapter(sql, sqlConnect))
            {
                sqldataAdapte.Fill(dtBang);
            }
            DongKetNoiSQL();
            return dtBang;
        }

        public void CapNhatDuLieu(string sql)
        {
            KetNoiCSDL();
            using (SqlCommand sqlcommand = new SqlCommand())
            {
                sqlcommand.Connection = sqlConnect;
                sqlcommand.CommandText = sql;
                sqlcommand.ExecuteNonQuery();
            }
            DongKetNoiSQL();
        }
    }
}
