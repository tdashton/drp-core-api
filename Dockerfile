FROM mcr.microsoft.com/dotnet/sdk:6.0

COPY . /opt
EXPOSE 5119

RUN ["dotnet", "add", "/opt", "package", "Microsoft.EntityFrameworkCore.Design", "--version", "6.0.20"] \
    ["dotnet", "add", "/opt", "package", "Npgsql.EntityFrameworkCore.PostgreSQL", "--version", "6.0.8"] \
    ["dotnet", "add", "/opt", "package", "EFCore.NamingConventions", "--version", "6.0.0"] \
    ["dotnet", "build", "/opt"]

ENTRYPOINT ["dotnet", "run", "--project", "/opt"]
