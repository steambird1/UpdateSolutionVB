@echo off
rem This document can help generate ExtractList.txt.
set /p begin="Input directory: "
for /F "tokens=*" %%i in ('dir /s /b %begin%') do echo %%~nxi ^> ^\ >> ExtractList.txt
echo Completed!
pause