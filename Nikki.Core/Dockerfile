FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Nikki.Core/Nikki.Core.csproj", "Nikki.Core/"]
RUN dotnet restore "Nikki.Core/Nikki.Core.csproj"
COPY . .
WORKDIR "/src/Nikki.Core"
RUN dotnet build "Nikki.Core.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Nikki.Core.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Nikki.Core.dll"]
