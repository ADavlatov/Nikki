FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Nikki.Gateway/Nikki.Gateway.csproj", "Nikki.Gateway/"]
RUN dotnet restore "Nikki.Gateway/Nikki.Gateway.csproj"
COPY . .
WORKDIR "/src/Nikki.Gateway"
RUN dotnet build "Nikki.Gateway.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Nikki.Gateway.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Nikki.Gateway.dll"]
