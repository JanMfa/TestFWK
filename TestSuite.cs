using System;
using System.Collections.Generic;
using System.Linq;

namespace TestFW
{
    // Make TestSuite a singleton class since you dont want more than one object of TestSuite class
    public class TestSuite
    {
        #region TestSuite Singleton 
        // static variable single_instance of type TestSuite 
        private static TestSuite singleTestSuiteInstance = null;

        // static method to create instance of Singleton class 
        public static TestSuite getInstance()
        {
            if (singleTestSuiteInstance == null)
                singleTestSuiteInstance = new TestSuite();

            return singleTestSuiteInstance;
        }
        
        // static method to delete instance of Singleton class 
        public static void delInstance()
        {
            singleTestSuiteInstance = null;
        }
        #endregion

        #region TestSuite Main
        private static List<string> testCaseList = new List<string>();
        protected static Dictionary<string, TestCaseBase> testInit = new Dictionary<string, TestCaseBase>();
        protected static Dictionary<string, TestReport> testRes = new Dictionary<string, TestReport>();

        // Add the test cases into the testInit Dictionary
        public static void AddTestCases()
        {
            // Get the test case list
            TestCasesList();
            // Populate the test cases list into testInit Dictionary 
            foreach (string tc in testCaseList)
            {
                switch (tc)
                {
                    case "Test1":
                        testInit.Add(tc , new Test1("1_id", "Test_1_name", "Test_1_des"));
                        break;
                    case "Test2":
                        testInit.Add(tc, new Test2("2_id", "Test_2_name", "Test_2_des"));
                        break;
                    case "Test3":
                        testInit.Add(tc, new Test3("3_id", "Test_3_name", "Test_3_des"));
                        break;
                    default: //Put the unknown testCases in the Test Report
                        testRes.Add(tc, new TestReport("", "Test Case name is not known", "No Test is running for this Test case ID", TestResultEnum.Skipped.ToString()));
                        break; 
                }
            }
        }

        // Function to run the test suite 
        public static void RunTestCases()
        {
            Console.WriteLine("Running testcases:");

            foreach (KeyValuePair<string, TestCaseBase> tc in testInit)
            {
                Console.WriteLine("**********************************************************************");
                // Getting each test cases values
                TestCaseBase values = testInit[tc.Key];
                string ID = values.getId();
                string tcName = values.getName();
                string tcDesc = values.getDesc();
                Console.WriteLine("Running {0} : {1}, {2}", ID, tcName, tcDesc);
                // Run the test case
                TestResultEnum retEnum = values.precheck();
                if (retEnum == 0)
                {
                    retEnum = values.run();
                    if (retEnum == 0)
                    {
                        retEnum = values.postcheck();
                    }
                }
                //Changing the returned int value to enum values
                //put the result for each test case in the dictionary
                testRes.Add(tc.Key, new TestReport(ID, tcName, tcDesc, retEnum.ToString()));
                Console.WriteLine("***********************************************************************");
                Console.WriteLine("");
            }
        }

        // Function to publish the test suite result
        public static void PublishTestResult() {
            Console.WriteLine("Publish testReport:");
            foreach (KeyValuePair<string, TestReport> tc in testRes)
            {
                if (tc.Key == "")
                {
                    Console.WriteLine("***********************************************************************************************************");
                    Console.WriteLine("{0}, {1}, {2}", tc.Value.TestName, tc.Value.TestDescription, tc.Value.TestResult);
                }
                else 
                {
                    Console.WriteLine("***********************************************************************************************************");
                    Console.WriteLine("{0}, {1}, {2}, {3}, {4}", tc.Key, tc.Value.TestID, tc.Value.TestName, tc.Value.TestDescription, tc.Value.TestResult);
                }
            }
            Console.WriteLine("***********************************************************************************************************");
        }
        #endregion

        #region Helper Function
        //Coverting test case string to list of test cases
        private static void TestCasesList()
        {
            // Get the test case string from Initialize class
            string testCasesString = Initialize.GetTestCases();
            // If test case string is not empty
            if (testCasesString != "")
            {
                // Create a list of test cases
                testCaseList = testCasesString.Split(',').ToList();
            }
            // If test case string is empty
            // Throw an exception
            else
            {
                throw new ArgumentNullException(testCasesString, "Unable to get test case string, is it declared in \"TC_Names=\" attribute in config.txt");
            }
        }
        #endregion
    }
}
