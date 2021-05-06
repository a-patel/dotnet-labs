#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["AutoMapperExamples.Api/AutoMapperExamples.Api.csproj", "AutoMapperExamples.Api/"]
RUN dotnet restore "AutoMapperExamples.Api/AutoMapperExamples.Api.csproj"
COPY . .
WORKDIR "/src/AutoMapperExamples.Api"
RUN dotnet build "AutoMapperExamples.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "AutoMapperExamples.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AutoMapperExamples.Api.dll"]