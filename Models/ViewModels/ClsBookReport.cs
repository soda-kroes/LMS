using System;

namespace LMS_RUPP.Models.ViewModels
{
    public class ClsBookReport
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime DateBorrow { get; set; } = DateTime.Now;
        public string DateBorrowStr { get; set; }
        public DateTime DateReturn { get; set; } = DateTime.Now;
        public string DateReturnStr { get; set; }
        public int BookId { get; set; }
        public string Purpose { get; set; }
        public string StatusStr { get; set; }
    }
}
