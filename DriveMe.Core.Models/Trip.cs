/*
    Aggregate root for trip context
*/
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using DriveMe.Infrastructure;
using DriveMe.Infrastructure.DomainBase;

namespace DriveMe.Domain.Models
{
    [Table("Trips")]
    public partial class Trip: EntityBase, IAggregateRoot
    {
        #region Properties
      
        public string Title { get; set; }
        public Guid DriverId { get; set; }
        public Guid VehicleId { get; set; }
        public Guid RouteId { get; set; }
        public virtual ICollection<Guid> Passengers { get; set; }

        [NotMapped]
        public List<Passenger> Passangers { get; set; }
        [NotMapped]
        public Driver Driver { get; set; }
        [NotMapped]
        public Vehicle Vehicle { get; set; }
        [NotMapped]
        public Route Route { get; set; }

        public DateTime? StartTime { get; set; }

        public DateTime? EndTime { get; set; }
        #endregion

       
    }
}