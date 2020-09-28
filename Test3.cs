using System;

namespace TestFW
{
	public class Test3 : TestCaseBase
    {

        // Initializing the test case by assigning test cases values from base class
        public Test3(string id, string name, string desc) : base(id, name, desc)
        {
        }

        #region Test Case Main
        // Function to initialize the current test case
        public override TestResultEnum precheck()
        {
            Console.WriteLine("Running Precheck for Test 3");
            return TestResultEnum.Skipped;
        }

        //Do whatever is need to run the test case.
        public override TestResultEnum run()
        {
            Console.WriteLine("Running Run for Test 3");
            return TestResultEnum.Passed;
        }

        // Checking required to do after the test case finished execution
        public override TestResultEnum postcheck()
        {
            Console.WriteLine("Running Postcheck for Test 3");
            return TestResultEnum.Passed;
        }
        #endregion
    }
}