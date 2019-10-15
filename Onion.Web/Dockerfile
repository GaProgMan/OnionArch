FROM microsoft/aspnetcore:2.0-stretch AS base
WORKDIR /app
EXPOSE 80

FROM microsoft/aspnetcore-build:2.0-stretch AS build
WORKDIR /src
COPY ["Onion.Web/Onion.Web.csproj", "Onion.Web/"]
COPY ["Onion.Data/Onion.Data.csproj", "Onion.Data/"]
COPY ["Onion.Service/Onion.Service.csproj", "Onion.Service/"]
COPY ["Onion.Repo/Onion.Repo.csproj", "Onion.Repo/"]
RUN dotnet restore "Onion.Web/Onion.Web.csproj"
COPY . .
WORKDIR "/src/Onion.Web"
RUN dotnet build "Onion.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Onion.Web.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Onion.Web.dll"]