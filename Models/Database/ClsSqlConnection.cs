using System;
using System.Configuration;
using System.Data.SqlClient;

namespace LMS_RUPP.Models.DBConnection
{
    public class ClsSqlConnection
    {
        private int ErrCode;
        private string ErrMsg;
        private SqlConnection con;

        public int _ErrCode { get { return ErrCode; } }//read only
        public string _ErrMsg { get { return ErrMsg; } }//read only
        public SqlConnection _Con { get { return con; } }//read only
        public SqlCommand _Cmd { get; set; }
        public SqlDataAdapter _Ad { get; set; }

        public ClsSqlConnection()
        {
            getConnection();
        }

        private void getConnection()
        {
            try
            {
                string constr = "Server=DESKTOP-FQ90H1P\\SQLEXPRESS;Database=LMS;User Id=sodaSQL;Password=sodaIT@168;TrustServerCertificate=True";
                //string constr = "Server=192.168.103.71;Database=LMS;User Id=cpb_int;Password=123cp!@#;TrustServerCertificate=True";
                con = new SqlConnection(constr);
                if (con.State == System.Data.ConnectionState.Closed)
                {
                    con.Open();
                }
                if (con.State == System.Data.ConnectionState.Open)
                {
                    ErrCode = 0;
                }
                else
                {
                    ErrCode = 9999999;
                    ErrMsg = "Unknow";
                }
            }
            catch (Exception ex)
            {
                ErrCode = ex.HResult;
                ErrMsg = ex.Message;
            }
        }
    }
}
