FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["microservices/FeeTracker/FeeTracker.Api/FeeTracker.Api.csproj", "microservices/FeeTracker/FeeTracker.Api/"]
RUN dotnet restore "microservices/FeeTracker/FeeTracker.Api/FeeTracker.Api.csproj"
COPY . .
WORKDIR "/src/microservices/FeeTracker/FeeTracker.Api"
RUN dotnet build "FeeTracker.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "FeeTracker.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "FeeTracker.Api.dll"]
