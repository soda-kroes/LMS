using LMS_RUPP.Models.DBConnection;
using LMS_RUPP.Models.Response;
using LMS_RUPP.Models.ViewModels;
using LMS_RUPP.Utils;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace LMS_RUPP.Controllers
{
    public class AuthController : Controller
    {
        public IActionResult LoginPage()
        {
            return View();
        }
        public IActionResult CheckLogin(string Username, string Password)
        {
            StatusResponse response = new StatusResponse();
            ClsSqlConnection con = new ClsSqlConnection();
            DataTable table = new DataTable();
            bool find = false;
            ClsUser obj = new ClsUser();
            if(con._ErrCode == 0)
            {
                try
                {
                    string query = "SELECT * FROM tblUser WHERE Username = @Username AND Password = @Password";
                    con._Cmd = new SqlCommand(query, con._Con);
                    con._Cmd.Parameters.AddWithValue("@Username", Username);
                    con._Cmd.Parameters.AddWithValue("@Password", Password);

                    con._Ad = new SqlDataAdapter(con._Cmd);

                    con._Ad.Fill(table);
                    foreach (DataRow row in table.Rows)
                    {
                        find = true;
                        obj.Id = Convert.ToInt32(row["Id"].ToString());
                        obj.IdCard = row["IdCard"].ToString();
                        obj.Username = row["Username"].ToString();
                        obj.Password = row["Password"].ToString();
                        obj.Role = row["Role"].ToString();
                        obj.Locked = row["Locked"].ToString();
                        obj.Change = row["Change"].ToString();
                        obj.CreateDate = Convert.ToDateTime(row["CreatedDate"]);
                        obj.CreateDateStr = FormateDate.ClientFormatDate(obj.CreateDate);
                        obj.CreateBy = row["CreatedBy"].ToString();
                        obj.ExpiredLock = row["ExpiredLocked"].ToString();
                        obj.Status = row["Status"].ToString();
                        obj.Tell = row["Tell"].ToString();
                        obj.ExpiredDate = Convert.ToDateTime(row["ExpiredDate"].ToString());
                        HttpContext.Session.SetString("UserName", obj.Username); // Set the session with the user's name
                    }
                    if (find)
                    {
                        if (obj.Status == "I")
                        {
                            response.ErrCode = 1;
                            response.ErrMsg = "User is inactice please contact to admin";
                        }
                        else if (obj.Locked == "Y")
                        {
                            response.ErrCode = 2;
                            response.ErrMsg = "User is locked please contact to admin";
                        }

                        else if (obj.ExpiredDate < DateTime.Now && obj.Change == "N")
                        {
                            response.ErrCode = 3;
                            response.ErrMsg = "User is expired please contact to admin";
                        }
                        else if (obj.Change == "N")
                        {
                            response.ErrCode = 4;
                            response.ErrMsg = "";
                            HttpContext.Session.SetString("tmpCode", Username);
                        }
                        else
                        {
                            HttpContext.Session.SetString("Code", Username);
                            response.ErrCode = 0;
                            response.ErrMsg = "Login Successfully";
                        }
                    }
                    else
                    {
                        response.ErrCode = 99999;
                        response.ErrMsg = "username or password Incorrect.";
                    }
                }
                catch(Exception ex)
                {
                    response.ErrCode = ex.HResult;
                    response.ErrMsg = ex.Message;
                }
            }
            return Ok(response);
        }
         public IActionResult ChangeDefaultPassword()
        {
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("tmpCode")))
            {
                return View();
            }
            else
            {
                return RedirectToAction("LoginPage", "Auth");
            }
        }

        public IActionResult PostChangePassword(string NewPassword)
        {
            ClsSqlConnection con = new ClsSqlConnection();
            StatusResponse response = new StatusResponse();
            if (con._ErrCode == 0)
            {
                try
                {

                    con._Cmd = new SqlCommand();
                    con._Cmd.Connection = con._Con;
                    con._Cmd.CommandText = "UPDATE [dbo].[tblUser] SET Password = @password, [Change] = @change WHERE IdCard = @idcard";
                    con._Cmd.Parameters.AddWithValue("@password", NewPassword);
                    con._Cmd.Parameters.AddWithValue("@change", "Y");
                    con._Cmd.Parameters.AddWithValue("@idcard", HttpContext.Session.GetString("tmpCode"));
                    con._Cmd.ExecuteNonQuery();

                    HttpContext.Session.SetString("Code", HttpContext.Session.GetString("tmpCode"));
                    HttpContext.Session.SetString("tmpCode", "");

                    response.ErrCode = 0;
                    response.ErrMsg = "Password change success";


                }
                catch (Exception ex)
                {
                    response.ErrCode = ex.HResult;
                    response.ErrMsg = ex.Message;
                }
            }
            else
            {

                response.ErrCode = con._ErrCode;
                response.ErrMsg = con._ErrMsg;
            }


            return Ok(response);
        }
        public IActionResult LogOut()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("LoginPage", "Auth");
        }

    }
}
