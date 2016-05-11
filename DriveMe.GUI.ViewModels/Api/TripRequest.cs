using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DriveMe.GUI.ViewModels.Base;

namespace DriveMe.GUI.ViewModels.Api
{
    public class TripRequest: ViewModel
    {
        public int Id { get; set; }
        public string Address { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }


    }
}
