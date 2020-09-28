# README

TestFWK is the test framework that is made so user can maintain their tests easily.
Sample output is attached under TestFW.exe

- [What is TestFWK ?](#what-is-testfwk)
- [Before running the TestFWK?](#what-is-needed)
- [HOW TO add a new test case into the TestFWK](#how-to-add-testcase)
- [HOW TO compile](#how-to-compile)

## What is TestFWK?

TestFWK is a scalable test automation framework built in console app using C#.
At the end of the test execution, the user will be able to generate the
summary of test result. Status and the execution result are printed and
shown in console.

## Before running the TestFWK?
1. config.txt is a text file that is used to store the attribute of the test suite. 
	This file is required to be present to be able to run the suite
1. Currently, the only attribute defined is "TC_Names". This can be expanded, but need to be declared under Initialize class in GetConfigAttributes function.
1. Each attribute is define in each line
1. If you don't want to include the attribute in config.txt you can add "//" to indicate the line is not included 
	For eg. //TC_Names=Test1,Test2,Test3
1. Path of config.txt file need to be declared under "fileDir" variable in Initialize class

## HOW TO add a new test case into the TestSuite:
_Let's say, the user want to add a test case called "Test4" into TestFWK_
1. Add Test4 under "TC_Names" in config.txt
1. In TestSuite.cs under AddTestCases function, add another switch condition
		case "Test4":
            testInit.Add(tc, new Test4("4_id", "Test_4_name", "Test_4_des"));
            break;
1. Create Test4.cs
1. Declare Test4 class as below to inherit everything from TestCaseBase class
		public class Test4 : TestCaseBase
1. Define constructor with test id, name and descriptor parameter:
		  public Test4(string id, string name, string desc) : base(id, name, desc)
	, and methods that need to be overridden:
	 	public override TestResultEnum precheck();
        public override TestResultEnum run();
        public override TestResultEnum postcheck();

## HOW TO compile:

### Use Visual Studio
1. Download Visual Studio. (https://visualstudio.microsoft.com/downloads/)
1. Download all the files (config.txt, Initialize.cs, Program.cs, TestReport.cs, TestSuite.cs, TestCaseBase.cs, and some of test case files)
1. Put all the downloaded files in the same path/folder
1. Create a new C# Project (https://docs.microsoft.com/en-us/visualstudio/ide/quickstart-csharp-console?view=vs-2019)
1. Build your solution (Build > Build Solution), and make sure there is no error generated
1. Run the solution (Debug > Start Debugging)
1. Console of the test report will appear

### Without Visual Studio
1. Download .NET framework https://dotnet.microsoft.com/download/dotnet-framework
1. Create a .bat file in desktop
1.	The .bat file consist of:
	@ECHO OFF
	SET CUR_DIR=%~dp0
	ECHO %CUR_DIR%
	SET PGM=<path to your .cs files>
	cd %PGM%
	ECHO Creating .exe for cs
	REM Taking .net framework location file
	For /F "Skip=2 Tokens=2*" %%A In (
		'Reg Query "HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\.NETFramework" /V InstallRoot'
	) Do Set "path=%%B" 
	Echo .net framework installation file  is %path%
	REM \HKEY_LOCAL_MACHINE\SOFTWARE\Microsoft\.NETFramework\v4.0.30319
	REM Now, just hardcode the version .net v4.0.30319
	SET path=%path%v4.0.30319\
	ECHO .net framework v4.0.30319 file  is %path%
	ECHO %CUR_DIR%
	%path%\csc.exe /out:"%CUR_DIR%\out.exe" <list of .cs file>
	EXIT
1.	Run the .bat file, and this will give out.exe file
1.	Run the .exe file
