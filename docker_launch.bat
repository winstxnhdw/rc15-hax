@echo off

set app_name=rc15-hax

docker stop %app_name%
docker rm %app_name%

docker build -t %app_name% .
docker run --name %app_name% %app_name%

rmdir /s /q bin
docker cp rc15-hax:/submodules/SharpMonoInjectorCore/bin/ .
docker cp rc15-hax:/bin/rc15-hax.dll ./bin/
start /WAIT /B ./bin/SharpMonoInjectorCore.exe inject -p RobocraftClient -a bin/rc15-hax.dll -n RC15_HAX -c Loader -m Load

pause