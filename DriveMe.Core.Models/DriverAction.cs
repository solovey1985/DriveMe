using System;
using System.Reflection;
using DriveMe.Infrastructure.DomainBase;

namespace DriveMe.Domain.Models
{
    public partial class Driver : IAggregateRoot
    {
        public Driver(Guid id) : base(id) { }

        public Driver(Guid id, string FirstName, string LastName) : this(id)
        {
            this.FirstName = FirstName;
            this.LastName = LastName;
        }
        public Driver() { }

        #region CRUD
        #endregion

        #region Profile Edit

        public bool ChangePhone(string newPhone)
        {
            throw new NotImplementedException(MethodBase.GetCurrentMethod().ToString());
        }
        #endregion

        protected override void Validate()
        {
            throw new NotImplementedException();
        }
    }
}
