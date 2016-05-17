using System;
using System.Linq;
using DriveMe.DAL.Contexts;
using DriveMe.Domain.Models;
using NUnit.Framework;
namespace DriveMe.Tests.NUnit.DbContext
{
    [TestFixture]
    public class DriveMeContextTest
    {
        [Test]
        public void Can_Insert_InContext_Succes()
        {
            using (TripContext context = new TripContext())
            {
                Guid g =Guid.NewGuid();
                Trip t = new Trip() { StartTime = DateTime.Now, EndTime = DateTime.Now.AddHours(1), Title = "TestRoute" };
      
                context.Trips.Add(t);
                context.SaveChanges();
            }
        }

        [Test]
        public void Can_Get_OneTrip_Success()
        {
            using (TripContext context = new TripContext())
            {
                var trip = context.Trips.FirstOrDefault();
                Assert.NotNull(trip);
            }
        }
    }
}
