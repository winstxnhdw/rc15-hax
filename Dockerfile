FROM mcr.microsoft.com/dotnet/sdk:11.0.100

WORKDIR /app
COPY . .

RUN dotnet publish launcher/launcher.csproj -c Release -restoreProperty:RestoreLockedMode=true
