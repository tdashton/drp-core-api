# Tutorial

https://www.endpointdev.com/blog/2021/07/dotnet-5-web-api/

# Setup DB

```sh
dotnet tool install --global dotnet-ef --version "6.2.0"
dotnet tool install --global dotnet-aspnet-codegenerator --version "6.0.0"

docker exec drp-core-api-drp-api-1 /root/.dotnet/tools/dotnet-ef --no-build --verbose migrations add AddInitialTables --project /opt
docker exec drp-core-api-drp-api-1 /root/.dotnet/tools/dotnet-ef --no-build --verbose database update --project /opt
```
