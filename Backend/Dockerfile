FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /source
COPY . .
# https://learn.microsoft.com/en-us/dotnet/core/tools/dotnet-build
RUN dotnet publish --use-current-runtime --self-contained false --configuration Release -o /app  /p:UseAppHost=false

# final stage/image
FROM mcr.microsoft.com/dotnet/aspnet:7.0
WORKDIR /app
COPY --from=build /app .
EXPOSE 80
ENTRYPOINT ["dotnet", "Backend.dll"]