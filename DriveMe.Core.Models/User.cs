using System;
using DriveMe.Infrastructure;

namespace DriveMe.Domain.Models
{
    public abstract class User:EntityBase
    {
        #region Properties
        public string FirstName {get;set;}
        public string LastName {get;set;}
        public string Phone {get;set;}
        public string HomeAddress { get; set; }
        public string WorkAddress { get; set; }
        public string FavouriteAddress { get; set; }


        #endregion

        protected User(Guid id) : base(id) { }

        protected User()
        {}
    }
}