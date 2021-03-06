﻿/*
    Aggregate root for trip context
*/
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using DriveMe.Infrastructure;
using DriveMe.Infrastructure.DomainBase;

namespace DriveMe.Domain.Models
{

    public partial class Trip: Entity, IAggregateRoot
    {
        #region Properties
      
        public string Title { get; set; }
        
  
        
        public DateTime? StartTime { get; set; }
        public DateTime? EndTime { get; set; }
        public virtual ICollection<User> Passengers { get; set; }
        public virtual User Driver { get; set; }
        public virtual Vehicle Vehicle { get; set; }

        public virtual Route Route { get; set; }

       
        #endregion

       
    }
}