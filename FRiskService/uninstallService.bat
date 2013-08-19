@echo off
set SERVICE_HOME=%~dp0
set SERVICE_EXE=FRiskService.exe
set SERVICE_NAME=FRiskService
REM the following directory is for .NET 1.1, your mileage may vary
set INSTALL_UTIL_HOME=C:\Windows\Microsoft.NET\Framework64\v4.0.30319

set PATH=%PATH%;%INSTALL_UTIL_HOME%

cd /D %SERVICE_HOME%

echo Uninstalling Service...
installutil /u /name=%SERVICE_NAME% %SERVICE_EXE%

echo Done.