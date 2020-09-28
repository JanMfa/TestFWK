using System;

namespace TestFW
{
	public class Test1 : TestCaseBase
    {
        // Initializing the test case by assigning test cases values from base class
        public Test1(string id, string name, string desc) : base(id, name, desc)
        {
        }

        #region Test Case Main
        // Function to initialize the current test case
        public override TestResultEnum precheck()
        {
            Console.WriteLine("Prechecking Test 1");
            return TestResultEnum.Passed;
        }

        //Do whatever is need to run the test case.
        public override TestResultEnum run()
        {
            Console.WriteLine("Executing Test 1");
            doSomething();
            return TestResultEnum.Passed; ;
        }

        // Checking required to do after the test case finished execution
        public override TestResultEnum postcheck()
        {
            Console.WriteLine("Postchecking Test 1");
            return TestResultEnum.Passed; ;
        }
        #endregion

        #region Test Case Helper
        void doSomething()
        {
            Console.WriteLine("DoSomething Test 1");
        }
        #endregion
    }

}