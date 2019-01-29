FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /app

# copy csproj and restore as distinct layers
COPY *.sln .
COPY UnicornStore/*.csproj ./UnicornStore/
RUN dotnet restore

# copy everything else and build app
COPY UnicornStore/. ./UnicornStore/
WORKDIR /app/UnicornStore
RUN dotnet publish -c Release -o out


FROM microsoft/dotnet:2.2-aspnetcore-runtime-alpine AS runtime
WORKDIR /app
COPY --from=build /app/UnicornStore/out ./
ENTRYPOINT ["dotnet", "UnicornStore.dll"]
