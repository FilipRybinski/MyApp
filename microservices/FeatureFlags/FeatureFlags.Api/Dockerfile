FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["microservices/FeatureFlags/FeatureFlags.Api/FeatureFlags.Api.csproj", "microservices/FeatureFlags/FeatureFlags.Api/"]
RUN dotnet restore "microservices/FeatureFlags/FeatureFlags.Api/FeatureFlags.Api.csproj"
COPY . .
WORKDIR "/src/microservices/FeatureFlags/FeatureFlags.Api"
RUN dotnet build "FeatureFlags.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "FeatureFlags.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "FeatureFlags.Api.dll"]
