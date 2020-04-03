FROM mcr.microsoft.com/dotnet/core/sdk:3.1.201 AS build-env
WORKDIR /app

# # Copy csproj and restore as distinct layers
# COPY /src/TestApp/AppA/AppA.csproj ./
# RUN dotnet restore AppA.csproj

# Copy everything else and build
COPY . ./
RUN dotnet publish src/TestApp/AppA/AppA.csproj -c Release -o out 

# Build runtime image
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
WORKDIR /appa
COPY --from=build-env /app/out .
ENTRYPOINT ["dotnet", "AppA.dll"]