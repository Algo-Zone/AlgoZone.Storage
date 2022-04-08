FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["AlgoZone.Storage/AlgoZone.Storage.csproj", "AlgoZone.Storage/"]
COPY ["AlgoZone.Storage.Businesslayer/AlgoZone.Storage.Businesslayer.csproj", "AlgoZone.Storage.Businesslayer/"]
COPY ["AlgoZone.Storage.Datalayer.RabbitMQ/AlgoZone.Storage.Datalayer.RabbitMQ.csproj", "AlgoZone.Storage.Datalayer.RabbitMQ/"]
COPY ["AlgoZone.Storage.Datalayer.TimescaleDB/AlgoZone.Storage.Datalayer.TimescaleDB.csproj", "AlgoZone.Storage.Datalayer.TimescaleDB/"]
RUN dotnet restore "AlgoZone.Storage/AlgoZone.Storage.csproj"
COPY . .
WORKDIR "/src/AlgoZone.Storage"
RUN dotnet build "AlgoZone.Storage.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "AlgoZone.Storage.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AlgoZone.Storage.dll"]
