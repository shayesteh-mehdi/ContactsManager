FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["ContactsManager.EndPoints.WebAPI/ContactsManager.EndPoints.WebAPI.csproj", "ContactsManager.EndPoints.WebAPI/"]
RUN dotnet restore "ContactsManager.EndPoints.WebAPI/ContactsManager.EndPoints.WebAPI.csproj"
COPY . .
WORKDIR "/src/ContactsManager.EndPoints.WebAPI"
RUN dotnet build "ContactsManager.EndPoints.WebAPI.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "ContactsManager.EndPoints.WebAPI.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "ContactsManager.EndPoints.WebAPI.dll"]