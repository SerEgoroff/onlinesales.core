#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0-alpine AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["src/SalesPro/SalesPro.csproj", "src/SalesPro/"]
RUN dotnet restore "src/SalesPro/SalesPro.csproj"
COPY . .
WORKDIR "/src"
RUN dotnet build "SalesPro.sln" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "./src/SalesPro/SalesPro.csproj" -c Release -o /app/publish /p:UseAppHost=false
RUN dotnet publish "./plugins/SalesPro.Plugin.EmailSync/SalesPro.Plugin.EmailSync.csproj" -c Release -o /app/publish/plugins/SalesPro.Plugin.EmailSync /p:UseAppHost=false
RUN dotnet publish "./plugins/SalesPro.Plugin.ReverseProxy/SalesPro.Plugin.ReverseProxy.csproj" -c Release -o /app/publish/plugins/SalesPro.Plugin.ReverseProxy /p:UseAppHost=false
RUN dotnet publish "./plugins/SalesPro.Plugin.SendGrid/SalesPro.Plugin.SendGrid.csproj" -c Release -o /app/publish/plugins/SalesPro.Plugin.SendGrid /p:UseAppHost=false
RUN dotnet publish "./plugins/SalesPro.Plugin.Sms/SalesPro.Plugin.Sms.csproj" -c Release -o /app/publish/plugins/SalesPro.Plugin.Sms /p:UseAppHost=false
RUN dotnet publish "./plugins/SalesPro.Plugin.Vsto/SalesPro.Plugin.Vsto.csproj" -c Release -o /app/publish/plugins/SalesPro.Plugin.Vsto /p:UseAppHost=false

FROM base AS final
RUN apk add --no-cache icu-libs
RUN apk add --no-cache icu-data-full
RUN apk add --no-cache curl bash
WORKDIR /app
RUN curl -o ./wait-for-it.sh https://raw.githubusercontent.com/vishnubob/wait-for-it/master/wait-for-it.sh && chmod +x ./wait-for-it.sh
ENV DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=false
COPY --from=publish /app/publish .
HEALTHCHECK --interval=1m --timeout=10s --retries=3 CMD wget --spider --tries=1 --no-verbose http://localhost:80/api/version || exit 1
