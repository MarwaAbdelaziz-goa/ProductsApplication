#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
ENV ExposePortForHttp=8080
ENV ExposePortForHttps=4443
ENV GroupNm="appuser"
ENV UsrNm="appuser"
ENV ASPNETCORE_URLS=http://*:${ExposePortForHttp}
ENV ASPNETCORE_ENVIRONMENT="Development"
ENV ApiProjectConfig__ConnectionString="Server=tcp:172.20.181.247,1600;Database=Test;User ID=sa;Password=ad13!min;"

WORKDIR /app
EXPOSE ${ExposePortForHttp}
EXPOSE ${ExposePortForHttps}

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
#Creating new non-root group and user. Delete the following line in case of Local development where root user could be used
RUN groupadd -r ${GroupNm} && useradd -r -s /bin/false -g ${GroupNm} ${UsrNm}
WORKDIR /app
#Changing ownership of main directory and using the newly created user. Delete the following 2 lines in case of Local development where root user could be used
RUN chown -R ${UsrNm}:${GroupNm} /app
USER ${UsrNm}
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ProductsApplication.dll"]
