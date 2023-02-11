#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443
VOLUME /media
VOLUME /config

RUN apt-get update && apt-get install -y ffmpeg

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Convertarr.Web/Convertarr.Web.csproj", "Convertarr.Web/"]
COPY ["Convertarr.Core/Convertarr.Core.csproj", "Convertarr.Core/"]
COPY ["Convertarr.Data/Convertarr.Data.csproj", "Convertarr.Data/"]
RUN dotnet restore "Convertarr.Web/Convertarr.Web.csproj"
COPY . .
WORKDIR "/src/Convertarr.Web"
RUN dotnet build "Convertarr.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Convertarr.Web.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Convertarr.Web.dll"]