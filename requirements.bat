@echo off

set project_name=rc15-hax
dotnet restore %project_name%
dotnet build %project_name%
dotnet build submodules/SharpMonoInjectorCore/SharpMonoInjector

:dev
set /p choice=Would you like to build dnSpy? [y/N]: 
if /i '%choice%'=='Y' goto dnSpy
echo Skipping dnSpy build..
pause
exit

:dnSpy
dotnet publish submodules/dnSpy -f net5.0-windows
robocopy submodules/dnSpy/dnSpy/dnSpy/bin/Debug/net5.0-windows ./dnSpy5.0 /e /move /njh /njs /ndl /nc /ns
pause