FROM mcr.microsoft.com/dotnet/sdk:6.0

WORKDIR /

COPY . ./
RUN dotnet build submodules/SharpMonoInjectorCore/SharpMonoInjector.Console
RUN dotnet build rc15-hax
