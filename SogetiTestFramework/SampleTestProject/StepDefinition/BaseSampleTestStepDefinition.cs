using SogetiTestFramework.Helper;
using SogetiTestFramework.StepDefinition;
using SogetiTestFramework.Utility;

using static SampleTestProject.Enum.SampleTestProjectGlobals;

namespace SampleTestProject.StepDefinition
{
    /// <summary>
    /// BaseSampleTestProjectStepDefinition class will be used to support common functionality for Sample Test
    /// applications.
    /// </summary>
    public class BaseSampleTestProjectStepDefinition : BaseStepDefinition
    {
        private static readonly Log logger = new Log(typeof(BaseSampleTestProjectStepDefinition));

        /////////////////////////////////////////////////////////
        //HELPER METHODS
        /////////////////////////////////////////////////////////

        /// <summary>
        /// This method validates temporary values that were stored globally, that the values can be retrieved and removed from the globals list.
        /// </summary>
        public void ValidateGlobals()
        {
            BaseList<object> items = globals.Get<BaseList<object>>(SearchItems.ToString());

            foreach (var item in items)
            {
                softAsseert.AssertThatIsNotNull(item, "Item is null");
                logger.Info("Global object type of: " + item.GetType() + ", and value: '" + item.ToString() + "'");
            }

            globals.RemoveFromList(SearchItems.ToString(), items[0]);
            items = globals.Get<BaseList<object>>(SearchItems.ToString());
            foreach (var item in items)
            {
                softAsseert.AssertThatIsNull(item, "Expected null but was: " + item.ToString());
            }

            softAsseert.ProcessAsserts();
        }
    }
}
