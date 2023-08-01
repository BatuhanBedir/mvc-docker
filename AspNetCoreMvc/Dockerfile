FROM mcr.microsoft.com/dotnet/sdk:7.0 as build
WORKDIR /app
COPY AspNetCoreMvc.csproj .
RUN dotnet restore
COPY . .
RUN dotnet publish AspNetCoreMvc.csproj -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:7.0
WORKDIR /app
COPY --from=build /app/out .
ENV ASPNETCORE_URLS="http://*:4500"
ENV ASPNETCORE_ENVIRONMENT="DEVELOPMENT"
ENV MySqlCon="uzak sunucu veritabaný yolu"
ENTRYPOINT ["dotnet", "AspNetCoreMvc.dll"]