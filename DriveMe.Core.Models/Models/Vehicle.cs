using System;

namespace DriveMe.Core.Models
{
    public class Vehicle
    {
        public int Id { get; set; }

        public string Vendor { get; set; }

        public string Model { get; set; }

        public string Plate { get; set; }

        public ConsoleColor Color { get; set; }

        public User User { get; set; }
    }
}