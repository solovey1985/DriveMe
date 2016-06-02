using System;
using TechTalk.SpecFlow;

namespace DriveMe.Tests.Spec
{
    [Binding]
    public class AdminAddNewUserSteps
    {
        [Given(@"I have crated a new user")]
        public void GivenIHaveCratedANewUser()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Given(@"I assign him to User Role")]
        public void GivenIAssignHimToUserRole()
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"I pressed Create")]
        public void WhenIPressedCreate()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"User should have User Role")]
        public void ThenUserShouldHaveUserRole()
        {
            ScenarioContext.Current.Pending();
        }
    }
}
