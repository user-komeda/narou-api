FROM mcr.microsoft.com/dotnet/aspnet:10.0@sha256:20459dc8f0cccd42304c73239edaef18a4667664c0a4d44e25599eab6d9611ca AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:10.0@sha256:8e8a5bbd8dd6a6c594d6c08775fd5fc4a40b67d6bbd27882e6e8b9d5684eac97 AS build
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
