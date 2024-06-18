using LMS_RUPP.Models.ViewModels;
using System.Collections.Generic;

namespace LMS_RUPP.Models.Response
{
    public class DashboardResponse
    {
        public int ErrCode { get; set; }
        public string ErrMsg { get; set; }
        public List<Dashboard> Dashboards { get; set; }
    }
}
