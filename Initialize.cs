using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;


namespace TestFW
{
    class Initialize
    {
        // Please change fileDir to the path where you put your config.txt
        private static string fileDir = @"<----Fill this in--->";

        #region Initialize Class Variables
        // declared config file name 
        private static string configFile = "config.txt";
        private static string fullFilePath = null;
        // String variable to store testcases list from config.txt
        private static string testCases = null;
        #endregion

        #region Initialize Setter and Getter
        private static void SetTestCases() { testCases = GetConfigAttributes("testCases"); }
        public static string GetTestCases() { return testCases; }
        #endregion

        #region Initialize Main
        // This function is used to get list of test cases need to be run in config.txt
        public static void Initialization()
        {
            // Get the path of config.txt
            GetConfigFilePath();
            // Set the test case attribute to run
            SetTestCases();
        }

        #endregion

        #region Helper Function
        // Helper function to get the full path of config.txt
        private static void GetConfigFilePath()
        {
            fullFilePath = Path.Combine(fileDir, configFile);
            if (!File.Exists(fullFilePath))
            {
                // Exit when the file does not exist
                throw new FileNotFoundException("{0}is not found", fullFilePath);
            }
        }

        // Helper function to get the attribute in config.txt 
        // Depending on the parameter and their key
        // For the current program, only "testcases" is defined
        // This function is expected to be reused with different attributes
        private static string GetConfigAttributes(string attribute)
        {
            string key = null;
            string value = null;
            // Add another if condition here to expand the attribute
            // key is whatever defined in config.txt
            if (attribute == "testCases")
            {
                key = "TC_Names=";
            }
            else
            {
                Console.WriteLine("Attribute chosen does not exist");
            }
            // Reading config.txt file
            var output = ReadFilePerLine(fullFilePath);
            // Checking if there is any output
            if (output.Any())
            {
                // If there is, look for the line that contains the key value
                foreach (var line in output)
                {
                    if ((line.StartsWith(key)) && (line.Contains(key)))
                    {
                        value = line.Replace(key, "");
                    }
                }
            }
            return value;
        }

        // Helper function to read each line in the defined FileName
        public static List<string> ReadFilePerLine(String FileName)
        {
            String line = null;
            // Create an empty list of string
            List<String> lines = new List<String>();
            // Pass the file path and file name to the StreamReader constructor
            StreamReader sr = new StreamReader(FileName);
            // Continue to read until you reach end of file
            while (!sr.EndOfStream)
            {
                // Read the next line
                line = sr.ReadLine();
                // Add the line to the list
                lines.Add(line);
            }
            //close the file
            sr.Close();
            return lines;
        }
        #endregion
    }
}
