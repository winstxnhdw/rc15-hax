#!/bin/bash

if [ "$1" = "--dev" ]
then
  rm -r bin
  rm -r rc15-hax/obj
  dotnet build rc15-hax
fi

submodules/SharpMonoInjector4.8/bin/SharpMonoInjectorCore.exe inject -p RobocraftClient -a rc15-hax/bin/rc15-hax.dll -n RC15_HAX -c Loader -m Load
