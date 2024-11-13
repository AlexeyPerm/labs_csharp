FROM mcr.microsoft.com/dotnet/runtime:8.0 AS base
USER $APP_UID
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["Lab12_4_list/Lab12_4_list.csproj", "Lab12_4_list/"]
RUN dotnet restore "Lab12_4_list/Lab12_4_list.csproj"
COPY . .
WORKDIR "/src/Lab12_4_list"
RUN dotnet build "Lab12_4_list.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "Lab12_4_list.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Lab12_4_list.dll"]
