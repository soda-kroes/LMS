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
                    string query = "REPORT_BOOK";
                    if (!string.IsNullOrEmpty(fromDate) && !string.IsNullOrEmpty(toDate) && string.IsNullOrEmpty(status))
                    {
                        query = "REPORT_BOOK1";
                    }
                    else if (string.IsNullOrEmpty(fromDate) && string.IsNullOrEmpty(toDate) && !string.IsNullOrEmpty(status))
                    {
                        query = "REPORT_BOOK2";
                    }
                    else if (!string.IsNullOrEmpty(fromDate) && !string.IsNullOrEmpty(toDate) && !string.IsNullOrEmpty(status))
                    {
                        query = "REPORT_BOOK3";
                    }

                    DataTable table = new DataTable();
                    using (SqlDataAdapter adapter = new SqlDataAdapter(query, con._Con))
                    {
                        adapter.SelectCommand.CommandType = CommandType.StoredProcedure;

                        if (!string.IsNullOrEmpty(fromDate) && !string.IsNullOrEmpty(toDate) && string.IsNullOrEmpty(status))
                        {
                            adapter.SelectCommand.Parameters.AddWithValue("@fromDate", fromDate);
                            adapter.SelectCommand.Parameters.AddWithValue("@toDate", toDate);
                        }
                        else if (string.IsNullOrEmpty(fromDate) && string.IsNullOrEmpty(toDate) && !string.IsNullOrEmpty(status))
                        {
                            adapter.SelectCommand.Parameters.AddWithValue("@Status", status);
                        }
                        else if (!string.IsNullOrEmpty(fromDate) && !string.IsNullOrEmpty(toDate) && !string.IsNullOrEmpty(status))
                        {
                            adapter.SelectCommand.Parameters.AddWithValue("@fromDate", fromDate);
                            adapter.SelectCommand.Parameters.AddWithValue("@toDate", toDate);
                            adapter.SelectCommand.Parameters.AddWithValue("@status", status);
                        }

                        adapter.Fill(table);
                    }

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
                    response.BookReports = list;
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
