FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["DecoratorTask1.1/DecoratorTask1.1.csproj", "DecoratorTask1.1/"]
RUN dotnet restore "DecoratorTask1.1/DecoratorTask1.1.csproj"
COPY . .
WORKDIR "/src/DecoratorTask1.1"
RUN dotnet build "DecoratorTask1.1.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DecoratorTask1.1.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DecoratorTask1.1.dll"]
