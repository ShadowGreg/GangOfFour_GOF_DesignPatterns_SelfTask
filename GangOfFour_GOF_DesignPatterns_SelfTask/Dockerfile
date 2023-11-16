FROM mcr.microsoft.com/dotnet/runtime:8.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["GangOfFour_GOF_DesignPatterns_SelfTask/GangOfFour_GOF_DesignPatterns_SelfTask.csproj", "GangOfFour_GOF_DesignPatterns_SelfTask/"]
RUN dotnet restore "GangOfFour_GOF_DesignPatterns_SelfTask/GangOfFour_GOF_DesignPatterns_SelfTask.csproj"
COPY . .
WORKDIR "/src/GangOfFour_GOF_DesignPatterns_SelfTask"
RUN dotnet build "GangOfFour_GOF_DesignPatterns_SelfTask.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "GangOfFour_GOF_DesignPatterns_SelfTask.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "GangOfFour_GOF_DesignPatterns_SelfTask.dll"]
