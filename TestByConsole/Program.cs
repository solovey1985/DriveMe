using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DriveMe.Domain.Models;
using DriveMe.GUI.AppServices;

namespace TestByConsole
{
    class Program
    {
        static void Main(string[] args)
        {

            DriverService service = new DriverService(Guid.NewGuid());
            Guid g = service.CreateDriver("Sokl", "And");
            service.DriverId = g;
            service.CreateTrip(DateTime.Now);
            
            foreach (Trip  trip in service.GetAllTrips())
            {
                Console.WriteLine($"Trip Id: {trip.Id} Name:{trip.Title}");
            }
            
        }
    }
}
