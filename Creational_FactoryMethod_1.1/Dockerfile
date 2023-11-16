FROM mcr.microsoft.com/dotnet/runtime:8.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["Creational_FactoryMethod/Creational_FactoryMethod.csproj", "Creational_FactoryMethod/"]
RUN dotnet restore "Creational_FactoryMethod/Creational_FactoryMethod.csproj"
COPY . .
WORKDIR "/src/Creational_FactoryMethod"
RUN dotnet build "Creational_FactoryMethod.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Creational_FactoryMethod.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Creational_FactoryMethod.dll"]
