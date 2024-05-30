using System;

namespace LMS_RUPP.Models.ViewModels
{
    public class ClsMember
    {
        public int Id { get; set; }
        public int IdCard { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Gender { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string DateOfBirthStr { get; set; }
        public string Email { get; set; }
        public string Tell { get; set; }
        public DateTime CreatedDate { get; set; }
        public string CreatedDateStr { get; set; }
        public string Address { get; set; }
        public int Status { get; set; }
        public string StatusStr { get; set; }   

    }
}
