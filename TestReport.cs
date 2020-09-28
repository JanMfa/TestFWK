namespace TestFW
{
    // Enum for TestReport 
    public enum TestResultEnum
    {
        Passed,
        Failed,
        Skipped
    };
    // This struct will contain the dictionary for test report
    public struct TestReport
    {
        #region TestReport Setter and Getter
        public string TestID { get; private set; }
        public string TestName { get; private set; }
        public string TestDescription { get; private set; }
        public string TestResult { get; private set; }
        #endregion

        #region TestReport Initialization
        public TestReport(string testID, string testName, string testDescription, string testResult):this()
        {
            this.TestID = testID;
            this.TestName = testName;
            this.TestDescription = testDescription;
            this.TestResult = testResult;
        }
        #endregion
    }
}
