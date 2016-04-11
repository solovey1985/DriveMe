using System;
using TechTalk.SpecFlow;

namespace DriveMe.Tests.Spec.DriverBehavour
{
    [Binding]
    public class DriverSearchBehavourSteps
    {
        [Given(@"I have created new  Route")]
        public void GivenIHaveCreatedNewRoute()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Given(@"I have added (.*) pick boarding Locations into the Route")]
        public void GivenIHaveAddedPickBoardingLocationsIntoTheRoute(int p0)
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"I press add")]
        public void WhenIPressAdd()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"the Route should contain (.*) boarding locations")]
        public void ThenTheRouteShouldContainBoardingLocations(int p0)
        {
            ScenarioContext.Current.Pending();
        }
    }
}
