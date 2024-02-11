#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["MoneyTransferAPI.API/MoneyTransferAPI.API.csproj", "MoneyTransferAPI.API/"]
RUN dotnet restore "MoneyTransferAPI.API/MoneyTransferAPI.API.csproj"
COPY . .
WORKDIR "/src/MoneyTransferAPI.API"
RUN dotnet build "MoneyTransferAPI.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "MoneyTransferAPI.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MoneyTransferAPI.API.dll"]