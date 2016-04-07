using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DriveMe.Core.Models
{
    public class Driver : User
    {
        public Vehicle Vehicle { get; set; }
    }
}