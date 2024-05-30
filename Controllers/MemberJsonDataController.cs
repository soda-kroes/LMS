using LMS_RUPP.Models.DBConnection;
using LMS_RUPP.Models.Response;
using LMS_RUPP.Models.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Data;
using System;
using System.Data.SqlClient;
using LMS_RUPP.Utils;
using System.Collections.Generic;
using System.Linq;
using System.Globalization;

namespace LMS_RUPP.Controllers
{
    public class MemberJsonDataController : Controller
    {
        public IActionResult PostMember(ClsMember objMember)
        {
            ClsSqlConnection con = new ClsSqlConnection();
            StatusResponse response = new StatusResponse();
            if (con._ErrCode == 0)
            {
                try
                {



                    DateTime dt = DateTime.Now;
                    objMember.CreatedDate = dt;
                    objMember.Status = 1;

                    objMember.DateOfBirth = (DateTime)FormateDate.ServerFormatDate(objMember.DateOfBirthStr);

                    //prevent duplicate user
                    bool find = false;
                    DataTable table = new DataTable();
                    string Query = @"SELECT * FROM [dbo].[tblMember] WHERE IdCard IN ('" + objMember.IdCard + "')";
                    con._Ad = new SqlDataAdapter(Query, con._Con);
                    con._Ad.Fill(table);
                    foreach (DataRow row in table.Rows)
                    {
                        find = true;
                    }
                    if (!find)
                    {
                        con._Cmd = new SqlCommand("INSERT_MEMBER", con._Con);
                        con._Cmd.CommandType = CommandType.StoredProcedure;
                        con._Cmd.Parameters.AddWithValue("@IdCard", objMember.IdCard);
                        con._Cmd.Parameters.AddWithValue("@FirstName", objMember.FirstName);
                        con._Cmd.Parameters.AddWithValue("@LastName", objMember.LastName);
                        con._Cmd.Parameters.AddWithValue("@Gender", objMember.Gender);
                        con._Cmd.Parameters.AddWithValue("@DateOfBirth",objMember.DateOfBirth);
                        con._Cmd.Parameters.AddWithValue("@Email", objMember.Email);
                        con._Cmd.Parameters.AddWithValue("@Tell", objMember.Tell);
                        con._Cmd.Parameters.AddWithValue("@CreatedDate", objMember.CreatedDate);
                        con._Cmd.Parameters.AddWithValue("@Status", objMember.Status);
                        con._Cmd.Parameters.AddWithValue("@Address", objMember.Address);
                        con._Cmd.ExecuteNonQuery();

                        response.ErrCode = 0;
                        response.ErrMsg = "Member create success.";
                    }
                    else
                    {
                        response.ErrCode = 1;
                        response.ErrMsg = "IdCard is not available.";
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

        public IActionResult GetMember()
        {
            ClsSqlConnection con = new ClsSqlConnection();
            ClsMemberResponse response = new ClsMemberResponse();
           
            if (con._ErrCode == 0)
            {
                List<ClsMember> list = new List<ClsMember>();
                ClsMember obj;

                try
                {
                    DataTable table = new DataTable();
                    string query = "SELECT CASE WHEN Status = 1 THEN 'Active' ELSE 'Inactive' END AS StatusStr,* FROM [LMS].[dbo].[tblMember];";
                    con._Ad = new SqlDataAdapter(query, con._Con);
                    con._Ad.Fill(table);
                    foreach (DataRow row in table.Rows)
                    {
                        obj = new ClsMember();
                        obj.Id = Convert.ToInt32(row["Id"].ToString());
                        obj.IdCard = Convert.ToInt32(row["IdCard"].ToString());
                        obj.FirstName = row["FirstName"].ToString();
                        obj.LastName = row["LastName"].ToString();
                        obj.Gender = row["Gender"].ToString();
                        obj.CreatedDate = Convert.ToDateTime(row["CreatedDate"]);
                        obj.CreatedDateStr = FormateDate.ClientFormatDate(obj.CreatedDate);
                        obj.Email = row["Email"].ToString();
                        obj.Tell = row["Tell"].ToString();
                        obj.DateOfBirth = Convert.ToDateTime(row["DateOfBirth"]);
                        obj.DateOfBirthStr = FormateDate.ClientFormatDate(obj.DateOfBirth);
                        obj.Address = row["Address"].ToString();
                        obj.StatusStr = row["StatusStr"].ToString();
                        list.Add(obj);
                    }
                    response.ErrCode = 0;
                    response.ErrMsg = "Success";
                    response.Members = list.ToList();
                }
                catch (Exception ex)
                {
                    response.ErrCode = ex.HResult;
                    response.ErrMsg = ex.Message;
                }

            }
        
            return Ok(response);
        }

        public IActionResult GetMemberByIDcard(int IdCard)
        {
            ClsSqlConnection con = new ClsSqlConnection();
            ClsMemberResponse response = new ClsMemberResponse();

            if (con._ErrCode == 0)
            {
                List<ClsMember> list = new List<ClsMember>();
                ClsMember obj;

                try
                {
                    DataTable table = new DataTable();
                    string query = "SELECT CASE WHEN Status = 1 THEN 'Active' ELSE 'Inactive' END AS StatusStr,* FROM [LMS].[dbo].[tblMember] WHERE IdCard = @IDCARD";
                    con._Ad = new SqlDataAdapter(query, con._Con);
                    con._Ad.SelectCommand.Parameters.AddWithValue("@IDCARD", IdCard);
                    con._Ad.Fill(table);
                    foreach (DataRow row in table.Rows)
                    {
                        obj = new ClsMember();
                        obj.Id = Convert.ToInt32(row["Id"].ToString());
                        obj.IdCard = Convert.ToInt32(row["IdCard"].ToString());
                        obj.FirstName = row["FirstName"].ToString();
                        obj.LastName = row["LastName"].ToString();
                        obj.Gender = row["Gender"].ToString();
                        obj.CreatedDate = Convert.ToDateTime(row["CreatedDate"]);
                        obj.CreatedDateStr = FormateDate.ClientFormatDate(obj.CreatedDate);
                        obj.Email = row["Email"].ToString();
                        obj.Tell = row["Tell"].ToString();
                        obj.DateOfBirth = Convert.ToDateTime(row["DateOfBirth"]);
                        obj.DateOfBirthStr = FormateDate.ClientFormatDate(obj.DateOfBirth);
                        obj.Address = row["Address"].ToString();
                        obj.StatusStr = row["StatusStr"].ToString();
                        list.Add(obj);
                    }
                    response.ErrCode = 0;
                    response.ErrMsg = "Success";
                    response.Members = list.ToList();
                }
                catch (Exception ex)
                {
                    response.ErrCode = ex.HResult;
                    response.ErrMsg = ex.Message;
                }

            }

            return Ok(response);
        }

        public IActionResult GetAllIDCard()
        {
            ClsSqlConnection con = new ClsSqlConnection();
            ClsMemberResponse response = new ClsMemberResponse();

            if (con._ErrCode == 0)
            {
                List<ClsMember> list = new List<ClsMember>();
                ClsMember obj;

                try
                {
                    DataTable table = new DataTable();
                    string query = "SELECT IdCard FROM [LMS].[dbo].[tblMember]";
                    con._Ad = new SqlDataAdapter(query, con._Con);
                    con._Ad.Fill(table);
                    foreach (DataRow row in table.Rows)
                    {
                        obj = new ClsMember();
                        obj.IdCard = Convert.ToInt32(row["IdCard"].ToString());
                        list.Add(obj);
                    }
                    response.ErrCode = 0;
                    response.ErrMsg = "Success";
                    response.Members = list.ToList();
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
