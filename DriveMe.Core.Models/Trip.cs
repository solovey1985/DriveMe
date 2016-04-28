/*
    Aggregate root for trip context
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DriveMe.Infrastructure;

namespace DriveMe.Domain.Models
{
    public partial class Trip: EntityBase
    {
        #region Properties
        
        public string Title { get; set; }

        public List<Passenger> Passangers { get; set; }

        public Driver Driver { get; set; }

        public Vehicle Vehicle { get; set; }

        public Route Route { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }
        #endregion
    }
}