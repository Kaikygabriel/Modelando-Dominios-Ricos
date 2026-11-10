FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR ./src
COPY . .
RUN dotnet restore 
RUN dotnet build  -o ./src/application

FROM microsoft.com/dotnet/aspnet:10.0 AS runtime
WORKDIR ./src
COPY --from=build ./src/application . 
ENTRYPOINT ["dotnet","PaymentContext.Domain.dll"]