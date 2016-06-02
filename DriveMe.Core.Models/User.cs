using System;
using DriveMe.Infrastructure;
using DriveMe.Infrastructure.DomainBase;

namespace DriveMe.Domain.Models
{
    public class User:EntityBase, IAggregateRoot, IDriveMeUser
    {
        #region Properties
        public string FirstName {get;set;}
        public string LastName {get;set;}
        public string Phone {get;set;}
        public string Login { get; set; }
        public string Email { get; set; }
        public string HomeAddress { get; set; }
        public string WorkAddress { get; set; }
        public string FavouriteAddress { get; set; }
        public Role Role { get; set; }

        #endregion

        public User(Guid id) : base(id) { }

        public User()
        {}
    
        public override bool Validate()
        {
            return true;
        }
    }

    
}