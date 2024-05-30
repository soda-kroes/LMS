using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LMS_RUPP.Models.ViewModels
{
    public class ClsUser
    {
        public int Id { get; set; }
        public string IdCard { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public string Tell { get; set; }
        public string Role { get; set; }
        public string Locked { get; set; }
        public string Change { get; set; }
        public DateTime CreateDate { get; set; }
        public string CreateDateStr { get; set; }
        public string CreateBy { get; set; }
        public DateTime ExpiredDate { get; set; }
        public string ExpiredDateStr { get; set; }
        public string ExpiredLock { get; set; }
        public string Status { get; set; }
        public DateTime UpdatedDate { get; set; }
        public string UpdatedDateStr { get; set; }
    }
}
