/*Naming Conventions is applied 
    [MethodName_StateUnderTest_ExpectedBehavior]
    Public void Sum_NegativeNumberAs1stParam_ExceptionThrown()
*/

using Bigly.Domain.Models;
using NUnit.Framework;

namespace Bigly.Tests.NUnit.Domain
{
    [TestFixture]
    public class PositionTests
    {
        [Test]
        public void WithTitle_ProperTitle_InstanceWithGivenTitle()
        {
            //Arrange
            Location expected = new Location("Address1", new Position(20, 20), "Title");
            //Act 
            Location actual = expected.WithTitle("New Title");
            //Assert
            Assert.AreEqual(actual.Address, expected.Address);
            Assert.AreEqual(actual.Position, expected.Position);
            Assert.AreNotEqual(actual.Title, expected.Title);
            Assert.AreSame(actual.Position,expected.Position);
        }

        [Test]
        public void WithAddress_ProperAddress_InstanceWithGivenAddress()
        {
            //Arrange
            Location expected = new Location("Address1", new Position(20, 20), "Title");
            //Act 
            Location actual = expected.WithAddress("New Address");
            //Assert
            Assert.AreNotEqual(actual.Address, expected.Address);
            Assert.AreEqual(actual.Position, expected.Position);
            Assert.AreEqual(actual.Title, expected.Title);
            Assert.AreSame(actual.Position, expected.Position);
        }

        [Test]
        public void WithPosition_ProperPosition_InstanceWithGivenPosition()
        {
            //Arrange
            Location expected = new Location("Address1", new Position(20, 20), "Title");
            //Act 
            Location actual = expected.WithPosition(new Position(30,30));
            //Assert
            Assert.AreEqual(actual.Address, expected.Address);
            Assert.AreNotEqual(actual.Position, expected.Position);
            Assert.AreEqual(actual.Title, expected.Title);
            Assert.AreNotSame(actual.Position, expected.Position);
        }

        [Test]
        public void IsTheSameStreet_ProperPosition_ShouldBeTrue()
        {
            //Arrange
            Location expected = new Location("Address1", new Position(30.7777777, 30.7777777), "Title");
            //Act 
            Location actual = expected.WithPosition(new Position(30.7777466, 30.7777466));
            //Assert
            
            Assert.True(actual.Position.IsTheSameStreet(expected.Position));
        }


    }
}
