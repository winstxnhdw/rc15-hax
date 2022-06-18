#!/bin/bash


if [ "$1" = "--dev" ]
then
  rm -r rc15-hax/bin
  rm -r rc15-hax/obj
  dotnet build rc15-hax
fi

submodules/SharpMonoInjector4.8/SharpMonoInjector.Console/bin/debug/SharpMonoInjector4.8.exe inject -p RobocraftClient -a rc15-hax/bin/Debug/net35/rc15-hax.dll -n RC15_HAX -c Loader -m Load
