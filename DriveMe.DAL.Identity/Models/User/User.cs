using System;

namespace DriveMe.DAL.Identity.Models
{
    public class User
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string  LastName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public DateTime Birthday { get; set; }
        public DateTime LastLoginDate { get; set; }
        public bool IsOnline { get; set; }
        public Role Role { get; set; }
    }
}