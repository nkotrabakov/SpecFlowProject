using SpecFlowProject.REST.RestContext;
using SpecFlowProject.REST.Utils;
using TechTalk.SpecFlow;

namespace SpecFlowProject.REST.RestHooks
{
    [Binding]
    internal sealed class RestHooks
    {

        [AfterScenario]
        [Scope(Tag = "deleteSingleUser")]

        public static void DeleteUser(ScenarioContext scenarioContext, BaseRestClient baseRestClient)
        {
            var idToDelete = scenarioContext.Get<int>(RestLabels.lastCreatedUserID);

            baseRestClient.DeleteSingleUser(idToDelete);
        }
    }
}
