/*
    Aggregate root for trip context
*/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DriveMe.Domain.Models
{
    public partial class Trip
    {
        #region Properties
        public int Id { get; set; }

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