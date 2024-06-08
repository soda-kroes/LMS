using LMS_RUPP.Models.DBConnection;
using LMS_RUPP.Models.Response;
using LMS_RUPP.Models.ViewModels;
using LMS_RUPP.Utils;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace LMS_RUPP.Controllers
{
    public class MasterDataController : Controller
    {
        public IActionResult GetTypeOfBook()
        {
            ClsTypeOfBookResponse response = new ClsTypeOfBookResponse();
            ClsSqlConnection con = new ClsSqlConnection();
            List<ClsTypeOfBook> list = new List<ClsTypeOfBook>();
            ClsTypeOfBook obj;

            if (con._ErrCode == 0)
            {
                try
                {
                    DataTable dt = new DataTable();
                    con._Cmd = new SqlCommand("SELECT * FROM [LMS].[dbo].[tblTypeOfBook] WHERE Status = 1",con._Con);
                    con._Ad = new SqlDataAdapter(con._Cmd);
                    con._Ad.Fill(dt);
                    foreach (DataRow row in dt.Rows)
                    {
                        obj = new ClsTypeOfBook();
                        obj.Id = Convert.ToInt32(row["Id"].ToString());
                        obj.Name = row["Name"].ToString();
                        list.Add(obj);
                    }
                    response.TypeOfBooks = list.ToList();
                    response.ErrCode = 0;
                    response.ErrMsg = "";
                }
                catch(Exception ex)
                {
                    response.ErrCode = ex.HResult;
                    response.ErrMsg = ex.Message;
                }
            }
            return Ok(response);
        }

        public IActionResult GetHistoryRequest(int UserId)
        {
            ClsSqlConnection con = new ClsSqlConnection();
            ClsHistoryRequestResponse response = new ClsHistoryRequestResponse();

            if (con._ErrCode == 0)
            {
                List<ClsHistoryRequest> list = new List<ClsHistoryRequest>();
                ClsHistoryRequest obj;

                try
                {
                    DataTable table = new DataTable();
                    string query = @"SELECT *, CASE WHEN Status = 1 THEN 'Borrow' ELSE 'Return' END AS StatusStr FROM [dbo].[tblRequest] WHERE MemberId = @MemberId";
                    con._Ad = new SqlDataAdapter(query, con._Con);
                    con._Ad.SelectCommand.Parameters.AddWithValue("@MemberId", UserId);
                    con._Ad.Fill(table);
                    foreach (DataRow row in table.Rows)
                    {
                        obj = new ClsHistoryRequest();
                        obj.Id = Convert.ToInt32(row["Id"].ToString());
                        obj.BookId = row["BookId"].ToString();
                        obj.DateBorrow = Convert.ToDateTime(row["DateBorrow"]);
                        obj.DateBorrowStr = FormateDate.ClientFormatDate(obj.DateBorrow);
                        obj.DateReturn = Convert.ToDateTime(row["DateReturn"]);
                        obj.DateReturnStr = FormateDate.ClientFormatDate(obj.DateReturn);
                        obj.Purpose = row["Purpose"].ToString();
                        obj.StatusStr = row["StatusStr"].ToString();
                        list.Add(obj);
                    }
                    response.ErrCode = 0;
                    response.ErrMsg = "Success";
                    response.HistoryRequests = list.ToList();
                }
                catch (Exception ex)
                {
                    response.ErrCode = ex.HResult;
                    response.ErrMsg = ex.Message;
                }

            }

            return Ok(response);
        }

    }
}
