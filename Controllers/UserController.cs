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
    public class UserController : Controller
    {
        public IActionResult ViewUser()
        {
            return View();
        }
        public IActionResult PostUser(ClsUser user)
        {
            ClsSqlConnection con = new ClsSqlConnection();
            StatusResponse response = new StatusResponse();
            if(con._ErrCode == 0)
            {
                try
                {
                    DateTime dt = DateTime.Now;
                    user.Change = "N";
                    user.CreateBy = "ADMIN";
                    user.CreateDate = dt;
                    user.Password = "LMS123";
                    user.ExpiredDate = dt.AddDays(1);
                    user.Locked = "N";
                    user.ExpiredLock = "N";
                    user.Status = "A";
                    user.UpdatedDate = dt;

                    //prevent duplicate user
                    bool find = false;
                    DataTable table = new DataTable();
                    string Query = @"SELECT * FROM tblUser WHERE IdCard IN ('" + user.IdCard + "')";
                    con._Ad = new SqlDataAdapter(Query, con._Con);
                    con._Ad.Fill(table);
                    foreach (DataRow row in table.Rows)
                    {
                        find = true;
                    }
                    if (!find)
                    {
                        con._Cmd = new SqlCommand("INSERT_USER", con._Con);
                        con._Cmd.CommandType = CommandType.StoredProcedure;
                        con._Cmd.Parameters.AddWithValue("@IdCard",user.IdCard);
                        con._Cmd.Parameters.AddWithValue("@Username", user.Username);
                        con._Cmd.Parameters.AddWithValue("@Password", user.Password);
                        con._Cmd.Parameters.AddWithValue("@Role", user.Role);
                        con._Cmd.Parameters.AddWithValue("@Locked", user.Locked);
                        con._Cmd.Parameters.AddWithValue("@Change", user.Change);
                        con._Cmd.Parameters.AddWithValue("@CreateDate", user.CreateDate);
                        con._Cmd.Parameters.AddWithValue("@CreateBy",user.CreateBy);
                        con._Cmd.Parameters.AddWithValue("@ExpiredDate", user.ExpiredDate);
                        con._Cmd.Parameters.AddWithValue("@ExpiredLocked", user.ExpiredLock);
                        con._Cmd.Parameters.AddWithValue("@Status", user.Status);
                        con._Cmd.Parameters.AddWithValue("@Tell", user.Tell);
                        con._Cmd.Parameters.AddWithValue("@UpdatedDate", user.UpdatedDate);
                        con._Cmd.ExecuteNonQuery();

                        response.ErrCode = 0;
                        response.ErrMsg = "User create success.";
                    }
                    else
                    {
                        response.ErrCode = 1;
                        response.ErrMsg = "Id Card is not available.";
                    }
                }catch (Exception ex)
                {
                    response.ErrCode = ex.HResult;
                    response.ErrMsg = ex.Message;
                }
            }
            return Ok(response);
        }


        public IActionResult GetUser()
        {
            ClsSqlConnection con = new ClsSqlConnection();
            UserResponse userResponse = new UserResponse();
            if (con._ErrCode == 0)
            {
                List<ClsUser> users = new List<ClsUser>();
                ClsUser obj;
                try
                {
                    DataTable table = new DataTable();
                    string query = "SELECT_USER";
                    con._Ad = new SqlDataAdapter(query, con._Con);
                    con._Ad.SelectCommand.CommandType = CommandType.StoredProcedure;
                    con._Ad.Fill(table);
                    foreach (DataRow row in table.Rows)
                    {
                        obj = new ClsUser();
                        obj.Id = Convert.ToInt32(row["Id"].ToString());
                        obj.IdCard = row["IdCard"].ToString();
                        obj.Username = row["Username"].ToString();
                        obj.Password = row["Password"].ToString();
                        obj.Role = row["UserRole"].ToString();
                        obj.Locked = row["UserLocked"].ToString();
                        obj.Change = row["UserChange"].ToString();
                        obj.CreateDate = Convert.ToDateTime(row["CreatedDate"]);
                        obj.CreateDateStr = FormateDate.ClientFormatDate(obj.CreateDate);
                        obj.CreateBy = row["CreatedBy"].ToString();
                        obj.ExpiredLock = row["ExpiredLocked"].ToString();
                        obj.Status = row["UserStatus"].ToString();
                        obj.Tell = row["Tell"].ToString();
                        users.Add(obj);
                    }
                    userResponse.ErrCode = 0;
                    userResponse.ErrMsg = "Success";
                    userResponse.Users = users.ToList();
                }
                catch (Exception ex)
                {
                    userResponse.ErrCode = ex.HResult;
                    userResponse.ErrMsg = ex.Message;
                }
                
            }
            else
            {
                userResponse.ErrCode = con._ErrCode;
                userResponse.ErrMsg = con._ErrMsg;

            }
            return Ok(userResponse);
        }

        public IActionResult GetUserById(int idCard)
        {
            ClsSqlConnection con = new ClsSqlConnection();
            UserResponse userResponse = new UserResponse();
            if (con._ErrCode == 0)
            {
                List<ClsUser> users = new List<ClsUser>();
                ClsUser obj;
                try
                {
                    DataTable table = new DataTable();
                    string query = "SELECT_USER_BY_ID";
                    con._Ad = new SqlDataAdapter(query, con._Con);
                    con._Ad.SelectCommand.CommandType = CommandType.StoredProcedure;
                    con._Ad.SelectCommand.Parameters.AddWithValue("@IdCard",idCard);
                    con._Ad.Fill(table);
                    foreach (DataRow row in table.Rows)
                    {
                        obj = new ClsUser();
                        obj.Id = Convert.ToInt32(row["Id"].ToString());
                        obj.IdCard = row["IdCard"].ToString();
                        obj.Username = row["Username"].ToString();
                        obj.Password = row["Password"].ToString();
                        obj.Role = row["UserRole"].ToString();
                        obj.Locked = row["UserLocked"].ToString();
                        obj.Change = row["UserChange"].ToString();
                        obj.CreateDate = Convert.ToDateTime(row["CreatedDate"]);
                        obj.CreateDateStr = FormateDate.ClientFormatDate(obj.CreateDate);
                        obj.CreateBy = row["CreatedBy"].ToString();
                        obj.ExpiredLock = row["ExpiredLocked"].ToString();
                        obj.Status = row["UserStatus"].ToString();
                        obj.Tell = row["Tell"].ToString();
                        users.Add(obj);
                    }
                    userResponse.ErrCode = 0;
                    userResponse.ErrMsg = "Success";
                    userResponse.Users = users.ToList();
                }
                catch (Exception ex)
                {
                    userResponse.ErrCode = ex.HResult;
                    userResponse.ErrMsg = ex.Message;
                }

            }
            else
            {
                userResponse.ErrCode = con._ErrCode;
                userResponse.ErrMsg = con._ErrMsg;

            }
            return Ok(userResponse);
        }
        public IActionResult DeleteUser(int idCard)
        {
            ClsSqlConnection con = new ClsSqlConnection();
            UserResponse userResponse = new UserResponse();
            if (con._ErrCode == 0)
            {
                try
                {
                    string Query = "DELETE [dbo].[tblUser] WHERE IdCard = @idCard";
                    con._Cmd = new SqlCommand(Query,con._Con);
                    con._Cmd.Parameters.AddWithValue("@idCard",idCard);
                    con._Cmd.ExecuteNonQuery();
                    
                    userResponse.ErrCode = 0;
                    userResponse.ErrMsg = "User Delete Success.";
                }
                catch (Exception ex)
                {
                    userResponse.ErrCode = ex.HResult;
                    userResponse.ErrMsg = ex.Message;
                }

            }
            else
            {
                userResponse.ErrCode = con._ErrCode;
                userResponse.ErrMsg = con._ErrMsg;

            }
            return Ok(userResponse);
        }

        public IActionResult UpdateUser(ClsUser user)
        {
            ClsSqlConnection con = new ClsSqlConnection();
            StatusResponse response = new StatusResponse();
            if (con._ErrCode == 0)
            {
                try
                {
                    con._Cmd = new SqlCommand("UPDATE_USER", con._Con);
                    con._Cmd.CommandType = CommandType.StoredProcedure;
                    con._Cmd.Parameters.AddWithValue("@IdCard", user.IdCard);
                    con._Cmd.Parameters.AddWithValue("@Username", user.Username);
                    con._Cmd.Parameters.AddWithValue("@Role", user.Role);
                    con._Cmd.Parameters.AddWithValue("@Tell", user.Tell);
                    con._Cmd.Parameters.AddWithValue("@Status", user.Status);    
                    con._Cmd.ExecuteNonQuery();

                    response.ErrCode = 0;
                    response.ErrMsg = "User update success.";
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
