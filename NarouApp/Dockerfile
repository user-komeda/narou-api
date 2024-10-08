FROM mcr.microsoft.com/dotnet/aspnet:9.0@sha256:a54b9e95a8e30028bd0a862dfc1a67ee36e71f7900b25aed37c9119c55682c7f AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:9.0@sha256:ecdbce3ac370d065b4e34bdb367ed8ac10e24d2af630716f9828bf24b360691c AS build
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
