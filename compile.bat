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