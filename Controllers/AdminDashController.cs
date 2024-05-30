using LMS_RUPP.Models.DBConnection;
using LMS_RUPP.Models.Response;
using LMS_RUPP.Models.ViewModels;
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
    public class AdminDashController : Controller
    {
        public IActionResult Index()
        {
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("Code")))
            {
                return View();
            }
            else
            {
                return RedirectToAction("LoginPage", "Auth");
            }
        }
        public IActionResult ViewBook()
        {
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("Code")))
            {
                return View();
            }
            else
            {
                return RedirectToAction("LoginPage", "Auth");
            }
        }



        public IActionResult ViewMember()
        {
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("Code")))
            {
                return View();
            }
            else
            {
                return RedirectToAction("LoginPage", "Auth");
            }
        }

        public IActionResult ReportBook()
        {
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("Code")))
            {
                return View();
            }
            else
            {
                return RedirectToAction("LoginPage", "Auth");
            }
        }

        public IActionResult BorrowBook()
        {
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("Code")))
            {
                return View();
            }
            else
            {
                return RedirectToAction("LoginPage", "Auth");
            }
        }

        public IActionResult ReturnBook()
        {
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("Code")))
            {
                return View();
            }
            else
            {
                return RedirectToAction("LoginPage", "Auth");
            }
        }
    }
}
