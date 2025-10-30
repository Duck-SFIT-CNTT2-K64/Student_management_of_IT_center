using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Student_manager.DAL
{
    public class DataProcesser
    {
        string strConnect = "Data Source=DangHuy\\SQLEXPRESS;DataBase=QLSV_TrungTamTinHoc;Integrated Security=True";
        SqlConnection sqlConnect = null;

        //Ham mo ket noi
        private void KetNoiCSDL()
        {
            sqlConnect = new SqlConnection(strConnect);
            if (sqlConnect.State != ConnectionState.Open)
                sqlConnect.Open();
        }
        //Ham dong ket noi
        private void DongKetNoiSQL()
        {
            if (sqlConnect.State != ConnectionState.Closed)
            {
                sqlConnect.Close();
            }
            sqlConnect.Dispose();
        }
        //Ham thuc thi cau lenh dang select tra ve mot Datatable
        public DataTable DocBang(string sql)
        {
            DataTable dtBang = new DataTable();
            KetNoiCSDL();
            SqlDataAdapter sqldataAdapte = new SqlDataAdapter(sql, sqlConnect);
            sqldataAdapte.Fill(dtBang);
            DongKetNoiSQL();
            return dtBang;
        }

        public void CapNhatDuLieu(string sql)
        {
            KetNoiCSDL();
            SqlCommand sqlcommand = new SqlCommand();
            sqlcommand.Connection = sqlConnect;
            sqlcommand.CommandText = sql;
            sqlcommand.ExecuteNonQuery();
            DongKetNoiSQL();
            sqlcommand.Dispose();
        }
    }
}
