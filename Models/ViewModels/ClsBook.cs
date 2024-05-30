using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LMS_RUPP.Models.ViewModels
{
    public class ClsBook
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public int TypeOfBookId { get; set; }
        public string TypeOfBook { get; set; }
        public string BookImage { get; set; }

    }
}
