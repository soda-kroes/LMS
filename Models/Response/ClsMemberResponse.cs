using LMS_RUPP.Models.ViewModels;
using System.Collections.Generic;

namespace LMS_RUPP.Models.Response
{
    public class ClsMemberResponse
    {
        public int ErrCode { get; set; }
        public string ErrMsg { get; set; }
        public List<ClsMember> Members { get; set; }
    }
}
