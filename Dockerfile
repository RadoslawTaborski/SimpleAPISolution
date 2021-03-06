FROM mcr.microsoft.com/dotnet/sdk:6.0.200-alpine3.14-arm32v7 AS build-env
WORKDIR /src
USER root

COPY SimpleAPISln.sln /src/
COPY src/SimpleAPI/*.csproj /src/src/SimpleAPI/
COPY test/SimpleAPI.Test/*.csproj /src/test/SimpleAPI.Test/
RUN dotnet restore

COPY src/SimpleAPI/. /src/src/SimpleAPI/
WORKDIR /src/src/SimpleAPI
RUN dotnet build -c Release -o /app

FROM build-env AS publish
RUN dotnet publish -c Release -o /app/out -r linux-arm

FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app
EXPOSE 80
COPY --from=publish /app/out .
ENTRYPOINT ["dotnet", "SimpleAPI.dll"]
