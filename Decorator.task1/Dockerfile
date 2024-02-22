FROM mcr.microsoft.com/dotnet/runtime:8.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["Decorator.task1/Decorator.task1.csproj", "Decorator.task1/"]
RUN dotnet restore "Decorator.task1/Decorator.task1.csproj"
COPY . .
WORKDIR "/src/Decorator.task1"
RUN dotnet build "Decorator.task1.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Decorator.task1.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Decorator.task1.dll"]
