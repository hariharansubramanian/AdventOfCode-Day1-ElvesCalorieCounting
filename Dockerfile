FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["ElvesCalorieCounter.csproj", "./"]
RUN dotnet restore "ElvesCalorieCounter.csproj"
COPY . .
WORKDIR "/src/"
RUN dotnet build "ElvesCalorieCounter.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ElvesCalorieCounter.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ElvesCalorieCounter.dll"]
