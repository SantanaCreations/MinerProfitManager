FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 53697
EXPOSE 44336

FROM microsoft/dotnet:2.1-sdk AS build
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
ENTRYPOINT ["dotnet", "MinerProfitManager.dll"]