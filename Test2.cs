using System;

namespace TestFW
{
	public class Test2 : TestCaseBase
    {

        // Initializing the test case by assigning test cases values from base class
        public Test2(string id, string name, string desc) : base(id, name, desc)
        {
        }

        #region Test Case Main
        // Function to initialize the current test case
        public override TestResultEnum precheck()
        {
            Console.WriteLine("Prechecking Test 2");
            return TestResultEnum.Passed; 
        }

        //Do whatever is need to run the test case.
        public override TestResultEnum run()
        {
            Console.WriteLine("Executing Test 2");
            return TestResultEnum.Failed;
        }

        // Checking required to do after the test case finished execution
        public override TestResultEnum postcheck()
        {
            Console.WriteLine("Running Postcheck for Test 2");
            return TestResultEnum.Passed; 
        }
        #endregion
    }
}