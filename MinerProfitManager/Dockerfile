#FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
FROM mcr.microsoft.com/dotnet/sdk:3.1 AS base
WORKDIR /app
EXPOSE 53697
EXPOSE 44336

# FROM microsoft/dotnet:2.1-sdk AS build
FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY MinerProfitManager/MinerProfitManager.csproj MinerProfitManager/
RUN dotnet restore MinerProfitManager/MinerProfitManager.csproj
COPY . .
WORKDIR /src/MinerProfitManager
RUN dotnet build MinerProfitManager.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish MinerProfitManager.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .

# Optional: Set this here if not setting it from docker-compose.yml
# ENV ASPNETCORE_ENVIRONMENT Development

ENTRYPOINT ["dotnet", "MinerProfitManager.dll"]