FROM mcr.microsoft.com/dotnet/aspnet:7.0
WORKDIR /app
COPY  /published ./
ENTRYPOINT ["dotnet", "SpoiledRabbot.dll"]