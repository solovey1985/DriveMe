using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Bigly.Infrastructure;

namespace Bigly.Domain.Models
{
    public class Rate : Entity
    {
        public string EmployeePosition { get; set; }
        public decimal AmountPerPeriod { get; set; }
        public Period Period { get; set; }

        public override bool Validate()
        {
            throw new NotImplementedException();
        }
    }
}
