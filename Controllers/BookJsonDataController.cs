using LMS_RUPP.Models.DBConnection;
using LMS_RUPP.Models.Response;
using LMS_RUPP.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System;
using System.Linq;
using LMS_RUPP.Utils;

namespace LMS_RUPP.Controllers
{
    public class BookJsonDataController : Controller
    {

        public IActionResult PostBook(ClsBook book)
        {
            ClsSqlConnection con = new ClsSqlConnection();
            StatusResponse response = new StatusResponse();
            if (con._ErrCode == 0)
            {
                try
                {

                    bool find = false;
                    DataTable dt = new DataTable();
                    string Query = @"SELECT * FROM [dbo].[tblBook] WHERE BookId IN ('" + book.BookId + "')";
                    con._Ad = new SqlDataAdapter(Query, con._Con);
                    con._Ad.Fill(dt);
                    foreach (DataRow row in dt.Rows)
                    {
                        find = true;
                    }

                    if (!find)
                    {
                        string QueryInsert = @"INSERT INTO [dbo].[tblBook] (BookId,Title,Author,TypeOfBookId,BookImage)
                                    Values(@BookId,@Title,@Author,@TypeOfBookId,@BookImage) ";
                        con._Cmd = new SqlCommand(QueryInsert, con._Con);
                        con._Cmd.Parameters.AddWithValue("@BookId", book.BookId);
                        con._Cmd.Parameters.AddWithValue("@Title", book.Title);
                        con._Cmd.Parameters.AddWithValue("@Author", book.Author);
                        con._Cmd.Parameters.AddWithValue("@TypeOfBookId", book.TypeOfBookId);
                        con._Cmd.Parameters.AddWithValue("@BookImage", book.BookImage);
                        con._Cmd.ExecuteNonQuery();
                        response.ErrCode = 0;
                        response.ErrMsg = "Book add success.";
                    }
                    else
                    {
                        response.ErrCode = 1;
                        response.ErrMsg = "BookId is not available.";
                    }
                }
                catch (Exception ex)
                {
                    response.ErrCode = ex.HResult;
                    response.ErrMsg = ex.Message;
                }
            }
            return Ok(response);
        }

        public IActionResult GetBook()
        {
            ClsBookResponse response = new ClsBookResponse();
            ClsSqlConnection con = new ClsSqlConnection();
            if (con._ErrCode == 0)
            {
                List<ClsBook> list = new List<ClsBook>();
                ClsBook obj;
                try
                {
                    DataTable dt = new DataTable();
                    con._Ad = new SqlDataAdapter(@"select b.BookId,b.Title,b.Author,t.Name,b.BookImage from [dbo].[tblBook] b 
                                                   INNER JOIN [dbo].[tblTypeOfBook] t ON b.TypeOfBookId = t.id ", con._Con);
                    con._Ad.Fill(dt);
                    foreach (DataRow row in dt.Rows)
                    {
                        obj = new ClsBook();
                        obj.BookId = Convert.ToInt32(row["BookId"].ToString());
                        obj.Title = row["Title"].ToString();
                        obj.Author = row["Author"].ToString();
                        obj.TypeOfBook = row["Name"].ToString();
                        obj.BookImage = row["BookImage"].ToString();
                        list.Add(obj);

                    }
                    response.ErrCode = 0;
                    response.ErrMsg = "Success";
                    response.Books = list.ToList();

                }
                catch (Exception ex)
                {
                    response.ErrCode = ex.HResult;
                    response.ErrMsg = ex.Message;
                }
            }
            return Ok(response);
        }

        public IActionResult getAllBookId()
        {
            ClsSqlConnection con = new ClsSqlConnection();
            ClsBookResponse response = new ClsBookResponse();

            if (con._ErrCode == 0)
            {
                List<ClsBook> list = new List<ClsBook>();
                ClsBook obj;

                try
                {
                    DataTable table = new DataTable();
                    string query = "SELECT * FROM [LMS].[dbo].[tblBook]";
                    con._Ad = new SqlDataAdapter(query, con._Con);
                    con._Ad.Fill(table);
                    foreach (DataRow row in table.Rows)
                    {
                        obj = new ClsBook();
                        obj.BookId = Convert.ToInt32(row["BookId"].ToString());
                        list.Add(obj);
                    }
                    response.ErrCode = 0;
                    response.ErrMsg = "Success";
                    response.Books = list.ToList();
                }
                catch (Exception ex)
                {
                    response.ErrCode = ex.HResult;
                    response.ErrMsg = ex.Message;
                }

            }

            return Ok(response);
        }

        public IActionResult GetBookById(int BookID)
        {
            ClsSqlConnection con = new ClsSqlConnection();
            ClsBookResponse response = new ClsBookResponse();

            if (con._ErrCode == 0)
            {
                List<ClsBook> list = new List<ClsBook>();
                ClsBook obj;

                try
                {
                    DataTable table = new DataTable();
                    string query = @"SELECT t2.BookId,t2.Author,t2.Title,t2.BookImage,t1.Name as TypeOfBook from [dbo].[tblTypeOfBook] t1
                                     INNER JOIN [dbo].[tblBook] t2
                                     ON t1.Id = t2.TypeOfBookId where BookId = @bookID";
                    con._Ad = new SqlDataAdapter(query, con._Con);
                    con._Ad.SelectCommand.Parameters.AddWithValue("@bookID", BookID);
                    con._Ad.Fill(table);
                    foreach (DataRow row in table.Rows)
                    {
                        obj = new ClsBook();
                        obj.BookId = Convert.ToInt32(row["BookId"].ToString());
                        obj.Title = row["Title"].ToString();
                        obj.Author = row["Author"].ToString();
                        obj.TypeOfBook = row["TypeOfBook"].ToString();
                        obj.BookImage = row["BookImage"].ToString();
                        list.Add(obj);
                    }
                    response.ErrCode = 0;
                    response.ErrMsg = "Success";
                    response.Books = list.ToList();
                }
                catch (Exception ex)
                {
                    response.ErrCode = ex.HResult;
                    response.ErrMsg = ex.Message;
                }

            }

            return Ok(response);
        }

        [HttpPost]
        public IActionResult RequestBorrowBook([FromBody] RequestData requestData)
        {
            ClsSqlConnection con = new ClsSqlConnection();
            StatusResponse response = new StatusResponse();

            try
            {
                if (con._ErrCode == 0)
                {
                    // Get the current local date and time
                    DateTime now = DateTime.Now;

                    // Generate a four-digit number using the current date and time
                    Random random = new Random();
                    int randomNumber = random.Next(10000); // Generate a random number between 0 and 9999

                    // Combine the current date and time with the random number
                    string requestNo = now.ToString("yyyyMMddHHmmss") + randomNumber.ToString("D4");

                    foreach (ClsRequest request in requestData.ObjRequest)
                    {
                        con._Cmd = new SqlCommand("INSERT_REQUEST", con._Con);
                        con._Cmd.CommandType = CommandType.StoredProcedure;
                        con._Cmd.Parameters.AddWithValue("@Req_No", requestNo);
                        con._Cmd.Parameters.AddWithValue("@UserId", request.UserId);
                        con._Cmd.Parameters.AddWithValue("@BookId", request.BookId);
                        con._Cmd.Parameters.AddWithValue("@DateBorrow", request.DateBorrowStr);
                        con._Cmd.Parameters.AddWithValue("@DateReturn", request.DateReturnStr);
                        con._Cmd.Parameters.AddWithValue("@Status", "1");
                        con._Cmd.Parameters.AddWithValue("@Purpose", request.Purpose);
                        con._Cmd.ExecuteNonQuery();
                    }

                    response.ErrCode = 0;
                    response.ErrMsg = "Request Success.";
                }
            }
            catch (Exception ex)
            {
                response.ErrCode = ex.HResult;
                response.ErrMsg =  ex.Message;
            }

            return Ok(response);
        }


        public IActionResult GetBookBorrowByUserId(int UserId)
        {
            ClsSqlConnection con = new ClsSqlConnection();
            ClsRequestResponse response = new ClsRequestResponse();

            if (con._ErrCode == 0)
            {
                List<ClsRequest> list = new List<ClsRequest>();
                ClsRequest obj;

                try
                {
                    DataTable table = new DataTable();
                    string query = @"select * from [dbo].[tblRequest] where UserId = @UserId AND Status = @Status";
                    con._Ad = new SqlDataAdapter(query, con._Con);
                    con._Ad.SelectCommand.Parameters.AddWithValue("@UserId", UserId);
                    con._Ad.SelectCommand.Parameters.AddWithValue("@Status", "1");
                    con._Ad.Fill(table);
                    foreach (DataRow row in table.Rows)
                    {
                        obj = new ClsRequest();
                        obj.Id = Convert.ToInt32(row["Id"]);
                        obj.BookId = row["BookId"].ToString();
                        obj.DateBorrow = Convert.ToDateTime(row["DateBorrow"]);
                        obj.DateBorrowStr = FormateDate.ClientFormatDate(obj.DateBorrow);
                        obj.DateReturn = Convert.ToDateTime(row["DateReturn"]);
                        obj.DateReturnStr = FormateDate.ClientFormatDate(obj.DateReturn);
                        obj.Purpose = row["Purpose"].ToString();
                        list.Add(obj);
                    }
                    response.ErrCode = 0;
                    response.ErrMsg = "Success";
                    response.Requests = list.ToList();
                }
                catch (Exception ex)
                {
                    response.ErrCode = ex.HResult;
                    response.ErrMsg = ex.Message;
                }

            }

            return Ok(response);
        }

        public IActionResult ReturnBook(int BookId,int UserId)
        {
            ClsSqlConnection con = new ClsSqlConnection();
            StatusResponse response = new StatusResponse();

            if (con._ErrCode == 0)
            {

                try
                {
                    string Query = @"  UPDATE [dbo].[tblRequest] SET Status = 0 WHERE UserId = @user_id AND BookId = @book_id";
                    con._Cmd = new SqlCommand(Query,con._Con);
                    con._Cmd.Parameters.AddWithValue("@user_id",UserId);
                    con._Cmd.Parameters.AddWithValue("@book_id", BookId);
                    con._Cmd.ExecuteNonQuery();
                    response.ErrCode = 0;
                    response.ErrMsg = "Book Return Success.";
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
