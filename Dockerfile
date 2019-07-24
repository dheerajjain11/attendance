FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:2.2-stretch AS build
WORKDIR /src
COPY . .
WORKDIR "/src/Attendance"
RUN dotnet build "Attendance.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "Attendance.csproj" -c Release -o /app

FROM base AS final
COPY --from=publish /app /app
COPY --from=publish /src /app
COPY entrypoint.sh /app
WORKDIR /app
RUN chmod +x ./entrypoint.sh
CMD /bin/bash ./entrypoint.sh
ENTRYPOINT ["dotnet", "Attendance.dll"]