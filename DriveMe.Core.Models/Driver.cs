using System;
using System.ComponentModel.DataAnnotations.Schema;
using DriveMe.Infrastructure.DomainBase;

namespace DriveMe.Domain.Models
{
    public partial class Driver : User, IAggregateRoot
    {
        public Guid VehicleId { get; set; }
        public Vehicle Vehicle { get; set; }
        

    }
}