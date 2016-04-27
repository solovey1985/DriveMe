using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DriveMe.Domain.Models
{
    public class Location
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Address { get; set; }

        public Position Position { get; set; }
    }
}