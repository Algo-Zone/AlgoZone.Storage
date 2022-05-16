FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["AlgoZone.Storage.Api/AlgoZone.Storage.Api.csproj", "AlgoZone.Storage.Api/"]
RUN dotnet restore "AlgoZone.Storage.Api/AlgoZone.Storage.Api.csproj"
COPY . .
WORKDIR "/src/AlgoZone.Storage.Api"
RUN dotnet build "AlgoZone.Storage.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "AlgoZone.Storage.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AlgoZone.Storage.Api.dll"]
