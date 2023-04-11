FROM mcr.microsoft.com/dotnet/runtime:7.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["ExportData/ExportData.csproj", "ExportData/"]
RUN dotnet restore "ExportData/ExportData.csproj"
COPY . .
WORKDIR "/src/ExportData"
RUN dotnet build "ExportData.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ExportData.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ExportData.dll"]
