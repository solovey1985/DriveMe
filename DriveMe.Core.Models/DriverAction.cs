using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DriveMe.Domain.Models
{
    public partial class Driver
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
