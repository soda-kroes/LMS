using System;

namespace LMS_RUPP.Models.ViewModels
{
    public class ClsRequest
    {
        public int Id { get; set; } 
        public string MemberId { get; set; }
        public DateTime DateBorrow { get; set; } = DateTime.Now;
        public string DateBorrowStr { get; set; }
        public DateTime DateReturn { get; set; } = DateTime.Now;
        public string DateReturnStr { get; set; }
        public string BookId { get; set; } 
        public string Purpose { get; set; }

    }
}
