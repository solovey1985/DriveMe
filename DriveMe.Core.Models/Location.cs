using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DriveMe.Infrastructure.DomainBase;

namespace DriveMe.Domain.Models
{
    public class Location:ValueObjectBase<Location>
    {
        
        public string Title { get; private set; }

        public string Address { get; private set; }

        public Position Position { get; private  set; }
        
        #region Equals
        public override bool Equals(Location other)
        {
            throw new NotImplementedException();
        }

        public override bool Equals(object obj)
        {
            throw new NotImplementedException();
        }

        public override int GetHashCode()
        {
            throw new NotImplementedException();
        }
        #endregion
    }
}