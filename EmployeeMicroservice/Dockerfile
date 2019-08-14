FROM mcr.microsoft.com/dotnet/core/aspnet:2.2-stretch-slim AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY ["employeemicroservice.csproj", ""]
RUN dotnet restore "employeemicroservice.csproj"
COPY . .
WORKDIR "/src/"
RUN dotnet build "employeemicroservice.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "employeemicroservice.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "employeemicroservice.dll"]