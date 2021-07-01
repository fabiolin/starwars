#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.


FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443
EXPOSE 1433

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["starwars/starwars.csproj", "starwars/"]
RUN dotnet restore "starwars/starwars.csproj"
COPY . .
WORKDIR "/src/starwars"
RUN dotnet build "starwars.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "starwars.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "starwars.dll"]

##See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.
#
#FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
#WORKDIR /app
#EXPOSE 80
#EXPOSE 443
#EXPOSE 1433
##ENV SA_PASSWORD Cda(cda9
##ENV ACCEPT_EULA Y
##ENV MSSQL_PID Express
##
#FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
#WORKDIR /src
#COPY ["starwars.csproj", "."]
#RUN dotnet restore "./starwars.csproj"
#COPY . .
#WORKDIR "/src/."
#RUN dotnet build "starwars.csproj" -c Release -o /app/build
##
#FROM build AS publish
#RUN dotnet publish "starwars.csproj" -c Release -o /app/publish
##
##FROM base AS mssql
##CMD apt get update && apt install -y wget
##CMD wget -qO- https://packages.microsoft.com/keys/microsoft.asc | sudo apt-key add -
##CMD add-apt-repository "$(wget -qO- https://packages.microsoft.com/config/ubuntu/18.04/mssql-server-2019.list)"
##CMD apt-get update
##CMD apt-get install -y mssql-server
##
### expose port used by api
###EXPOSE 5003
###ENV ASPNETCORE_URLS=http://+:5003
##
#FROM base AS final
#WORKDIR /app
#COPY --from=publish /app/publish .
#ENTRYPOINT ["dotnet", "starwars.dll"]