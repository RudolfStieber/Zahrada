FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Zkopíruj celý projekt
COPY . .

# (případně přidej restore pro solution, pokud máš více .csproj)
RUN dotnet restore "Zahradnictvi.csproj"

# Build & publish
RUN dotnet publish "Zahradnictvi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=build /app/publish .

ENTRYPOINT ["dotnet", "Zahradnictvi.dll"]
