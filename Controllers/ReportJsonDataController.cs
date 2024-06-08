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
        public IActionResult GetBookReport(string fromDate, string toDate, string status)
        {
            ClsSqlConnection con = new ClsSqlConnection();
            ClsBookReportResponse response = new ClsBookReportResponse();

            if (con._ErrCode == 0)
            {
                List<ClsBookReport> list = new List<ClsBookReport>();
                ClsBookReport obj;

                try
                {
                    string query;
                    DataTable table = new DataTable();
                    con._Ad = new SqlDataAdapter("", con._Con); // Initialize SqlDataAdapter

                    if (!string.IsNullOrEmpty(fromDate) && !string.IsNullOrEmpty(toDate))
                    {
                        query = "REPORT_BOOK1";
                        con._Ad.SelectCommand.CommandText = query;
                        con._Ad.SelectCommand.Parameters.AddWithValue("@fromDate", fromDate);
                        con._Ad.SelectCommand.Parameters.AddWithValue("@toDate", toDate);
                    }
                    else if (!string.IsNullOrEmpty(status))
                    {
                        query = "REPORT_BOOK2";
                        con._Ad.SelectCommand.CommandText = query;
                        con._Ad.SelectCommand.Parameters.AddWithValue("@Status", status);
                    }
                    else
                    {
                        query = "REPORT_BOOK";
                        con._Ad.SelectCommand.CommandText = query;
                    }

                    con._Ad.SelectCommand.CommandType = CommandType.StoredProcedure;
                    con._Ad.Fill(table);

                    foreach (DataRow row in table.Rows)
                    {
                        obj = new ClsBookReport();
                        obj.MemberId = Convert.ToInt32(row["MemberId"]);
                        obj.BookId = Convert.ToInt32(row["BookId"]);
                        obj.DateBorrow = Convert.ToDateTime(row["DateBorrow"]);
                        obj.DateBorrowStr = FormateDate.ClientFormatDate(obj.DateBorrow);
                        obj.DateReturn = Convert.ToDateTime(row["DateReturn"]);
                        obj.DateReturnStr = FormateDate.ClientFormatDate(obj.DateReturn);
                        obj.Purpose = row["Purpose"].ToString();
                        obj.StatusStr = row["StatusStr"].ToString();
                        obj.MemberName = row["MemberName"].ToString();
                        obj.BookName = row["Title"].ToString();
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
