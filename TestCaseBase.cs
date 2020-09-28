using System;

namespace TestFW
{
    // Abstract class defined to defined Abstraction of TestCaseBase
    // So this class cannot be instantiated only can be subclasses
    // Abstract method is defined to make sure all the testcases are uniformly redefined
    public abstract class TestCaseBase
    {
        // Initializing the test case parameters
        protected TestCaseBase(string id, string name, string desc)
        {
            tc_id = id;
            tc_name = name;
            tc_desc = desc;
        }

        #region Test Case Base Initialization
        // Variables for test case base
        protected string tc_id;
        protected string tc_name;
        protected string tc_desc;

        // Getter functions for test case id, test case name, test case description
        public string getId()
        {
            return tc_id;
        }

        public string getName()
        {
            return tc_name;
        }

        public string getDesc()
        {
            return tc_desc;
        }
        #endregion

        #region Test Case Base Method Overriding 
        // Checking required specifically for each test case before running it.
        // Initialize the environment before running the test case.
        public abstract TestResultEnum precheck();

        //Do whatever is need to execute the test case.
        public abstract TestResultEnum run();

        // Checking required to do after the test case finished execution.
        // Cleaning by the end of the test case.
        public abstract TestResultEnum postcheck();
        #endregion
    };
}
