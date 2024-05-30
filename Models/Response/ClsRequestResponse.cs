using LMS_RUPP.Models.ViewModels;
using System.Collections.Generic;

namespace LMS_RUPP.Models.Response
{
    public class ClsRequestResponse
    {
        public int ErrCode { get; set; }
        public string ErrMsg { get; set; }
        public List<ClsRequest> Requests { get; set; }
    }
}
