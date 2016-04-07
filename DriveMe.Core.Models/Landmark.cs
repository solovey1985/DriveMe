using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DriveMe.Core.Models
{
    public class Landmark
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public Position Position { get; set; }

        public string Address { get; set; }

        public int Distance { get; set; }

        public int Direction { get; set; }
    }
}