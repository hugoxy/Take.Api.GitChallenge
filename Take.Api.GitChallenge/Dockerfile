FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-alpine3.11 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-alpine3.11 AS build
WORKDIR /src
COPY ["Take.Api.GitChallenge.Facades/Take.Api.GitChallenge.Facades.csproj", "Take.Api.GitChallenge.Facades/"]
COPY ["Take.Api.GitChallenge.Models/Take.Api.GitChallenge.Models.csproj", "Take.Api.GitChallenge.Models/"]
COPY ["Take.Api.GitChallenge.Services/Take.Api.GitChallenge.Services.csproj", "Take.Api.GitChallenge.Services/"]
COPY ["Take.Api.GitChallenge/Take.Api.GitChallenge.csproj", "Take.Api.GitChallenge/"]

RUN dotnet restore "Take.Api.GitChallenge/Take.Api.GitChallenge.csproj"
COPY . .
WORKDIR "/src/Take.Api.GitChallenge"
RUN dotnet build "Take.Api.GitChallenge.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Take.Api.GitChallenge.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Take.Api.GitChallenge.dll"]