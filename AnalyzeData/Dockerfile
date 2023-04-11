FROM mcr.microsoft.com/dotnet/runtime:7.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["AnalyzeData/AnalyzeData.csproj", "AnalyzeData/"]
RUN dotnet restore "AnalyzeData/AnalyzeData.csproj"
COPY . .
WORKDIR "/src/AnalyzeData"
RUN dotnet build "AnalyzeData.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "AnalyzeData.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AnalyzeData.dll"]
