using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DriveMe.Domain.Models
{
    public partial class Driver : User
    {


        public Vehicle Vehicle { get; set; }
        

    }
}