#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["src/OFG.CqrsSample.API/OFG.CqrsSample.API.csproj", "src/OFG.CqrsSample.API/"]
COPY ["src/OFG.CqrsSample.Application/OFG.CqrsSample.Application.csproj", "src/OFG.CqrsSample.Application/"]
COPY ["src/OFG.CqrsSample.Domain/OFG.CqrsSample.Domain.csproj", "src/OFG.CqrsSample.Domain/"]
COPY ["src/OFG.CqrsSample.Infrastructure/OFG.CqrsSample.Infrastructure.csproj", "src/OFG.CqrsSample.Infrastructure/"]
RUN dotnet restore "src/OFG.CqrsSample.API/OFG.CqrsSample.API.csproj"
COPY . .
WORKDIR "/src/src/OFG.CqrsSample.API"
RUN dotnet build "OFG.CqrsSample.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "OFG.CqrsSample.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "OFG.CqrsSample.API.dll"]
