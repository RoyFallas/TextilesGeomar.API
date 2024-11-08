# Use the official .NET runtime image for .NET 8 as a base image
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
EXPOSE 80

# Use the official .NET SDK image for .NET 8 to build the app
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

# Set working directory
WORKDIR /src

# Copy the main project csproj and restore dependencies
COPY ["TextilesGeomar.API/TextilesGeomar.API.csproj", "TextilesGeomar.API/"]
RUN dotnet restore "TextilesGeomar.API/TextilesGeomar.API.csproj"

# Copy the test project csproj and restore dependencies
COPY ["TextilesGeomar.Tests/TextilesGeomar.Tests.csproj", "TextilesGeomar.Tests/"]
RUN dotnet restore "TextilesGeomar.Tests/TextilesGeomar.Tests.csproj"

# Copy all source files and build the application
COPY . . 
RUN dotnet build "TextilesGeomar.API/TextilesGeomar.API.csproj" -c Release -o /build

# Build the test project
RUN dotnet build "TextilesGeomar.Tests/TextilesGeomar.Tests.csproj" -c Release

# Create the directory for test results
RUN mkdir -p /src/testresults

# Run tests and save results to a specific directory with verbosity and logging
RUN dotnet test "TextilesGeomar.Tests/TextilesGeomar.Tests.csproj" --no-build --logger "trx;LogFileName=/src/testresults/TestResults.trx" --verbosity normal \
    && echo "Tests completed" \
    && ls -l /src/testresults

# Publish the main app
FROM build AS publish
RUN dotnet publish "TextilesGeomar.API/TextilesGeomar.API.csproj" -c Release -o /publish

# Final stage, copy the app and set the entry point
FROM base AS final
WORKDIR /app
COPY --from=publish /publish .
ENTRYPOINT ["dotnet", "TextilesGeomar.API.dll"]
