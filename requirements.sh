#!/bin/bash

if [ "$1" = "--dev" ]
then
  dotnet publish submodules/dnSpy -f net48
  mv submodules/dnSpy/dnSpy/dnSpy/bin/Debug/net48 ./dnSpy48
fi

dotnet build submodules/SharpMonoInjector4.8/SharpMonoInjector.Console
dotnet build rc15-hax
