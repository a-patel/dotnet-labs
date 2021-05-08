#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["SerilogExamples.Api/SerilogExamples.Api.csproj", "SerilogExamples.Api/"]
RUN dotnet restore "SerilogExamples.Api/SerilogExamples.Api.csproj"
COPY . .
WORKDIR "/src/SerilogExamples.Api"
RUN dotnet build "SerilogExamples.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "SerilogExamples.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "SerilogExamples.Api.dll"]