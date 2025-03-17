FROM mcr.microsoft.com/dotnet/sdk:6.0

COPY . .

RUN dotnet build rc15-hax
RUN dotnet publish submodules/SharpMonoInjectorCore/SharpMonoInjector
