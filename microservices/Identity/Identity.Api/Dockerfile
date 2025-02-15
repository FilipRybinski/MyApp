FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

COPY ["microservices/Identity", "microservices/Identity"]
COPY ["microservices/Shared", "microservices/Shared"]

COPY ["microservices-tests/MyApp.Identity.Tests.Unit", "microservices-tests/MyApp.Identity.Tests.Unit"]

RUN dotnet restore "microservices/Identity/Identity.Api/Identity.Api.csproj"
COPY . .

WORKDIR "/src/microservices-tests/MyApp.Identity.Tests.Unit"
RUN dotnet test -c $BUILD_CONFIGURATION 

WORKDIR "/src/microservices/Identity/Identity.Api"
RUN dotnet build "Identity.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "Identity.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Identity.Api.dll"]
