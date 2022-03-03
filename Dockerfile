FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build-env
WORKDIR /src

COPY SimpleAPISln.sln /src/
COPY src/SimpleAPI/*.csproj /src/src/SimpleAPI/
COPY test/SimpleAPI.Test/*.csproj /src/test/SimpleAPI.Test/
RUN dotnet restore

COPY src/SimpleAPI/. /src/src/SimpleAPI/
WORKDIR /src/src/SimpleAPI
RUN dotnet build -c Release -o /app

COPY test/SimpleAPI.Test/. /src/test/SimpleAPI.Test/
WORKDIR /src/test/SimpleAPI.Test
RUN dotnet build -c Release -o /app

FROM build-env AS publish
RUN dotnet publish -c Release -o /app/out -r linux-arm

FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app
EXPOSE 80
COPY --from=publish /app/out .
ENTRYPOINT ["dotnet", "SimpleAPI.dll"]