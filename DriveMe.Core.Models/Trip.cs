/*
    Aggregate root for trip context
*/
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using DriveMe.Infrastructure;

namespace DriveMe.Domain.Models
{
    [Table("Trips")]
    public partial class Trip: EntityBase
    {
        #region Properties
      
        public string Title { get; set; }
        [NotMapped]
        public List<Passenger> Passangers { get; set; }
        [NotMapped]
        public Driver Driver { get; set; }
        [NotMapped]
        public Vehicle Vehicle { get; set; }
        [NotMapped]
        public Route Route { get; set; }

        public DateTime StartTime { get; set; }

        public DateTime EndTime { get; set; }
        #endregion
    }
}