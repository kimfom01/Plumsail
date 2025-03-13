FROM mcr.microsoft.com/dotnet/aspnet:9.0.3-alpine3.21 AS base
USER $APP_UID
WORKDIR /app

EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:9.0.201-alpine3.21 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Plumsail/Plumsail.csproj", "Plumsail/"]
RUN dotnet restore "Plumsail/Plumsail.csproj"
COPY . .
WORKDIR "/src/Plumsail"
RUN dotnet build "Plumsail.csproj" -c $BUILD_CONFIGURATION --no-restore -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "Plumsail.csproj" -c $BUILD_CONFIGURATION --no-restore -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Plumsail.dll"]
