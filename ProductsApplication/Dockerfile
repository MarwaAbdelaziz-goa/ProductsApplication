#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443
ENV ApiProjectConfig__ConnectionString="Server=tcp:172.20.181.247,1600;Database=Test;User ID=sa;Password=ad13!min;"
FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["ProductsApplication/ProductsApplication.csproj", "ProductsApplication/"]
RUN dotnet restore "ProductsApplication/ProductsApplication.csproj"
COPY . .
WORKDIR "/src/ProductsApplication"
RUN dotnet build "ProductsApplication.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ProductsApplication.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ProductsApplication.dll"]