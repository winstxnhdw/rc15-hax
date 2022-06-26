@echo off

del /F /Q bin
del /F /Q rc15-hax/obj

dotnet build rc15-hax
start /WAIT /B ./submodules/SharpMonoInjectorCore/bin/SharpMonoInjectorCore.exe inject -p RobocraftClient -a bin/rc15-hax.dll -n RC15_HAX -c Loader -m Load

pause