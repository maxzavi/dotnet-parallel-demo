FROM mcr.microsoft.com/dotnet/runtime:6.0 AS base
WORKDIR /app

# Creates a non-root user with an explicit UID and adds permission to access the /app folder
# For more info, please refer to https://aka.ms/vscode-docker-dotnet-configure-containers
RUN adduser -u 5678 --disabled-password --gecos "" appuser && chown -R appuser /app
USER appuser

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["parallel-proj/parallel-proj.csproj", "parallel-proj/"]
RUN dotnet restore "parallel-proj/parallel-proj.csproj"
COPY . .
WORKDIR "/src/parallel-proj"
RUN dotnet build "parallel-proj.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "parallel-proj.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "parallel-proj.dll"]
