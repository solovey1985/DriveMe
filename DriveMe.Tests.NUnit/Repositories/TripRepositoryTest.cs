using System;
using Bigly.DAL.Contexts;
using Bigly.DAL.Repositories;
using Bigly.Domain.Models;
using NUnit.Framework;

namespace Bigly.Tests.NUnit.Repositories
{
    [TestFixture]
    class TripRepositoryTest
    {
        [Test]
        public void Can_Isnert_NormalEntity_Success()
        {
            Guid g = Guid.NewGuid();
            Trip t = new Trip() {Id = g, EndTime = DateTime.Now.AddHours(2), StartTime = DateTime.Now};
            Trip t2;
            using (TripContext cntx = new TripContext())
            {
                TripRepository repo = new TripRepository();
                repo.Insert(t);
               t2 = repo.GetById(g);
              
            }

            Assert.NotNull(t2);

        }
    }
}
