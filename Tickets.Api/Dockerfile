#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["Tickets.Api/Tickets.Api.csproj", "Tickets.Api/"]
COPY ["Tickets/Tickets.csproj", "Tickets/"]
COPY ["Core/Core.csproj", "Core/"]
RUN dotnet restore "Tickets.Api/Tickets.Api.csproj"
COPY . .
WORKDIR "/src/Tickets.Api"
RUN dotnet build "Tickets.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Tickets.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Tickets.Api.dll"]