FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["microservices/QueueMailer/QueueMailer.Api/QueueMailer.Api.csproj", "microservices/QueueMailer/QueueMailer.Api/"]
RUN dotnet restore "microservices/QueueMailer/QueueMailer.Api/QueueMailer.Api.csproj"
COPY . .
WORKDIR "/src/microservices/QueueMailer/QueueMailer.Api"
RUN dotnet build "QueueMailer.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "QueueMailer.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "QueueMailer.Api.dll"]
