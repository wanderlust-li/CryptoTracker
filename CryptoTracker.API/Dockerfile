FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["CryptoTracker.API/CryptoTracker.API.csproj", "CryptoTracker.API/"]
COPY ["CryptoTracker.Application/CryptoTracker.Application.csproj", "CryptoTracker.Application/"]
COPY ["CryptoTracker.Domain/CryptoTracker.Domain.csproj", "CryptoTracker.Domain/"]
RUN dotnet restore "CryptoTracker.API/CryptoTracker.API.csproj"
COPY . .
WORKDIR "/src/CryptoTracker.API"
RUN dotnet build "CryptoTracker.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "CryptoTracker.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CryptoTracker.API.dll"]
