using System;
using DriveMe.Infrastructure;

namespace DriveMe.Domain.Models
{
    public class Vehicle:EntityBase
    {
     
        public string Vendor { get; set; }
        public string Model { get; set; }
        public string Plate { get; set; }
        public ConsoleColor Color { get; set; }
        public int MaxPassengers { get; set; }
        public int MaxWeightKg { get; set; }
        public Driver Driver { get; set; }
        protected override void Validate()
        {
            throw new NotImplementedException();
        }
    }
}