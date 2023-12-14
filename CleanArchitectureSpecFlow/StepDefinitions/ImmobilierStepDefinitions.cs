using System;
using TechTalk.SpecFlow;

namespace CleanArchitectureSpecFlow.StepDefinitions
{
    [Binding]
    public class ImmobilierStepDefinitions
    {
        [Given(@"there are Immobolier in the system")]
        public void GivenThereAreImmobolierInTheSystem()
        {
            throw new PendingStepException();
        }

        [When(@"I make a POST request on '([^']*)' with this data:")]
        public void WhenIMakeAPOSTRequestOnWithThisData(string p0, Table table)
        {
            throw new PendingStepException();
        }

        [Then(@"a successful response is returned with the newly added Immobolier")]
        public void ThenASuccessfulResponseIsReturnedWithTheNewlyAddedImmobolier()
        {
            throw new PendingStepException();
        }

        [Then(@"the response status code is (.*)")]
        public void ThenTheResponseStatusCodeIs(int p0)
        {
            throw new PendingStepException();
        }

        [When(@"I make a GET request on '([^']*)'")]
        public void WhenIMakeAGETRequestOn(string p0)
        {
            throw new PendingStepException();
        }

        [Then(@"a successful response is returned with a list of Immobolier")]
        public void ThenASuccessfulResponseIsReturnedWithAListOfImmobolier()
        {
            throw new PendingStepException();
        }
    }
}
