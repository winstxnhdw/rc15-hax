#!/bin/bash

if [ "$1" = "--dev" ]
then
  dotnet build rc15-hax
fi

submodules/SharpMonoInjector4.8/build/debug/smi.exe inject -p RobocraftClient -a rc15-hax/bin/Debug/net48/rc15-hax.dll -n RC15_HAX -c Loader -m Load
