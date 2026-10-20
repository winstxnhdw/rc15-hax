@echo off

cd /d "%~dp0"
set app_name=rc15-hax

docker stop %app_name%
docker rm %app_name%

docker build -t %app_name% .
if errorlevel 1 goto error
docker create --name %app_name% %app_name%
if errorlevel 1 goto error

docker cp %app_name%:/app/launcher.exe .\launcher.exe
if errorlevel 1 goto error
.\launcher.exe
if errorlevel 1 goto error
exit /b 0

:error
pause
exit /b 1
