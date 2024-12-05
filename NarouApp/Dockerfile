FROM mcr.microsoft.com/dotnet/aspnet:9.0@sha256:d8f01f752bf9bd3ff630319181a2ccfbeecea4080a1912095a34002f61bfa345 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:9.0@sha256:fe8ceeca5ee197deba95419e3b85c32744970b730ae11645e13f1cb74a848d98 AS build
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
