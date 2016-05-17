using System;
using DriveMe.GUI.ViewModels.Base;

namespace DriveMe.GUI.ViewModels.Api
{
    public class TripRequest: ViewModel
    {
        public int Id { get; set; }
        public string Address { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public double StartLatitude { get; set; }
        public double StartLongitude { get; set; }
        public double EndLatitude { get; set; }
        public double EndLongitude { get; set; }


    }
}
