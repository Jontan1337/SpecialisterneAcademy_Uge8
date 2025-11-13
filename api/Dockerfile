# Build stage
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

# -- REMOVE -- 
COPY *.sln .
COPY CerealAPI/CerealAPI.csproj CerealAPI/
RUN dotnet restore
# -- REMOVE --

# RUN dotnet restore "CerealAPI/CerealAPI.csproj"
COPY CerealAPI/. ./CerealAPI/
WORKDIR /src/CerealAPI
RUN dotnet publish -c Release -o /app
# RUN dotnet publish -o /app
# RUN dotnet publish "CerealAPI.csproj" -c Release -o /app/publish

# Runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS runtime
WORKDIR /app
COPY --from=build /app ./
EXPOSE 8080
ENTRYPOINT ["dotnet", "CerealAPI.dll"]