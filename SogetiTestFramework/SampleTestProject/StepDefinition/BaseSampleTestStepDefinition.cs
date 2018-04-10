using SogetiTestFramework.StepDefinition;


namespace SampleTestProject.StepDefinition
{
    /// <summary>
    /// BaseSampleTestProjectStepDefinition class will be used to support common functionality for Sample Test
    /// applications.
    /// </summary>
    public class BaseSampleTestProjectStepDefinition : BaseStepDefinition
    {
        protected string App1BaseUrl = "http://www.google.com";
        protected string App2BaseUrl = "http://www.sogeti.com";
    }
}
