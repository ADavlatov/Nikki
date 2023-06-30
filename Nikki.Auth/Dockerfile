FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Nikki.Auth/Nikki.Auth.csproj", "Nikki.Auth/"]
RUN dotnet restore "Nikki.Auth/Nikki.Auth.csproj"
COPY . .
WORKDIR "/src/Nikki.Auth"
RUN dotnet build "Nikki.Auth.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Nikki.Auth.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Nikki.Auth.dll"]
