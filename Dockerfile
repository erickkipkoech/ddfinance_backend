# Use the official .NET SDK image to build the application
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

# Set the working directory inside the container
WORKDIR /app

# Copy the project files
COPY *.csproj ./
RUN dotnet restore

# Copy the rest of the application files
COPY . ./

# Build the application
RUN dotnet publish -c Release -o out

# Use the official ASP.NET Core runtime image
FROM mcr.microsoft.com/dotnet/aspnet:8.0

# Set the working directory inside the container
WORKDIR /app

# Copy the build output from the previous stage
COPY --from=build /app/out .

# Set the entry point for the container
ENTRYPOINT ["dotnet", "ddfinance_backend.dll"]

# Expose the port the application listens on
EXPOSE 5200
EXPOSE 7068
