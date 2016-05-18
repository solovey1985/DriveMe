using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace DriveMe.Domain.Models
{
    public partial class Driver : User
    {
        public Guid VehicleId { get; set; }
        public Vehicle Vehicle { get; set; }
        

    }
}