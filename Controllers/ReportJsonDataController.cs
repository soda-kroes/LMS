using LMS_RUPP.Models.DBConnection;
using LMS_RUPP.Models.Response;
using LMS_RUPP.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System;
using LMS_RUPP.Utils;
using System.Linq;

namespace LMS_RUPP.Controllers
{
    public class ReportJsonDataController : Controller
    {
        public IActionResult GetBookReport()
        {
            ClsSqlConnection con = new ClsSqlConnection();
            ClsBookReportResponse response = new ClsBookReportResponse();

            if (con._ErrCode == 0)
            {
                List<ClsBookReport> list = new List<ClsBookReport>();
                ClsBookReport obj;

                try
                {
                    DataTable table = new DataTable();
                    string query = "REPORT_BOOK";
                    con._Ad = new SqlDataAdapter(query, con._Con);
                    con._Ad.SelectCommand.CommandType = CommandType.StoredProcedure;
                    con._Ad.Fill(table);
                    foreach (DataRow row in table.Rows)
                    {
                        obj = new ClsBookReport();
                        obj.Id = Convert.ToInt32(row["Id"].ToString());
                        obj.UserId = Convert.ToInt32(row["UserId"].ToString()); 
                        obj.BookId = Convert.ToInt32(row["BookId"].ToString());
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
                    response.BookReports = list.ToList();
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
