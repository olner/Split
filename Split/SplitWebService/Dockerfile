#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

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