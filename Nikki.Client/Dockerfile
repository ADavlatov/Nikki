FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Nikki.Client/Nikki.Client.csproj", "Nikki.Client/"]
RUN dotnet restore "Nikki.Client/Nikki.Client.csproj"
COPY . .
WORKDIR "/src/Nikki.Client"
RUN dotnet build "Nikki.Client.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Nikki.Client.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Nikki.Client.dll"]
