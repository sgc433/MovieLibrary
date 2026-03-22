FROM mcr.microsoft.com/dotnet/sdk:10.0.101 AS build
WORKDIR /app
COPY . .
EXPOSE 8080
EXPOSE 8081


FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "MovieLibrary.dll"]
