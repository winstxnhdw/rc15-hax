@echo off

dotnet build rc15-hax
start /wait /b ./submodules/SharpMonoInjectorCore/dist/SharpMonoInjector.exe inject -p RobocraftClient -a bin/rc15-hax.dll -n Hax -c Loader -m Load

pause
