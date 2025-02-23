FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["microservices/QueueMailer/QueueMailer.Worker/QueueMailer.Worker.csproj", "microservices/QueueMailer/QueueMailer.Worker/"]
RUN dotnet restore "microservices/QueueMailer/QueueMailer.Worker/QueueMailer.Worker.csproj"
COPY . .
WORKDIR "/src/microservices/QueueMailer/QueueMailer.Worker"
RUN dotnet build "QueueMailer.Worker.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "QueueMailer.Worker.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "QueueMailer.Worker.dll"]
