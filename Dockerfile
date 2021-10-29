# .NET Core SDK
FROM  mcr.microsoft.com/dotnet/sdk:5.0 AS build-env

# Sets the working directory
WORKDIR /app

# Copy Projects
#COPY *.sln .
COPY src/CQRS.Application/CQRS.Application.csproj /CQRS.Application/
COPY src/CQRS.Core/CQRS.Core.csproj /CQRS.Core/
COPY src/CQRS.CrossCutting/CQRS.CrossCutting.csproj /CQRS.CrossCutting/
COPY src/CQRS.Domain/CQRS.Domain.csproj /CQRS.Domain/
COPY src/CQRS.Infrastructure/CQRS.Infrastructure.csproj /CQRS.Infrastructure/
COPY src/CQRS.API/CQRS.API.csproj /CQRS.API/

# .NET Core Restore
RUN dotnet restore /CQRS.API/CQRS.API.csproj

# Copy All Files
COPY src ./

# .NET Core Build and Publish
RUN dotnet publish ./CQRS.API/CQRS.API.csproj -c Release -o out

# ASP.NET Core Runtime
FROM mcr.microsoft.com/dotnet/aspnet:5.0
WORKDIR /app
EXPOSE 80
COPY --from=build-env app/out ./
ENTRYPOINT ["dotnet", "CQRS.API.dll"]