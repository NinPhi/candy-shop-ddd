FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["CandyStore.WebApi/CandyStore.WebApi.csproj", "CandyStore.WebApi/"]
RUN dotnet restore "CandyStore.Web/CandyStore.WebApi.csproj"
COPY . .
WORKDIR "/src/CandyStore.WebApi"
RUN dotnet build "CandyStore.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CandyStore.WebApi.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CandyStore.WebApi.dll"]