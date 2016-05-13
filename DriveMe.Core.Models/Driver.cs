using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace DriveMe.Domain.Models
{
    public partial class Driver : User
    {

        public Guid VehicleId { get; set; }

        [NotMapped]
        public Vehicle Vehicle { get; set; }
        

    }
}