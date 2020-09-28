using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestFW
{
    class Program
    { 
        static void Main(string[] args)
        {
            // Getting the Singleton object of TestSuit
            TestSuite obj = TestSuite.getInstance();
            // Calling the Initialization to initialize the test case list
            Initialize.Initialization();
            // Adding the test cases object into the Dictionary from the test case list
            TestSuite.AddTestCases();
            // Running the test cases 
            TestSuite.RunTestCases();
            // Publishing the test result on console
            TestSuite.PublishTestResult();
            // Delete the Singleton object
            TestSuite.delInstance();
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
    }
}

