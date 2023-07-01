FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 5000

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["SplitWebService/SplitWebService.csproj", "SplitWebService/"]
COPY ["Split.Engine/Split.Engine.csproj", "Split.Engine/"]
COPY ["Split.DbContext/Split.DbContexts.csproj", "Split.DbContext/"]
RUN dotnet restore "SplitWebService/SplitWebService.csproj"
COPY . .
WORKDIR "/src/SplitWebService"
RUN dotnet build "SplitWebService.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SplitWebService.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SplitWebService.dll"]
