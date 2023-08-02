# Tutorial

https://www.endpointdev.com/blog/2021/07/dotnet-5-web-api/

# Database

## Initial Setup

```sh
dotnet tool install --global dotnet-ef --version "6.2.0"
dotnet tool install --global dotnet-aspnet-codegenerator --version "6.0.0"

docker exec drp-core-api-drp-api-1 /root/.dotnet/tools/dotnet-ef --no-build --verbose migrations add AddInitialTables --project /opt
docker exec drp-core-api-drp-api-1 /root/.dotnet/tools/dotnet-ef --no-build --verbose database update --project /opt
```

# Controllers

Adding controllers

```sh
docker exec drp-core-api-drp-api-1 /root/.dotnet/tools/dotnet-aspnet-codegenerator --no-build --project /opt controller -name DesignController -m Design -dc CoreApiContext -async -api -outDir Controllers -f
```

# Resources

## Getting Started with EF Core (Database)

https://learn.microsoft.com/en-us/ef/core/get-started/overview/first-app


