using System;
using Bigly.Api.ViewModels.Base;

namespace Bigly.Api.ViewModels.Api
{
    public class TripRequest: ViewModel
    {
        public int Id { get; set; }
        public string StartAddress { get; set; }
        public string EndAddress { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public double StartLatitude { get; set; }
        public double StartLongitude { get; set; }
        public double EndLatitude { get; set; }
        public double EndLongitude { get; set; }


    }
}
