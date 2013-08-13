@echo off
set SERVICE_HOME=%~dp0
set SERVICE_EXE=FRiskService.exe
REM the following directory is for .NET 1.1, your mileage may vary
set INSTALL_UTIL_HOME=C:\Windows\Microsoft.NET\Framework64\v4.0.30319
REM Account credentials if the service uses a user account
REM set USER_NAME=<user account>
REM set PASSWORD=<user password>

set PATH=%PATH%;%INSTALL_UTIL_HOME%

cd /D %SERVICE_HOME%

echo Installing Service...
installutil %SERVICE_EXE%
REM /name=FRiskService /account=<account type> /user=%USER_NAME% /password=% PASSWORD%

net start FRiskService

echo Done.