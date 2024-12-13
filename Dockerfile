FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["WeatherApp.csproj", "./"]
RUN dotnet restore "./WeatherApp.csproj"
COPY . .
WORKDIR "/src/"
RUN dotnet publish "WeatherApp.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .
ENTRYPOINT ["dotnet", "WeatherApp.dll"]
