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

    public partial class Trip: EntityBase, IAggregateRoot
    {
        #region Properties
      
        public string Title { get; set; }
        public Guid DriverId { get; set; }
        public Nullable<Guid> VehicleId { get; set; }
        public Guid RouteId { get; set; }
        public virtual ICollection<Guid> Passengers { get; set; }
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }

        public List<Passenger> Passangers { get; set; }

        public Driver Driver { get; set; }

        public Vehicle Vehicle { get; set; }

        public Route Route { get; set; }

       
        #endregion

       
    }
}