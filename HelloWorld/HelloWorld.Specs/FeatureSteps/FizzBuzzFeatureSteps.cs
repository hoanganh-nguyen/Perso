using System;
using NUnit.Framework;
using TechTalk.SpecFlow;

namespace HelloWorld.Specs.FeatureSteps
{
    [Binding]
    public class FizzBuzzFeatureSteps
    {
        private FizzBuzz _fizzBuzz = new FizzBuzz();

        [Given(@"I have entered (.*)")]
        public void GivenIHaveEntered(int number)
        {
            ScenarioContext.Current.Add("Input",number);
        }
        
        [When(@"I call FizzBuzzTranslator")]
        public void WhenICallFizzBuzzTranslator()
        {
            int number = Convert.ToInt32(ScenarioContext.Current["Input"]);
            string output = _fizzBuzz.GetFizzBuzz(number);
            ScenarioContext.Current.Add("Output",output);
        }
        
        [Then(@"the result should be (.*)")]
        public void ThenTheResultShouldBe(string expected)
        {
            string output = ScenarioContext.Current["Output"].ToString();
            Assert.AreEqual(expected,output);
        }
    }
}
