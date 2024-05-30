using LMS_RUPP.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LMS_RUPP.Models.Response
{
    public class UserResponse
    {
        public int ErrCode { get; set; }
        public string ErrMsg { get; set; }
        public List<ClsUser> Users { get; set; }
    }
}

