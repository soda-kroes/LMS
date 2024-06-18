using LMS_RUPP.Models.ViewModels;
using System.Collections.Generic;

namespace LMS_RUPP.Models.Response
{
    public class MemberCountResponse
    {
        public int ErrCode { get; set; }
        public string ErrMsg { get; set; }
        public int MemberAmount { get; set; }
    }
}
