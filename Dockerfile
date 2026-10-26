FROM mcr.microsoft.com/dotnet/sdk:10.0.403

WORKDIR /app
COPY . .

RUN dotnet publish launcher/launcher.csproj -c Release -restoreProperty:RestoreLockedMode=true
