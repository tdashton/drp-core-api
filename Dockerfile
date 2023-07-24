FROM mcr.microsoft.com/dotnet/sdk:6.0

COPY . /opt
EXPOSE 5119

RUN ["dotnet", "add", "/opt", "package", "Microsoft.EntityFrameworkCore.Design"] \
    ["dotnet", "add", "/opt", "package", "Npgsql.EntityFrameworkCore.PostgreSQL"] \
    ["dotnet", "add", "/opt", "package", "EFCore.NamingConventions"] \
    ["dotnet", "build", "/opt"]

ENTRYPOINT ["dotnet", "run", "--project", "/opt"]
