@echo off
setlocal enabledelayedexpansion
rem This document can help generate ExtractList.txt.
set /p begin="Input directory: "
mkdir output
for /F "tokens=*" %%i in ('dir /s /b %begin%') do (
	set myname=%random%_%%~nxi
	echo !myname! ^> ^\ >> ExtractList.txt
	copy %%~i output\!myname!
)
echo Completed! Please compress files in %~dp0\output.
pause