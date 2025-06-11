FROM mcr.microsoft.com/dotnet/aspnet:9.0@sha256:1e12c265e1e1b3714c5805ab0cab63380eb687b0a04f3b3ef3392494a6122614 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:9.0@sha256:faa2daf2b72cbe787ee1882d9651fa4ef3e938ee56792b8324516f5a448f3abe AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["NarouApp.csproj", "./"]
RUN dotnet restore "NarouApp.csproj"
COPY . .
WORKDIR "/src/"
RUN dotnet build "NarouApp.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "NarouApp.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "NarouApp.dll"]
