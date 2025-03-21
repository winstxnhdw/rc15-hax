FROM mcr.microsoft.com/dotnet/sdk:9.0

COPY . .

RUN dotnet build rc15-hax
RUN dotnet publish submodules/SharpMonoInjectorCore
