@echo off

rmdir /s /q bin
rmdir /s /q "rc15-hax/obj"
cls

dotnet build rc15-hax
start /wait /b ./submodules/SharpMonoInjectorCore/bin/SharpMonoInjector.exe inject -p RobocraftClient -a bin/rc15-hax.dll -n Hax -c Loader -m Load

pause