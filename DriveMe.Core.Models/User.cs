using System;
using System.Collections.Generic;
using Bigly.Infrastructure;
using Bigly.Infrastructure.DomainBase;

namespace Bigly.Domain.Models
{
    public class Employee : Entity, IAggregateRoot
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public ICollection<Salary> Salries { get; set; } 

        public override bool Validate()
        {
            return !string.IsNullOrEmpty(FirstName) && !string.IsNullOrEmpty(LastName);
        }
    }


}