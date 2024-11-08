# Use the official .NET runtime image for .NET 8 as a base image
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
EXPOSE 80

# Use the official .NET SDK image for .NET 8 to build the app
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

# Set working directory
WORKDIR /src

# Copy the csproj and restore dependencies (via NuGet)
COPY ["TextilesGeomar.API/TextilesGeomar.API.csproj", "TextilesGeomar.API/"]
RUN dotnet restore "TextilesGeomar.API/TextilesGeomar.API.csproj"

# Copy the rest of the code and build the app
COPY . .
RUN dotnet build "TextilesGeomar.API/TextilesGeomar.API.csproj" -c Release -o /build

# Publish the app
FROM build AS publish
RUN dotnet publish "TextilesGeomar.API/TextilesGeomar.API.csproj" -c Release -o /publish

# Final stage, copy the app and set the entry point
FROM base AS final
WORKDIR /app
COPY --from=publish /publish .
ENTRYPOINT ["dotnet", "TextilesGeomar.API.dll"]
