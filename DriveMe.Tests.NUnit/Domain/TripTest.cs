using Bigly.Domain.Models;
using NUnit.Framework;

namespace Bigly.Tests.NUnit.Domain
{
    [TestFixture]
    public class TripTest
    {
       
        public void CanGetTripById()
        {
            Trip trip = new Trip();
           Assert.NotNull(trip);
        }
    }
}
