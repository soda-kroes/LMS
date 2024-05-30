using System;

namespace LMS_RUPP.Models.ViewModels
{
    public class ClsHistoryRequest
    {
        public int Id { get; set; }
        public string BookId { get; set; }
        public DateTime DateBorrow { get; set; }
        public string DateBorrowStr { get; set; }
        public DateTime DateReturn { get; set; }    
        public string DateReturnStr { get; set;}
        public string Purpose { get; set; } 
        public int Status { get; set; }
        public string StatusStr { get; set; }
    }
}
